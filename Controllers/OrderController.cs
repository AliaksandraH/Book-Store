using Microsoft.AspNetCore.Mvc;
using Shop.Data.interfaces;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    public class OrderController : Controller
    {
        private readonly IAllOrders allOrders;
        private readonly ShopCart shopCart;

        public OrderController(IAllOrders allOrders, ShopCart shopCart)
        {
            this.allOrders = allOrders;
            this.shopCart = shopCart;
        }

        // dla html(aby pobrać dane za strony - IActionResult)
        public IActionResult Checkout()
        {
            shopCart.listShopItems = shopCart.getShopItems();
            // czy w koszyku są jakieś zakupy
            if (shopCart.listShopItems.Count() == 0)
            {
                // Error
                //ModelState.AddModelError("", "Nie masz książek w koszyku!");
                return RedirectToAction("CompleteError");
            }
            return View();
        }

        // wysłać dane, metodą POST, podczas naciskania przycisku
        [HttpPost]
        public IActionResult Checkout(Order order)
        {

            // poprawne wypełnienie inputs
            if (ModelState.IsValid)
            {
                allOrders.createOrder(order);
                return RedirectToAction("Complete");
            } 

            return View(order);
        }

        public IActionResult Complete()
        {
            shopCart.RemoveToCart();
            ViewBag.Message = "Zamówienie złożone";
            return View();
        }

        public IActionResult CompleteError()
        {
            ViewBag.Message = "Nie masz książek w koszyku!";
            return View();
        }
    }
}
