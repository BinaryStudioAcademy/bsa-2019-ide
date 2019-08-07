using IDE.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace IDE.DAL.Context
{
    public static class ModelBuilderExtensions
    {
        public static void Configure(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RefreshToken>().Ignore(t => t.IsActive);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Builds)
                .WithOne(b => b.User)
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ProjectMember>()
               .HasKey(pm => new { pm.ProjectId, pm.UserId });

            modelBuilder.Entity<ProjectMember>()
                .HasOne(pm => pm.Project)
                .WithMany(p => p.ProjectMembers)
                .HasForeignKey(pm => pm.ProjectId);

            modelBuilder.Entity<ProjectMember>()
                .HasOne(pm => pm.User)
                .WithMany(u => u.ProjectMembers)
                .HasForeignKey(pm => pm.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Build>()
                .HasOne(b => b.Project)
                .WithMany(p => p.Builds)
                .HasForeignKey(pm => pm.ProjectId);

            modelBuilder.Entity<Build>()
                .HasOne(pm => pm.User)
                .WithMany(u => u.Builds)
                .HasForeignKey(pm => pm.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }

        public static void Seed(this ModelBuilder modelBuilder)
        {
            // Add database seed logic here
        }
    }
}
