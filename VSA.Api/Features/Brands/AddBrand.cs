using Carter;
using FluentValidation;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Reflection;
using VSA.Api.Contracts;
using VSA.Api.Database;
using VSA.Api.Entities;
using VSA.Api.Features.Brands;
using VSA.Api.Shared;

namespace VSA.Api.Features.Brands
{
    public static class AddBrand
    {
        public class Command : IRequest<Result<Guid>>
        {
            public string Name { get; set; }

            public string DisplayText { get; set; }

            public string Address { get; set; }
        }

        public class Validator : AbstractValidator<Command>
        {
            public Validator() {

                RuleFor(x => x.Name).NotEmpty();
                RuleFor(x => x.DisplayText).NotEmpty();
                RuleFor(x => x.Address).NotEmpty();
            }
        }
        internal sealed class Handler : IRequestHandler<Command, Result<Guid>>
        {
            private readonly AppDbContext _dbContext;
            private readonly IValidator<Command> _validator;

            public Handler(AppDbContext dbContext, IValidator<Command> validator)
            {
                _dbContext = dbContext;
                _validator = validator;
            }

            public async Task<Result<Guid>> Handle(Command request, CancellationToken cancellationToken)
            {
                var validationRequest = _validator.Validate(request);
                if(!validationRequest.IsValid)
                {
                    return Result.Failure<Guid>(new Error(
                        "AddBrand.Validaion", 
                        validationResult.ToString()));
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

                return brand.Id;
            }
        }

    }
}

public class AddBrandEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("api/brands", async (AddBrandRequest request, ISender sender) =>
        {
            var command = request.Adapt<AddBrand.Command>();
            
            /*
            new AddBrand.Command
            {
                Name = request.Name,
                DisplayText = request.DisplayText,
                Address = request.Address
               };
            */

            var result = await sender.Send(command);

            if (result.IsFailure)
            {
                return Results.BadRequest(result.Error);
            }

            return Results.Ok(result.Value);
        });
    }
}
