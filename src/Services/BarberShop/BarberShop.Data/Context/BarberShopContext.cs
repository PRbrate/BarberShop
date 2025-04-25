using BarberShop.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace BarberShop.Data.Context
{
    public class BarberShopContext : IdentityDbContext<User>
    {
        public BarberShopContext(DbContextOptions<BarberShopContext> options) : base(options){}

        public DbSet<User> User { get; set; }
        public DbSet<Haircut> Haircut { get; set; }
        public DbSet<Subscription> Subscription { get; set; }
        public DbSet<Service> Service { get; set; }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder
                .Properties<string>()
                .AreUnicode(false)
                .HaveMaxLength(100);

            configurationBuilder
                .Properties<double>()
                .HavePrecision(8, 2);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("dbo");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BarberShopContext).Assembly);

            modelBuilder.Entity<IdentityUserLogin<string>>()
                .HasKey(login => login.UserId);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Subscriptions)
                .WithOne(s => s.User)
                .HasForeignKey(s => s.UserId);

            modelBuilder.Entity<Haircut>()
                .HasOne(u => u.User)
                .WithMany(h => h.Haircuts)
                .HasForeignKey(h => h.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Service>()
                .HasOne(u => u.User)
                .WithMany(s => s.Services)
                .HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Service>()
                .HasOne(u => u.Haircut)
                .WithMany(s => s.Services)
                .HasForeignKey(s => s.HaircutId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Subscription>()
                .HasOne(u => u.User)
                .WithMany(s => s.Subscriptions)
                .HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Service>()
                .Property(p => p.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Subscription>()
                .Property(p => p.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Haircut>()
                .Property(p => p.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd();

        }

    }
}
