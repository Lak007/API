using Microsoft.EntityFrameworkCore;
using NewZealandWalks.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewZealandWalks.Data
{
    public class NewZealandWalksDbcontext :DbContext
    {
        public NewZealandWalksDbcontext(DbContextOptions dbcontextoptions):base(dbcontextoptions)
        {

        }

        public DbSet<Difficulty> Difficulties { get; set;}
        public DbSet<Region> Regions { get; set;}
        public DbSet<Walks> Walks { get; set; }
    }
}
