namespace Common.REST_API
{
    public class ProcessorType : Enumeration
    {

        public static readonly ProcessorType i3 = new ProcessorType(1, "i3");
        public static readonly ProcessorType i5 = new ProcessorType(2, "i5");
        public static readonly ProcessorType i7 = new ProcessorType(3, "i7");
        public static readonly ProcessorType i9 = new ProcessorType(4, "i9");

        public ProcessorType(int id, string name) : base(id, name)
        {
        }
    }
}
