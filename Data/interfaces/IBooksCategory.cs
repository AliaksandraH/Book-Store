using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.interfaces
{
    public interface IBooksCategory
    {
        // zwraca wszystke categorys 
        IEnumerable<Category> AllCategories { get; }
    }
}
