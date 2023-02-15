﻿using Microsoft.AspNetCore.Mvc;
using Shop.Data.interfaces;
using Shop.Data.Models;
using Shop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    public class ShopCartController : Controller
    {
        private IAllBooks _bookRep;
        private readonly ShopCart _shopCart;
        public ShopCartController(IAllBooks bookRep, ShopCart shopCart)
        {
            _bookRep = bookRep;
            _shopCart = shopCart;
        }

        // dla html(szablon strony)
        public ViewResult Index()
        {
            var items = _shopCart.getShopItems();
            _shopCart.listShopItems = items;

            var obj = new ShopCartViewModel
            {
                shopCart = _shopCart
            };

            return View(obj);
        }

        // dla html(przekierować na inną strone)
        public RedirectToActionResult addToCart(int id)
        {
            var item = _bookRep.Books.FirstOrDefault(i => i.id == id);
            if (item != null)
            {
                _shopCart.AddToCart(item);
            }
            return RedirectToAction("Index");
        }

    }
}
