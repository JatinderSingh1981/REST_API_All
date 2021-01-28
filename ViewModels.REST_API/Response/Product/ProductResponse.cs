using Models.REST_API;

namespace ViewModels.REST_API
{
    //public class ProductResponse<T> where T : Product
    //{
    //    public T Product { get; set; }
    //    public bool IsSuccess { get; set; }
    //    public string Message { get; set; }
    //}

    public class ProductResponse
    {
        public Product Product { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
