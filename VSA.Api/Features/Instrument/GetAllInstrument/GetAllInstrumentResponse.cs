using VSA.Api.Entities;

namespace VSA.Api.Features.Instrument.GetAllInstrument
{
    public record GetAllInstrumentResponse
    {
        public Guid BrandId { get; set; }

        public string BrandName { get; set; } = string.Empty;

        public string BrandDisplayText { get; set; } = string.Empty;

        public string BrandAddress { get; set; } = string.Empty;


        public string Model { get; set; } = string.Empty;


        public string Color { get; set; } = string.Empty;


        public DateTime? ProductionYear { get; set; }


        public decimal Price { get; set; }
    }
}
