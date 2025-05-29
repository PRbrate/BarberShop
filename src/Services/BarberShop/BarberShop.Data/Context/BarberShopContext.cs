using BarberShop.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
namespace BarberShop.Data
{
    public class BarberShopContext : IdentityDbContext<User>
    {
        public BarberShopContext(DbContextOptions<BarberShopContext> options) : base(options) { }

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
                .HasOne(u => u.Subscriptions)
                .WithOne(s => s.User)
                .HasForeignKey<Subscription>(s => s.UserId)
                .OnDelete(DeleteBehavior.Restrict);

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

            modelBuilder.Entity<Service>()
                .HasQueryFilter(s => !s.IsFinish);

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

            var dateTimeConverter = new ValueConverter<DateTime, DateTime>(
               v => v.ToUniversalTime(),
               v => DateTime.SpecifyKind(v, DateTimeKind.Utc)
            );

            // Aplica o converter a todas as propriedades DateTime
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var properties = entityType.ClrType.GetProperties()
                    .Where(p => p.PropertyType == typeof(DateTime));

                foreach (var property in properties)
                {
                    modelBuilder.Entity(entityType.Name)
                        .Property(property.Name)
                        .HasConversion(dateTimeConverter);
                }
            }

        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.State != EntityState.Modified)
                    continue;

                if (entry.Properties.Any(p => p.Metadata.Name == "UpdatedAt"))
                {
                    entry.Property("UpdatedAt").CurrentValue = DateTime.UtcNow;
                }

                if (entry.Properties.Any(p => p.Metadata.Name == "CreatedAt"))
                {
                    entry.Property("CreatedAt").IsModified = false;
                }
                if (entry.Properties.Any(p => p.Metadata.Name == "UserId"))
                {
                    entry.Property("UserId").IsModified = false;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }


    }
}
