using backend.finance.domain.Model;
using Microsoft.EntityFrameworkCore;

namespace backend.finance.infra.Context
{
    public class Connection : DbContext
    {
        public Connection(DbContextOptions<Connection> options) : base(options)
        {
        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Transfer> Transfers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(a => a.Id);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.Id); 

                entity.HasMany(u => u.Accounts)
                      .WithOne(a => a.User)
                      .HasForeignKey(a => a.UserId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.OwnsOne(u => u.CPF);
                entity.OwnsOne(u => u.Email);
            });

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Connection).Assembly);
            base.OnModelCreating(modelBuilder);
        }

    }

}
