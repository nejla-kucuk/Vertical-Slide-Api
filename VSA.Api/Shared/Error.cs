namespace VSA.Api.Shared
{
    public class Error
    {
        public static Error None => new Error();

        public string Code { get; }

        public string Description { get; }

        public Error(string code, string description)
        {
            Code = code;
            Description = description;
        }

        private Error()
        {
            // Default constructor for Error.None
        }
    }
}
