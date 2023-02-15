using Microsoft.AspNetCore.Mvc;
using Shop.Data.interfaces;
using Shop.Data.Models;
using Shop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// Dla pracy z html ("zmienia typ")
namespace Shop.Controllers
{
    public class BooksController : Controller
    {
        private readonly IAllBooks _allBooks;
        private readonly IAddBook _addBook;
        private readonly IBooksCategory _allCategories;

        public BooksController(IAllBooks iAllBooks, IAddBook iaddBook, IBooksCategory iBooksCategory)
        {
            _allBooks = iAllBooks;
            _addBook = iaddBook;
            _allCategories = iBooksCategory;
        }

        // Lista wszystkich książek
        // Lista książek według kategorii
        [Route("Books/List")]
        [Route("Books/List/{category}")]
        public ViewResult List(string category)
        {
            string _category = category;
            IEnumerable<Book> books = null;
            string currCategory = "";
            if (string.IsNullOrEmpty(category))
            {
                books = _allBooks.Books.OrderBy(i=>i.id);
            } else {
                if (string.Equals("biography", category, StringComparison.OrdinalIgnoreCase)) {
                    books = _allBooks.Books.Where(i => i.Category.categoryName.Equals("Biografie")).OrderBy(i => i.id);
                    currCategory = "Biografie";
                } 
                else if (string.Equals("forChildren", category, StringComparison.OrdinalIgnoreCase))
                {
                    books = _allBooks.Books.Where(i => i.Category.categoryName.Equals("Dla dzieci")).OrderBy(i => i.id);
                    currCategory = "Dla dzieci";
                } 
                else if (string.Equals("history", category, StringComparison.OrdinalIgnoreCase))
                {
                    books = _allBooks.Books.Where(i => i.Category.categoryName.Equals("Historia")).OrderBy(i => i.id);
                    currCategory = "Historia";
                } 
                else if (string.Equals("comics", category, StringComparison.OrdinalIgnoreCase))
                {
                    books = _allBooks.Books.Where(i => i.Category.categoryName.Equals("Komiks")).OrderBy(i => i.id);
                    currCategory = "Komiks";
                }
                else if (string.Equals("crimeSensationThriller", category, StringComparison.OrdinalIgnoreCase))
                {
                    books = _allBooks.Books.Where(i => i.Category.categoryName.Equals("Kryminał, sensacja, thriller")).OrderBy(i => i.id);
                    currCategory = "Kryminał, sensacja, thriller";
                }
                else if (string.Equals("kitchenDiet", category, StringComparison.OrdinalIgnoreCase))
                {
                    books = _allBooks.Books.Where(i => i.Category.categoryName.Equals("Kuchnia i diety")).OrderBy(i => i.id);
                    currCategory = "Kuchnia i diety";
                }
                else if (string.Equals("literatureTraditional", category, StringComparison.OrdinalIgnoreCase))
                {
                    books = _allBooks.Books.Where(i => i.Category.categoryName.Equals("Literatura obyczajowa")).OrderBy(i => i.id);
                    currCategory = "Literatura obyczajowa";
                }
                else if (string.Equals("literatureBeautifulForeign", category, StringComparison.OrdinalIgnoreCase))
                {
                    books = _allBooks.Books.Where(i => i.Category.categoryName.Equals("Literatura piękna obca")).OrderBy(i => i.id);
                    currCategory = "Literatura piękna obca";
                }
                else if (string.Equals("lliteratureBeautifulPoland", category, StringComparison.OrdinalIgnoreCase))
                {
                    books = _allBooks.Books.Where(i => i.Category.categoryName.Equals("Lliteratura piękna polska")).OrderBy(i => i.id);
                    currCategory = "Lliteratura piękna polska";
                }
            }
            
            var bookObj = new BooksListViewModel
            {
                allBooks = books,
                currCategory = currCategory
            };

            ViewBag.Title = "Book";

            return View(bookObj);
        }

        // Strona z wypwłnianiem danych o książce
        public IActionResult AddBook()
        {
            return View();
        }

        // Strona z wypwłnianiem danych o książce po kliknięciu przycisku
        [HttpPost]
        public IActionResult AddBook(Book book)
        {
            // poprawne wypełnienie inputs
            if (ModelState.IsValid)
            {
                // dodawanie książki do BD
                _addBook.createBook(book);
                return RedirectToAction("Complete");
            }
            return View(book);
        }

        public IActionResult Complete()
        {
            ViewBag.Message = "Książka dodana";
            return View();
        }
    }
}
