using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shop.Data;
using Shop.Data.interfaces;
using Shop.Data.mocks;
using Shop.Data.Models;
using Shop.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop
{
    public class Startup
    {
        // dla BD
        private IConfigurationRoot _confString;
        public Startup(Microsoft.AspNetCore.Hosting.IHostingEnvironment hostEnv)
        {
            // dla pobrania danych z dbsettings
            _confString = new ConfigurationBuilder().SetBasePath(hostEnv.ContentRootPath).AddJsonFile("dbsettings.json").Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDBContent>(options => options.UseSqlServer(_confString.GetConnectionString("DefaultConnection")));
            //interfaces + mock
            //services.AddTransient<IAllBooks, MockBooks>();
            //services.AddTransient<IBooksCategory, MockCategory>();
            //interfaces + Repository
            services.AddTransient<IAllBooks, BookRepository>();
            services.AddTransient<IAddBook, BookRepository>();
            services.AddTransient<IBooksCategory, CategoryRepository>();
            services.AddTransient<IAllOrders, OrdersRepository>();
            services.AddRazorPages();
            // dla session
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            // różne koszyki dla różnych użytkowników (session)
            services.AddScoped(sp => ShopCart.GetCart(sp));
            services.AddMvc(option => option.EnableEndpointRouting = false);
            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // strona z błędami
            app.UseDeveloperExceptionPage();
            // pokazuje kod strony
            app.UseStatusCodePages();
            // połąnczenie Static Files
            app.UseStaticFiles();
            // dla session
            app.UseSession();
            // dla połąnczenie url domyślego jażeli nie mamy innego
            //app.UseMvcWithDefaultRoute();

            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute(name: "categoryFilter", template: "Books/{action}/{category?}", defaults: new { Controller = "Books", action = "List" });
            });

            using (var scope = app.ApplicationServices.CreateScope())
            {
                AppDBContent content = scope.ServiceProvider.GetRequiredService<AppDBContent>();
                DBObjects.initial(content);
            }

        }
    }
}
