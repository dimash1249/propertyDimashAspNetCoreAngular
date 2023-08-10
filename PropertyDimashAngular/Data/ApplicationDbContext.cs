using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PropertyDimashAngular.Models;

namespace PropertyDimashAngular.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public virtual DbSet<Property> Properties { get; set; }
        public virtual DbSet<PropertyImage> PropertyImages { get; set; }
        public virtual DbSet<ResidentialComplex> ResidentialComplexes { get; set; }
        public virtual DbSet<News> News { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<News>().HasOne(d => d.User).WithMany(d => d.News).HasForeignKey(d => d.UserId).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Flat>().HasOne(d => d.ResidentialComplex).WithMany(d => d.Properties).HasForeignKey(d => d.ResidentialComplexId).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Property>().HasOne(d => d.User).WithMany(d => d.Properties).HasForeignKey(d => d.UserId).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<PropertyImage>().HasOne(d => d.Property).WithMany(d => d.Images).HasForeignKey(d => d.PropertyId).OnDelete(DeleteBehavior.Cascade);
            SeedRoles(builder);
            SeedModerator(builder);
            SeedReporter(builder);
            SeedAdministrator(builder);
            SeedResidentialComplex(builder);
        }

        
        private void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "Administrator_id", Name = "Administrator", NormalizedName = "ADMINISTRATOR", ConcurrencyStamp = "1" },
                new IdentityRole { Id = "Moderator_id", Name = "Moderator", NormalizedName = "MODERATOR", ConcurrencyStamp = "2" },
                new IdentityRole { Id = "Reporter_id", Name = "Reporter", NormalizedName = "REPORTER", ConcurrencyStamp = "3" },
                new IdentityRole { Id = "User_id", Name = "User", NormalizedName = "USER", ConcurrencyStamp = "4" }
                );
        }
        
        private void SeedModerator(ModelBuilder builder)
        {
            var moderator = new ApplicationUser
            {
                Id = "Dimash_id",
                FirstName = "Dimash",
                LastName = "Nogaybaev",
                UserName = "nogaybaevd11@list.ru",
                NormalizedUserName = "nogaybaevd11@list.ru",
                Email = "nogaybaevd11@list.ru",
                NormalizedEmail = "nogaybaevd11@list.ru",
                EmailConfirmed = true,
                SecurityStamp = string.Empty,
                ProfileImage = Array.Empty<byte>(),
            };
            var hasher = new PasswordHasher<ApplicationUser>();
            moderator.PasswordHash = hasher.HashPassword(moderator, "password123");
            builder.Entity<ApplicationUser>().HasData(moderator);
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { RoleId = "Moderator_id", UserId = "Dimash_id" });
        }

        private void SeedReporter(ModelBuilder builder)
        {
            var reporter = new ApplicationUser
            {
                Id = "Reporterid",
                FirstName = "Reporter",
                LastName = "Reporter",
                UserName = "reporter@list.ru",
                NormalizedUserName = "reporter@list.ru",
                Email = "reporter@list.ru",
                NormalizedEmail = "reporter@list.ru",
                EmailConfirmed = true,
                SecurityStamp = string.Empty,
                ProfileImage = Array.Empty<byte>(),
            };
            var hasher = new PasswordHasher<ApplicationUser>();
            reporter.PasswordHash = hasher.HashPassword(reporter, "password123");
            builder.Entity<ApplicationUser>().HasData(reporter);
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { RoleId = "Reporter_id", UserId = "Reporterid" });
        }

        private void SeedAdministrator(ModelBuilder builder)
        {
            var administrator = new ApplicationUser
            {
                Id = "Administratorid",
                FirstName = "Administrator",
                LastName = "Administrator",
                UserName = "administrator@list.ru",
                NormalizedUserName = "administrator@list.ru",
                Email = "administrator@list.ru",
                NormalizedEmail = "administrator@list.ru",
                EmailConfirmed = true,
                SecurityStamp = string.Empty,
                ProfileImage = Array.Empty<byte>(),
            };
            var hasher = new PasswordHasher<ApplicationUser>();
            administrator.PasswordHash = hasher.HashPassword(administrator, "password123");
            builder.Entity<ApplicationUser>().HasData(administrator);
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { RoleId = "Administrator_id", UserId = "Administratorid" });
        }
        private void SeedResidentialComplex(ModelBuilder builder)
        {
            builder.Entity<ResidentialComplex>().HasData(
                new ResidentialComplex { Id = "ResidentialComplexId", ResidentialComplexName = "Residential complex", AddressStreet = "Residential complex", AddressNumber = "6" });
        }
    }
}
