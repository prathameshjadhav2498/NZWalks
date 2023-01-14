using NZWalksDemo.Models.Domain;

namespace NZWalksDemo.Interfaces
{
    public interface IWalkRepository
    {
        Task<IEnumerable<Walk>> GetAllAsync();
        Task<Walk> GetByIdAsync(Guid id);
        Task<Walk> AddAsync(Walk walk);
        Task<Walk> DeleteAsync(Guid id);
        Task<Walk> UpdateAsync(Guid id, Walk walk);
    }
}
