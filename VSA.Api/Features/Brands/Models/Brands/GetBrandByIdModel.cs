using VSA.Api.Entities;

namespace VSA.Api.Features.Brands.Models.Brands
{
    public class GetBrandByIdModel
    {
        public string Name { get; set; }

        public string DisplayText { get; set; }

        public string Address { get; set; }

        public DateTime CreatedOnUtc { get; set; }

        // List<Instrument> Instruments { get; set; }
    }
}
