using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NewZealandWalks.Data;
using NewZealandWalks.Models.Domain;

namespace NewZealandWalks.Repository
{
    public class SqlRegionRepository:IRegionRepository
    {
        private readonly NewZealandWalksDbcontext _dbcontext;
        public SqlRegionRepository(NewZealandWalksDbcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<Region?> AddregionAsync(Region region)
        {
            await _dbcontext.AddAsync(region);
            await _dbcontext.SaveChangesAsync();
            return region;
        }

        public async Task<Region?> DeleteRegionByIdAsync(Guid id)
        {
            Region region = await _dbcontext.Regions.FindAsync(id);
            if (region == null) {
                return null;
            }
            _dbcontext.Regions.Remove(region);
            await _dbcontext.SaveChangesAsync();
            return region;
        }

        public async Task<List<Region>> GetListAsync()
        {
            return await _dbcontext.Regions.ToListAsync();
        }

        public async Task<Region> GetRegionByIDAsync(Guid id)
        {
            return await _dbcontext.Regions.FindAsync(id);
        }

        public async Task<Region?> UpdateRegionByIDAsync(Guid id, Region region)
        {
            Region regionData = await _dbcontext.Regions.FindAsync(id);
            if (regionData == null) {
                return null;
            }
            regionData.Code = region.Code;
            regionData.Name = region.Name;
            regionData.RegionImageUrl = region.RegionImageUrl;
            await _dbcontext.SaveChangesAsync();
            return regionData;
        }
    }
}
