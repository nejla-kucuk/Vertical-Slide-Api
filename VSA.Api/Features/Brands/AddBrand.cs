using Carter;
using FluentValidation;
using Mapster;
using MediatR;
using System.Net;
using System.Reflection;
using VSA.Api.Contracts;
using VSA.Api.Database;
using VSA.Api.Entities;
using VSA.Api.Shared;

namespace VSA.Api.Features.Brands
{
    public static class AddBrand
    {
        public class Command : IRequest<BrandResponse>
        { 

            public string Name { get; set; }

            public string DisplayText { get; set; }

            public string Address { get; set; }
        }


        public class Validator : AbstractValidator<Command>
        {
            public Validator()
            {

                RuleFor(x => x.Name).NotEmpty();
                RuleFor(x => x.DisplayText).NotEmpty();
                RuleFor(x => x.Address).NotEmpty();
            }
        }

        internal sealed class Handler : IRequestHandler<Command, BrandResponse>
        {
            private readonly AppDbContext _dbContext;
            private readonly IValidator<Command> _validator;

            public Handler(AppDbContext dbContext, IValidator<Command> validator)
            {
                _dbContext = dbContext;
                _validator = validator;
            }

            public async Task<BrandResponse> Handle(Command request, CancellationToken cancellationToken)
            {
                var validationRequest = _validator.Validate(request);
                if (!validationRequest.IsValid)
                {
                    throw new ErrorException(
                        "AddBrand.Validaion",
                        "Values are not empty.");
                }

                var brand = new Brand
                {
                    Id = Guid.NewGuid(),
                    Name = request.Name,
                    DisplayText = request.DisplayText,
                    Address = request.Address,
                    CreatedOn = DateTime.UtcNow
                };

                _dbContext.Add(brand);

                await _dbContext.SaveChangesAsync(cancellationToken);

                var brandResponse = new BrandResponse
                {
                    Id = brand.Id
                };

                return brandResponse;
            }

        }
    }

}
