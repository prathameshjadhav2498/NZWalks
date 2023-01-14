using Microsoft.EntityFrameworkCore;
using NZWalksDemo.Data;
using NZWalksDemo.Interfaces;
using NZWalksDemo.Models.Domain;

namespace NZWalksDemo.Repositories
{
    public class WalkRepository : IWalkRepository
    {
        private readonly NZWalksDbContext _context;
        public WalkRepository(NZWalksDbContext context)
        {
            _context = context;
        }
        public async Task<Walk> AddAsync(Walk walk)
        {
            walk.Id = Guid.NewGuid();
            await _context.Walks.AddAsync(walk);
            await _context.SaveChangesAsync();
            return walk;
        }

        public async Task<Walk> DeleteAsync(Guid id)
        {
            var walk = await _context.Walks.FirstOrDefaultAsync(f => f.Id == id);
            if (walk != null)
            {
                _context.Walks.Remove(walk);
                await _context.SaveChangesAsync();
                return walk;
            }
            return null;
        }

        public async Task<IEnumerable<Walk>> GetAllAsync()
        {
            var walks = await _context.Walks
                .Include(i => i.Region)
                .Include(i => i.WalkDifficulty)
                .ToListAsync();
            return walks;
        }

        public async Task<Walk> GetByIdAsync(Guid id)
        {
            var walk = await _context.Walks
                .Include(i => i.Region)
                .Include(i => i.WalkDifficulty)
                .FirstOrDefaultAsync(f => f.Id == id);
            return walk;
        }

        public async Task<Walk> UpdateAsync(Guid id, Walk walk)
        {
            var walkDetails = await _context.Walks.FirstOrDefaultAsync(f => f.Id == id);
            if (walkDetails != null)
            {
                walkDetails.Length = walk.Length;
                walkDetails.Name = walk.Name;
                walkDetails.RegionId = walk.RegionId;
                walkDetails.WalkDifficultyId = walk.WalkDifficultyId;
                walkDetails.UpdatedBy = "a";
                walkDetails.UpdatedOn = DateTime.UtcNow;

                await _context.SaveChangesAsync();

                return walkDetails;

            }
            return null;

        }
    }
}
