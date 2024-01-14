namespace VSA.Api.Shared
{
    public class ErrorException : Exception
    {

        public string Code { get; }


        public ErrorException(string code, string message) : base(message)
        {
            Code = code;
          
        }

       

        private ErrorException()
        {
           
        }
    }
}
