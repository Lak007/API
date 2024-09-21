using NewZealandWalks.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewZealandWalks.Models.Domain
{
    public class Walks
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double LengthinKms { get; set; }
        public string? WalkImageUrl { get; set; }
        public Guid DifficultyId { get; set;}
        public Guid RegionId { get; set; }

        public Difficulty Difficulty { get; set;}
        public Region Region { get; set; }
    }
}
