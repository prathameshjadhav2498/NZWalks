using Microsoft.EntityFrameworkCore;
using NZWalksDemo.Data;
using NZWalksDemo.Interfaces;
using NZWalksDemo.Models.Domain;

namespace NZWalksDemo.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private readonly NZWalksDbContext _context;
        public RegionRepository(NZWalksDbContext context)
        {
            _context = context;
        }

        public async Task<Region> AddAsync(Region region)
        {
            region.Id = new Guid();
            region.CreatedBy = "a";
            region.CreatedOn = DateTime.UtcNow;
            region.IsDeleted = false;
            await _context.AddAsync(region);
            await _context.SaveChangesAsync();
            return region;

        }

        public async Task<Region> DeleteAsync(Guid id)
        {
            var region = await _context.Regions.FirstOrDefaultAsync(f => !f.IsDeleted && f.Id == id);
            if (region != null)
            {
                _context.Regions.Remove(region);
                await _context.SaveChangesAsync();
                return region;
            }

            return null;
        }

        public async Task<IEnumerable<Region>> GetAllAsync()
        {
            return await _context.Regions.ToListAsync();
        }

        public async Task<Region> GetByIdAsync(Guid id)
        {
            return await _context.Regions.FirstOrDefaultAsync(f => !f.IsDeleted && f.Id.Equals(id));
        }

        public async Task<Region> UpdateAsync(Guid id, Region region)
        {
            var existingRegion = await _context.Regions.FirstOrDefaultAsync(f => f.Id.Equals(id));

            if (existingRegion == null)
            {
                return null;
            }

            existingRegion.Area = region.Area;
            existingRegion.Code = region.Code;
            existingRegion.Name = region.Name;
            existingRegion.Lat = region.Lat;
            existingRegion.Long = region.Long;
            existingRegion.Population = region.Population;
            await _context.SaveChangesAsync();
            return existingRegion;
        }
    }
}
