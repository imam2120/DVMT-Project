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
    public class DesignationManager : IDesignationManager
    {
        private readonly DBContext _dbContext;
        private readonly IDesignationRepository _iDesignationRepository;
        public DesignationManager()
        {
            _dbContext = new DBContext(DatabaseConfiguration.ConnectionString);
            _iDesignationRepository = new DesignationRepository(_dbContext);
        }


        public IEnumerable<Designation> GetDesignation()
        {
            try
            {
                _dbContext.Open();
                var users = _iDesignationRepository.GetDesignation();
                return users;
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

        public Designation GetADesignation(string designationid)
        {
            try
            {
                _dbContext.Open();
                var userStatus = _iDesignationRepository.GetADesignation(designationid);
                return userStatus;
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
        public Message CreateOrUpdate(Designation designation, int create)
        {
            var message = new Message();
            try
            {
                _dbContext.Open();
                _iDesignationRepository.CreateOrUpdate(designation, create);
                message = Message.SetMessages.SetSuccessMessage("Designation Created Successfully");
            }
            catch (Exception ex)
            {
                message = Message.SetMessages.SetErrorMessage("Error in Creating Designation" + ex.Message);
            }
            finally
            {
                _dbContext.Close();
            }

            return message;
        }
        public Message Delete(string designationid)
        {
            var message = new Message();
            try
            {
                _dbContext.Open();
                _iDesignationRepository.Delete(designationid);
                message = Message.SetMessages.SetSuccessMessage("Designation Deleted Successfully");
            }
            catch (Exception ex)
            {
                message = Message.SetMessages.SetErrorMessage("Error in Deleting Designation" + ex.Message);
            }
            finally
            {
                _dbContext.Close();
            }

            return message;
        }


    }
}
