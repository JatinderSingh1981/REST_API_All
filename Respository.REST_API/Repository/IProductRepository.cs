using Entities.REST_API;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repository.REST_API
{
    public interface IProductBaseRepository<T> where T : class
    {
        Task<IEnumerable<Product>> GetProductList();
        Task<T> GetProduct(Expression<Func<T, bool>> predicate, bool includeProduct = true);
        Task<T> AddProduct(T product);

    }

    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<T> GetProduct<T>(Expression<Func<T, bool>> predicate) where T : class;
        Task<T> AddProduct<T>(T product) where T : class;

        //Task<T> GetProductById<T>(int productId);
        //Task<T> AddProduct<T>(T product);
    }
}
