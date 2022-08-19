using PayRoll.Core.BLL.Interface;
using PayRoll.Core.DAL.Interface;
using PayRoll.Core.DAL.Repository;
using PayRoll.Core.Model;
using PayRoll.Core.Utility.DBManager;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PayRoll.Core.BLL.Interface
{
    public class CommonManager : ICommonManager
    {
        private readonly DBContext _dbContext;
        private readonly ICommonRepository _iCommonRepository;
       

        public CommonManager()
        {
            _dbContext = new DBContext(DatabaseConfiguration.ConnectionString);
            _iCommonRepository = new CommonRepository(_dbContext);
        }


        public UserStatus GetAStatus(string statusId)
        {
            try
            {
                _dbContext.Open();
                var statuse = _iCommonRepository.GetAStatus(statusId);
                return statuse;
            }
            catch
            {
                return null;

            }
            finally
            {
                _dbContext.Close();
            }
        }

        public Object GetEmployeeBasicInfo(string EmployeeId) 
        {
            try
            {
                _dbContext.Open();
                DataTable statuse = _iCommonRepository.GetEmployeeBasicInfo(EmployeeId);
                dynamic employeeBasicInfo = new System.Dynamic.ExpandoObject();
                employeeBasicInfo.EmployeeName = statuse.Rows[0]["Name"].ToString();
                return employeeBasicInfo;
            }
            catch (Exception)
            {
                return null;
            }
            finally 
            {
                _dbContext.Close();
            }
        
        }


        public Permission GetScreenWisePermission(string screenCode)
        {
            try
            {
                _dbContext.Open();
                var statuse = _iCommonRepository.GetScreenWisePermission(screenCode);
                return statuse;
            }
            catch
            {
                return null;

            }
            finally
            {
                _dbContext.Close();
            }
        }


        public string GetServerDate()
        {
            try
            {
                _dbContext.Open();
                var date = _iCommonRepository.GetServerDate();
                return DateTime.Parse( date).ToString("dd-MMM-yyyy");
            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                _dbContext.Close();
            
            }
        
        
        }

        public IEnumerable<SelectListItem> GetUserStatuses()
        {
            try
            {
                _dbContext.Open();
                var ustatuses = _iCommonRepository.GetUserStatuses().Select(
                    o => new SelectListItem
                    {
                        Value = o.StatusId,
                        Text = o.StatusName
                    }).ToList();
                return ustatuses;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                _dbContext.Close();
            }
        }

       



       




       

      


        public IEnumerable<SelectListItem> GetMonthsOfYear()
        {
            string[] months = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            var monthsYear = months.Select((r, index) => new SelectListItem
            {
                Text = r,
                Value = (index + 1).ToString()
            }).ToList();
            return monthsYear;
        }

        public IEnumerable<SelectListItem> GetAllMaritalStatus()
        {
            string[] maStatus = { "Single", "Married", "Divorce" };
            var maritalStatus = maStatus.Select((r, index) => new SelectListItem
            {
                Text = r,
                Value = (index + 1).ToString()
            }).ToList();
            return maritalStatus;
        }


        public IEnumerable<RoleWiseScreenPermission> GetModules(string roleId)
        {
            try
            {
                _dbContext.Open();
                var screens = _iCommonRepository.GetModules(roleId);
                return screens;
            }
            catch
            {
                return null;
            }
            finally
            {
                _dbContext.Close();
            }

        }

      
       


        public IEnumerable<RoleWiseScreenPermission> GetSubModules(string roleId, string parentScreenId)
        {
            try
            {
                _dbContext.Open();
                var screens = _iCommonRepository.GetSubModules(roleId, parentScreenId);
                return screens;
            }
            catch
            {
                return null;
            }
            finally
            {
                _dbContext.Close();
            }


        }

        public IEnumerable<DDLSourceModel> GetDDlist(DDLSourceModel sourceModel)
        {
            try
            {
                DataTable dataTable = new DataTable();
                List<DDLSourceModel> sourceModelsList = new List<DDLSourceModel>();

                dataTable = _iCommonRepository.GetDDlist(sourceModel);
                sourceModelsList = (from DataRow dr in dataTable.Rows
                                    select new DDLSourceModel
                                    {
                                        Key = dr.ItemArray[0].ToString(),
                                        Value = dr.ItemArray[1].ToString()
                                    }).ToList();


                return sourceModelsList;
            }
            catch
            {
                return null;
            }
            finally
            {

            }
        }
    }
}
