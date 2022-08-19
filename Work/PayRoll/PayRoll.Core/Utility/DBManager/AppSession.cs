using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayRoll.Core.Utility.DBManager
{
    public  class AppSession
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string UserRoleId { get; set; }
        public string UserStatus { get; set; }
        public string UserTenancyId { set; get; }
        public string UserTenancyName { set; get; }
        public string UserTenancyAddress { set; get; }

    }
}
