using Microsoft.IdentityModel.Tokens;
using NZWalksDemo.Models.Domain;

namespace NZWalksDemo.Interfaces
{
    public interface IUserRepository
    {
        Task<User> AuthenticateAsync(string username, string password);
    }
}
