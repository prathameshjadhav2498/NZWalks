using NZWalksDemo.Models.Domain;

namespace NZWalksDemo.Interfaces
{
    public interface ITokenHandler
    {
        Task<string> CreateTokenAsync(User user);
    }
}
