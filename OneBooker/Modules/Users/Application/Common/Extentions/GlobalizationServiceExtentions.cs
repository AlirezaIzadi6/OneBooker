using OneBooker.Shared.Services.Globalization;
using System.Globalization;

namespace OneBooker.Modules.Users.Application.Common.Extentions;

public static class GlobalizationServiceExtentions
{
    public static string NotFoundError(this IGlobalizationService globalizationService, string item)
    {
        return string.Format(
            CultureInfo.InvariantCulture,
            globalizationService.Localize(Messages.Messages.NotFound),
            item);
    }

    public static string InvalidInputError(this IGlobalizationService globalizationService, string item)
    {
        return string.Format(
            CultureInfo.InvariantCulture,
            globalizationService.Localize(Messages.Messages.InvalidInput),
            item);
    }
}