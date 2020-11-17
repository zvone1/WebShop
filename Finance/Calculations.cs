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
        /// <param name="cartData.ProductName">Type of the product.</param>
        /// <param name="cartData.CartTotal">Amount of certain product as INT</param>
        /// <returns></returns>
        //public double CalculatePrice(string cartData.ProductName, int cartData.CartTotal, string relatedProduct = "")
        public CartData CalculatePrice(CartData cartData)
        {

            if (cartData.ProductName.Equals(ProductNames.Butter))
            {

                cartData.ProductPrice = cartData.Quantitiy * ProductsPrices.Butter;
            }

            if (cartData.ProductName.Equals(ProductNames.Milk))
            {
                if (cartData.ProductName.Equals(ProductNames.Milk) && cartData.Quantitiy > 3)
                {
                    int freeProducts = cartData.Quantitiy / 3;
                    double discountedPrice = 0;

                    if (cartData.Quantitiy != 0)
                    {
                        cartData.DiscountQuantity = freeProducts;
                        cartData.DiscountAmount = Discounts.Milk;
                    }

                    int payedProducts = cartData.Quantitiy - freeProducts;
                    cartData.ProductPrice = (ProductsPrices.Milk * payedProducts) + discountedPrice;
                }
                else
                {
                    cartData.ProductPrice = cartData.Quantitiy * ProductsPrices.Milk;
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

                if (discountActive.Equals(ProductNames.Butter))
                {
                    int freeProducts = cartData.ButterQuantity / 2;
                    int standardProducts = cartData.Quantitiy / 2;
                    double discountedPrice = 0;
                    if (freeProducts != 0)
                    {
                        double standardPrice = 0;
                        discountedPrice = freeProducts * ProductsPrices.Bread * Discounts.Bread;
                        if (standardProducts != 0)
                        {
                            standardPrice = (cartData.Quantitiy - freeProducts) * ProductsPrices.Bread;
                        }

                        cartData.ProductPrice = standardPrice + discountedPrice;
                        cartData.DiscountQuantity = freeProducts;

                        return cartData;
                    }
                    else
                    {
                        discountedPrice = 1 * ProductsPrices.Bread * Discounts.Bread;
                        int fullPrice = cartData.Quantitiy - 1;
                        cartData.ProductPrice = (ProductsPrices.Bread * fullPrice) + discountedPrice;
                    }
                }
                else
                {
                    cartData.ProductPrice = cartData.Quantitiy * ProductsPrices.Bread;
                }
            }

            return cartData;
        }
    }
}
