using Application.Contracts.Users;
using Domain.Constants;
using Domain.Interfaces;

namespace Identites.Authorization;

public class RestaurantsAuthorizeService(IUserContext userContext) : IRestaurantsAuthorizeService
{
    public bool AuthorizeAsync(ResourceOperation resourceOperation, string ownerId)
    {
        var user = userContext.GetCurrentUser();

        if (user == null)
        {
            return false;
        }

        if (resourceOperation == ResourceOperation.read)
            return true;

        if (resourceOperation == ResourceOperation.update && (user.IsAdmin || ownerId == user.UserId))
            return true;

        return false;
    }
}
