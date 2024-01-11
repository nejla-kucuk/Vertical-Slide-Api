using MediatR;

namespace VSA.Api.Features.Instrument.UpdateInstrument
{
    public class UpdateInstrumentCommand : IRequest<UpdateInstrumentResponse>
    { 
        public Guid Id { get; set; }

        public Guid BrandId { get; set; } = Guid.Empty;

        public string Model { get; set; } = string.Empty;

        public string Color { get; set; } = string.Empty;

        public DateTime? ProductionYear { get; set; }

        public decimal Price { get; set; }
    }
}
