using Microsoft.Extensions.Localization;
using OneBooker.SharedKernel.ServiceRegistration.Interfaces;

namespace OneBooker.SharedKernel.Services.Globalization;

public class GlobalizationService(IStringLocalizerFactory localizerFactory) : IGlobalizationService, ISingletonService
{
    public string Localize<TMessage>(TMessage message)
    {
        Type messageType = typeof(TMessage);

        IStringLocalizer localizer = localizerFactory.Create(messageType);
        string key = message.ToString();

        return localizer.GetString(key);
    }
}