USE [master]
GO
/****** Object:  Database [Payroll]    Script Date: 26-Aug-22 8:41:36 AM ******/
CREATE DATABASE [Payroll]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PayRoll', FILENAME = N'D:\Professional\SQL Server Backup\MSSQL12\DATA\PayRoll.mdf' , SIZE = 5312KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'PayRoll_log', FILENAME = N'D:\Professional\SQL Server Backup\MSSQL12\DATA\PayRoll_log.ldf' , SIZE = 3520KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Payroll] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Payroll].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Payroll] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Payroll] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Payroll] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Payroll] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Payroll] SET ARITHABORT OFF 
GO
ALTER DATABASE [Payroll] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Payroll] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Payroll] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Payroll] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Payroll] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Payroll] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Payroll] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Payroll] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Payroll] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Payroll] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Payroll] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Payroll] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Payroll] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Payroll] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Payroll] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Payroll] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Payroll] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Payroll] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Payroll] SET  MULTI_USER 
GO
ALTER DATABASE [Payroll] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Payroll] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Payroll] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Payroll] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Payroll] SET DELAYED_DURABILITY = DISABLED 
GO
USE [Payroll]
GO
/****** Object:  UserDefinedTableType [dbo].[AttendanceCollection]    Script Date: 26-Aug-22 8:41:36 AM ******/
CREATE TYPE [dbo].[AttendanceCollection] AS TABLE(
	[EmployeeId] [int] NULL,
	[AttendanceDate] [date] NULL,
	[UserId] [int] NULL
)
GO
/****** Object:  UserDefinedFunction [dbo].[IsNegative]    Script Date: 26-Aug-22 8:41:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[IsNegative](
@Number DECIMAL(38,16)
)
RETURNS VARCHAR (50)
WITH RETURNS NULL ON NULL INPUT
AS
BEGIN 
DECLARE @result VARCHAR (50)

/*Trim trailing zeroes and decimal point*/
SET @result = REPLACE(RTRIM(REPLACE(REPLACE(RTRIM(REPLACE(@Number,'0', ' ')),' ', '0'),'.', ' ')),' ', '.')

IF @Number < 0
    SET @result = '(' + SUBSTRING(@result,2,LEN(@result)) + ')'

RETURN @result
END




