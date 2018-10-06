using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace FinalXML
{
    public class SummaryDocumentsLine
    {
        public int LineID { get; set; }
        public string DocumentTypeCode { get; set; }
        public string ID { get; set; }
        public string NumeroDocumento { get; set; }
        // A partir de aqui son los datos para el resumen diario.
        public AccountingCustomerParty AccountingCustomerParty { get; set; }
        public Status Status { get; set; }
        public PayableAmount TotalAmount { get; set; }
        public List<BillingPayment> BillingPayments { get; set; }
        public AllowanceCharge AllowanceCharge { get; set; }
        public List<TaxTotal> TaxTotals { get; set; }

        public SummaryDocumentsLine()
        {
            TotalAmount = new PayableAmount();
            BillingPayments = new List<BillingPayment>();
            AllowanceCharge = new AllowanceCharge();
            TaxTotals = new List<TaxTotal>();
        }
    }
}
