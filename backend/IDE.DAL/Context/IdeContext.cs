using IDE.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using System.Linq;

namespace IDE.DAL.Context
{
    public sealed class IdeContext : DbContext
    {
        private static bool _isDatabaseUpdatedChecked = false;

        public IdeContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Build> Builds { get; private set; }
        public DbSet<Project> Projects { get; private set; }
        public DbSet<User> Users { get; private set; }
        public DbSet<ProjectMember> ProjectMembers { get; private set; }
        public DbSet<Image> Images { get; private set; }
        public DbSet<RefreshToken> RefreshTokens { get; private set; }
        public DbSet<GitCredential> GitCredentials { get; private set; }
        public DbSet<FavouriteProjects> FavouriteProjects { get; private set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Configure();
            modelBuilder.Seed();
        }

        public void InitializeDatabase()
        {
            if (_isDatabaseUpdatedChecked)
            {
                return;
            }

            try //If we need we can check if database with such connection string exists, not to create smth new by mistake
            {
                Database.OpenConnection();
                Database.CloseConnection();
            }
            catch (SqlException)
            {
                throw new System.Exception("Database with such connection string doesn't exist");
            }

            if (Database.GetPendingMigrations().Count() != 0)
            {
                Database.Migrate();
            }

            _isDatabaseUpdatedChecked = true;
        }
    }
}