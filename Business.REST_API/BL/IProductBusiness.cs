using ViewModels.REST_API;
using System.Threading.Tasks;
using Models.REST_API;

namespace Business.REST_API
{
    public interface IProductBusiness
    {
        Task<ProductsResponse> GetProducts();
        Task<ProductResponse> GetProductById<T>(int ProductId) where T : class;
        Task<ProductResponse> AddProduct<T>(T model) where T : class;

        //Task<ProductResponse<T>> GetProductById<T>(int ProductId) where T : Product;
        //Task<ProductResponse<T>> AddProduct<T>(T model) where T : Product;
    }
}
