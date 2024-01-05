using FluentValidation;
using MediatR;
using VSA.Api.Entities;
using VSA.Api.Infrastructure.Database;
using VSA.Api.Shared;

namespace VSA.Api.Features.Instrument.AddInstrument
{
    public class AddInstrumentCommand : IRequest<AddInstrumentResponse>
    {
        public Guid BrandId { get; set; }

        public string Model { get; set; }

        public string Color { get; set; }

        public DateTime? ProductionYear { get; set; }

        public decimal Price { get; set; }

    }

}
