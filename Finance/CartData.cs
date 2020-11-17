using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.Finance
{
    /// <summary>
    /// Data for carts.
    /// </summary>
    public class CartData
    {
        public int Quantity { get; set; }
        public string ProductName { get; set; }
        public string RelatedProduct { get; set; }
        public double ProductPrice { get; set; }
        public int DiscountQuantity { get; set; }
        public double DiscountAmount { get; set; }
        public int ButterQuantity { get; set; }
    }
}
