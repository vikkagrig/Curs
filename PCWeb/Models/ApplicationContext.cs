using Microsoft.EntityFrameworkCore;

namespace PCWeb.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Entrant> Entrants { get; set; }
        public DbSet<List> Lists{ get; set; }
        public DbSet<Spaciality> Spacialities { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public ApplicationContext(DbContextOptions <ApplicationContext> options) : base(options) 
        {
            Database.EnsureCreated();
        }
    }
}
