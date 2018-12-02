using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pharmacy.Entities
{
    public class SaleInvoice
    {
        public int SaleInvoiceCode { get; set; }
        public string CustomerName { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal GrandTotal { get; set; }
    }
}
