namespace OneBooker.Modules.Users.Application.Login;

public record LoginRequest
{
    public string UserName { get; set; }
    public string Password { get; set; }
}