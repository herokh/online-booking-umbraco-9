using FluentValidation;
using Newtonsoft.Json;
using OnlineBooking.Application.Constants;
using OnlineBooking.Application.Contracts;
using OnlineBooking.Application.Extensions;
using OnlineBooking.Application.Validators;
using OnlineBooking.ViewModel.Forms;
using System;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Services;
using Umbraco.Extensions;

namespace OnlineBooking.Application.Services
{
    public class VaccineRegistrationService : IVaccineRegistrationService
    {
        private readonly IContentService _contentService;
        private readonly IVariationContextAccessor _variationContextAccessor;
        public VaccineRegistrationService(IContentService contentService,
            IVariationContextAccessor variationContextAccessor)
        {
            _contentService = contentService;
            _variationContextAccessor = variationContextAccessor;
        }

        public void Register(VaccineRegistrationView vaccineRegistrationView, IPublishedContent publishedContent)
        {
            new VaccineRegistrationValidator()
                .ValidateAndThrow(vaccineRegistrationView);

            var contentAtRoot = publishedContent.Root();
            var formSettings = contentAtRoot.GetFormSettingsNode(DocumentPropertyAliases.FormMappingsVaccineRegistration, _variationContextAccessor);
            var savedFormDataNode = formSettings.GetPropertyValue<IPublishedContent>(DocumentPropertyAliases.FormSavedFormData);

            // save data as content node
            var savedFormData = _contentService.Create($"{vaccineRegistrationView.LastName}_{vaccineRegistrationView.FirstName}", savedFormDataNode.Key, DocumentTypeAliases.FormData);
            var jsonFormData = JsonConvert.SerializeObject(vaccineRegistrationView, Formatting.Indented);
            savedFormData.SetValue(DocumentPropertyAliases.FormDataValues, $"_{jsonFormData}");
            savedFormData.SetValue(DocumentPropertyAliases.FormDataCreatedAt, DateTime.UtcNow);
            _contentService.SaveAndPublish(savedFormData);
        }
    }
}
