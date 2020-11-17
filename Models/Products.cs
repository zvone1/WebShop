using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.Models
{
    public class Products
    {
        public int MilkQuantity { get; set; }
        public double PriceMilk { get; set; }

        public int BreadQuantity { get; set; }
        public double PriceBread { get; set; }

        public int ButterQuantity { get; set; }
        public double PriceButter { get; set; }

        public double Subtotal { get; set; }

        public double DiscountMilk { get; set; }
        public double DiscountBread { get; set; }
        public double DiscountButter { get; set; }


        public int MilkDiscountQuantity { get; set; }
        public int BreadDiscountQuantity { get; set; }

    }

}
