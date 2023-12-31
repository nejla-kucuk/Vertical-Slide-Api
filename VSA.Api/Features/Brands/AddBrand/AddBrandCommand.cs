using MediatR;


namespace VSA.Api.Features.Brands.AddBrand
{
    public class AddBrandCommand : IRequest<AddBrandResponse>
    {
        public string Name { get; set; }

        public string DisplayText { get; set; }

        public string Address { get; set; }
    }

}
