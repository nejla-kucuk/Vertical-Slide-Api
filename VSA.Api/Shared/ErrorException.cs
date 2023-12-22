namespace VSA.Api.Shared
{
    public class ErrorException : Exception
    {

        public string Code { get; }


        public ErrorException(string code, string message) : base(message)
        {
            Code = code;
          
        }

        public static ErrorException NotFound(string code, string resourceName)
        {
            return new ErrorException(code, $"{resourceName} not found.");
        }

        private ErrorException()
        {
           
        }
    }
}
