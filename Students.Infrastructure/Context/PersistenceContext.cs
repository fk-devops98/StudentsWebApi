using Microsoft.EntityFrameworkCore;
using Students.Domain.Entities;

namespace Students.Infrastructure.Context
{
    public class PersistenceContext : DbContext
    {
        public PersistenceContext(DbContextOptions<PersistenceContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Student> Students { get; set; } = null!;

        public async Task CommitAsync()
        {
            await SaveChangesAsync().ConfigureAwait(false);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
            {
                return;
            }

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");

                entity.HasIndex(e => e.Username, "IX_Student_Username").IsUnique();
                entity.Property(e => e.Career).HasColumnType("VARCHAR(50)");
                entity.Property(e => e.FirstName).HasColumnType("VARCHAR(20)");
                entity.Property(e => e.LastName).HasColumnType("VARCHAR(20)");
                entity.Property(e => e.Username).HasColumnType("VARCHAR(20)");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}