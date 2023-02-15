using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Models
{
    public class OrderDetail
    {
        public int id { get; set; }
        public int orderId { get; set; }
        public int BookId { get; set; }
        public double price { get; set; }
        public virtual Book book { get; set; }
        public virtual Order order { get; set; }
    }
}
