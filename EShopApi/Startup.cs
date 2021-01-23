using EshopApi.Contracts;
using EShopApi.Models;
using EShopApi.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EShopApi
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //Add my Created scaffolding Context
            services.AddDbContext<EShopApi_DbContext>(Options=>
                Options.UseSqlServer("Data Source=.;Initial Catalog=EShopApi_Db;Integrated Security=True")
                );
            //if anyone want you a ICustomerRepository you give CustomerRepository
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<ISalesPersonsRepository, SalesPersonsRepository>();

            //Add system cashe to show data when we are offline
            services.AddResponseCaching();

            //let me use memory cashe in my controllers or injections
            services.AddMemoryCache();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseResponseCaching();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
