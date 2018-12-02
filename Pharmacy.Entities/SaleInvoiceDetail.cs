using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pharmacy.Entities
{
    public class SaleInvoiceDetail
    {
        public int SaleInvoiceDetailCode { get; set; }
        public int SaleInvoiceCode { get; set; }
        public int ProductCode { get; set; }
        public int Qty { get; set; }
        public decimal Rate { get; set; }
        public decimal Total { get; set; }
    }
}
