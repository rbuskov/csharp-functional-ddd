using System;

namespace Example.Core
{
    public class InvalidResultException : Exception
    {
        public object Result { get; }

        public override string Message => $"Invalid result '{Result}'.";
        
        public InvalidResultException(object result)
        {
            Result = result;
        }
    }
}