using ViewModels.REST_API;
using System.Threading.Tasks;
using Models.REST_API;

namespace Business.REST_API
{
    public interface IProductBusiness<T, S> where T : Product where S : class
    {
        Task<ProductsResponse> GetProducts();
        Task<ProductResponse<T>> GetProductById(int productId);
        Task<ProductResponse<T>> AddProduct(T model);
        
    }
}
