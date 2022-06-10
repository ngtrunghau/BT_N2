using Microsoft.EntityFrameworkCore;

namespace BT_N2.Data
{
    public class MyDbContext:DbContext
    {
        public MyDbContext(DbContextOptions options):base(options) { }
        #region DbSet
            public DbSet<user> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<user>(e =>
            {
                e.ToTable("users");
                e.HasKey(e => e.Id);
                e.HasIndex(e=>e.username).IsUnique();
            });
        }
        #endregion
    }
}
