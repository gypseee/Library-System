using Library_System.Models.DomainModels;
using Microsoft.EntityFrameworkCore;

namespace Library_System.Data
{
    public class LmDbContext : DbContext 
    {
        public LmDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
                
        }


        public DbSet<Books> Books { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Profiles> Profile { get; set; }
        public DbSet<LendRecords> LendRecords { get; set; }


    }
}
