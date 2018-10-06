using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalXML
{
    [Serializable]
    public class SUNATRetentionInformation
    {
        public PayableAmount SUNATRetentionAmount { get; set; }
        public string SUNATRetentionDate { get; set; }
        public PayableAmount SUNATNetTotalPaid { get; set; }
        public ExchangeRate ExchangeRate { get; set; }

        public SUNATRetentionInformation()
        {
            SUNATRetentionAmount = new PayableAmount();
            SUNATNetTotalPaid = new PayableAmount();
            ExchangeRate = new ExchangeRate();
        }
    }
}
