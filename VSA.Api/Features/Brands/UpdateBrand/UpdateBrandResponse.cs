namespace VSA.Api.Features.Brands.UpdateBrand
{
    public record UpdateBrandResponse
    {

        public string Name { get; set; }

        public string DisplayText { get; set; }

        public string Address { get; set; }
    }
}
