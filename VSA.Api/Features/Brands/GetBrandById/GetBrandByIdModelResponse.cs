using VSA.Api.Entities;

namespace VSA.Api.Features.Brands.GetBrandById
{
    public class GetBrandByIdModelResponse
    {
        public string Name { get; set; }

        public string DisplayText { get; set; }

        public string Address { get; set; }

        public DateTime CreatedOnUtc { get; set; }

        // List<Instrument> Instruments { get; set; }
    }
}
