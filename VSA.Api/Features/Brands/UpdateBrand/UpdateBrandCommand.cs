using FluentValidation;
using MediatR;
using VSA.Api.Database;
using VSA.Api.Shared;

namespace VSA.Api.Features.Brands.UpdateBrand
{
    public class UpdateBrandCommand : IRequest<UpdateBrandResponse>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string DisplayText { get; set; }

        public string Address { get; set; }
    }

 

}
