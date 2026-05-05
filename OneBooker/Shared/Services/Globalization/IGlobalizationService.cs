namespace OneBooker.Shared.Services.Globalization;

public interface IGlobalizationService
{
    string Localize<TMessage>(TMessage message);
}