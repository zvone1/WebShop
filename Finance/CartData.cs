using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.Finance
{
    public class CartData
    {
        public int Quantitiy { get; set; }
        public string ProductName { get; set; }
        public string RelatedProduct { get; set; }
        public double ProductPrice { get; set; }
        public double DiscountPrice { get; set; }
        public int DiscountQuantity { get; set; }
        public double DiscountAmount { get; set; }
        public double DiscountPercent { get; set; }
        public int ButterQuantity { get; set; }
    }
}
