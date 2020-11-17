using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebShop.Models;
using WebShop.Finance;

namespace WebShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UpdateCartButter()
        {

            int currentAmount = 1;

            if (!HttpContext.Session.GetInt32("cartButter").HasValue)
            {

                HttpContext.Session.SetInt32("cartButter", 1);
            }
            else
            {
                currentAmount = HttpContext.Session.GetInt32("cartButter").Value;
                ++currentAmount;
                HttpContext.Session.SetInt32("cartButter", currentAmount);
            }

            return View("Index");
        }

        public IActionResult UpdateCartBread()
        {

            int currentAmount = 1;

            if (!HttpContext.Session.GetInt32("cartBread").HasValue)
            {

                HttpContext.Session.SetInt32("cartBread", 1);
            }
            else
            {
                currentAmount = HttpContext.Session.GetInt32("cartBread").Value;
                ++currentAmount;
                HttpContext.Session.SetInt32("cartBread", currentAmount);
            }

            return View("Index");
        }

        public IActionResult UpdateCartMilk()
        {

            int currentAmount = 1;

            if (!HttpContext.Session.GetInt32("cartMilk").HasValue)
            {

                HttpContext.Session.SetInt32("cartMilk", 1);
            }
            else
            {
                currentAmount = HttpContext.Session.GetInt32("cartMilk").Value;
                ++currentAmount;
                HttpContext.Session.SetInt32("cartMilk", currentAmount);
            }

            return View("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Cart(Calculations calculations)
        {
            Products products = new Products();
            if (HttpContext.Session.GetInt32("cartButter") != null)
            {
                products.ButterQuantity = HttpContext.Session.GetInt32("cartButter").Value;
                CartData cartData = new CartData
                {
                    ProductName = ProductNames.Butter,
                    Quantitiy = products.ButterQuantity
                };
                products.PriceButter = Math.Round(calculations.CalculatePrice(cartData).ProductPrice, 2);
            }

            if (HttpContext.Session.GetInt32("cartMilk") != null)
            {
                products.MilkQuantity = HttpContext.Session.GetInt32("cartMilk").Value;
                CartData cartData = new CartData()
                {
                    ProductName = ProductNames.Milk,
                    Quantitiy = products.MilkQuantity
                };

                products.PriceMilk = Math.Round(calculations.CalculatePrice(cartData).ProductPrice, 2);
                products.DiscountMilk = calculations.CalculatePrice(cartData).DiscountAmount * 100;
                products.MilkDiscountQuantity = calculations.CalculatePrice(cartData).DiscountQuantity;

            }
            //Isključi autentifikaciju i ostale stvari.
            if (HttpContext.Session.GetInt32("cartBread") != null)
            {
                products.BreadQuantity = HttpContext.Session.GetInt32("cartBread").Value;

                CartData cartData = new CartData()
                {
                    ProductName = ProductNames.Bread,
                    Quantitiy = products.BreadQuantity,
                    ButterQuantity = products.ButterQuantity
                };

                if (products.ButterQuantity >= 2)
                {
                    cartData.RelatedProduct = ProductNames.Butter;
                    calculations.CalculatePrice(cartData);
                    products.PriceBread = Math.Round(calculations.CalculatePrice(cartData).ProductPrice, 2);
                    products.DiscountBread = calculations.CalculatePrice(cartData).DiscountAmount * 100;
                    products.BreadDiscountQuantity = calculations.CalculatePrice(cartData).DiscountQuantity;
                }
                else
                {
                    products.PriceBread = Math.Round(calculations.CalculatePrice(cartData).ProductPrice, 2);
                }
            }

            products.Subtotal = Math.Round(products.PriceButter + products.PriceMilk + products.PriceBread, 3);

            return View("Cart", products);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
