using Microsoft.EntityFrameworkCore;
using contestant.Models;

namespace contestant.Models
{
    public class ContestantContext: DbContext
    {
        public ContestantContext(DbContextOptions options): base(options) {

        }

        public DbSet<District> District {get; set;}
        public DbSet<Contestant> Contestant {get; set;}
        public DbSet<ContestantRating> ContestantRating {get; set;}
    }    
}