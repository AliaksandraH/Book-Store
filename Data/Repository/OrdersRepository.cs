using Shop.Data.interfaces;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Repository
{
    public class OrdersRepository : IAllOrders
    {
        // dla BD
        private readonly AppDBContent appDBContent;
        // dla ShopCart
        private readonly ShopCart shopCart;

        public OrdersRepository(AppDBContent appDBContent, ShopCart shopCart)
        {
            this.appDBContent = appDBContent;
            this.shopCart = shopCart;

        }
        public void createOrder(Order order)
        {
            order.orderTime = DateTime.Now;
            appDBContent.Order.Add(order);
            appDBContent.SaveChanges();

            var items = shopCart.getShopItems();
            foreach(var el in items)
            {
                var orderDetail = new OrderDetail()
                {
                    orderId = order.id,
                    BookId = el.book.id,                    
                    price = el.book.price
                };
                appDBContent.OrderDetail.Add(orderDetail);
            }
            appDBContent.SaveChanges();
        }
    }
}
