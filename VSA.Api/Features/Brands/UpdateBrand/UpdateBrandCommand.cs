using MediatR;


namespace VSA.Api.Features.Brands.UpdateBrand
{
    public class UpdateBrandCommand : IRequest<UpdateBrandResponse>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string DisplayText { get; set; }

        public string Address { get; set; }
    }

 

}
