using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Models
{
    public class ShopCartItem
    {
        public int id { get; set; }
        public Book book { get; set; }
        public double price { get; set; }
        // id produkru w koszyku
        public string ShopCartId { get; set; }
    }
}
