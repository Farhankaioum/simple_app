using BookApp.Foundation.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookApp.Foundation.Contexts
{
    public class BookDbContext : DbContext
    {
        private string _connectionString;
        private string _migrationAssemblyName;

        public BookDbContext(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            if (!dbContextOptionsBuilder.IsConfigured)
            {
                dbContextOptionsBuilder.UseSqlServer(
                    _connectionString,
                    m => m.MigrationsAssembly(_migrationAssemblyName));
            }

            base.OnConfiguring(dbContextOptionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasOne(b => b.User)
                .WithMany(u => u.Books)
                .HasForeignKey(b => b.UserId)
                .HasPrincipalKey(u => u.Id);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Book> Books { get; set; }
    }
}
