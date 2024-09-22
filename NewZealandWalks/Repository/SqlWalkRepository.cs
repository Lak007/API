using NewZealandWalks.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewZealandWalks.Data;

namespace NewZealandWalks.Repository
{
    public class SqlWalkRepository : IWalkRepository
    {
        private readonly NewZealandWalksDbcontext _dbcontext;

        public SqlWalkRepository(NewZealandWalksDbcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<Walks> AddWalkAsync(Walks walk)
        {
            await _dbcontext.Walks.AddAsync(walk);
            await _dbcontext.SaveChangesAsync();
            return walk;
        }

        public async Task<Walks?> GetWalksbyIdAsync(Guid id)
        {
            Walks? walk = await _dbcontext.Walks.FindAsync(id);
            return walk;
        }

        public async  Task<Walks?> UpdateWalksById(Guid id, Walks walks)
        {
            var walk = await _dbcontext.Walks.FindAsync(id);
            if (walk == null) {
                return null;
            }
            walk.Name = walks.Name;
            walk.LengthinKms = walks.LengthinKms;
            walk.Description = walks.Description;
            walk.DifficultyId = walks.DifficultyId;
            walk.RegionId = walks.RegionId;
            await _dbcontext.SaveChangesAsync();
            return walk;
        }

        public async Task<Walks?> DeleteWalksById(Guid id) {
            Walks walk = await _dbcontext.Walks.FindAsync(id);
            if (walk == null) {
                return null;
            }
             _dbcontext.Walks.Remove(walk);
            await _dbcontext.SaveChangesAsync();
            return walk;
        }
    }
}