GO
/****** Object:  Table [dbo].[Acc_Sys_AccountType]    Script Date: 26-Aug-22 8:41:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Acc_Sys_AccountType](
	[AccountType] [varchar](3) NOT NULL,
	[TypeDescription] [nvarchar](35) NOT NULL,
	[ATOrder] [tinyint] NOT NULL,
 CONSTRAINT [PK_Acc_Sys_AccountType] PRIMARY KEY CLUSTERED 
(
	[AccountType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[BloodGroup]    Script Date: 26-Aug-22 8:41:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BloodGroup](
	[GroupId] [int] NULL,
	[GroupName] [nvarchar](3) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ChartOfAccounts]    Script Date: 26-Aug-22 8:41:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChartOfAccounts](
	[GLAccountNo] [nvarchar](11) NOT NULL,
	[GLAccountName] [nvarchar](100) NOT NULL,
	[GLPrefix] [nvarchar](3) NOT NULL,
	[PGLAccountNo] [nvarchar](11) NOT NULL,
	[GLType] [nvarchar](1) NOT NULL,
	[GLACType] [nvarchar](1) NOT NULL,
	[GLLevel] [nvarchar](1) NOT NULL,
	[AllowEntry] [nvarchar](1) NOT NULL,
	[Status] [nvarchar](1) NOT NULL,
	[SetupDate] [datetime] NULL,
	[UserId] [nvarchar](10) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ChartOfAccountType]    Script Date: 26-Aug-22 8:41:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChartOfAccountType](
	[AccTypeCode] [nchar](3) NULL,
	[GLPrefix] [nchar](3) NULL,
	[GLType] [nchar](1) NULL,
	[AccTypeDescription] [nvarchar](50) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Customer]    Script Date: 26-Aug-22 8:41:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[Customer](
	[CustomerId] [int] NOT NULL,
	[GLAccountNo] [nvarchar](11) NOT NULL,
	[CustomerName] [nchar](50) NOT NULL,
	[ContactPerson] [nchar](30) NOT NULL,
	[ContactNumber] [nchar](15) NOT NULL,
	[EmailAddress] [nchar](30) NULL,
	[MailingAddress] [nchar](100) NULL,
	[CurrentBalance] [numeric](18, 2) NOT NULL,
	[DueBalance] [numeric](18, 2) NOT NULL,
	[Status] [tinyint] NOT NULL,
	[SetupDate] [datetime] NULL,
	[UserId] [int] NOT NULL,
	[CreateBy] [varchar](10) NULL,
	[CreateDate] [datetime] NULL,
	[ModifyBy] [varchar](10) NULL,
	[ModifyDate] [datetime] NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC,
	[GLAccountNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Department]    Script Date: 26-Aug-22 8:41:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Department](
	[DepartmentId] [int] NOT NULL,
	[DepartmentName] [nvarchar](20) NULL,
	[Status] [int] NOT NULL,
	[CreateBy] [varchar](10) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[MakeBy] [varchar](10) NOT NULL,
	[MakeDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[DepartmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Designation]    Script Date: 26-Aug-22 8:41:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Designation](
	[DesignationId] [int] NOT NULL,
	[DesignationName] [nvarchar](60) NULL,
	[Status] [int] NOT NULL,
	[CreateBy] [varchar](10) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[MakeBy] [varchar](10) NOT NULL,
	[MakeDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Designation] PRIMARY KEY CLUSTERED 
(
	[DesignationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 26-Aug-22 8:41:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Employee](
	[EmployeeId] [int] NOT NULL,
	[EmployeeCode] [varchar](11) NOT NULL,
	[GLAccountNo] [nvarchar](11) NOT NULL,
	[Balance] [numeric](18, 2) NOT NULL,
	[EmployeeName] [nvarchar](100) NULL,
	[FatherName] [nvarchar](100) NULL,
	[MotherName] [nvarchar](50) NULL,
	[PresentAddress] [nvarchar](max) NULL,
	[PermanentAddress] [nvarchar](max) NULL,
	[GenderId] [int] NULL,
	[NationalID] [varchar](50) NULL,
	[DateOfBirth] [datetime] NULL,
	[ContractNumber] [nvarchar](11) NULL,
	[EmergencyNumber] [nvarchar](11) NULL,
	[BloodGroup] [nvarchar](15) NULL,
	[MaritalStatus] [int] NULL,
	[DeptId] [int] NULL,
	[DesignationId] [int] NULL,
	[JoiningDate] [datetime] NULL,
	[JoiningType] [int] NULL,
	[StatusId] [int] NULL,
	[ImagePath] [varchar](500) NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifyBy] [int] NULL,
	[ModifyDate] [datetime] NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC,
	[EmployeeCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EmployeeTransaction]    Script Date: 26-Aug-22 8:41:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EmployeeTransaction](
	[EmployeeCode] [varchar](11) NULL,
	[TransDate] [datetime] NULL,
	[OpeningBalance] [numeric](18, 2) NULL,
	[TotalReceived] [numeric](18, 2) NULL,
	[TotalBalance] [numeric](18, 2) NULL,
	[TotalSale] [numeric](18, 2) NULL,
	[ClosingBalance] [numeric](18, 2) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[GLTransaction]    Script Date: 26-Aug-22 8:41:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[GLTransaction](
	[BranchId] [nchar](4) NULL,
	[GLAccountNo] [varchar](11) NULL,
	[TransDate] [datetime] NULL,
	[TransNo] [varchar](11) NULL,
	[DrCr] [char](1) NULL,
	[TransMode] [char](1) NULL,
	[Amount] [numeric](18, 2) NULL,
	[Narration] [varchar](100) NULL,
	[Status] [int] NULL,
	[IsReverse] [int] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[GLTransactionAuditLog]    Script Date: 26-Aug-22 8:41:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[GLTransactionAuditLog](
	[BranchId] [nchar](4) NULL,
	[ProductId] [nchar](5) NULL,
	[GLAccountNo] [varchar](11) NULL,
	[TransDate] [datetime] NULL,
	[DrCr] [char](1) NULL,
	[TransMode] [char](1) NULL,
	[Amount] [numeric](18, 2) NULL,
	[Narration] [varchar](100) NULL,
	[Status] [int] NULL,
	[IsReverse] [int] NULL,
	[UserId] [int] NOT NULL,
	[MakeBy] [int] NOT NULL,
	[MakeDate] [datetime] NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LastGLAccountNo]    Script Date: 26-Aug-22 8:41:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LastGLAccountNo](
	[AccountType] [varchar](3) NOT NULL,
	[TypeDescription] [nvarchar](35) NOT NULL,
	[LastAccountNo] [int] NOT NULL,
 CONSTRAINT [PK_LastGLAccountNo] PRIMARY KEY CLUSTERED 
(
	[AccountType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LastTransactionNo]    Script Date: 26-Aug-22 8:41:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LastTransactionNo](
	[TransType] [varchar](2) NOT NULL,
	[TypeDescription] [nvarchar](35) NOT NULL,
	[LastSeqNo] [int] NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Product]    Script Date: 26-Aug-22 8:41:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[Product](
	[ProductId] [int] NOT NULL,
	[ProductName] [varchar](100) NULL,
	[GLAccountNo] [nvarchar](11) NOT NULL,
	[Unit] [int] NULL,
	[CostPrice] [numeric](18, 2) NULL,
	[RetailSalePrice] [numeric](18, 2) NULL,
	[WholeSalePrice] [numeric](18, 2) NULL,
	[Balance] [numeric](18, 2) NULL,
	[Status] [tinyint] NULL,
	[Retunable] [tinyint] NULL,
	[IsSync] [tinyint] NULL,
	[EffectiveDate] [datetime] NULL,
	[ExpiryDate] [datetime] NULL,
	[CreatedBy] [varchar](10) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifyBy] [varchar](10) NULL,
	[ModifyDate] [datetime] NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC,
	[GLAccountNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ProductGroup]    Script Date: 26-Aug-22 8:41:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductGroup](
	[GroupCode] [nchar](3) NOT NULL,
	[GroupName] [nvarchar](50) NOT NULL,
	[FixedProductName] [bit] NULL,
	[FixedBarCode] [tinyint] NULL,
	[FixedStyleCode] [tinyint] NULL,
	[HasVariation] [tinyint] NULL,
	[Active] [bit] NOT NULL,
	[SetupDate] [date] NOT NULL,
	[UserID] [int] NOT NULL,
	[FixedBarCodeForFixedItem] [tinyint] NULL,
 CONSTRAINT [PK_ProductGroup] PRIMARY KEY CLUSTERED 
(
	[GroupCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RoleWiseScreenPermission]    Script Date: 26-Aug-22 8:41:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleWiseScreenPermission](
	[RoleId] [nvarchar](4) NOT NULL,
	[ScreenId] [nchar](4) NOT NULL,
	[Permission] [nchar](3) NULL CONSTRAINT [DF_RoleWiseScreenPermission_Permission]  DEFAULT ((0)),
	[SetDate] [datetime] NULL,
	[UserName] [nvarchar](50) NULL,
 CONSTRAINT [PK_RoleWiseScreenPermission_1] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC,
	[ScreenId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Screens]    Script Date: 26-Aug-22 8:41:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Screens](
	[ScreenId] [nchar](4) NOT NULL,
	[ScreenName] [nvarchar](50) NOT NULL,
	[URL] [nvarchar](100) NOT NULL,
	[ParentScreenId] [nchar](4) NOT NULL,
	[IconName] [nvarchar](50) NULL,
	[Manager] [nvarchar](50) NULL,
	[Remarks] [nvarchar](50) NULL,
	[SetDate] [datetime] NULL,
	[UserName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Screens] PRIMARY KEY CLUSTERED 
(
	[ScreenId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Supplier]    Script Date: 26-Aug-22 8:41:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Supplier](
	[SupplierId] [int] NOT NULL,
	[GLAccountNo] [nvarchar](11) NOT NULL,
	[SupplierName] [nchar](50) NOT NULL,
	[ContactPerson] [nchar](30) NOT NULL,
	[ContactNumber] [nchar](15) NOT NULL,
	[EmailAddress] [nchar](30) NULL,
	[MailingAddress] [nchar](100) NULL,
	[CurrentBalance] [numeric](18, 2) NOT NULL,
	[DueBalance] [numeric](18, 2) NOT NULL,
	[Status] [tinyint] NOT NULL,
	[SetupDate] [datetime] NULL,
	[UserId] [int] NOT NULL,
	[CreateBy] [varchar](10) NULL,
	[CreateDate] [datetime] NULL,
	[ModifyBy] [varchar](10) NULL,
	[ModifyDate] [datetime] NULL,
 CONSTRAINT [PK_Supplier] PRIMARY KEY CLUSTERED 
(
	[SupplierId] ASC,
	[GLAccountNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SysGendar]    Script Date: 26-Aug-22 8:41:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SysGendar](
	[GenderID] [char](1) NOT NULL,
	[Description] [nvarchar](10) NULL,
	[Status] [tinyint] NULL,
 CONSTRAINT [PK_SysGendar] PRIMARY KEY CLUSTERED 
(
	[GenderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SysMaritalStatus]    Script Date: 26-Aug-22 8:41:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SysMaritalStatus](
	[MaritalID] [char](1) NOT NULL,
	[Description] [nvarchar](10) NULL,
	[Status] [tinyint] NULL,
 CONSTRAINT [PK_SysMaritalStatus] PRIMARY KEY CLUSTERED 
(
	[MaritalID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserInfo]    Script Date: 26-Aug-22 8:41:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserInfo](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](20) NOT NULL,
	[UserFullName] [nvarchar](100) NULL,
	[UserPassword] [nvarchar](50) NOT NULL,
	[UserRoleId] [nvarchar](4) NOT NULL,
	[UserStatus] [nvarchar](2) NOT NULL,
	[SetDate] [date] NULL,
	[ModifyUser] [varchar](100) NULL,
 CONSTRAINT [PK_UserInfo] PRIMARY KEY CLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserRole]    Script Date: 26-Aug-22 8:41:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserRole](
	[RoleId] [nvarchar](4) NOT NULL,
	[RoleName] [varchar](50) NOT NULL,
	[SetDate] [datetime] NULL,
	[UserName] [nvarchar](20) NULL,
 CONSTRAINT [PK_UserRole_1] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserStatus]    Script Date: 26-Aug-22 8:41:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserStatus](
	[StatusId] [nvarchar](2) NOT NULL,
	[StatusName] [varchar](20) NOT NULL,
	[SetDate] [datetime] NULL,
	[UserName] [nvarchar](20) NULL,
 CONSTRAINT [PK_UserStatus_1] PRIMARY KEY CLUSTERED 
(
	[StatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Acc_Sys_AccountType] ([AccountType], [TypeDescription], [ATOrder]) VALUES (N'EMP', N'Employee Account', 2)
INSERT [dbo].[Acc_Sys_AccountType] ([AccountType], [TypeDescription], [ATOrder]) VALUES (N'EXP', N'Expenditure Account', 3)
INSERT [dbo].[Acc_Sys_AccountType] ([AccountType], [TypeDescription], [ATOrder]) VALUES (N'PRD', N'Product Account', 1)
INSERT [dbo].[BloodGroup] ([GroupId], [GroupName]) VALUES (1, N'A+')
INSERT [dbo].[BloodGroup] ([GroupId], [GroupName]) VALUES (2, N'A-')
INSERT [dbo].[BloodGroup] ([GroupId], [GroupName]) VALUES (3, N'O+')
INSERT [dbo].[BloodGroup] ([GroupId], [GroupName]) VALUES (4, N'O-')
INSERT [dbo].[BloodGroup] ([GroupId], [GroupName]) VALUES (5, N'AB+')
INSERT [dbo].[BloodGroup] ([GroupId], [GroupName]) VALUES (6, N'AB-')
INSERT [dbo].[BloodGroup] ([GroupId], [GroupName]) VALUES (7, N'B+')
INSERT [dbo].[BloodGroup] ([GroupId], [GroupName]) VALUES (8, N'B-')
INSERT [dbo].[Customer] ([CustomerId], [GLAccountNo], [CustomerName], [ContactPerson], [ContactNumber], [EmailAddress], [MailingAddress], [CurrentBalance], [DueBalance], [Status], [SetupDate], [UserId], [CreateBy], [CreateDate], [ModifyBy], [ModifyDate]) VALUES (1, N'CUS00000001', N'qwqwqw                                            ', N'wq                            ', N'1212           ', N'21                            ', N'qwqwq                                                                                               ', CAST(21.00 AS Numeric(18, 2)), CAST(212.00 AS Numeric(18, 2)), 0, CAST(N'2022-08-25 00:39:21.287' AS DateTime), 7, N'7', CAST(N'2022-08-25 00:39:21.287' AS DateTime), NULL, NULL)
INSERT [dbo].[Department] ([DepartmentId], [DepartmentName], [Status], [CreateBy], [CreateDate], [MakeBy], [MakeDate]) VALUES (1, N'IT', 0, N'Admin', CAST(N'2022-08-18 00:00:00.000' AS DateTime), N'Admin', CAST(N'2022-08-18 00:00:00.000' AS DateTime))
INSERT [dbo].[Department] ([DepartmentId], [DepartmentName], [Status], [CreateBy], [CreateDate], [MakeBy], [MakeDate]) VALUES (2, N'Sales', 0, N'Admin', CAST(N'2022-08-18 00:00:00.000' AS DateTime), N'Admin', CAST(N'2022-08-18 00:00:00.000' AS DateTime))
INSERT [dbo].[Department] ([DepartmentId], [DepartmentName], [Status], [CreateBy], [CreateDate], [MakeBy], [MakeDate]) VALUES (3, N'New department', 0, N'Admin', CAST(N'2022-08-23 00:22:56.353' AS DateTime), N'Admin', CAST(N'2022-08-23 00:22:56.353' AS DateTime))
INSERT [dbo].[Designation] ([DesignationId], [DesignationName], [Status], [CreateBy], [CreateDate], [MakeBy], [MakeDate]) VALUES (1, N'Exicutive', 0, N'Admin', CAST(N'2022-08-18 00:00:00.000' AS DateTime), N'Admin', CAST(N'2022-08-18 00:00:00.000' AS DateTime))
INSERT [dbo].[Designation] ([DesignationId], [DesignationName], [Status], [CreateBy], [CreateDate], [MakeBy], [MakeDate]) VALUES (2, N'Programmer', 0, N'Admin', CAST(N'2022-08-18 00:00:00.000' AS DateTime), N'Admin', CAST(N'2022-08-18 00:00:00.000' AS DateTime))
INSERT [dbo].[Designation] ([DesignationId], [DesignationName], [Status], [CreateBy], [CreateDate], [MakeBy], [MakeDate]) VALUES (3, N'ewe', 0, N'Admin', CAST(N'2022-08-23 20:24:17.623' AS DateTime), N'Admin', CAST(N'2022-08-23 20:24:17.623' AS DateTime))
INSERT [dbo].[Designation] ([DesignationId], [DesignationName], [Status], [CreateBy], [CreateDate], [MakeBy], [MakeDate]) VALUES (4, N'New 2 Designation', 0, N'Admin', CAST(N'2022-08-23 20:33:53.067' AS DateTime), N'Admin', CAST(N'2022-08-23 20:33:53.067' AS DateTime))
INSERT [dbo].[Employee] ([EmployeeId], [EmployeeCode], [GLAccountNo], [Balance], [EmployeeName], [FatherName], [MotherName], [PresentAddress], [PermanentAddress], [GenderId], [NationalID], [DateOfBirth], [ContractNumber], [EmergencyNumber], [BloodGroup], [MaritalStatus], [DeptId], [DesignationId], [JoiningDate], [JoiningType], [StatusId], [ImagePath], [CreatedBy], [CreatedDate], [ModifyBy], [ModifyDate]) VALUES (1, N'EMP1', N'EMP00000001', CAST(0.00 AS Numeric(18, 2)), N'Md. Abdul Malek', N'Md. Fakir Chand Pramanik', N'Mst.', N'Rashahi', N'Pabna Sadar', 1, N'01723987961', CAST(N'2022-08-19 00:00:00.000' AS DateTime), N'01723987961', N'01723987961', N'0+', 1, 1, 2, CAST(N'2022-08-19 16:33:45.953' AS DateTime), NULL, 0, N'', 1, CAST(N'2022-08-19 16:33:45.953' AS DateTime), NULL, CAST(N'2022-08-19 16:33:45.953' AS DateTime))
INSERT [dbo].[Employee] ([EmployeeId], [EmployeeCode], [GLAccountNo], [Balance], [EmployeeName], [FatherName], [MotherName], [PresentAddress], [PermanentAddress], [GenderId], [NationalID], [DateOfBirth], [ContractNumber], [EmergencyNumber], [BloodGroup], [MaritalStatus], [DeptId], [DesignationId], [JoiningDate], [JoiningType], [StatusId], [ImagePath], [CreatedBy], [CreatedDate], [ModifyBy], [ModifyDate]) VALUES (2, N'EMP00000002', N'EMP00000001', CAST(0.00 AS Numeric(18, 2)), N'Md. Imam Hossain', N'MD', N'MST', N'Dhaka', N'Dhaka', 1, N'0987654321', CAST(N'2022-08-19 00:00:00.000' AS DateTime), N'0987654321', N'0987654321', N'0+', 1, 1, 2, CAST(N'2022-08-19 16:37:02.543' AS DateTime), NULL, 0, N'', 1, CAST(N'2022-08-19 16:37:02.543' AS DateTime), NULL, CAST(N'2022-08-19 16:37:02.543' AS DateTime))
INSERT [dbo].[Employee] ([EmployeeId], [EmployeeCode], [GLAccountNo], [Balance], [EmployeeName], [FatherName], [MotherName], [PresentAddress], [PermanentAddress], [GenderId], [NationalID], [DateOfBirth], [ContractNumber], [EmergencyNumber], [BloodGroup], [MaritalStatus], [DeptId], [DesignationId], [JoiningDate], [JoiningType], [StatusId], [ImagePath], [CreatedBy], [CreatedDate], [ModifyBy], [ModifyDate]) VALUES (3, N'EMP00000003', N'EMP00000001', CAST(0.00 AS Numeric(18, 2)), N'Arif', N'MD', N'mst', N'natore', N'natore', 1, N'01723987951', CAST(N'2022-08-19 00:00:00.000' AS DateTime), N'01723987951', N'01723987951', N'o+', 1, 1, 2, CAST(N'2022-08-19 19:37:01.223' AS DateTime), NULL, 0, N'', 1, CAST(N'2022-08-19 19:37:01.223' AS DateTime), NULL, CAST(N'2022-08-19 19:37:01.223' AS DateTime))
INSERT [dbo].[Employee] ([EmployeeId], [EmployeeCode], [GLAccountNo], [Balance], [EmployeeName], [FatherName], [MotherName], [PresentAddress], [PermanentAddress], [GenderId], [NationalID], [DateOfBirth], [ContractNumber], [EmergencyNumber], [BloodGroup], [MaritalStatus], [DeptId], [DesignationId], [JoiningDate], [JoiningType], [StatusId], [ImagePath], [CreatedBy], [CreatedDate], [ModifyBy], [ModifyDate]) VALUES (4, N'EMP00000004', N'EMP00000001', CAST(0.00 AS Numeric(18, 2)), N'Md. lutfaur', N'gfgf', N'trtrt', N'ttrt', N'trt', 1, N'09234325', CAST(N'2022-08-19 00:00:00.000' AS DateTime), N'7676', N'6577', N'0+', 1, 1, 1, CAST(N'2022-08-19 19:57:09.623' AS DateTime), NULL, 0, N'', 1, CAST(N'2022-08-19 19:57:09.623' AS DateTime), NULL, CAST(N'2022-08-19 19:57:09.623' AS DateTime))
INSERT [dbo].[Employee] ([EmployeeId], [EmployeeCode], [GLAccountNo], [Balance], [EmployeeName], [FatherName], [MotherName], [PresentAddress], [PermanentAddress], [GenderId], [NationalID], [DateOfBirth], [ContractNumber], [EmergencyNumber], [BloodGroup], [MaritalStatus], [DeptId], [DesignationId], [JoiningDate], [JoiningType], [StatusId], [ImagePath], [CreatedBy], [CreatedDate], [ModifyBy], [ModifyDate]) VALUES (5, N'EMP00000005', N'EMP00000001', CAST(0.00 AS Numeric(18, 2)), N'erer', N'rer', N'434', N'ere', N'ere', 1, N'43', CAST(N'2022-08-09 00:00:00.000' AS DateTime), N'343', N'434', N'6', 1, 1, 1, CAST(N'2022-08-20 22:42:45.117' AS DateTime), NULL, 0, N'', 1, CAST(N'2022-08-20 22:42:45.117' AS DateTime), NULL, CAST(N'2022-08-20 22:42:45.117' AS DateTime))
INSERT [dbo].[Employee] ([EmployeeId], [EmployeeCode], [GLAccountNo], [Balance], [EmployeeName], [FatherName], [MotherName], [PresentAddress], [PermanentAddress], [GenderId], [NationalID], [DateOfBirth], [ContractNumber], [EmergencyNumber], [BloodGroup], [MaritalStatus], [DeptId], [DesignationId], [JoiningDate], [JoiningType], [StatusId], [ImagePath], [CreatedBy], [CreatedDate], [ModifyBy], [ModifyDate]) VALUES (6, N'EMP00000006', N'EMP00000001', CAST(0.00 AS Numeric(18, 2)), N'Md. Abdul malek', N'Md. Fakir Chand Pramanik', N'2323', N'Pabna', N'Pabna', 1, N'323232', CAST(N'2022-08-22 00:00:00.000' AS DateTime), N'23232', N'3232', N'0', 1, 1, 1, CAST(N'2022-08-22 22:10:00.060' AS DateTime), NULL, 0, N'', 1, CAST(N'2022-08-22 22:10:00.060' AS DateTime), NULL, CAST(N'2022-08-22 22:10:00.060' AS DateTime))
INSERT [dbo].[Employee] ([EmployeeId], [EmployeeCode], [GLAccountNo], [Balance], [EmployeeName], [FatherName], [MotherName], [PresentAddress], [PermanentAddress], [GenderId], [NationalID], [DateOfBirth], [ContractNumber], [EmergencyNumber], [BloodGroup], [MaritalStatus], [DeptId], [DesignationId], [JoiningDate], [JoiningType], [StatusId], [ImagePath], [CreatedBy], [CreatedDate], [ModifyBy], [ModifyDate]) VALUES (7, N'EMP00000007', N'EMP00000001', CAST(0.00 AS Numeric(18, 2)), N'wewe', N'wew', N'dsd', N'wew', N'ewe', 1, N'434', CAST(N'2022-08-22 00:00:00.000' AS DateTime), N'43', N'343', N'5', 2, 2, 1, CAST(N'2022-08-22 22:42:09.227' AS DateTime), NULL, 0, N'', 1, CAST(N'2022-08-22 22:42:09.227' AS DateTime), NULL, CAST(N'2022-08-22 22:42:09.227' AS DateTime))
INSERT [dbo].[Employee] ([EmployeeId], [EmployeeCode], [GLAccountNo], [Balance], [EmployeeName], [FatherName], [MotherName], [PresentAddress], [PermanentAddress], [GenderId], [NationalID], [DateOfBirth], [ContractNumber], [EmergencyNumber], [BloodGroup], [MaritalStatus], [DeptId], [DesignationId], [JoiningDate], [JoiningType], [StatusId], [ImagePath], [CreatedBy], [CreatedDate], [ModifyBy], [ModifyDate]) VALUES (8, N'EMP00000008', N'EMP00000001', CAST(0.00 AS Numeric(18, 2)), N'aaaaa', N'aaa', N'AAA', N'aa', N'aa', 1, N'33', CAST(N'2022-08-22 00:00:00.000' AS DateTime), N'22', N'33', N'3', 1, 1, 1, CAST(N'2022-08-22 22:42:53.957' AS DateTime), NULL, 0, N'', 1, CAST(N'2022-08-22 22:42:53.957' AS DateTime), NULL, CAST(N'2022-08-22 22:42:53.957' AS DateTime))
INSERT [dbo].[Employee] ([EmployeeId], [EmployeeCode], [GLAccountNo], [Balance], [EmployeeName], [FatherName], [MotherName], [PresentAddress], [PermanentAddress], [GenderId], [NationalID], [DateOfBirth], [ContractNumber], [EmergencyNumber], [BloodGroup], [MaritalStatus], [DeptId], [DesignationId], [JoiningDate], [JoiningType], [StatusId], [ImagePath], [CreatedBy], [CreatedDate], [ModifyBy], [ModifyDate]) VALUES (9, N'EMP00000009', N'EMP00000001', CAST(0.00 AS Numeric(18, 2)), N'ere', N'ere', N'dfd', N're', N'ere', 1, N'45', CAST(N'2022-08-16 00:00:00.000' AS DateTime), N'45', N'54', N'3', 1, 1, 1, CAST(N'2022-08-22 22:50:11.900' AS DateTime), NULL, 0, N'', 1, CAST(N'2022-08-22 22:50:11.900' AS DateTime), NULL, CAST(N'2022-08-22 22:50:11.900' AS DateTime))
INSERT [dbo].[Employee] ([EmployeeId], [EmployeeCode], [GLAccountNo], [Balance], [EmployeeName], [FatherName], [MotherName], [PresentAddress], [PermanentAddress], [GenderId], [NationalID], [DateOfBirth], [ContractNumber], [EmergencyNumber], [BloodGroup], [MaritalStatus], [DeptId], [DesignationId], [JoiningDate], [JoiningType], [StatusId], [ImagePath], [CreatedBy], [CreatedDate], [ModifyBy], [ModifyDate]) VALUES (10, N'EMP00000010', N'EMP00000002', CAST(0.00 AS Numeric(18, 2)), N'eeee', N'eee', N'eee', N'eee', N'eee', 1, N'333', CAST(N'2022-08-22 00:00:00.000' AS DateTime), N'333', N'333', N'2', 1, 1, 1, CAST(N'2022-08-22 22:51:01.457' AS DateTime), NULL, 0, N'', 1, CAST(N'2022-08-22 22:51:01.457' AS DateTime), NULL, CAST(N'2022-08-22 22:51:01.457' AS DateTime))
INSERT [dbo].[LastGLAccountNo] ([AccountType], [TypeDescription], [LastAccountNo]) VALUES (N'CUS', N'Customer Account', 1)
INSERT [dbo].[LastGLAccountNo] ([AccountType], [TypeDescription], [LastAccountNo]) VALUES (N'EMP', N'Employee Account', 2)
INSERT [dbo].[LastGLAccountNo] ([AccountType], [TypeDescription], [LastAccountNo]) VALUES (N'EXP', N'Expenditure Account', 0)
INSERT [dbo].[LastGLAccountNo] ([AccountType], [TypeDescription], [LastAccountNo]) VALUES (N'PRD', N'Product Account', 3)
INSERT [dbo].[LastGLAccountNo] ([AccountType], [TypeDescription], [LastAccountNo]) VALUES (N'SUP', N'Supplier Account', 2)
INSERT [dbo].[LastTransactionNo] ([TransType], [TypeDescription], [LastSeqNo]) VALUES (N'PD', N'Product Distribution to Employee', 0)
INSERT [dbo].[LastTransactionNo] ([TransType], [TypeDescription], [LastSeqNo]) VALUES (N'PS', N'Product Sale By Employee', 0)
INSERT [dbo].[LastTransactionNo] ([TransType], [TypeDescription], [LastSeqNo]) VALUES (N'EE', N'Employee Expense Entry', 0)
INSERT [dbo].[Product] ([ProductId], [ProductName], [GLAccountNo], [Unit], [CostPrice], [RetailSalePrice], [WholeSalePrice], [Balance], [Status], [Retunable], [IsSync], [EffectiveDate], [ExpiryDate], [CreatedBy], [CreatedDate], [ModifyBy], [ModifyDate]) VALUES (1, N'Test1', N'PRD00000003', 1, CAST(1111.00 AS Numeric(18, 2)), CAST(1111.00 AS Numeric(18, 2)), CAST(1111.00 AS Numeric(18, 2)), CAST(0.00 AS Numeric(18, 2)), 0, 0, 0, CAST(N'2022-08-24 00:00:00.000' AS DateTime), CAST(N'2022-08-24 00:00:00.000' AS DateTime), N'7', NULL, NULL, NULL)
INSERT [dbo].[RoleWiseScreenPermission] ([RoleId], [ScreenId], [Permission], [SetDate], [UserName]) VALUES (N'0001', N'1000', N'0  ', CAST(N'2017-08-18 15:14:17.167' AS DateTime), N'razu')
INSERT [dbo].[RoleWiseScreenPermission] ([RoleId], [ScreenId], [Permission], [SetDate], [UserName]) VALUES (N'0001', N'1001', N'111', CAST(N'2016-09-23 16:50:22.707' AS DateTime), N'razu')
INSERT [dbo].[RoleWiseScreenPermission] ([RoleId], [ScreenId], [Permission], [SetDate], [UserName]) VALUES (N'0001', N'1002', N'111', CAST(N'2017-08-18 15:14:17.193' AS DateTime), N'razu')
INSERT [dbo].[RoleWiseScreenPermission] ([RoleId], [ScreenId], [Permission], [SetDate], [UserName]) VALUES (N'0001', N'1003', N'111', CAST(N'2015-10-16 17:56:30.963' AS DateTime), N'razu')
INSERT [dbo].[RoleWiseScreenPermission] ([RoleId], [ScreenId], [Permission], [SetDate], [UserName]) VALUES (N'0001', N'2000', N'0  ', CAST(N'2017-08-24 21:32:33.167' AS DateTime), N'razu')
INSERT [dbo].[RoleWiseScreenPermission] ([RoleId], [ScreenId], [Permission], [SetDate], [UserName]) VALUES (N'0001', N'2001', N'111', CAST(N'2017-08-24 21:32:33.207' AS DateTime), N'razu')
INSERT [dbo].[RoleWiseScreenPermission] ([RoleId], [ScreenId], [Permission], [SetDate], [UserName]) VALUES (N'0001', N'3000', N'0  ', CAST(N'2017-09-24 07:56:08.733' AS DateTime), N'razu')
INSERT [dbo].[RoleWiseScreenPermission] ([RoleId], [ScreenId], [Permission], [SetDate], [UserName]) VALUES (N'0001', N'3001', N'111', CAST(N'2017-09-10 21:02:19.643' AS DateTime), N'razu')
INSERT [dbo].[RoleWiseScreenPermission] ([RoleId], [ScreenId], [Permission], [SetDate], [UserName]) VALUES (N'0001', N'3002', N'111', CAST(N'2017-09-24 07:56:08.763' AS DateTime), N'razu')
INSERT [dbo].[RoleWiseScreenPermission] ([RoleId], [ScreenId], [Permission], [SetDate], [UserName]) VALUES (N'0001', N'4000', N'0  ', CAST(N'2017-11-22 09:40:54.583' AS DateTime), N'razu')
INSERT [dbo].[RoleWiseScreenPermission] ([RoleId], [ScreenId], [Permission], [SetDate], [UserName]) VALUES (N'0001', N'4001', N'111', CAST(N'2017-09-29 10:28:50.647' AS DateTime), N'razu')
INSERT [dbo].[RoleWiseScreenPermission] ([RoleId], [ScreenId], [Permission], [SetDate], [UserName]) VALUES (N'0001', N'4002', N'111', CAST(N'2017-09-30 11:34:43.713' AS DateTime), N'razu')
INSERT [dbo].[RoleWiseScreenPermission] ([RoleId], [ScreenId], [Permission], [SetDate], [UserName]) VALUES (N'0001', N'4003', N'111', CAST(N'2017-10-17 21:46:49.817' AS DateTime), N'razu')
INSERT [dbo].[RoleWiseScreenPermission] ([RoleId], [ScreenId], [Permission], [SetDate], [UserName]) VALUES (N'0001', N'5000', N'0  ', CAST(N'2017-11-22 09:41:11.240' AS DateTime), N'razu')
INSERT [dbo].[RoleWiseScreenPermission] ([RoleId], [ScreenId], [Permission], [SetDate], [UserName]) VALUES (N'0001', N'5001', N'111', CAST(N'2017-11-22 09:41:11.280' AS DateTime), N'mm')
INSERT [dbo].[RoleWiseScreenPermission] ([RoleId], [ScreenId], [Permission], [SetDate], [UserName]) VALUES (N'0001', N'5002', N'111', CAST(N'2017-11-22 09:41:11.280' AS DateTime), N'mm')
INSERT [dbo].[RoleWiseScreenPermission] ([RoleId], [ScreenId], [Permission], [SetDate], [UserName]) VALUES (N'0001', N'6000', N'0  ', CAST(N'2022-08-13 00:02:33.987' AS DateTime), N'mm')
INSERT [dbo].[RoleWiseScreenPermission] ([RoleId], [ScreenId], [Permission], [SetDate], [UserName]) VALUES (N'0001', N'6001', N'111', CAST(N'2022-08-13 00:02:33.987' AS DateTime), N'mm')
INSERT [dbo].[RoleWiseScreenPermission] ([RoleId], [ScreenId], [Permission], [SetDate], [UserName]) VALUES (N'0002', N'1000', N'0  ', CAST(N'2022-05-14 15:34:05.813' AS DateTime), N'mm')
INSERT [dbo].[RoleWiseScreenPermission] ([RoleId], [ScreenId], [Permission], [SetDate], [UserName]) VALUES (N'0002', N'1001', N'111', CAST(N'2022-05-14 15:34:00.537' AS DateTime), N'mm')
INSERT [dbo].[RoleWiseScreenPermission] ([RoleId], [ScreenId], [Permission], [SetDate], [UserName]) VALUES (N'0002', N'1002', N'111', CAST(N'2022-05-14 15:34:04.690' AS DateTime), N'mm')
INSERT [dbo].[RoleWiseScreenPermission] ([RoleId], [ScreenId], [Permission], [SetDate], [UserName]) VALUES (N'0002', N'1003', N'111', CAST(N'2022-05-14 15:34:05.813' AS DateTime), N'mm')
INSERT [dbo].[RoleWiseScreenPermission] ([RoleId], [ScreenId], [Permission], [SetDate], [UserName]) VALUES (N'0002', N'2000', N'0  ', CAST(N'2022-05-14 15:34:17.650' AS DateTime), N'mm')
INSERT [dbo].[RoleWiseScreenPermission] ([RoleId], [ScreenId], [Permission], [SetDate], [UserName]) VALUES (N'0002', N'2001', N'111', CAST(N'2022-05-14 15:34:17.650' AS DateTime), N'mm')
INSERT [dbo].[RoleWiseScreenPermission] ([RoleId], [ScreenId], [Permission], [SetDate], [UserName]) VALUES (N'0002', N'3000', N'0  ', CAST(N'2022-05-14 15:34:21.530' AS DateTime), N'mm')
INSERT [dbo].[RoleWiseScreenPermission] ([RoleId], [ScreenId], [Permission], [SetDate], [UserName]) VALUES (N'0002', N'3001', N'111', CAST(N'2022-05-14 15:34:20.277' AS DateTime), N'mm')
INSERT [dbo].[RoleWiseScreenPermission] ([RoleId], [ScreenId], [Permission], [SetDate], [UserName]) VALUES (N'0002', N'3002', N'111', CAST(N'2022-05-14 15:34:21.530' AS DateTime), N'mm')
INSERT [dbo].[RoleWiseScreenPermission] ([RoleId], [ScreenId], [Permission], [SetDate], [UserName]) VALUES (N'0002', N'4000', N'0  ', CAST(N'2022-05-14 15:34:29.123' AS DateTime), N'mm')
INSERT [dbo].[RoleWiseScreenPermission] ([RoleId], [ScreenId], [Permission], [SetDate], [UserName]) VALUES (N'0002', N'4001', N'111', CAST(N'2022-05-14 15:34:24.153' AS DateTime), N'mm')
INSERT [dbo].[RoleWiseScreenPermission] ([RoleId], [ScreenId], [Permission], [SetDate], [UserName]) VALUES (N'0002', N'4002', N'111', CAST(N'2022-05-14 15:34:25.080' AS DateTime), N'mm')
INSERT [dbo].[RoleWiseScreenPermission] ([RoleId], [ScreenId], [Permission], [SetDate], [UserName]) VALUES (N'0002', N'4003', N'111', CAST(N'2022-05-14 15:34:29.127' AS DateTime), N'mm')
INSERT [dbo].[RoleWiseScreenPermission] ([RoleId], [ScreenId], [Permission], [SetDate], [UserName]) VALUES (N'0002', N'5000', N'0  ', CAST(N'2022-05-14 15:34:30.187' AS DateTime), N'mm')
INSERT [dbo].[RoleWiseScreenPermission] ([RoleId], [ScreenId], [Permission], [SetDate], [UserName]) VALUES (N'0002', N'5001', N'111', CAST(N'2022-05-14 15:34:30.187' AS DateTime), N'mm')
INSERT [dbo].[RoleWiseScreenPermission] ([RoleId], [ScreenId], [Permission], [SetDate], [UserName]) VALUES (N'0002', N'5002', N'111', CAST(N'2017-11-22 09:41:11.280' AS DateTime), N'mm')
INSERT [dbo].[RoleWiseScreenPermission] ([RoleId], [ScreenId], [Permission], [SetDate], [UserName]) VALUES (N'0002', N'6000', N'0  ', CAST(N'2022-08-23 18:18:42.370' AS DateTime), N'mm')
INSERT [dbo].[RoleWiseScreenPermission] ([RoleId], [ScreenId], [Permission], [SetDate], [UserName]) VALUES (N'0002', N'6001', N'0  ', CAST(N'2022-08-23 18:18:42.370' AS DateTime), N'mm')
INSERT [dbo].[RoleWiseScreenPermission] ([RoleId], [ScreenId], [Permission], [SetDate], [UserName]) VALUES (N'0003', N'1000', N'0  ', CAST(N'2017-08-18 23:49:18.587' AS DateTime), N'razu')
INSERT [dbo].[RoleWiseScreenPermission] ([RoleId], [ScreenId], [Permission], [SetDate], [UserName]) VALUES (N'0003', N'1001', N'111', CAST(N'2017-08-15 20:17:23.913' AS DateTime), N'razu')
INSERT [dbo].[RoleWiseScreenPermission] ([RoleId], [ScreenId], [Permission], [SetDate], [UserName]) VALUES (N'0003', N'1002', N'1  ', CAST(N'2017-08-18 23:49:18.587' AS DateTime), N'razu')
INSERT [dbo].[RoleWiseScreenPermission] ([RoleId], [ScreenId], [Permission], [SetDate], [UserName]) VALUES (N'0003', N'4000', N'0  ', CAST(N'2017-10-16 23:29:21.967' AS DateTime), N'razu')
INSERT [dbo].[RoleWiseScreenPermission] ([RoleId], [ScreenId], [Permission], [SetDate], [UserName]) VALUES (N'0003', N'4002', N'111', CAST(N'2017-10-16 23:29:22.007' AS DateTime), N'razu')
INSERT [dbo].[RoleWiseScreenPermission] ([RoleId], [ScreenId], [Permission], [SetDate], [UserName]) VALUES (N'0005', N'1000', N'0  ', CAST(N'2018-09-09 23:14:56.097' AS DateTime), N'razu')
INSERT [dbo].[RoleWiseScreenPermission] ([RoleId], [ScreenId], [Permission], [SetDate], [UserName]) VALUES (N'0005', N'1001', N'111', CAST(N'2018-09-09 23:14:56.097' AS DateTime), N'razu')
INSERT [dbo].[Screens] ([ScreenId], [ScreenName], [URL], [ParentScreenId], [IconName], [Manager], [Remarks], [SetDate], [UserName]) VALUES (N'1000', N'Security Policy', N'Security Policy', N'0000', N'Test.jpg', NULL, NULL, NULL, NULL)
INSERT [dbo].[Screens] ([ScreenId], [ScreenName], [URL], [ParentScreenId], [IconName], [Manager], [Remarks], [SetDate], [UserName]) VALUES (N'1001', N'User Role', N'UserRole\Index', N'1000', N'Test.jpg', NULL, NULL, NULL, NULL)
INSERT [dbo].[Screens] ([ScreenId], [ScreenName], [URL], [ParentScreenId], [IconName], [Manager], [Remarks], [SetDate], [UserName]) VALUES (N'1002', N'User Information', N'UserInfo\Index', N'1000', N'Test.jpg', NULL, NULL, NULL, NULL)
INSERT [dbo].[Screens] ([ScreenId], [ScreenName], [URL], [ParentScreenId], [IconName], [Manager], [Remarks], [SetDate], [UserName]) VALUES (N'1003', N'Role Wise Screen Permission', N'RoleWiseScreen\Index', N'1000', N'Test.jpg', NULL, NULL, NULL, NULL)
INSERT [dbo].[Screens] ([ScreenId], [ScreenName], [URL], [ParentScreenId], [IconName], [Manager], [Remarks], [SetDate], [UserName]) VALUES (N'2000', N'Employee', N'Employee\Index', N'0000', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Screens] ([ScreenId], [ScreenName], [URL], [ParentScreenId], [IconName], [Manager], [Remarks], [SetDate], [UserName]) VALUES (N'2001', N'Employee Setup', N'EmployeeInfo\Index', N'2000', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Screens] ([ScreenId], [ScreenName], [URL], [ParentScreenId], [IconName], [Manager], [Remarks], [SetDate], [UserName]) VALUES (N'3000', N'Customer', N'CustomerInfo\Index', N'0000', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Screens] ([ScreenId], [ScreenName], [URL], [ParentScreenId], [IconName], [Manager], [Remarks], [SetDate], [UserName]) VALUES (N'3001', N'Supplier Setup', N'SupplierInfo\Index', N'3000', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Screens] ([ScreenId], [ScreenName], [URL], [ParentScreenId], [IconName], [Manager], [Remarks], [SetDate], [UserName]) VALUES (N'3002', N'Customer Setup', N'CustomerInfo\Index', N'3000', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Screens] ([ScreenId], [ScreenName], [URL], [ParentScreenId], [IconName], [Manager], [Remarks], [SetDate], [UserName]) VALUES (N'4000', N'Transaction', N'Transaction\Index', N'0000', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Screens] ([ScreenId], [ScreenName], [URL], [ParentScreenId], [IconName], [Manager], [Remarks], [SetDate], [UserName]) VALUES (N'4001', N'Product Purces', N'ProductPurces\Index', N'4000', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Screens] ([ScreenId], [ScreenName], [URL], [ParentScreenId], [IconName], [Manager], [Remarks], [SetDate], [UserName]) VALUES (N'4002', N'Distribution', N'Distribution\Index', N'4000', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Screens] ([ScreenId], [ScreenName], [URL], [ParentScreenId], [IconName], [Manager], [Remarks], [SetDate], [UserName]) VALUES (N'4003', N'Sale Entry', N'SaleEntry\Index', N'4000', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Screens] ([ScreenId], [ScreenName], [URL], [ParentScreenId], [IconName], [Manager], [Remarks], [SetDate], [UserName]) VALUES (N'5000', N'Administration', N'Administration\Index', N'0000', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Screens] ([ScreenId], [ScreenName], [URL], [ParentScreenId], [IconName], [Manager], [Remarks], [SetDate], [UserName]) VALUES (N'5001', N'Department Setup', N'Department\Index', N'5000', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Screens] ([ScreenId], [ScreenName], [URL], [ParentScreenId], [IconName], [Manager], [Remarks], [SetDate], [UserName]) VALUES (N'5002', N'Designation Setup', N'Designation\Index', N'5000', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Screens] ([ScreenId], [ScreenName], [URL], [ParentScreenId], [IconName], [Manager], [Remarks], [SetDate], [UserName]) VALUES (N'6000', N'Product', N'ProductInfo\Index', N'0000', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Screens] ([ScreenId], [ScreenName], [URL], [ParentScreenId], [IconName], [Manager], [Remarks], [SetDate], [UserName]) VALUES (N'6001', N'ProductSetup', N'ProductInfo\Index', N'6000', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Supplier] ([SupplierId], [GLAccountNo], [SupplierName], [ContactPerson], [ContactNumber], [EmailAddress], [MailingAddress], [CurrentBalance], [DueBalance], [Status], [SetupDate], [UserId], [CreateBy], [CreateDate], [ModifyBy], [ModifyDate]) VALUES (1, N'SUP00000001', N'sss                                               ', N'dsd                           ', N'333            ', N'ds                            ', N'dfd                                                                                                 ', CAST(33.00 AS Numeric(18, 2)), CAST(33.00 AS Numeric(18, 2)), 0, CAST(N'2022-08-23 23:21:22.160' AS DateTime), 7, N'7', CAST(N'2022-08-23 23:21:22.160' AS DateTime), NULL, NULL)
INSERT [dbo].[Supplier] ([SupplierId], [GLAccountNo], [SupplierName], [ContactPerson], [ContactNumber], [EmailAddress], [MailingAddress], [CurrentBalance], [DueBalance], [Status], [SetupDate], [UserId], [CreateBy], [CreateDate], [ModifyBy], [ModifyDate]) VALUES (2, N'SUP00000002', N'Supplier 2                                        ', N'ffg                           ', N'3232           ', N'33fdsds                       ', N'3orrr                                                                                               ', CAST(11.00 AS Numeric(18, 2)), CAST(11.00 AS Numeric(18, 2)), 0, CAST(N'2022-08-23 23:50:17.840' AS DateTime), 7, N'7', CAST(N'2022-08-23 23:50:17.840' AS DateTime), NULL, NULL)
INSERT [dbo].[SysGendar] ([GenderID], [Description], [Status]) VALUES (N'0', N'Both', 1)
INSERT [dbo].[SysGendar] ([GenderID], [Description], [Status]) VALUES (N'1', N'Male', 0)
INSERT [dbo].[SysGendar] ([GenderID], [Description], [Status]) VALUES (N'2', N'Female', 0)
INSERT [dbo].[SysMaritalStatus] ([MaritalID], [Description], [Status]) VALUES (N'1', N'Single', 0)
INSERT [dbo].[SysMaritalStatus] ([MaritalID], [Description], [Status]) VALUES (N'2', N'Marrid', 0)
SET IDENTITY_INSERT [dbo].[UserInfo] ON 

INSERT [dbo].[UserInfo] ([UserId], [UserName], [UserFullName], [UserPassword], [UserRoleId], [UserStatus], [SetDate], [ModifyUser]) VALUES (11, N'2m', N'Abdul Malek', N'2m', N'0002', N'01', CAST(N'2022-05-14' AS Date), N'2m')
INSERT [dbo].[UserInfo] ([UserId], [UserName], [UserFullName], [UserPassword], [UserRoleId], [UserStatus], [SetDate], [ModifyUser]) VALUES (7, N'mm', N'Abdul Malek', N'mm', N'0001', N'01', CAST(N'2022-05-10' AS Date), N'mm')
INSERT [dbo].[UserInfo] ([UserId], [UserName], [UserFullName], [UserPassword], [UserRoleId], [UserStatus], [SetDate], [ModifyUser]) VALUES (12, N'tr', N'rttr', N'rtr', N'0003', N'01', CAST(N'2022-07-30' AS Date), N'tr')
INSERT [dbo].[UserInfo] ([UserId], [UserName], [UserFullName], [UserPassword], [UserRoleId], [UserStatus], [SetDate], [ModifyUser]) VALUES (13, N'tt', N'Md. Abdul Malek', N'tt', N'0001', N'01', CAST(N'2022-08-13' AS Date), N'tt')
SET IDENTITY_INSERT [dbo].[UserInfo] OFF
INSERT [dbo].[UserRole] ([RoleId], [RoleName], [SetDate], [UserName]) VALUES (N'0001', N'Admin', CAST(N'2022-08-23 20:04:38.110' AS DateTime), N'mm')
INSERT [dbo].[UserRole] ([RoleId], [RoleName], [SetDate], [UserName]) VALUES (N'0002', N'supper user', CAST(N'2022-05-14 15:30:15.433' AS DateTime), N'mm')
INSERT [dbo].[UserRole] ([RoleId], [RoleName], [SetDate], [UserName]) VALUES (N'0003', N'entry user', CAST(N'2022-05-14 15:30:24.650' AS DateTime), N'mm')
INSERT [dbo].[UserStatus] ([StatusId], [StatusName], [SetDate], [UserName]) VALUES (N'01', N'Active', NULL, NULL)
INSERT [dbo].[UserStatus] ([StatusId], [StatusName], [SetDate], [UserName]) VALUES (N'02', N'InActive', NULL, NULL)
ALTER TABLE [dbo].[RoleWiseScreenPermission]  WITH CHECK ADD  CONSTRAINT [FK_RoleWiseScreenPermission_Screens] FOREIGN KEY([ScreenId])
REFERENCES [dbo].[Screens] ([ScreenId])
GO
ALTER TABLE [dbo].[RoleWiseScreenPermission] CHECK CONSTRAINT [FK_RoleWiseScreenPermission_Screens]
GO
ALTER TABLE [dbo].[UserInfo]  WITH CHECK ADD  CONSTRAINT [FK_UserInfo_UserInfo] FOREIGN KEY([UserName])
REFERENCES [dbo].[UserInfo] ([UserName])
GO
ALTER TABLE [dbo].[UserInfo] CHECK CONSTRAINT [FK_UserInfo_UserInfo]
GO
/****** Object:  StoredProcedure [dbo].[Sp_CollectEmployeeAttendance]    Script Date: 26-Aug-22 8:41:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[Sp_CollectEmployeeAttendance]
@DataCollection AS AttendanceCollection READONLY

AS
BEGIN
set NOCOUNT ON;
declare @AttDate Date,@UserId int

select @AttDate=AttendanceDate from @DataCollection
select @UserId=UserId from @DataCollection


delete a from Tbl_EmployeeAttendance a where a.AttendanceDate=@AttDate

insert into Tbl_EmployeeAttendance
select a.EmployeeId,@AttDate,@AttDate,NULL,CASE when b.EmployeeId is null then 0 else 1 end,0,0,GETDATE(),@UserId  
from Tbl_Employee a
left join @DataCollection b on a.EmployeeId=b.EmployeeId






END



GO
/****** Object:  StoredProcedure [dbo].[Sp_GetEmployeePaySlip]    Script Date: 26-Aug-22 8:41:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[Sp_GetEmployeePaySlip]
@EmployeeId AS int,
@SalaryYear as int,
@SalaryMonth as int
AS
BEGIN
set NOCOUNT ON;

select d.Name,e.DesignationName AS Designation,x.BreakupName,[dbo].[IsNegative](x.Amount) AS Amount,x.Bk,f.TotalSalary,[dbo].[IsNegative](c.AdjustedAmount) AS AdjustedAmount,
f.TotalSalary+c.AdjustedAmount AS NetPay,DateName( month , DateAdd( month , @SalaryMonth , 0 ) - 1 )+' '+ CAST( @SalaryYear AS varchar(4)) AS SalaryYearMonth from (
select distinct a.EmployeeId,e.BreakupName,b.Amount,1 AS Bk
from [dbo].[Tbl_EmployeeMonthlySalary] a 
inner join [dbo].[Tbl_EmployeeSalaryDetails] b on a.EmployeeId=b.EmployeeId
inner join Tbl_SalaryBreakup e on e.BreakupId=b.BreakupId

where a.EmployeeId=@EmployeeId and a.SalaryYear=@SalaryYear and a.SalaryMonth=@SalaryMonth

union ALL

select a.EmployeeId,b.AdjustmentName AS BreakupName,CASE when a.AddWithSalary=1 then a.AdjustmentAmount else (-1)*a.AdjustmentAmount end AS Amount,2 AS Bk
 from Tbl_EmployeeMonthlySalaryAdjustment a 
inner join Tbl_AdjustmentPurpose b on a.AdjustmentId=b.AdjustmentId


 where a.EmployeeId=@EmployeeId and a.SalaryYear=@SalaryYear and a.SalaryMonth=@SalaryMonth
 ) x 
inner join (select a.EmployeeId, SUM(a.Amount) AS TotalSalary from Tbl_EmployeeSalaryDetails a group by a.EmployeeId) f on f.EmployeeId=x.EmployeeId
inner join
 (select a.EmployeeId,Sum(CASE when a.AddWithSalary=1 then a.AdjustmentAmount else (-1)*a.AdjustmentAmount end) AS AdjustedAmount 
 from Tbl_EmployeeMonthlySalaryAdjustment a group by a.EmployeeId
 ) c on c.EmployeeId=x.EmployeeId 
 inner join Tbl_Employee d on d.EmployeeId=x.EmployeeId
inner join Tbl_Designation e on d.DesignationId=e.DesignationId





END



GO
/****** Object:  StoredProcedure [dbo].[Sp_GetEmployeeYearMonthWiseOTLate]    Script Date: 26-Aug-22 8:41:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[Sp_GetEmployeeYearMonthWiseOTLate]
@AttYear AS int,
@AttMonth AS int

AS
BEGIN
set NOCOUNT ON;


select b.EmployeeId,b.Name,REPLACE(CONVERT(VARCHAR(11), a.AttendanceDate, 106), ' ', '-') AS AttendanceDate,CAST (a.AttendanceInTime AS time) AS AttendanceInTime,CAST(a.AttendanceOutTime AS time) AS AttendanceOutTime,
CASE when c.OtInMin is not null  then c.OtInMin else DATEDIFF(MINUTE,a.AttendanceInTime,a.AttendanceOutTime)-(8*60) End AS ExtraOfficeTimeInMin,
Case when c.OtInMin is not null then 1 else 0 End AS 'IsOtEligible' ,
isnull(a.Late,0) AS 'IsLate'  
from [dbo].[Tbl_EmployeeAttendance] a
inner join Tbl_Employee b on a.EmployeeId=b.EmployeeId
left join Tbl_EmployeeOvertime c on c.EmployeeId=b.EmployeeId and c.AttendanceDate=a.AttendanceDate
where YEAR(a.AttendanceDate)*100+MONTH(a.AttendanceDate)=@AttYear*100+@AttMonth and a.IsOffice=1



END



GO
/****** Object:  StoredProcedure [dbo].[Sp_GetNewSalaryStructure]    Script Date: 26-Aug-22 8:41:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create Procedure [dbo].[Sp_GetNewSalaryStructure]
@SalaryGroupId AS int,
@TotalSalary AS money

AS
BEGIN
set NOCOUNT ON;


DECLARE @Diff money
DECLARE @SalaryBreakup AS table (BreakupId int,BreakupName varchar(60),Amount money)

insert into @SalaryBreakup
select a.BreakupId,b.BreakupName,CAST( (round(a.Percentage*.01*@TotalSalary,0))AS int) Amount from Tbl_SalarygroupWiseBreakup a
inner join Tbl_SalaryBreakup b on a.BreakupId=b.BreakupId
where a.SalaryGroupId=@SalaryGroupId

set @Diff=(select SUM(a.Amount) from @SalaryBreakup a)-@TotalSalary
if (@Diff<>0 ) 
begin 
update a set a.Amount=a.Amount-@Diff from @SalaryBreakup a where a.BreakupId in (
 select top 1 a.BreakupId from @SalaryBreakup a 
 inner join Tbl_SalaryBreakup b on a.BreakupId=b.BreakupId
 where a.BreakupName not like '%basic%')

end

select * from @SalaryBreakup a 


END



GO
/****** Object:  StoredProcedure [dbo].[Sp_UpdateEmployeeYearMonthWiseOTLate]    Script Date: 26-Aug-22 8:41:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[Sp_UpdateEmployeeYearMonthWiseOTLate]
@EmployeeId As int,
@AttDate AS Date,
@OTInMin AS float,
@IsOT AS bit,
@IsLate AS bit,
@User AS varchar(60)

AS
BEGIN
set NOCOUNT ON;


if (exists( select * from Tbl_EmployeeOvertime a where a.EmployeeId=@EmployeeId and a.AttendanceDate=@AttDate) AND @IsOT=1)
begin
  update a set a.OTInMin=@OTInMin from Tbl_EmployeeOvertime a where a.EmployeeId=@EmployeeId and a.AttendanceDate=@AttDate
end
else	
begin
  if @IsOT=1
  begin
    insert into Tbl_EmployeeOvertime values(@EmployeeId,@AttDate,@OTInMin,GetDate(),@User)
  end
end


update a set a.Late=@IsLate 
from [dbo].[Tbl_EmployeeAttendance] a 
where a.EmployeeId=@EmployeeId and a.AttendanceDate=@AttDate



END



GO
/****** Object:  StoredProcedure [dbo].[Sp_UpdateSpecificPermission]    Script Date: 26-Aug-22 8:41:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Sp_UpdateSpecificPermission]
(
    @RoleId nchar(4),
    @ScreenId nchar(4), 
	@OperationType varchar(7),
    @Action varchar(6)

)

AS 
BEGIN


declare @Save nchar(1),@Update nchar(1),@Delete nchar(1),@CurrPermission nchar(3)
select @Save=left(a.Permission,1),@Update=SUBSTRING(a.Permission,2,1),@Delete=RIGHT(a.Permission,1)   from RoleWiseScreenPermission a
where a.RoleId=@RoleId and a.ScreenId=@ScreenId
if @OperationType='Save'
begin
  if @Action='Save'
  begin
    set @Save=1
  end
  else
  begin
  set @Save=0
  end
  
end

if @OperationType='Update'
begin

  if @Action='Save'
  begin
    set @Update=1
  end
  else
  begin
  set @Update=0
  end


end

if @OperationType='Delete'
begin

if @Action='Save'
  begin
    set @Delete=1
  end
  else
  begin
  set @Delete=0
  end

end

set @CurrPermission=@Save+@Update+@Delete


update a set a.Permission=@CurrPermission from RoleWiseScreenPermission a
where a.RoleId=@RoleId and a.ScreenId=@ScreenId 


End


GO
/****** Object:  StoredProcedure [dbo].[USP_CustomerEntry]    Script Date: 26-Aug-22 8:41:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[USP_CustomerEntry](  @CustomerId int = NULL,
									@GLAccountNo nchar(11) = NULL,
									@CustomerName nchar(50) = NULL,
									@ContactPerson nchar(30) = NULL,
									@ContactNumber nchar(15) = NULL,
									@EmailAddress nchar(30)= NULL,
									@MailingAddress nchar(100)= NULL,
									@CurrentBalance numeric(18, 2) = NULL,
									@DueBalance numeric(18, 2) = NULL,
									@Status tinyint = NULL,
									@SetupDate datetime = NULL,
									@UserId int = NULL,
									@CreateBy varchar(10) = NULL,
									@CreateDate datetime = NULL,
									@ModifyBy varchar(10) = NULL,
									@ModifyDate datetime = NULL,
									@Action int
									)AS
BEGIN
	DECLARE @GenGLAccountNo nvarchar(11),@GenStatus int,@GenCurrentBalance numeric(18, 2),@GenEntryTypeId nchar(3),
			@GenDueBalance numeric(18, 2), @GenCustomerId int, @GenSetupDate datetime, @NewSupplierCount int
	IF @Action = 1
		BEGIN

			select @GenCustomerId = isnull(MAX(a.CustomerId),0)+1 from Customer a;
			select @GenEntryTypeId ='CUS';
			select @GenGLAccountNo = AccountType+RIGHT('00000000'+convert(varchar,LastAccountNo+1),8) from LastGLAccountNo where AccountType = @GenEntryTypeId;
			select @GenStatus = 0;
			select @GenSetupDate = GETDATE();

			INSERT INTO Customer(CustomerId,GLAccountNo,CustomerName,ContactPerson,ContactNumber,EmailAddress,
					MailingAddress,CurrentBalance,DueBalance,Status,SetupDate,UserId,CreateBy,CreateDate,ModifyBy,ModifyDate)
			VALUES(@GenCustomerId,@GenGLAccountNo,@CustomerName,@ContactPerson,@ContactNumber,@EmailAddress,
					@MailingAddress,@CurrentBalance,@DueBalance,@GenStatus,@GenSetupDate,@UserId,@UserId,@GenSetupDate,@ModifyBy,@ModifyDate)
		
			select @NewSupplierCount = count(*) from Customer where CustomerId = @GenCustomerId and GLAccountNo = @GenGLAccountNo;
		
			if @NewSupplierCount > 0
				begin
					update a set a.LastAccountNo = a.LastAccountNo + 1  from LastGLAccountNo a  where a.AccountType = @GenEntryTypeId;
				end

		END
	IF @Action = 2
		BEGIN			
			UPDATE a set a.CustomerName = @CustomerName,
					     a.ContactPerson = @ContactPerson,
						 a.ContactNumber = @ContactNumber,
						 a.EmailAddress = @EmailAddress,
						 a.MailingAddress = @MailingAddress,
						 a.UserId = @UserId,
						 a.ModifyBy = @ModifyBy,
						 a.ModifyDate = @ModifyDate
			FROM Customer a WHERE a.CustomerId = @CustomerId and a.GLAccountNo = @GLAccountNo;			

		END

END


GO
/****** Object:  StoredProcedure [dbo].[USP_DepartmentEntry]    Script Date: 26-Aug-22 8:41:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[USP_DepartmentEntry](@DepartmentId int = null,
									 @DepartmentName nvarchar(20) = null,
									 @Status int = null,
									 @CreateBy varchar(10) = null,
									 @CreateDate datetime = null,
									 @MakeBy varchar(10) = null,
									 @MakeDate datetime = null,
									 @Action int = null
									 ) as
begin
	declare @LastDepartmentId int,@NewStatus int
	if @Action = 1		
		begin
			select @LastDepartmentId = max(DepartmentId)+1 from Department;
			select @NewStatus = 0;

			insert into Department(DepartmentId,DepartmentName,Status,CreateBy,CreateDate,MakeBy,MakeDate)
			values (@LastDepartmentId,@DepartmentName,@NewStatus,'Admin',getdate(),'Admin',getdate());
		end
end
GO
/****** Object:  StoredProcedure [dbo].[USP_Depatment]    Script Date: 26-Aug-22 8:41:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[USP_Depatment]
(
@QryOption int 
)
As
If(@QryOption = 1)
Begin
Select DepartMentId [key] ,DepartmentName Value from Tbl_Department
end
If(@QryOption = 2)
Begin
Select [DesignationId] [key] ,[DesignationName] Value from Tbl_Designation
end



GO
/****** Object:  StoredProcedure [dbo].[USP_DesignationEntry]    Script Date: 26-Aug-22 8:41:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[USP_DesignationEntry](@DesignationId int = null,
											  @DesignationName nvarchar(20) = null,
											  @Status int = null,
											  @CreateBy varchar(10) = null,
											  @CreateDate datetime = null,
											  @MakeBy varchar(10) = null,
											  @MakeDate datetime = null,
											  @Action int = null
											 ) as
begin
	declare @LastDesignationId int,@NewStatus int
	if @Action = 1		
		begin
			select @LastDesignationId = max(DesignationId)+1 from Designation;
			select @NewStatus = 0;

			insert into Designation(DesignationId,DesignationName,Status,CreateBy,CreateDate,MakeBy,MakeDate)
			values (@LastDesignationId,@DesignationName,@NewStatus,'Admin',getdate(),'Admin',getdate());
		end
end

GO
/****** Object:  StoredProcedure [dbo].[USP_EmployeeEntry]    Script Date: 26-Aug-22 8:41:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[USP_EmployeeEntry]
(
    @EmployeeId int= null,
	@GLAccountNo nvarchar(11)= null,
	@EmployeeName nvarchar(100) = null,
	@FatherName nvarchar(100),
	@MotherName nvarchar(50),
	@PresentAddress nvarchar(max),
	@PermanentAddress nvarchar(max),
	@GenderId int,
	@DateOfBirth datetime,
	@ContractNumber nvarchar(11),
	@EmergencyNumber nvarchar(11),
	@BloodGroup nvarchar(15),
	@NationalId nvarchar(50),
	--@BirthDayRegNo varchar(50),
	@MaritalStatus int,
	@DeptId int,
	@DesignationId int,
	@JoiningDate datetime= null,
	@JoiningType int= null,
	@StatusId int = 0,
	@ImagePath varchar(500)= null,
	@UserId int,
	@Action int

)

AS 
BEGIN

DECLARE @GeneratedEmployee int , @GeneratedEmployeeCode varchar(30),@GeneratedGLAccountNo nvarchar(11),@GLAccountNoCount int,
		@NewEmployeeCount int

if @Action=1
	begin

		select @GeneratedEmployee = isnull(MAX(a.EmployeeId),0)+1 from Employee a;
		select @GeneratedEmployeeCode ='EMP'+RIGHT('00000000'+CONVERT(VARCHAR(11),@GeneratedEmployee),8);
		select @GeneratedGLAccountNo = AccountType+RIGHT('00000000'+convert(varchar,LastAccountNo+1),8) from LastGLAccountNo where AccountType = 'EMP';
		select @UserId = 1;

		insert into Employee ([EmployeeId],[EmployeeCode],[GLAccountNo],[Balance],[EmployeeName],[FatherName],[MotherName],[PresentAddress],
							  [PermanentAddress],[GenderId],[NationalID],[DateOfBirth],[ContractNumber],[EmergencyNumber],[BloodGroup],[MaritalStatus],
							  [DeptId],[DesignationId],[JoiningDate],[JoiningType],[StatusId],[ImagePath],[CreatedBy],[CreatedDate],[ModifyBy],[ModifyDate]) 
	    values(@GeneratedEmployee,@GeneratedEmployeeCode,@GeneratedGLAccountNo,0,@EmployeeName,@FatherName,@MotherName,@PresentAddress,
			  @PermanentAddress,@GenderId,@NationalId,@DateOfBirth,@ContractNumber,@EmergencyNumber,@BloodGroup,@MaritalStatus,
			  @DeptId,@DesignationId,GETDATE(),@JoiningType,@StatusId,@ImagePath,@UserId,GETDATE(),NULL,GETDATE())
	
		select @NewEmployeeCount = count(*) from Employee where EmployeeCode = @GeneratedEmployeeCode
		
		if @NewEmployeeCount > 0
			begin
				update a set a.LastAccountNo = a.LastAccountNo + 1  from LastGLAccountNo a  where a.AccountType = 'EMP';
			end

	end

if @Action=2
begin


if @ImagePath is not null 
begin 

update a set a.ImagePath=@ImagePath from Employee a where a.EmployeeId=@EmployeeId
end


  update a set a.EmployeeName=@EmployeeName,
  a.FatherName=@FatherName,
  a.MotherName=@MotherName,
  a.PresentAddress=@PresentAddress,
  a.PermanentAddress=@PermanentAddress,
  a.GenderId=@GenderId,
  a.ContractNumber=@ContractNumber,
  a.EmergencyNumber=@EmergencyNumber,
  a.BloodGroup=@BloodGroup,
  a.NationalID=@NationalId,
  a.DesignationId=@DesignationId,
  a.JoiningDate=@JoiningDate,
  a.JoiningType=@JoiningType,
  a.StatusId=@StatusId,
  a.MaritalStatus=@MaritalStatus,
  a.ModifyBy=@UserId,
  a.ModifyDate=GETDATE()
   from Employee a where a.EmployeeId=@EmployeeId

end

end








GO
/****** Object:  StoredProcedure [dbo].[USP_GetChartOfAccounts]    Script Date: 26-Aug-22 8:41:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[USP_GetChartOfAccounts]
(
    @GLAccountNo nvarchar(11) = null,
    @GLAccountName nvarchar(100) = null,
    @GLPrefix nvarchar(3) = null,
    @PGLAccountNo nvarchar(11) = null,
    @GLType nvarchar(1)=null,
    @GLACType  nvarchar(1)=null,
    @GLLevel nvarchar(1)=null,
    @AllowEntry nvarchar(1)=null,
    @Status nvarchar(1)=null,
    @SetupDate datetime = NULL,
    @UserId nvarchar(10)=null,
	@Action int

)

AS 
BEGIN

DECLARE @AccSetupDate datetime

if @Action=1
	begin
		select @AccSetupDate = GETDATE();
		INSERT INTO ChartOfAccounts(GLAccountNo,GLAccountName,GLPrefix,PGLAccountNo,GLType,GLACType,GLLevel,AllowEntry,Status,SetupDate,UserId)
		VALUES(@GLAccountNo,@GLAccountName,@GLPrefix,@PGLAccountNo,@GLType,@GLACType,@GLLevel,@AllowEntry,@Status,@AccSetupDate,@UserId)
	end

if @Action=2
begin
	UPDATE a set a.GLAccountName = @GLAccountName from ChartOfAccounts a where a.GLAccountNo = @GLAccountNo;
end

end



GO
/****** Object:  StoredProcedure [dbo].[USP_GetCustomer]    Script Date: 26-Aug-22 8:41:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[USP_GetCustomer]
(
    @Action int
)

AS 
BEGIN

if @Action = 1
	begin
		select * from Customer where Status = 0;
     end

if @Action = 2
	begin
		select CustomerId [key], CustomerName value from Customer where Status = 0
	end

end



GO
/****** Object:  StoredProcedure [dbo].[USP_GetDepartment]    Script Date: 26-Aug-22 8:41:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[USP_GetDepartment](@Action int = null) as
begin
	if @Action = 1		
		begin
			select DepartmentId,DepartmentName,Status,CreateBy,CreateDate,MakeBy,MakeDate from Department where status = 0;
		end
end
GO
/****** Object:  StoredProcedure [dbo].[USP_GetDesignation]    Script Date: 26-Aug-22 8:41:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[USP_GetDesignation](@Action int = null) as
begin
	if @Action = 1		
		begin
			select DesignationId,DesignationName,Status,CreateBy,CreateDate,MakeBy,MakeDate from Designation where status = 0;
		end
end


GO
/****** Object:  StoredProcedure [dbo].[USP_GetEmployee]    Script Date: 26-Aug-22 8:41:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[USP_GetEmployee]
(
    @Action int
)

AS 
BEGIN

if @Action = 1
	begin
		select * from Employee
     end

if @Action = 2
	begin
		select EmployeeId [key], EmployeeName value from Employee where StatusId = 0
	end

end

GO
/****** Object:  StoredProcedure [dbo].[USP_GetEmployeeCombo]    Script Date: 26-Aug-22 8:41:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[USP_GetEmployeeCombo]
(
@QryOption int 
)
As
BEGIN
If(@QryOption = 1)
	Begin
		Select DepartMentId [key], DepartmentName Value from Department
	end

If(@QryOption = 2)
	Begin
		Select DesignationId [key], DesignationName Value from Designation
	end

If(@QryOption = 3)
	Begin
		Select GenderId [key], Description Value from SysGendar where status = 0
	end

If(@QryOption = 4)
	Begin
		Select MaritalId [key], Description Value from SysMaritalStatus where status = 0
	end

If(@QryOption = 5)
	Begin
		Select GroupId [key], GroupName Value from BloodGroup
	end


END



GO
/****** Object:  StoredProcedure [dbo].[USP_GetProduct]    Script Date: 26-Aug-22 8:41:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE  [dbo].[USP_GetProduct] 
(
    @Action int
)

AS 
BEGIN

if @Action = 1
	begin
		select * from Product  where Status = 0;
     end

if @Action = 2
	begin
		select ProductId [key], ProductName value from Product  where Status = 0
	end

end



GO
/****** Object:  StoredProcedure [dbo].[USP_GetSupplier]    Script Date: 26-Aug-22 8:41:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USP_GetSupplier]
(
    @Action int
)

AS 
BEGIN

if @Action = 1
	begin
		select * from Supplier where Status = 0;
     end

if @Action = 2
	begin
		select SupplierId [key], SupplierName value from Supplier where Status = 0
	end

end


GO
/****** Object:  StoredProcedure [dbo].[USP_GLTransaction]    Script Date: 26-Aug-22 8:41:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
	CREATE PROCEDURE [dbo].[USP_GLTransaction](@BranchId nchar(4)= NULL,
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
/****** Object:  StoredProcedure [dbo].[USP_ProductEntry]    Script Date: 26-Aug-22 8:41:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[USP_ProductEntry]
(
	@ProductId int = null,
	@ProductName varchar(100)= NULL,
	@GLAccountNo Nvarchar(11)= NULL,
	@Unit int= 0,
	@CostPrice numeric(18, 2) =0,
	@RetailSalePrice numeric(18, 2) =0,
	@WholeSalePrice numeric(18, 2)= 0,
	@Balance numeric(18, 2) =0,
	@Status tinyint =0,
	@Retunable tinyint =0,
	@IsSync tinyint =0,
	@EffectiveDate datetime= NULL,
	@ExpiryDate datetime =NULL,
	@CreateBy varchar(10)= NULL,
	@CreateDate datetime =NULL,
	@ModifyBy varchar(10)= NULL,
	@ModifyDate datetime = NULL,
	@Action int
)
AS
BEGIN
	DECLARE @GenProductId int, @GenGLAccountNo nvarchar(11),@GenStatus int,@GenCurrentBalance numeric(18, 2),@GenEntryTypeId nchar(3),
			@GenDueBalance numeric(18, 2), @GenSetupDate datetime, @NewProductCount int

	if @Action = 1 
		BEGIN
			select @GenProductId = isnull(MAX(a.ProductId),0)+1 from Product a;
			select @GenEntryTypeId ='PRD';
			select @GenGLAccountNo = AccountType+RIGHT('00000000'+convert(varchar,LastAccountNo+1),8) from LastGLAccountNo where AccountType = @GenEntryTypeId;
			select @GenStatus = 0;
			select @GenSetupDate = GETDATE();

			INSERT INTO Product (ProductId,ProductName,GLAccountNo,Unit,CostPrice,RetailSalePrice,WholeSalePrice,
								Balance,Status,Retunable,IsSync,EffectiveDate,ExpiryDate,CreatedBy,CreatedDate,ModifyBy,ModifyDate)
			Values(@GenProductId,@ProductName,@GenGLAccountNo,@Unit,@CostPrice,@RetailSalePrice,@WholeSalePrice,
									   @Balance,@Status,@Retunable,@IsSync,@EffectiveDate,@ExpiryDate,@CreateBy,@CreateDate,@ModifyBy,@ModifyDate
									   );

		    select @NewProductCount = count(*) from Product where ProductId = @GenProductId and GLAccountNo = @GenGLAccountNo;

			if @NewProductCount > 0
				BEGIN
					update a set a.LastAccountNo = a.LastAccountNo + 1  from LastGLAccountNo a  where a.AccountType = @GenEntryTypeId;
				END

		END

	if @Action = 2 
		BEGIN
			update a set a.ProductName = @ProductName,
						 a.Unit = @Unit,
						 a.CostPrice = @CostPrice,
						 a.RetailSalePrice = @RetailSalePrice,
						 a.WholeSalePrice = @WholeSalePrice,
						 a.Balance = @Balance,
						 a.Status = @Status,
						 a.Retunable = @Retunable,
						 a.IsSync = @IsSync,
						 a.EffectiveDate = @EffectiveDate,
						 a.ExpiryDate = @ExpiryDate,
						 a.ModifyBy = @ModifyBy,
						 a.ModifyDate = @ModifyDate
			from Product a where a.ProductId = @ProductId;
		END

END







GO
/****** Object:  StoredProcedure [dbo].[USP_SpplierEntry]    Script Date: 26-Aug-22 8:41:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USP_SpplierEntry](  @SupplierId int = NULL,
									@GLAccountNo nchar(11) = NULL,
									@SupplierName nchar(50) = NULL,
									@ContactPerson nchar(30) = NULL,
									@ContactNumber nchar(15) = NULL,
									@EmailAddress nchar(30)= NULL,
									@MailingAddress nchar(100)= NULL,
									@CurrentBalance numeric(18, 2) = NULL,
									@DueBalance numeric(18, 2) = NULL,
									@Status tinyint = NULL,
									@SetupDate datetime = NULL,
									@UserId int = NULL,
									@CreateBy varchar(10) = NULL,
									@CreateDate datetime = NULL,
									@ModifyBy varchar(10) = NULL,
									@ModifyDate datetime = NULL,
									@Action int
									)AS
BEGIN
	DECLARE @GenGLAccountNo nvarchar(11),@GenStatus int,@GenCurrentBalance numeric(18, 2),@GenEntryTypeId nchar(3),
			@GenDueBalance numeric(18, 2), @GenSupplierId int, @GenSetupDate datetime, @NewSupplierCount int
	IF @Action = 1
		BEGIN

			select @GenSupplierId = isnull(MAX(a.SupplierId),0)+1 from Supplier a;
			select @GenEntryTypeId ='SUP';
			select @GenGLAccountNo = AccountType+RIGHT('00000000'+convert(varchar,LastAccountNo+1),8) from LastGLAccountNo where AccountType = @GenEntryTypeId;
			select @GenStatus = 0;
			select @GenSetupDate = GETDATE();

			INSERT INTO Supplier(SupplierId,GLAccountNo,SupplierName,ContactPerson,ContactNumber,EmailAddress,
					MailingAddress,CurrentBalance,DueBalance,Status,SetupDate,UserId,CreateBy,CreateDate,ModifyBy,ModifyDate)
			VALUES(@GenSupplierId,@GenGLAccountNo,@SupplierName,@ContactPerson,@ContactNumber,@EmailAddress,
					@MailingAddress,@CurrentBalance,@DueBalance,@GenStatus,@GenSetupDate,@UserId,@UserId,@GenSetupDate,@ModifyBy,@ModifyDate)
		
			select @NewSupplierCount = count(*) from Supplier where SupplierId = @GenSupplierId and GLAccountNo = @GenGLAccountNo;
		
			if @NewSupplierCount > 0
				begin
					update a set a.LastAccountNo = a.LastAccountNo + 1  from LastGLAccountNo a  where a.AccountType = @GenEntryTypeId;
				end

		END
	IF @Action = 2
		BEGIN			
			UPDATE a set a.SupplierName = @SupplierName,
					     a.ContactPerson = @ContactPerson,
						 a.ContactNumber = @ContactNumber,
						 a.EmailAddress = @EmailAddress,
						 a.MailingAddress = @MailingAddress,
						 a.UserId = @UserId,
						 a.ModifyBy = @ModifyBy,
						 a.ModifyDate = @ModifyDate
			FROM Supplier a WHERE a.SupplierId = @SupplierId and a.GLAccountNo = @GLAccountNo;			

		END

END
GO
USE [master]
GO
ALTER DATABASE [Payroll] SET  READ_WRITE 
GO


================********************=========================

ALTER procedure [dbo].[USP_DepartmentEntry](@DepartmentId int = null,
									 @DepartmentName nvarchar(20) = null,
									 @Status int = null,
									 @UserId varchar(10) = null,									
									 @Action int = null
									 ) as
begin
	declare @LastDepartmentId int,@NewStatus int
	if @Action = 1		
		begin
			select @LastDepartmentId = max(DepartmentId)+1 from Department;
			select @NewStatus = 0;

			insert into Department(DepartmentId,DepartmentName,Status,CreateBy,CreateDate,MakeBy,MakeDate)
			values (@LastDepartmentId,@DepartmentName,@NewStatus,@UserId,getdate(),null,null);
		end
if(@Action = 2)
begin 
Update Department Set DepartmentName =@DepartmentName Where DepartmentId =@DepartmentId
end
if(@Action = 3)
begin 
Delete Department Where DepartmentId =@DepartmentId
end
end
