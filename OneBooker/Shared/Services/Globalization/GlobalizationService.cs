using Microsoft.Extensions.Localization;

namespace OneBooker.Shared.Services.Globalization;

public class GlobalizationService(IStringLocalizerFactory localizerFactory) : IGlobalizationService
{
    public string Localize<TMessage>(TMessage message)
    {
        Type messageType = typeof(TMessage);

        IStringLocalizer localizer = localizerFactory.Create(messageType);
        string key = message.ToString();

        return localizer.GetString(key);
    }
}