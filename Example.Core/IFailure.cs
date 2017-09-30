using System.Collections.Generic;

namespace Example.Core
{
    public interface IFailure : IResult
    {
        IReadOnlyList<ErrorMessage> ErrorMessages { get; }        
    }
}