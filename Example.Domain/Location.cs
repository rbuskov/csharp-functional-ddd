namespace Example.Domain
{
    public class Location
    {
        public UnLocode UnLocode { get; }
        public string Name { get; }

        private Location(UnLocode unLocode, string name)
        {
            UnLocode = unLocode;
            Name = name;
        }
    }
}