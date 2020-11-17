using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Models;

namespace WebShop.Finance
{
    public class Calculations
    {
        /// <summary>
        /// Calculate price of products.
        /// </summary>
        /// <param name="cartData"></param>
        /// <returns></returns>
        public CartData CalculatePrice(CartData cartData)
        {

            if (cartData.ProductName.Equals(ProductNames.Butter))
            {

                cartData.ProductPrice = cartData.Quantity * ProductsPrices.Butter;
            }

            if (cartData.ProductName.Equals(ProductNames.Milk))
            {
                if (cartData.ProductName.Equals(ProductNames.Milk) && cartData.Quantity > 3)
                {
                    int freeProducts = cartData.Quantity / 3; //Calculate discount based on requested amount of "milk" product.
                    double discountedPrice = 0;

                    if (cartData.Quantity != 0)
                    {
                        cartData.DiscountQuantity = freeProducts;
                        cartData.DiscountAmount = Discounts.Milk;
                    }

                    int payedProducts = cartData.Quantity - freeProducts;
                    cartData.ProductPrice = (ProductsPrices.Milk * payedProducts) + discountedPrice;
                }
                else
                {
                    cartData.ProductPrice = cartData.Quantity * ProductsPrices.Milk;
                }

                return cartData;
            }

            if (cartData.ProductName.Equals(ProductNames.Bread))
            {
                string discountActive = "";

                if (cartData.RelatedProduct != null)
                {
                    discountActive = cartData.RelatedProduct;
                    cartData.DiscountAmount = Discounts.Bread;
                }

                //Apply discount for "bread" if "butter" is inside cart.
                if (discountActive.Equals(ProductNames.Butter)) //
                {
                    int freeProducts = cartData.ButterQuantity / 2;
                    int standardProducts = cartData.Quantity / 2;
                    double discountedPrice = 0;
                    if (freeProducts != 0)
                    {
                        double standardPrice = 0;
                        discountedPrice = freeProducts * ProductsPrices.Bread * Discounts.Bread;
                        if (standardProducts != 0)
                        {
                            standardPrice = (cartData.Quantity - freeProducts) * ProductsPrices.Bread;
                        }

                        cartData.ProductPrice = standardPrice + discountedPrice;
                        cartData.DiscountQuantity = freeProducts;

                        return cartData;
                    }
                    else
                    {
                        discountedPrice = 1 * ProductsPrices.Bread * Discounts.Bread;
                        int fullPrice = cartData.Quantity - 1;
                        cartData.ProductPrice = (ProductsPrices.Bread * fullPrice) + discountedPrice;
                    }
                }
                else
                {
                    cartData.ProductPrice = cartData.Quantity * ProductsPrices.Bread;
                }
            }

            return cartData;
        }
    }
}
