using MediatR;

namespace VSA.Api.Contracts
{
    public class AddBrandRequest : IRequest<BrandResponse>
    { 
       
        public string Name { get; set; }

        public string DisplayText { get; set; }

        public string Address { get; set; }
       
    }
}
