using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayRoll.Core.Model
{
    public class EmployeeInfo
    {
        public string EmployeeId { get; set; }
        public string GLAccountNo { get; set; }
        public string FatherName { get; set; }
        public string EmployeeCode { get; set; }
        public string EmployeeName { get; set; }
        public string MotherName { get; set; }
        public string PresentAddress { get; set; }
        public string PermanentAddress { get; set; }
        public string GenderId { get; set; }
        public string DateOfBirth { get; set; }
        public string ContractNumber { get; set; }
        public string EmergencyNumber { get; set; }
        public string BloodGroup { get; set; }
        public string NationalId { get; set; }
        public string BirthDayRegNo { get; set; }
        public string MaritalStatus { get; set; }
        public string DeptId { get; set; }
        public string DesignationId { get; set; }
        public string JoiningDate { get; set; }
        public string JoiningType { get; set; }
        public string StatusId { get; set; }
        public string Image { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string ModifyBy { get; set; }
        public string ModifyDate { get; set; }
        //public string UserId { get; set; }        
        public static EmployeeInfo ConvertToModel(DataRow row)
        {
            return new EmployeeInfo
            {
                EmployeeId = row.Table.Columns.Contains("EmployeeId") ? Convert.ToString(row["EmployeeId"]) : "",
                EmployeeCode = row.Table.Columns.Contains("EmployeeCode") ? Convert.ToString(row["EmployeeCode"]) : "",
                EmployeeName = row.Table.Columns.Contains("EmployeeName") ? Convert.ToString(row["EmployeeName"]) : "",
                GLAccountNo = row.Table.Columns.Contains("GLAccountNo") ? Convert.ToString(row["GLAccountNo"]) : "",
                FatherName = row.Table.Columns.Contains("FatherName") ? Convert.ToString(row["FatherName"]) : "",
                MotherName = row.Table.Columns.Contains("MotherName") ? Convert.ToString(row["MotherName"]) : "",
                PresentAddress = row.Table.Columns.Contains("PresentAddress") ? Convert.ToString(row["PresentAddress"]) : "",
                PermanentAddress = row.Table.Columns.Contains("PermanentAddress") ? Convert.ToString(row["PermanentAddress"]) : "",
                GenderId = row.Table.Columns.Contains("GenderId") ? Convert.ToString(row["GenderId"]) : "",
                DateOfBirth = row.Table.Columns.Contains("DOB") ? Convert.ToString(row["DOB"]) : "",
                ContractNumber = row.Table.Columns.Contains("ContractNumber") ? Convert.ToString(row["ContractNumber"]) : "",
                EmergencyNumber = row.Table.Columns.Contains("EmergencyNumber") ? Convert.ToString(row["EmergencyNumber"]) : "",
                BloodGroup = row.Table.Columns.Contains("BloodGroup") ? Convert.ToString(row["BloodGroup"]) : "",
                NationalId = row.Table.Columns.Contains("NationalId") ? Convert.ToString(row["NationalId"]) : "",
                MaritalStatus = row.Table.Columns.Contains("MaritalStatus") ? Convert.ToString(row["MaritalStatus"]) : "",
                DeptId = row.Table.Columns.Contains("DeptId") ? Convert.ToString(row["DeptId"]) : "",
                DesignationId = row.Table.Columns.Contains("DesignationId") ? Convert.ToString(row["DesignationId"]) : "",
                JoiningDate = row.Table.Columns.Contains("JoiningDate") ? Convert.ToString(row["JoiningDate"]) : "",
                JoiningType = row.Table.Columns.Contains("JoiningType") ? Convert.ToString(row["JoiningType"]) : "",
                StatusId = row.Table.Columns.Contains("StatusId") ? Convert.ToString(row["StatusId"]) : "",
                Image = row.Table.Columns.Contains("Image") ? Convert.ToString(row["Image"]) : "",
                CreatedBy = row.Table.Columns.Contains("CreatedBy") ? Convert.ToString(row["CreatedBy"]) : "",
                CreatedDate = row.Table.Columns.Contains("CreatedDate") ? Convert.ToString(row["CreatedDate"]) : "",
                ModifyBy = row.Table.Columns.Contains("ModifyBy") ? Convert.ToString(row["ModifyBy"]) : "",
                ModifyDate = row.Table.Columns.Contains("ModifyDate") ? Convert.ToString(row["ModifyDate"]) : "",
                //UserId = row.Table.Columns.Contains("UserId") ? Convert.ToString(row["UserId"]) : "",
            };

        }
    }
}
