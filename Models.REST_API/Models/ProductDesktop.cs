using Common.REST_API;

namespace Models.REST_API
{
    public class ProductDesktop : Product
    {
        public int Id { get; set; }
        public string FormFactor { get; set; }
        public int FormFactorId { get; set; }
    }
}
