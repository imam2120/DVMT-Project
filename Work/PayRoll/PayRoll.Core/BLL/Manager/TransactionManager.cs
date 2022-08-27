using PayRoll.Core.BLL.Interface;
using PayRoll.Core.DAL.Interface;
using PayRoll.Core.Utility.DBManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayRoll.Core.BLL.Manager
{
    public class TransactionManager : ITransactionManager
    {
        private readonly ITransactionRepository _ITransactionRepository;
        private readonly DBContext _dbContext;
    }
}
