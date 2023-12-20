using VSA.Api.Common;

namespace VSA.Api.Entities
{
    public class Instrument : EntityBase<Guid>
    {
        
        public Brand Brand { get; set; } //Entity

        public string Model { get; set; }

        public string Color { get; set; }

        public DateTime? ProductionYear { get; set; }

        public decimal Price { get; set; }
    }
}
