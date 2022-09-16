using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PayRoll.Core.Utility.DBManager
{
    public class OperationType
    {
        public static int ActionType(int operationType)
        {
            int ActionType = 0;

            if (operationType == 1)
            {
                ActionType = 1;
            }
            else if (operationType == 2)
            {
                ActionType = 2;
            }
            else if (operationType == 3)
            {
                ActionType = 3;
            }

            return ActionType;
        }
    }
}
