ALTER PROCEDURE [dbo].[USP_GLTransaction](@BranchId nchar(4)= NULL,
										  @TransType varchar (2),	
										  @GLAccountNo varchar(11)= NULL,
										  @TransDate datetime = NULL,
										  @TransNo varchar(11)= NULL,
										  @DrCr char(1)= NULL,
										  @TransMode char(1)= NULL,
										  @Amount numeric(18, 2)= NULL,
										  @Narration varchar(100) =NULL,
										  @Status int = 0,
										  @IsReverse int = 0
										)AS

--Create Table ProductPurces (TransDate, TransNo, ProductAccNo, OpeningBalance, PurcesAmount, ClosingBalance, ByCashAmount, ByBankAmount,
--							  DueAmount, SupAccNo, SupDueAmount, SupCurrBalance);

--Create Table EmployeeTarget (TransDate, TransNo, ProductAccNo, OpeningBalance, EmpAccNo, OpeningBalance, TargetAmount, ClosingBalance);

--Create Table SaleEntry (TransDate, TransNo, EmpAccNo, TargetAmount, SaleAmount, ByCashAmount, ByBankAmount, DueAmount
--							  CusAccNo, CusDueAmount, CurrBalance);

BEGIN
	DECLARE @GeneratedTransNo varchar(11), @TransCount int,
			@NewRecordCount int,@OpeningBalance numeric(18,2),@BalanceReceived numeric(18,2),@TotalToDaysBalance numeric(18,2), 
			@ClosingBalance numeric(18,2), @TotalSale numeric(18,2),@CurrentTransDate datetime;

	SELECT @GeneratedTransNo = TransType+RIGHT('00000000'+convert(varchar,LastSeqNo+1),9) FROM LastTransactionNo where TransType = @TransType;
	SELECT @CurrentTransDate = ISNULL(@TransDate,GETDATE());

	BEGIN			

		INSERT INTO GLTransaction(BranchId,GLAccountNo,TransDate,TransNo,DrCr,TransMode,Amount,Narration,Status,IsReverse)
		VALUES(@BranchId,@GLAccountNo,@CurrentTransDate,@GeneratedTransNo,@DrCr,@TransMode,@Amount,@Narration,@Status,@IsReverse);

		SELECT @TransCount = COUNT(*) FROM GLTransaction WHERE BranchId = @BranchId AND TransNo = @GeneratedTransNo AND TransDate = @CurrentTransDate;		
		SELECT @NewRecordCount = COUNT(*) FROM EmployeeTransaction WHERE TransDate = @CurrentTransDate;	

		IF @TransCount > 0 --Last TransNo Update
		BEGIN
			UPDATE A SET A.LastSeqNo = LastSeqNo + 1 FROM LastTransactionNo A where A.TransType = @TransType;
		END

		IF @TransType = 'PD'
			BEGIN			    
				IF @NewRecordCount <= 0 
					BEGIN
						SELECT @OpeningBalance =ISNULL(ClosingBalance,0) FROM EmployeeTransaction WHERE EmployeeCode = @GLAccountNo AND TransDate = @CurrentTransDate-1;
						SELECT @OpeningBalance = ISNULL(@OpeningBalance,0);
						SELECT @BalanceReceived = @Amount;
						SELECT @TotalToDaysBalance = @OpeningBalance + @BalanceReceived;
						SELECT @TotalSale = 0;
						SELECT @ClosingBalance = 0;

						INSERT INTO EmployeeTransaction(EmployeeCode,TransDate,OpeningBalance,TotalReceived,TotalBalance,TotalSale,ClosingBalance)
						VALUES(@GLAccountNo,@CurrentTransDate,@OpeningBalance,@BalanceReceived,@TotalToDaysBalance,@TotalSale,@ClosingBalance)
					END
			END
		IF @TransType = 'PS'
			BEGIN					
				UPDATE A SET A.TotalSale = A.TotalSale + @Amount FROM EmployeeTransaction A WHERE A.EmployeeCode = @GLAccountNo AND TransDate = @CurrentTransDate;
				UPDATE A SET A.ClosingBalance = A.TotalBalance-A.TotalSale  FROM EmployeeTransaction A WHERE A.EmployeeCode = @GLAccountNo AND TransDate = @CurrentTransDate;
			END
	END

END

GO


