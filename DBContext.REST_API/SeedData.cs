using Common.REST_API;
using Entities.REST_API;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBContext.REST_API
{
    public static class SeedData
    {
        public static readonly IEnumerable<Product> Products = new Product[]
        {
            new Product {
                ProductId = 1,
                ComputerTypeId = ProductType.Desktop.Id,
                ProcessorId = ProcessorType.i3.Id,
                BrandId = Brand.Dell.Id,
                USBPorts = 3,
                RamSlots = 4,
                Quantity = 100,
                Description = "Added the Desktop product through Seeding"
            },
            new Product {
                ProductId = 2,
                ComputerTypeId = ProductType.Laptop.Id,
                ProcessorId = ProcessorType.i5.Id,
                BrandId = Brand.HP.Id,
                USBPorts = 3,
                RamSlots = 2,
                Quantity = 50,
                Description = "Added the Laptop product through Seeding"
            }
        };

        public static readonly IEnumerable<ProductDesktop> Desktops = new ProductDesktop[]
        {
           new ProductDesktop
                {
                    Id = 1,
                    ProductId =1,
                    FormFactorId = FormFactor.MidTower.Id
                }

        };

        public static readonly IEnumerable<ProductLaptop> Laptops = new ProductLaptop[]
        {
           new ProductLaptop
                {
                    Id = 2,
                    ProductId =2,
                    ScreenSize = 15
                }

        };
    }
}
