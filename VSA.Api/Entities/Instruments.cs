using VSA.Api.Common;

namespace VSA.Api.Entities
{
    public class Instruments : EntityBase<Guid>
    {
        
        public Brand Brand { get; set; } //Entity

        public Guid BrandId { get; set; }

        public string Model { get; set; }

        public string Color { get; set; }

        public DateTime? ProductionYear { get; set; }

        public decimal Price { get; set; }
    }
}
