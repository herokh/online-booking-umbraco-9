using OnlineBooking.Application.Contracts;
using OnlineBooking.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace OnlineBooking.Extensions
{
    public static class ConfigServiceCollectionExtensions
    {
        public static IServiceCollection AddDependencyGroup(this IServiceCollection services)
        {
            RegisterApplicationServices(services);

            return services;
        }

        private static void RegisterApplicationServices(IServiceCollection services)
        {
            services.AddTransient<IHeaderService, HeaderService>();
            services.AddTransient<IFooterService, FooterService>();
            services.AddTransient<INewsService, NewsService>();
            services.AddTransient<IVaccineRegistrationService, VaccineRegistrationService>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<IEmailTemplateService, EmailTemplateService>();
            services.AddTransient<IChatbotService, ChatbotService>();
            services.AddTransient<IFlightSearchService, FlightSearchService>();
        }
    }
}
