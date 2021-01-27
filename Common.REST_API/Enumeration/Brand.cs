namespace Common.REST_API
{
    public class Brand : Enumeration
    {

        public static readonly Brand HP = new Brand(1, "HP");
        public static readonly Brand Dell = new Brand(2, "Dell");
        public static readonly Brand Lenovo = new Brand(3, "Lenovo");
        public static readonly Brand Microsoft = new Brand(4, "Microsoft");

        public Brand(int id, string name) : base(id, name)
        {
        }
    }
}
