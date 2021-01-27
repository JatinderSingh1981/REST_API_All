using Entities.REST_API;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Common.REST_API;
using System;

namespace DBContext.REST_API
{
    public class DataContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductDesktop> Desktops { get; set; }
        public DbSet<ProductLaptop> Laptops { get; set; }

        private readonly IOptions<AppSettings> _settings;

        public DataContext(DbContextOptions<DataContext> contextOptions,
            IOptions<AppSettings> settings) : base(contextOptions)
        {
            _settings = settings;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Log the queries to console
            optionsBuilder.LogTo(Console.WriteLine);

            // connect to sqlite database
            optionsBuilder
                .EnableSensitiveDataLogging()
                .UseSqlite(
                _settings.Value.ConnectionStrings.RestApiDatabase);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            //The above line is not required

            //This will default the schema from dbo to defaultschema
            //modelBuilder.HasDefaultSchema("defaultschema");

            ///** Enums **/
            modelBuilder.Entity<ProductType>().HasData(Enumeration.GetAll<ProductType>());
            modelBuilder.Entity<ProcessorType>().HasData(Enumeration.GetAll<ProcessorType>());
            modelBuilder.Entity<FormFactor>().HasData(Enumeration.GetAll<FormFactor>());
            modelBuilder.Entity<Brand>().HasData(Enumeration.GetAll<Brand>());

            ///** Seed Product, ProductDesktop, ProductLaptop **/
            modelBuilder.Entity<Product>()
                .HasData(SeedData.Products);
            modelBuilder.Entity<ProductDesktop>()
                .HasData(SeedData.Desktops);
            modelBuilder.Entity<ProductLaptop>()
                .HasData(SeedData.Laptops);
           
            

        }
    }
}
