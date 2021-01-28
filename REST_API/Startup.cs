using System;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Business.REST_API;
using Common.REST_API;
using Infrastructure.REST_API;
using ViewModels.REST_API;
using REST_API.Mapper;
using DBContext.REST_API;
using Microsoft.EntityFrameworkCore;
using Repository.REST_API;

namespace REST_API
{
    //Add Entity Framework Core code to get data from the database instead of the 3rd party API
    //Add Serilog, versioning, health check, 

    //If this were the real application, I would use No SQL DB to save the products in the database,
    //That way I don't need to create multiple tables to store the values. 
    //I could simply create 1 document, seperated by partition key
    //I would use SQL server for transaction data and Cosmos DB for storing the inventory records
    public class Startup
    {
        private readonly string localApis = "_localApis";
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddOptions();
            services.AddDbContext<DataContext>();
            services.Configure<AppSettings>(Configuration);
            services.AddApplicationInsightsTelemetry(Configuration);
            //services.AddHttpClientServices(Configuration);
            services.AddControllers();

            #region Swagger
            services.AddSwaggerGen();
            #endregion

            //services.AddAutoMapper(typeof(Startup));
            //services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddAutoMapper(typeof(ProductMapper).Assembly);

            #region DI
            services.AddTransient<ProductsResponse>();
            services.AddTransient<ProductResponse>();
            //services.AddTransient(typeof(ProductResponse<>));
            //services.AddTransient<IProductBusiness<>, ProductBusiness<>>();

            services.AddTransient<IProductBusiness, ProductBusiness>(); //This is parent class
            services.AddTransient<IProductBusiness, DesktopProductBusiness>(); //This is child class
            services.AddTransient<IProductBusiness, LaptopProductBusiness>();

            //services.AddTransient(typeof(IProductBusiness<,>), typeof(ProductBusiness<,>)); //This is parent class
            //services.AddTransient(typeof(DesktopProductBusiness<,>)); //This is child class

            services.AddTransient<IProductRepository, ProductRepository>();
            //services.AddTransient(typeof(IProductBaseRepository<>), typeof(ProductBaseRepository<>));
            #endregion

            //Add other urls here
            services.AddCors(o => o.AddPolicy(localApis, builder =>
            {
                builder.WithOrigins(
                        "http://localhost:4200")
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DataContext context)
        {
            app.UseCors(localApis);

            if (env.IsDevelopment())
            {
                //migrate database changes on startup (includes initial db creation)
                //apply migrations programmatically
                //If you are not running the Update-Database command on Package Manager Console
                //It should not be on Production
                context.Database.Migrate();

                app.UseDeveloperExceptionPage();

                #region Add Swagger only in Development mode

                app.UseSwagger();

                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Rhipe API");
                });
                #endregion
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
