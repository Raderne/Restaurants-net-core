namespace Application.Contracts.Users;

public interface IUserContext
{
    CurrentUser? GetCurrentUser();
}
