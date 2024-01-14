using VSA.Api.Entities;

namespace VSA.Api.Features.Brands.GetAllBrand
{
    public class GetAllBrandResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string DisplayText { get; set; }

        public string Address { get; set; }

        public DateTime CreatedOnUtc { get; set; }

        public string InstrumentModel { get; set; }
        public string InstrumentColor { get; set; }
        public DateTime? InstrumentProductionYear { get; set; }
        public decimal InstrumentPrice { get; set; }
    }
}
