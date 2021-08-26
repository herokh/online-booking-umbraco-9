using Microsoft.Extensions.DependencyInjection;
using OnlineBooking.Application.Contracts;
using OnlineBooking.Application.Services;
using OnlineBooking.Hangfire.Contexts;
using OnlineBooking.Hangfire.Contexts.Contracts;
using OnlineBooking.Hangfire.Jobs;
using OnlineBooking.Hangfire.Jobs.Contracts;
using Umbraco.Cms.Core.DependencyInjection;

namespace OnlineBooking.Hangfire.Extensions
{
    public static class ConfigServiceCollectionExtensions
    {

        public static IUmbracoBuilder AddDependencyGroup(this IUmbracoBuilder umbracoBuilder)
        {
            umbracoBuilder.Services.AddTransient<IEmailService, EmailService>();
            umbracoBuilder.Services.AddTransient<IEmailTemplateService, EmailTemplateService>();

            umbracoBuilder.Services.AddScoped<IVaccineRegistrationEmailJob, VaccineRegistrationEmailJob>();

            return umbracoBuilder;
        }

        public static IServiceCollection AddDependencyGroup(this IServiceCollection services)
        {
            services.AddTransient<IBackgroundJobContext, BackgroundJobContext>();

            return services;
        }

    }
}

