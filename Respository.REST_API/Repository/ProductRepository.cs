using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Common.REST_API;
using Entities.REST_API;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using DBContext.REST_API;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;

namespace Repository.REST_API
{
    public class ProductBaseRepository<T> : IProductBaseRepository<T> where T : class
    {
        private readonly DataContext _context;
        private readonly ILogger<ProductBaseRepository<T>> _logger;
        public ProductBaseRepository(DataContext context, IOptions<AppSettings> settings,
            ILogger<ProductBaseRepository<T>> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<Product>> GetProductList()
        {
            _logger.LogDebug("[GetProductList] -> Getting products list from DB");
            return await _context.Products.ToListAsync();

        }
        //public async Task<IEnumerable<T>> GetProductList<T>() where T : class
        //{
        //    return await _context.Set<T>().ToListAsync();
        //}
        public async Task<T> GetProduct(Expression<Func<T, bool>> predicate, bool includeProduct = true)
        {
            if (includeProduct)
                return await _context.Set<T>().Include("Product").FirstOrDefaultAsync(predicate);
            else
                return await _context.Set<T>().FirstOrDefaultAsync(predicate);
        }

        public async Task<T> AddProduct(T product)
        {
            await _context.Set<T>().AddAsync(product); //.Include("Product")
            var id = await _context.SaveChangesAsync();
            return await _context.Set<T>().FindAsync(id);
            //return GetProduct<T>(x => x. == id);
        }
    }

    //public class ProductDesktopRepository : ProductBaseRepository<ProductDesktop>
    //{
    //    private readonly DataContext _context;
    //    private readonly ILogger<ProductBaseRepository<ProductDesktop>> _logger;
    //    public ProductDesktopRepository(DataContext context, IOptions<AppSettings> settings,
    //        ILogger<ProductBaseRepository<ProductDesktop>> logger) : base(context, settings, logger)
    //    {
    //        _context = context;
    //        _logger = logger;
    //    }

    //}

    //public class ProductLaptopRepository : ProductBaseRepository<ProductLaptop>
    //{
    //    private readonly DataContext _context;
    //    private readonly ILogger<ProductBaseRepository<ProductLaptop>> _logger;
    //    public ProductLaptopRepository(DataContext context, IOptions<AppSettings> settings,
    //        ILogger<ProductBaseRepository<ProductLaptop>> logger) : base(context, settings, logger)
    //    {
    //        _context = context;
    //        _logger = logger;
    //    }

    //}

    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;
        private readonly ILogger<ProductRepository> _logger;

        public ProductRepository(DataContext context, IOptions<AppSettings> settings,
            ILogger<ProductRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            _logger.LogDebug("[GetProducts] -> Getting products list from DB");
            return await _context.Products.ToListAsync();

        }
        //public async Task<IEnumerable<T>> GetProductList<T>() where T : class
        //{
        //    return await _context.Set<T>().ToListAsync();
        //}
        public async Task<T> GetProduct<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return await _context.Set<T>().Include("Product").FirstOrDefaultAsync(predicate);
        }

        public async Task<T> AddProduct<T>(T product) where T : class
        {
            await _context.Set<T>().AddAsync(product); //.Include("Product")
            var id = await _context.SaveChangesAsync();
            return await _context.Set<T>().FindAsync(id);
            //return GetProduct<T>(x => x. == id);
        }

        //public async Task<T> GetProductById<T>(int productId) where T : class
        //{
        //    return await _context.Set<T>().FindAsync(productId);
        //}
        //public async Task<T> AddProduct<T>(T product)
        //{

        //}
    }
}
