using PayRoll.Core.BLL.Interface;
using PayRoll.Core.DAL.Interface;
using PayRoll.Core.Model;
using PayRoll.Core.Utility.DBManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PayRoll.Core.BLL.Interface
{
    public class UserRoleManager : IUserRoleManager
    {
        private readonly DBContext _dbContext;
        private readonly IUserRoleRepository _iUserRoleRepository;

        public UserRoleManager()
        {
            _dbContext = new DBContext(DatabaseConfiguration.ConnectionString);
            _iUserRoleRepository = new UserRoleRepository(_dbContext);
        }

        public Message CreateOrUpdate(UserRole userRole, int create)
        {            
            var message = new Message();
            try
            {
                _dbContext.Open();
                _iUserRoleRepository.CreateOrUpdate(userRole, create);
                message = Message.SetMessages.SetSuccessMessage("User Role Created Successfully.");

            }
            catch (Exception ex)
            {
                message = Message.SetMessages.SetErrorMessage(ex.Message);
            }
            finally
            {
                _dbContext.Close();
            }
            return message;
        }

        public Message Delete(UserRole userRole)
        {

            var message = new Message();
            try
            {
                _dbContext.Open();
                _iUserRoleRepository.Delete(userRole);
                message = Message.SetMessages.SetSuccessMessage("User Role Deleted Successfully.");

            }
            catch (Exception ex)
            {
                message = Message.SetMessages.SetErrorMessage(ex.Message);
            }
            finally
            {
                _dbContext.Close();
            }
            return message;
        }


        public string GenerateRoleId()
        {
            string roleId = String.Empty;
            try
            {
                _dbContext.Open();
                roleId = _iUserRoleRepository.GenerateRoleId();
            }
            catch (Exception ex)
            {
                roleId = String.Empty;
            }
            finally
            {
                _dbContext.Close();
            }
            return roleId;
        }


        public UserRole GetARole(string roleId)
        {
            try
            {
                _dbContext.Open();
                var role = _iUserRoleRepository.GetARole(roleId);
                return role;
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

        public IEnumerable<UserRole> GetRoles()
        {            
            try
            {
                _dbContext.Open();
                var roles = _iUserRoleRepository.GetRoles();
                return roles;
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


        public IEnumerable<SelectListItem> GetAllRoles()
        {
           
            try
            {
                _dbContext.Open();
                var units = _iUserRoleRepository.GetRoles().Select(
                    o => new SelectListItem
                    {
                        Value = o.RoleId,
                        Text = o.RoleName
                    }).ToList();
                return units;
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
    }
}
