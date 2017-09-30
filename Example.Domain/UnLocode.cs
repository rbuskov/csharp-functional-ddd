using Example.Core;

namespace Example.Domain
{
    public struct UnLocode
    {
        public string Value { get; }

        private UnLocode(string value) => Value = value;
   
        public static IResult Create(string value)
        {
            switch (value?.Trim().ToUpper())
            {
                case null:
                    return new Failure("UnLocode must have a value.");
                case var s when s.Length != 5:
                    return new Failure("Invalid UnLocode '{s}'. UnLocode value must be 5 characters long.");
                case var s:  
                    return new Success<UnLocode>(new UnLocode(s));
            }
        }
    }
}