using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProductCatalog_Repositories.Contexts;
using ProductCatalog_Services.Contracts;
using ProductCatalog_Services;
using ProductCatolog_Core.Models;
using ProductCatalog_Repositories.UnitOfWork;
using ProductCatalog_Repositories.Contracts;
using ProductCatalog_Repositories;
using Microsoft.Extensions.Options;
using System.Drawing;

namespace ProductCatalog_Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<RepositoryContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("SqlConn"),
                    b => b.MigrationsAssembly("ProductCatalog-Repositories")).UseLazyLoadingProxies()
            );



            builder.Services.AddIdentity<Customer, IdentityRole>()
                .AddEntityFrameworkStores<RepositoryContext>()
                .AddDefaultTokenProviders();

            builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();

            builder.Services.AddScoped<IServiceManager, ServiceManager>();
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<IOrderService, OrderService>();

            builder.Services.AddAutoMapper(typeof(Program));

            builder.Services.AddDistributedMemoryCache();
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(10);
                options.Cookie.HttpOnly = true;
            });

            builder.WebHost.UseSentry(options =>
            options.ConfigureScope(scope =>
            {
                scope.Level = SentryLevel.Debug;
            })
            );


            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<RepositoryContext>();
                if (context.Database.CanConnect())
                    Console.WriteLine("\n\n-db connection SUCCESSFUL-\n\n");
                else
                    Console.WriteLine("\n\n-db connection FAILED-\n\n");
            }

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseSentryTracing();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseSession();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "Admin",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                );
            });

            app.Run();
        }
    }
}
