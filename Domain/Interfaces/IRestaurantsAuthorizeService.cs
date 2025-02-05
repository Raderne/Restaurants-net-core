using Domain.Constants;

namespace Domain.Interfaces;

public interface IRestaurantsAuthorizeService
{
    bool AuthorizeAsync(ResourceOperation resourceOperation, string ownerId);
}
