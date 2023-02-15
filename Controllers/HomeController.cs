using Microsoft.AspNetCore.Mvc;
using Shop.Data.interfaces;
using Shop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    public class HomeController : Controller
    {
        private IAllBooks _bookRep;
        public HomeController(IAllBooks bookRep)
        {
            _bookRep = bookRep;
        }

        public ViewResult Index()
        {
            var homeBooks = new HomeViewModel
            {
                Books = _bookRep.Books
            };
            return View(homeBooks);
        }
    }
}
