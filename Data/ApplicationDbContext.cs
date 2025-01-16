using Club.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Club.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Athlete> Athletes { get; set; } = null!;
        public DbSet<Clubs> Clubs { get; set; } = null!;
        public DbSet<Competition> Competitions { get; set; } = null!;
        public DbSet<Field> Fields { get; set; } = null!;
        public DbSet<Manager> Managers { get; set; } = null!;
        public DbSet<Sponsor> Sponsors { get; set; } = null!;
        public DbSet<Staff> Staffs { get; set; } = null!;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Clubs - Field: One to One
            modelBuilder.Entity<Field>()
                .HasOne(t => t.Clubs)
                .WithOne(r => r.Field)
                .HasForeignKey<Clubs>(r => r.FieldId)
                .OnDelete(DeleteBehavior.Restrict);

            // Clubs - Athlete: One to Many
            modelBuilder.Entity<Clubs>()
                .HasMany(d => d.Athletes)
                .WithOne(t => t.Clubs)
                .HasForeignKey(t => t.ClubsId)
                .OnDelete(DeleteBehavior.Restrict);

            // Clubs - Sponsor: One to Many
            modelBuilder.Entity<Clubs>()
                .HasMany(d => d.Sponsors)
                .WithOne(t => t.Clubs)
                .HasForeignKey(t => t.ClubsId)
                .OnDelete(DeleteBehavior.Restrict);

            // Clubs - Manager: One to Many
            modelBuilder.Entity<Clubs>()
                .HasMany(d => d.Managers)
                .WithOne(t => t.Clubs)
                .HasForeignKey(t => t.ClubsId)
                .OnDelete(DeleteBehavior.Restrict);

            // Clubs - Staff: One to Many
            modelBuilder.Entity<Clubs>()
                .HasMany(d => d.Staffs)
                .WithOne(t => t.Clubs)
                .HasForeignKey(t => t.ClubsId)
                .OnDelete(DeleteBehavior.Restrict);

            // Competition - Clubs: One to Many
            modelBuilder.Entity<Competition>()
                .HasMany(t => t.Clubs)
                .WithOne(r => r.Competition)
                .HasForeignKey(r => r.CompetitionId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
