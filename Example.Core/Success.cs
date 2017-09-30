namespace Example.Core
{
    public class Success<T> : ISuccess
    {
        public T Result { get; }
        
        public Success(T result)
        {
            Result = result;
        }
    }
}