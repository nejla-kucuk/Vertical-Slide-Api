namespace VSA.Api.Features.Instrument.DeleteInstrument
{
    public class DeleteInstrumentResponse
    {
        public Guid BrandId { get; set; } 

        public string Model { get; set; } = string.Empty;

        public string Color { get; set; } = string.Empty;

        public DateTime? ProductionYear { get; set; }

        public decimal Price { get; set; }
    }
}
