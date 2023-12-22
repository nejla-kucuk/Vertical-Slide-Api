using System.Diagnostics.Metrics;

namespace VSA.Api.Contracts
{
    public class BrandResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string DisplayText { get; set; }

        public string Address { get; set; }

        public DateTime CreatedOnUtc { get; set; }

        public List<Instrument> Instruments { get; set; }

    }
}
