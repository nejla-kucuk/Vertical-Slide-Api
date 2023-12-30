using VSA.Api.Common;

namespace VSA.Api.Entities
{
    public class Instruments : EntityBase<Guid>
    {
        
        public Brand Brand { get; set; } = new Brand();

        public Guid BrandId { get; set; } = Guid.Empty;

        public string Model { get; set; } = string.Empty;

        public string Color { get; set; } = string.Empty;

        public DateTime? ProductionYear { get; set; } 

        public decimal Price { get; set; }
    }
}
