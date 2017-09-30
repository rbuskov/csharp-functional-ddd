using System.Collections.Generic;

namespace Example.Core
{
    public class Failure : IFailure
    {
        private readonly List<ErrorMessage> errorMessages = new List<ErrorMessage>();

        public IReadOnlyList<ErrorMessage> ErrorMessages => errorMessages.AsReadOnly();

        public Failure(string message) : this (new ErrorMessage(message)) { }

        public Failure(ErrorMessage errorMessage)
        {
            errorMessages.Add(errorMessage);
        }

        public Failure(IEnumerable<ErrorMessage> errorMessages)
        {
            this.errorMessages.AddRange(errorMessages);
        }
        

        public static Failure Combine(IEnumerable<IResult> results)
        {
            var errorMessages = new List<ErrorMessage>();

            foreach (var result in results)
                if (result is Failure failure)
                    errorMessages.AddRange(failure.errorMessages);
            
            return new Failure(errorMessages);
        }
    }
}