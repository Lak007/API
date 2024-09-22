using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewZealandWalks.Models.Domain;

namespace NewZealandWalks.Repository
{
    public interface IWalkRepository
    {
        Task<Walks> AddWalkAsync(Walks walk);
        Task<Walks> GetWalksbyIdAsync(Guid id);
        Task<Walks?> UpdateWalksById(Guid id, Walks walks);
        Task<Walks?> DeleteWalksById(Guid id);
    }

}
