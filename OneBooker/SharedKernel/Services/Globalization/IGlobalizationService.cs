namespace OneBooker.SharedKernel.Services.Globalization;

public interface IGlobalizationService
{
    string Localize<TMessage>(TMessage message);
}