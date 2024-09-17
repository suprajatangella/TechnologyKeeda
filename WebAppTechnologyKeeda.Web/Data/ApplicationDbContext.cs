using Microsoft.EntityFrameworkCore;
using TechnologyKeeda.Web.Models;

namespace TechnologyKeeda.Web.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) 
        {

        }

        public DbSet<People> Peoples { get; set; }
        
    }
}
