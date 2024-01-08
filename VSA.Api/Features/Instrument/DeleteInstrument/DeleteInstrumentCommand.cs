using MediatR;

namespace VSA.Api.Features.Instrument.DeleteInstrument
{
    public class DeleteInstrumentCommand: IRequest<DeleteInstrumentResponse>
    {
        public Guid Id { get; set; }
    }
}
