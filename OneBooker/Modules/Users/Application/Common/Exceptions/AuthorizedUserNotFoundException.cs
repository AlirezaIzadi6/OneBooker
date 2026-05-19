using OneBooker.Shared.Exceptions;

namespace OneBooker.Modules.Users.Application.Common.Exceptions;

public class AuthorizedUserNotFoundException : ApplicationBaseException
{
    public AuthorizedUserNotFoundException()
        : base("User was authorized, but corresponding id was not found in database.")
    {
    }
}