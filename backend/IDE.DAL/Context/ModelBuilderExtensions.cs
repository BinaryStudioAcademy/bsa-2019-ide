using Bogus;
using Humanizer;
using IDE.Common.Enums;
using IDE.Common.Security;
using IDE.DAL.Entities;
using IDE.DAL.Entities.NoSql;
using IDE.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IDE.DAL.Context
{
    public static class ModelBuilderExtensions
    {
        private const int ENTITY_COUNT = 20;
        private const int USER_COUNT = 2;
        private static DateTime DATE_TIME = new DateTime(2018, 1, 1);
        private static Random random = new Random(2048);
        
        public static void EnsureSeeded(this IdeContext context, IFileStorageNoSqlDbSettings settings)
        {
            if(context.Users.Count() == 0)
            {
                context.Seed(settings);
            }
        }

        public static void Configure(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RefreshToken>().Ignore(t => t.IsActive);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Builds)
                .WithOne(b => b.User)
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ProjectMember>()
                .HasKey(pm => new {pm.ProjectId, pm.UserId});

            modelBuilder.Entity<ProjectMember>()
                .HasOne(pm => pm.Project)
                .WithMany(p => p.ProjectMembers)
                .HasForeignKey(pm => pm.ProjectId);

            modelBuilder.Entity<ProjectMember>()
                .HasOne(pm => pm.User)
                .WithMany(u => u.ProjectMembers)
                .HasForeignKey(pm => pm.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<FavouriteProjects>()
               .HasKey(fp => new { fp.ProjectId, fp.UserId });

            modelBuilder.Entity<FavouriteProjects>()
                .HasOne(pm => pm.Project)
                .WithMany(p => p.FavouriteProjects)
                .HasForeignKey(pm => pm.ProjectId);

            modelBuilder.Entity<FavouriteProjects>()
                .HasOne(pm => pm.User)
                .WithMany(u => u.FavouriteProjects)
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

            modelBuilder.Entity<SocialAuthAccount>()
                .Property(sa => sa.AccountId)
                .IsRequired();
        }

        public static void Seed(this IdeContext context, IFileStorageNoSqlDbSettings settings)
        {
            Randomizer.Seed = new Random(2048);

            var avatars = GenerateRandomAvatars();
            context.Images.AddRange(avatars);
            context.SaveChanges();

            var users = GenerateRandomUsers(context.Images.ToList());
            context.Users.AddRange(users);
            //context.SaveChanges();

            var gits = GenerateRandomGitCredentials();
            context.GitCredentials.AddRange(gits);
            context.SaveChanges();

            var projects = GenerateRandomProjects(context.Users.ToList(), context.GitCredentials.ToList(), settings);
            context.Projects.AddRange(projects);
            context.SaveChanges();

            EnsureNoSqlDbSeeded(settings, context.Projects.ToList());

            var builds = GenerateRandomBuilds(context.Users.ToList(), context.Projects.ToList());
            context.Builds.AddRange(builds);
            //context.SaveChanges();

            var projectMembers = GenerateRandomProjectMembers(context.Users.ToList(), context.Projects.ToList())
                .GroupBy(x => x.ProjectId + " " + x.UserId).Select(x => x.First());
            context.ProjectMembers.AddRange(projectMembers);
            context.SaveChanges();
        }

        private static void EnsureNoSqlDbSeeded(IFileStorageNoSqlDbSettings settings, ICollection<Project> projects)
        {
            IMongoCollection<ProjectStructure> items;
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            var itemsCollectionName = GetItemsCollectionName();
            items = database.GetCollection<ProjectStructure>(itemsCollectionName);

            foreach (var project in projects)
            {
                var fileStructure = new FileStructure();
                fileStructure.Type = Common.ModelsDTO.Enums.TreeNodeType.Folder;
                fileStructure.Details = $"Super important details of file {project.Name}";
                fileStructure.Name = project.Name;

                var emptyStructure = new ProjectStructure();
                emptyStructure.Id = project.Id.ToString();
                emptyStructure.NestedFiles.Add(fileStructure);

                items.InsertOne(emptyStructure);
            }
        }

        private static ICollection<ProjectMember> GenerateRandomProjectMembers(ICollection<User> users,
            ICollection<Project> projects)
        {
            var testProjectMembersFake = new Faker<ProjectMember>()
                .RuleFor(p => p.ProjectId, f => f.PickRandom(projects).Id)
                .RuleFor(p => p.UserId, f => f.PickRandom(users).Id)
                .RuleFor(p => p.UserAccess, f => f.PickRandom<UserAccess>());

            var generatedProjectMembers = testProjectMembersFake.Generate(ENTITY_COUNT);

            return generatedProjectMembers;
        }

        private static ICollection<Build> GenerateRandomBuilds(ICollection<User> users, ICollection<Project> projects)
        {
            var testBuildsFake = new Faker<Build>()
                .RuleFor(p => p.BuildFinished, f => f.Date.Between(DATE_TIME.AddMonths(9), DATE_TIME.AddMonths(10)))
                .RuleFor(p => p.BuildMessage, f => f.Lorem.Sentence(10))
                .RuleFor(p => p.BuildStarted, f => f.Date.Between(DATE_TIME.AddMonths(8), DATE_TIME.AddMonths(9)))
                .RuleFor(p => p.BuildStatus, f => f.PickRandom<BuildStatus>())
                .RuleFor(p => p.ProjectId, f => f.PickRandom(projects).Id)
                .RuleFor(p => p.UserId, f => f.PickRandom(users).Id);


            var generatedProjectMembers = testBuildsFake.Generate(ENTITY_COUNT * 2);

            return generatedProjectMembers;
        }

        private static ICollection<User> GenerateRandomUsers(ICollection<Image> avatars)
        {
            var testUsersFake = new Faker<User>()
                .RuleFor(u => u.Birthday, f => f.Date.Between(DATE_TIME.AddYears(-20), DATE_TIME.AddYears(-16)))
                .RuleFor(u => u.FirstName, f => f.Name.FirstName())
                .RuleFor(u => u.LastName, f => f.Name.LastName())
                .RuleFor(u => u.RegisteredAt, f => f.Date.Between(DATE_TIME.AddDays(1), DATE_TIME.AddDays(180)))
                .RuleFor(u => u.LastActive, f => f.Date.Between(DATE_TIME.AddDays(180), DATE_TIME.AddDays(190)))
                .RuleFor(u => u.GitHubUrl, f => f.Internet.Url())
                .RuleFor(u => u.PasswordSalt, f => Convert.ToBase64String(GetRandomBytes()))
                .RuleFor(u => u.PasswordHash,
                    (f, u) => SecurityHelper.HashPassword(f.Internet.Password(12),
                        Convert.FromBase64String(u.PasswordSalt)))
                .RuleFor(u => u.Email, f => f.Internet.Email())
                .RuleFor(u => u.AvatarId, f => f.PickRandom(avatars).Id)
                .RuleFor(u => u.NickName, f => f.Internet.UserName());

            var generatedUsers = testUsersFake.Generate(USER_COUNT);

            var salt = Convert.ToBase64String(SecurityHelper.GetRandomBytes());
            var hashedPassword = SecurityHelper.HashPassword("12345678", Convert.FromBase64String(salt));

            var myUser = new User
            {
                Email = "test@gmail.com",
                PasswordHash = hashedPassword,
                PasswordSalt = salt,
                FirstName = "testUser",
                LastName = "testUser",
                NickName = "TheBestUser",
                AvatarId = avatars.ToList()[0].Id,
                Birthday = DateTime.Now.AddYears(-14),
                LastActive = DateTime.Now,
                RegisteredAt = DateTime.Now
            };

            generatedUsers.Add(myUser);

            return generatedUsers;
        }

        private static ICollection<Project> GenerateRandomProjects(ICollection<User> authors,
            ICollection<GitCredential> gits, IFileStorageNoSqlDbSettings settings)
        {
            var testProjectFake = new Faker<Project>()
                .RuleFor(i => i.AccessModifier, f => f.PickRandom<AccessModifier>())
                .RuleFor(i => i.AuthorId, f => f.PickRandom(authors).Id)
                .RuleFor(i => i.CompilerType, f => f.PickRandom<CompilerType>())
                .RuleFor(i => i.CountOfBuildAttempts, f => f.Random.Number(5, 10))
                .RuleFor(i => i.CountOfSaveBuilds, f => f.Random.Number(5, 10))
                .RuleFor(i => i.CreatedAt, f => f.Date.Between(DATE_TIME, DATE_TIME.AddDays(180)))
                .RuleFor(i => i.Description, f => f.Lorem.Sentence(5))
                .RuleFor(i => i.GitCredentialId, f => f.PickRandom(gits).Id)
                .RuleFor(i => i.Language, f => f.PickRandom<Language>())
                .RuleFor(i => i.Name, f => f.Lorem.Word())
                .RuleFor(i => i.Color, f => f.Internet.Color(50, 50, 50))
                .RuleFor(i => i.ProjectLink, f => f.Internet.Url())
                .RuleFor(i => i.ProjectType, f => f.PickRandom<ProjectType>());

            var generatedProjects = testProjectFake.Generate(ENTITY_COUNT);

            return generatedProjects;
        }

        private static ICollection<GitCredential> GenerateRandomGitCredentials()
        {
            var testGitFake = new Faker<GitCredential>()
                .RuleFor(i => i.Url, f => f.Internet.Url())
                .RuleFor(i => i.Login, f => f.Internet.UserName())
                .RuleFor(i => i.Provider, f => f.PickRandom<GitProvider>())
                .RuleFor(u => u.PasswordSalt, f => Convert.ToBase64String(GetRandomBytes()))
                .RuleFor(u => u.PasswordHash,
                    (f, u) => SecurityHelper.HashPassword(f.Internet.Password(12),
                        Convert.FromBase64String(u.PasswordSalt)));

            var generatedGits = testGitFake.Generate(ENTITY_COUNT);

            return generatedGits;
        }

        private static ICollection<Image> GenerateRandomAvatars()
        {
            var testImageFake = new Faker<Image>()
                .RuleFor(i => i.Url, f => f.Internet.Avatar());

            var generatedImages = testImageFake.Generate(USER_COUNT + 1);

            return generatedImages;
        }

        private static byte[] GetRandomBytes(int length = 32)
        {
            var bytes = new byte[32];
            for (int i = 0; i < length; i++)
                bytes[i] = (byte)random.Next(255);
            return bytes;
        }

        private static string GetItemsCollectionName()
        {
            var itemClassName = typeof(ProjectStructure).ToString().Split('.').Last();
            var itemsCollectionName = itemClassName.Pluralize();
            return itemsCollectionName;
        }
    }
}