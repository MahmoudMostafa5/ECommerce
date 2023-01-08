using Ecommerce.BLL;
using Ecommerce.BLL.Interfaces;
using Ecommerce.BLL.Repository;
using Ecommerce.DAL.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            //Connection String
            services.AddDbContextPool<ProductContext>(opts =>
            opts.UseSqlServer(Configuration.GetConnectionString("ConnecStr")));
            //Dependancies
            services.AddScoped<IProductRep, ProductRep>();

            services.AddScoped<IOrderRep, OrderRep>();

            services.AddScoped<ICustomerRep, CustomerRep>();

            services.AddScoped<IOrderProductRep, OrderProductRep>();

            services.AddScoped<ICityRep, CityRep>();
            services.AddScoped<ICountryRep, CountryRep>();
            services.AddScoped<IDistrictRep, DistrictRep>();
            services.AddScoped<ISupplierRep, SupllierRep>();

            //Identity
            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<ProductContext>()
                .AddTokenProvider<DataProtectorTokenProvider<IdentityUser>>(TokenOptions.DefaultProvider);
            
            //password Pattern
            services.Configure<IdentityOptions>(options =>
            {
                // Default Password settings.
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;
            });

            //Auto Mapper
            services.AddAutoMapper(x => x.AddProfile(new DomainProfile()));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
