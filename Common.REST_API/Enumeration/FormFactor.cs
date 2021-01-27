namespace Common.REST_API
{
    public class FormFactor : Enumeration
    {

        public static readonly FormFactor MidTower = new FormFactor(1, "MidTower");
        public static readonly FormFactor Tower = new FormFactor(2, "Tower");
        
        public FormFactor(int id, string name) : base(id, name)
        {
        }
    }
}
