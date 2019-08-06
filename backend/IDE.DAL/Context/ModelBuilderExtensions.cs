using IDE.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IDE.DAL.Context
{
    public static class ModelBuilderExtensions
    {
        public static void Configure(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProjectMember>()
               .HasKey(pm => new { pm.ProjectId, pm.UserId });
            modelBuilder.Entity<ProjectMember>()
                .HasOne(pm => pm.Project)
                .WithMany(p => p.ProjectMembers)
                .HasForeignKey(pm => pm.ProjectId);
            modelBuilder.Entity<ProjectMember>()
                .HasOne(pm => pm.User)
                .WithMany(u => u.ProjectMembers)
                .HasForeignKey(pm => pm.UserId);

            modelBuilder.Entity<Build>()
               .HasKey(b => new { b.ProjectId, b.UserId });
            modelBuilder.Entity<Build>()
                .HasOne(b => b.Project)
                .WithMany(p => p.Builds)
                .HasForeignKey(pm => pm.ProjectId);
            modelBuilder.Entity<Build>()
                .HasOne(pm => pm.User)
                .WithMany(u => u.Builds)
                .HasForeignKey(pm => pm.UserId);
        }

        public static void Seed(this ModelBuilder modelBuilder)
        {
            // Add database seed logic here
        }
    }
}
