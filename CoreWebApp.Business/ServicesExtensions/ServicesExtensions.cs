using CoreWebApp.Business.Implementations;
using CoreWebApp.Business.Interfaces;
using CoreWebApp.Repository.BaseRepository;
using CoreWebApp.Repository.BaseRepository.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CoreWebApp.Business.ServicesExtensions
{
    public static class ServicesExtensions
    {

        /// <summary>
        /// Adds my library services.
        /// </summary>
        /// <param name="services">The services.</param>
        public static void AddMyLibraryServices(this IServiceCollection services)
        {
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IPropertyService, PropertyService>();
            services.AddScoped<ISalesService, SalesService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

        }
    }
}
