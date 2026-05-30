using System.ComponentModel.DataAnnotations;

namespace OneBooker.Shared.Services.Email;

public record SendEmailRequest
{
    public ICollection<string> Recipients { get; init; }

    [MaxLength(100)]
    public string subject { get; init; }

    [MaxLength(4096)]
    public string Body { get; init; }
}