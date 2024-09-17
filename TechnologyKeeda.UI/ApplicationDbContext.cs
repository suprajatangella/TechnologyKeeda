using Microsoft.EntityFrameworkCore;
using TechnologyKeeda.Entities;

namespace TechnologyKeeda.Repositories
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) 
        {

        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }

        public DbSet<UserInfo> UserInfos { get; set; }

    }
}
