using IsSistemVakaTask.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace IsSistemVakaTask.Repositories
{
    public class VakaDbContext :DbContext
    {
        public VakaDbContext(DbContextOptions<VakaDbContext> options) : base(options)
        { 
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Table>().HasQueryFilter(h => !h.IsDelete);
            modelBuilder.Entity<Reservation>().HasQueryFilter(h => !h.IsDelete);

            base.OnModelCreating(modelBuilder);

        }

        public virtual DbSet<Table> Tables { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        
    }
}
