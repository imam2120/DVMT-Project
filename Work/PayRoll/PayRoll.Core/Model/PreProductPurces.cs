using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayRoll.Core.Model
{
   public class PreProductPurces
    {
		public string TransNo { get; set; }
		public string ProductAccNo { get; set; }
		public double OpeningBalance { get; set; }
		public double PurcesAmount { get; set; }
		public double ClosingBalance { get; set; }
		public double ByCashAmount { get; set; }
		public double ByBankAmount { get; set; }
		public double DueAmount { get; set; }
		public string SupAccNo { get; set; }
		public double SupDueAmount { get; set; }
		public double SupCurrBalance { get; set; }
	}
}
