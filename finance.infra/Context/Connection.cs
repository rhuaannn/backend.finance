using backend.finance.domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace backend.finance.infra.Context
{
    public class Connection : DbContext
    {
        public Connection(DbContextOptions<Connection> options) : base(options)
        {
           
        }
       
        public DbSet<Account> Accounts { get; set; } =null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Transfer> Transfers { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(a => a.Id);

                entity.HasMany(a => a.SentTransfers)
                      .WithOne(t => t.SourceAccount)
                      .HasForeignKey(t => t.SourceAccountId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(a => a.ReceivedTransfers)
                      .WithOne(t => t.DestinationAccount)
                      .HasForeignKey(t => t.DestinationAccountId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(a => a.User)
                      .WithMany(u => u.Accounts)
                      .HasForeignKey(a => a.UserId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.Id);

                entity.HasMany(u => u.Accounts)
                      .WithOne(a => a.User)
                      .HasForeignKey(a => a.UserId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(u => u.Transfers)
                      .WithOne(t => t.User)
                      .HasForeignKey(t => t.UserId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.OwnsOne(u => u.CPF);
                entity.OwnsOne(u => u.Email);
            });

            modelBuilder.Entity<Transfer>(entity =>
            {
                entity.HasKey(t => t.Id);

                entity.HasOne(t => t.User)
                      .WithMany(u => u.Transfers)
                      .HasForeignKey(t => t.UserId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(t => t.SourceAccount)
                      .WithMany(a => a.SentTransfers)
                      .HasForeignKey(t => t.SourceAccountId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(t => t.DestinationAccount)
                      .WithMany(a => a.ReceivedTransfers)
                      .HasForeignKey(t => t.DestinationAccountId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Connection).Assembly);
            base.OnModelCreating(modelBuilder);
        }


    }
 

}
