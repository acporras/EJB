using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalXML
{
    [Serializable]
    public class Payment
    {
        public string PaidDate { get; set; }
        public int IdPayment { get; set; }
        public PayableAmount PaidAmount { get; set; }

        public Payment()
        {
            PaidAmount = new PayableAmount();
        }
    }
}
