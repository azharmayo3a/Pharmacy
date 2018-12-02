using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pharmacy.Entities
{
    public class Products
    {
        public int ProductCode { get; set; }
        public int CategoryCode { get; set; }
        public string ProductName { get; set; }
        public decimal PurchaseRate { get; set; }
        public decimal SaleRate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string ImageURL { get; set; }
    }
}
