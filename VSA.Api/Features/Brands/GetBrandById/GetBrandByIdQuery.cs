using MediatR;


namespace VSA.Api.Features.Brands.GetBrandById
{
    public class GetBrandByIdQ : IRequest<GetBrandByIdModelResponse>
    {
        public Guid Id { get; set; }
    }

}
