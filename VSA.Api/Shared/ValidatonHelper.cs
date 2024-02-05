using FluentValidation;


namespace VSA.Api.Shared
{
    public class ValidationHelper
    {
        private readonly IValidator _validator;

        public ValidationHelper(IValidator validator)
        {
            _validator = validator;
        }

        public void ValidateAndThrow<T>(T request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request), "Request object cannot be null.");
            }

            var validationRequest = _validator.Validate((IValidationContext)request);
            if (!validationRequest.IsValid)
            {
                throw new ErrorException(
                    $"{typeof(T).Name}.Validation",
                    "Values are not valid.");
            }
        }
    }
}
