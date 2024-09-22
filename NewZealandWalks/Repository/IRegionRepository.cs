using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewZealandWalks.Models.Domain;

namespace NewZealandWalks.Repository
{
    public interface IRegionRepository
    {
        Task<List<Region>> GetListAsync();
        Task<Region> GetRegionByIDAsync(Guid id);
        Task<Region?> AddregionAsync(Region region);
        Task<Region?> UpdateRegionByIDAsync(Guid id, Region region);

        Task<Region?> DeleteRegionByIdAsync(Guid id);
    }
}
