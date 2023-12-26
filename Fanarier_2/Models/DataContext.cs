using Microsoft.EntityFrameworkCore;
using Fanarier_2.Models;

namespace Fanarier_2.Models
{
    public partial class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public virtual DbSet<Acq> Acqs { get; set; }

        public virtual DbSet<Client> Clients { get; set; }

        public virtual DbSet<Pair> Pairs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Конфигурация моделей здесь...
        }
    }
}

