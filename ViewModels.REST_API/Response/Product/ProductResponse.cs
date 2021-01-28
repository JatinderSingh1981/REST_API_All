using Models.REST_API;

namespace ViewModels.REST_API
{
    public class ProductResponse
    {
        public Product Product { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
