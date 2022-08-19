using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayRoll.Core.Model
{
   public class DDLSourceModel
    {
        public string SPName
        {
            get;
            set;
        }

        public Dictionary<string, string> Params
        {
            get;
            set;
        }

        public string Key
        {
            get;
            set;
        }
        public string Value
        {
            get;
            set;
        }
        public InputParameter inputParameter { get; set; }

    }
}
