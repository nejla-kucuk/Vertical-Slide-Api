using FluentValidation;
using MediatR;
using VSA.Api.Database;
using VSA.Api.Entities;
using VSA.Api.Shared;


namespace VSA.Api.Features.Brands.AddBrand
{
    public class AddBrandCommand : IRequest<AddBrandResponse>
    {
        public string Name { get; set; }

        public string DisplayText { get; set; }

        public string Address { get; set; }
    }

}
