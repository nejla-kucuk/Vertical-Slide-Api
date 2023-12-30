using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VSA.Api.Database;
using VSA.Api.Shared;

namespace VSA.Api.Features.Brands.GetBrandById
{
    public class GetBrandByIdQ : IRequest<GetBrandByIdModelResponse>
    {
        public Guid Id { get; set; }
    }

}
