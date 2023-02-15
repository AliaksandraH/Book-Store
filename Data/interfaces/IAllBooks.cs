using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.interfaces
{
    public interface IAllBooks
    {
        // zwraca wszystke towary 
        IEnumerable<Book> Books { get; }
        // zwraca towary których isFavourite -> true
        IEnumerable<Book> getFavBooks { get; }
        // zwraca towar po id
        Book getObjectBook(int bookId);
    }
}
