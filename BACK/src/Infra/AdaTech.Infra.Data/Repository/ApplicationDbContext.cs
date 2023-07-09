using Microsoft.EntityFrameworkCore;

namespace AdaTech.Infra.Data.Repository
{
    using AdaTech.Domain.Models;
    using AdaTech.Infra.Data.Repository.Maps;

    public class ApplicationDbContext :  DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options) {}

        public DbSet<Card> Cards { get; set; }    
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CardEntityConfiguration());
        }
    }
}
