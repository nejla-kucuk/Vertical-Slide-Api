namespace VSA.Api.Features.Brands.DeleteBrand
{
    public record DeleteBrandResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string DisplayText { get; set; }

        public string Address { get; set; }

    }
}
