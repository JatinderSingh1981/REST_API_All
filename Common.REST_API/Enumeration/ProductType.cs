namespace Common.REST_API
{
    public class ProductType : Enumeration
    {

        public static readonly ProductType Desktop = new ProductType(1, "Desktop");
        public static readonly ProductType Laptop = new ProductType(2, "Laptop");

        public ProductType(int id, string name) : base(id, name)
        {
        }
    }
}
