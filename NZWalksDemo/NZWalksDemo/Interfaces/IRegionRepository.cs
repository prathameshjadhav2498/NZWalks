using NZWalksDemo.Models.Domain;

namespace NZWalksDemo.Interfaces
{
    public interface IRegionRepository
    {
        Task<IEnumerable<Region>> GetAllAsync();
    }
}
