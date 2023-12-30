namespace VSA.Api.Features.Brands.GetAllBrand
{
    public class GetAllBrandResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string DisplayText { get; set; }

        public string Address { get; set; }

        public DateTime CreatedOnUtc { get; set; }
    }
}
