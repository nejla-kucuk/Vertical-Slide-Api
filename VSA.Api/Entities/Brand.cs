using VSA.Api.Common;

namespace VSA.Api.Entities
{
    public class Brand : EntityBase<Guid>
    { 

        public string Name { get; set; }

        public string DisplayText { get; set; }

        public string Address { get; set; }

        public List<Instruments> Instruments { get; set; }
    }
}
