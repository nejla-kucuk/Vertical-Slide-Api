using Carter;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using static VSA.Api.Features.Brands.AddBrand;

namespace VSA.Api
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Carter'ı ekleyin (Eğer eklenmemişse)
            services.AddCarter();

            // FluentValidation'ı ekleyin (Eğer eklenmemişse)
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            // MediatR'ı ekleyin
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddMediatR(typeof(AddBrandRequestHandler).Assembly);



        }
    }
}
