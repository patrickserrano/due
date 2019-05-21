using Microsoft.EntityFrameworkCore;

namespace Due.Models.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
        public DbSet<User> User { get; set; }
        public DbSet<Todo> Todo { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Todo>()
                 .HasOne(p => p.User);
            base.OnModelCreating(modelBuilder);
        }
    }
}