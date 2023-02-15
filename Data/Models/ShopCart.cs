using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Models
{
    public class ShopCart
    {
        // dla BD
        private readonly AppDBContent appDBContent;
        public ShopCart(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public string ShopCartId { get; set; }
        public List<ShopCartItem> listShopItems { get; set; }

        
        // były podukty w koszyku wcześniej
        public static ShopCart GetCart(IServiceProvider services)
        {
            // aby utworzyć sesję
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDBContent>();
            // sprawdzeie 
            string shopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", shopCartId);
            return new ShopCart(context) { ShopCartId = shopCartId };
        }

        // dodawanie produktów do koszyka
        public void AddToCart(Book book)
        {
            appDBContent.ShopCartItem.Add(new ShopCartItem
            {
                ShopCartId = ShopCartId,
                book = book,
                price = book.price
            });

            appDBContent.SaveChanges();
        }

        public void RemoveToCart()
        {
            //var comp = appDBContent.ShopCartItem.LastOrDefault();
            var count = appDBContent.ShopCartItem.Where(o => o.ShopCartId == ShopCartId).Count();
            for (int i=0; i < count; i++)
            {
                ShopCartItem comp = appDBContent.ShopCartItem.Where(o => o.ShopCartId == ShopCartId).FirstOrDefault();
                appDBContent.ShopCartItem.Remove(comp);
                appDBContent.SaveChanges();
            }                        
        }

        // pokazuje produkty w koszyku
        public List<ShopCartItem> getShopItems()
        {
            return appDBContent.ShopCartItem.Where(c => c.ShopCartId == ShopCartId).Include(s => s.book).ToList();
        }
    }
}
