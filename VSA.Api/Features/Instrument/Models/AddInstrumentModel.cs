namespace VSA.Api.Features.Instrument.Models
{
    public class AddInstrumentModel
    {
        public Guid BrandId { get; set; }

        public string Model { get; set; }

        public string Color { get; set; }

        public DateTime? ProductionYear { get; set; }

        public decimal Price { get; set; }
    }
}
