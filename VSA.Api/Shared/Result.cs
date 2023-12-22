using static System.Runtime.InteropServices.JavaScript.JSType;

namespace VSA.Api.Shared
{
    public class Result<T>
    {
        protected internal Result(bool isSuccess, Error error) { 
        
            if (isSuccess && error != Error.none)
            {
                throw new InvalidOperationException();
            }

            if (!isSuccess && error == Error.none)
            {
                throw new InvalidOperationException();
            }

            IsSuccess = isSuccess;
            Error = error;
        }

        public bool IsSuccess { get; }

        public bool isFailure => !IsSuccess;

        public Error Error { get; }

        internal Result<T1> Failure<T1>(Error error)
        {
            throw new NotImplementedException();
        }
    }
}
