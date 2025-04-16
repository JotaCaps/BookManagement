using BookManagement.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookManagement.Infrastructure.Persistence
{
    public class BookManagementDbContext : DbContext
    {
        public BookManagementDbContext(DbContextOptions<BookManagementDbContext> options)
            : base(options)
        {
            
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Loan> Loans { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Book>(e =>
                {
                    e.HasKey(b => b.Id);
                });

            builder
                .Entity<User>(e =>
                {
                    e.HasKey(u => u.Id);
                });

            builder
                .Entity<Loan>(e =>
                {
                    e.HasKey(l => l.Id);
                });

            builder.Entity<Loan>()
                .HasOne(l => l.User)
                .WithMany(l => l.Loans)
                .HasForeignKey(l => l.IdUser)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Loan>()
                .HasOne(b => b.Book)
                .WithMany(b => b.Loans)
                .HasForeignKey(b => b.IdBook)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }
    }
}
