namespace OneBooker.SharedKernel.Responses.ValidationResponse;

public class ValidationResult
{
    private ValidationResult(bool isValid, string errorMessage)
    {
        IsValid = isValid;
        ErrorMessage = errorMessage;
    }

    public bool IsValid { get; set; }

    public string ErrorMessage { get; set; }

    public static ValidationResult Success => new(true, null);

    public static ValidationResult Fail(string message)
    {
        return new ValidationResult(false, message);
    }
}