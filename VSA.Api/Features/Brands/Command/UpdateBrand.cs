using FluentValidation;
using MediatR;
using VSA.Api.Database;
using VSA.Api.Features.Brands.Models.Brands;

namespace VSA.Api.Features.Brands.Command
{
    public class UpdateBrand : IRequest<UpdateBrandModel>
    {
        public Guid Id { get; set; }
       
        public string Name { get; set; }

        public string DisplayText { get; set; }

        public string Address { get; set; }
    }

    public class UpdateBrandValidator : AbstractValidator<UpdateBrand>
    {
        public UpdateBrandValidator()
        {

            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.DisplayText).NotEmpty();
            RuleFor(x => x.Address).NotEmpty();
        }
    }

    public class UpdateBrandHandler : IRequestHandler<UpdateBrand, UpdateBrandModel>
    {
        private readonly AppDbContext _dbContext;
        private readonly IValidator<UpdateBrand> _validator;

        public UpdateBrandHandler(AppDbContext dbContext, IValidator<UpdateBrand> validator)
        {
            _dbContext = dbContext;
            _validator = validator;
        }

        public Task<UpdateBrandModel> Handle(UpdateBrand request, CancellationToken cancellationToken)
        {
            
        }
    }

}
