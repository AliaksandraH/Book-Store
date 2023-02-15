using Shop.Data.interfaces;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.mocks
{
    public class MockCategory : IBooksCategory
    {
        public IEnumerable<Category> AllCategories
        {
            get
            {
                return new List<Category>
                {
                    new Category { categoryName="Biografie"},
                    new Category { categoryName="Dla dzieci"},
                    new Category { categoryName="Historia"},
                    new Category { categoryName="Komiks"},
                    new Category { categoryName=" Kryminał, sensacja, thriller"},
                    new Category { categoryName="Kuchnia i diety"},
                    new Category { categoryName="Literatura obyczajowa"},
                    new Category { categoryName="Literatura piękna obca"},
                };
            }
        }
    }
}
