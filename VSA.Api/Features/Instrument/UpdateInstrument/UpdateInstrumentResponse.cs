namespace VSA.Api.Features.Instrument.UpdateInstrument
{
    public record UpdateInstrumentResponse
    {
        public Guid BrandId { get; set; } = Guid.Empty;

        public string Model { get; set; } = string.Empty;

        public string Color { get; set; } = string.Empty;

        public DateTime? ProductionYear { get; set; }

        public decimal Price { get; set; }
    }
}
