using Microsoft.EntityFrameworkCore;
using NZWalksDemo.Data;
using NZWalksDemo.Interfaces;
using NZWalksDemo.Models.Domain;

namespace NZWalksDemo.Repositories
{
    public class WalkDifficultyRepository : IWalkDifficultyRepository
    {
        private readonly NZWalksDbContext _context;
        public WalkDifficultyRepository(NZWalksDbContext context)
        {
            _context = context;
        }

        public async Task<WalkDifficulty> AddAsync(WalkDifficulty obj)
        {
            obj.Id = Guid.NewGuid();
            obj.CreatedBy = "a";
            obj.CreatedOn = DateTime.UtcNow;
            obj.IsDeleted = false;
            await _context.AddAsync(obj);
            await _context.SaveChangesAsync();
            return obj;
        }

        public async Task<IEnumerable<WalkDifficulty>> GetAllAsync()
        {
            var walkDifficulties = await _context.WalkDifficulties.ToListAsync();
            return walkDifficulties;
        }

        public async Task<WalkDifficulty> GetByIdAsync(Guid id)
        {
            var result = await _context.WalkDifficulties.FirstOrDefaultAsync(f => f.Id == id);
            if (result == null)
                return null;
            return result;
        }

        public async Task<WalkDifficulty> UpdateAsync(Guid id, WalkDifficulty obj)
        {
            var res = await _context.WalkDifficulties.FirstOrDefaultAsync(f => f.Id == id);
            if (res != null)
            {
                res.Code = obj.Code;
                await _context.SaveChangesAsync();
            }
            return null;
        }
    }
}
