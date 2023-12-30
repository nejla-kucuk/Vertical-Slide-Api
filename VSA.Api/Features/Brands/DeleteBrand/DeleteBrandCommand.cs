using MediatR;

namespace VSA.Api.Features.Brands.DeleteBrand
{
    public class DeleteBrandCommand : IRequest<DeleteBrandResponse>
    {
        public Guid Id { get; set; }
    }
}
