using VSA.Api.Common;

namespace VSA.Api.Entities
{
    public class Brand : EntityBase<Guid>
    { 

        public string Name { get; set; } = string.Empty;

        public string DisplayText { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public List<Instruments> Instruments { get; set; } = new List<Instruments>();
    }
}
