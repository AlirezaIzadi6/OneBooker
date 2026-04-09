namespace OneBooker.Shared.Responses;

public class ValidationResult
{
    public bool IsValid { get; set; }

    public string? ErrorMessage { get; set; }

    private ValidationResult(bool isValid, string? errorMessage)
    {
        IsValid = isValid;
        ErrorMessage = errorMessage;
    }

    public static ValidationResult Success => new(true, null);

    public static ValidationResult Fail(string message) => new(false, message);
}