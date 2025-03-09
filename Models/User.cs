using Api.Shared;
using Microsoft.AspNetCore.Identity;

namespace Api.Models
{
    public class User : IdentityUser<Guid>, ISortableEntity
    {
        public static string[] GetSortingKeys()
        {
            return [nameof(Id), nameof(UserName), nameof(Email)];
        }
    }
}
