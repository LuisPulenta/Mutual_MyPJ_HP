using Microsoft.EntityFrameworkCore;
using Mutual_MyPJ_HP.Data.Entities;

namespace Mutual_MyPJ_HP.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<ClientesTipo> ClientesTipos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ClientesTipo>().HasIndex(c => c.Name).IsUnique();
        }
    }
}