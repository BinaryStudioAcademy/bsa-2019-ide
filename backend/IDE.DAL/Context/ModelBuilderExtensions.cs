using IDE.Common.Enums;
using IDE.Common.Security;
using IDE.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Bogus;

namespace IDE.DAL.Context
{
    public static class ModelBuilderExtensions
    {
        private const int ENTITY_COUNT = 20;
        private const int USER_COUNT = 2;

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
            Randomizer.Seed = new Random(2048);

            var avatars = GenerateRandomAvatars(out int imageId);
            var images = GenerateRandomImages(imageId);

            var users = GenerateRandomUsers(avatars);
            var gits = GenerateRandomGitCredentials();
            var projects = GenerateRandomProjects(users, gits, images);
            var builds = GenerateRandomBuilds(users, projects);
            var projectMembers = GenerateRandomProjectMembers(users, projects).GroupBy(x => x.ProjectId + " " + x.UserId).Select(x => x.First());

            modelBuilder.Entity<Image>().HasData(avatars.Concat(images));
            modelBuilder.Entity<User>().HasData(users);
            modelBuilder.Entity<GitCredential>().HasData(gits);
            modelBuilder.Entity<Project>().HasData(projects);
            modelBuilder.Entity<Build>().HasData(builds);
            modelBuilder.Entity<ProjectMember>().HasData(projectMembers);
        }

        //Build
        //ProjectMember
        public static ICollection<ProjectMember> GenerateRandomProjectMembers(ICollection<User> users, ICollection<Project> projects)
        {
            var testProjectMembersFake = new Faker<ProjectMember>()
                .RuleFor(p => p.ProjectId, f => f.PickRandom(projects).Id)
                .RuleFor(p => p.UserId, f => f.PickRandom(users).Id)
                .RuleFor(p => p.UserAccess, f => f.PickRandom<UserAccess>());

            var generatedProjectMembers = testProjectMembersFake.Generate(ENTITY_COUNT);

            return generatedProjectMembers;
        }

        public static ICollection<Build> GenerateRandomBuilds(ICollection<User> users, ICollection<Project> projects)
        {
            int buildId = 1;

            var testBuildsFake = new Faker<Build>()
                .RuleFor(u => u.Id, f => buildId++)
                .RuleFor(p => p.BuildFinished, f => DateTime.Now)
                .RuleFor(p => p.BuildMessage, f => f.Lorem.Sentence(10))
                .RuleFor(p => p.BuildStarted, f => DateTime.Now)
                .RuleFor(p => p.BuildStatus, f => f.PickRandom<BuildStatus>())
                .RuleFor(p => p.ProjectId, f => f.PickRandom(projects).Id)
                .RuleFor(p => p.UserId, f => f.PickRandom(users).Id);


            var generatedProjectMembers = testBuildsFake.Generate(ENTITY_COUNT * 2);

            return generatedProjectMembers;
        }

        public static ICollection<User> GenerateRandomUsers(ICollection<Image> avatars)
        {
            int userId = 1;

            var testUsersFake = new Faker<User>()
                .RuleFor(u => u.Id, f => userId++)
                .RuleFor(u => u.Birthday, f => f.Date.Past(15))
                .RuleFor(u => u.FirstName, f => f.Name.FirstName())
                .RuleFor(u => u.LastName, f => f.Name.LastName())
                .RuleFor(u => u.RegisteredAt, f => DateTime.Now)
                .RuleFor(u => u.LastActive, f => DateTime.Now)
                .RuleFor(u => u.GitHubUrl, f => f.Internet.Url())
                .RuleFor(u => u.PasswordSalt, f => Convert.ToBase64String(SecurityHelper.GetRandomBytes()))
                .RuleFor(u => u.PasswordHash, (f, u) => SecurityHelper.HashPassword(f.Internet.Password(12), Convert.FromBase64String(u.PasswordSalt)))
                .RuleFor(u => u.Email, f => f.Internet.Email())
                .RuleFor(u => u.AvatarId, f => f.PickRandom(avatars).Id)
                .RuleFor(u => u.NickName, f => f.Internet.UserName());

            var generatedUsers = testUsersFake.Generate(USER_COUNT);

            var salt = Convert.ToBase64String(SecurityHelper.GetRandomBytes());
            var hashedPassword = SecurityHelper.HashPassword("12345", Convert.FromBase64String(salt));

            var myUser = new User
            {
                Id = userId,
                Email = "test@gmail.com",
                PasswordHash = hashedPassword,
                PasswordSalt = salt,
                FirstName = "testUser",
                LastName = "testUser",
                AvatarId = 1,
                Birthday = DateTime.Now.AddYears(-14),
                LastActive = DateTime.Now,
                RegisteredAt = DateTime.Now
            };

            generatedUsers.Add(myUser);

            return generatedUsers;
        }

        public static ICollection<Project> GenerateRandomProjects(ICollection<User> authors, ICollection<GitCredential> gits, ICollection<Image> logos)
        {
            int projectId = 1;

            var testProjectFake = new Faker<Project>()
                .RuleFor(i => i.Id, f => projectId++)
                .RuleFor(i => i.AccessModifier, f => f.PickRandom<AccessModifier>())
                .RuleFor(i => i.AuthorId, f => f.PickRandom(authors).Id)
                .RuleFor(i => i.CompilerType, f => f.PickRandom<CompilerType>())
                .RuleFor(i => i.CountOfBuildAttempts, f => f.Random.Number(5, 10))
                .RuleFor(i => i.CountOfSaveBuilds, f => f.Random.Number(5, 10))
                .RuleFor(i => i.CreatedAt, f => DateTime.Now)
                .RuleFor(i => i.Description, f => f.Lorem.Sentence(5))
                .RuleFor(i => i.GitCredentialId, f => f.PickRandom(gits).Id)
                .RuleFor(i => i.Language, f => f.PickRandom<Language>())
                .RuleFor(i => i.LogoId, f => f.PickRandom(logos).Id)
                .RuleFor(i => i.Name, f => f.Lorem.Word())
                .RuleFor(i => i.ProjectLink, f => f.Internet.Url())
                .RuleFor(i => i.ProjectType, f => f.PickRandom<ProjectType>());

            var generatedProjects = testProjectFake.Generate(ENTITY_COUNT);

            return generatedProjects;
        }

        public static ICollection<GitCredential> GenerateRandomGitCredentials()
        {
            int gitId = 1;

            var testGitFake = new Faker<GitCredential>()
                .RuleFor(i => i.Id, f => gitId++)
                .RuleFor(i => i.Url, f => f.Internet.Url())
                .RuleFor(i => i.Login, f => f.Internet.UserName())
                .RuleFor(i => i.Provider, f => f.PickRandom<GitProvider>())
                .RuleFor(u => u.PasswordSalt, f => Convert.ToBase64String(SecurityHelper.GetRandomBytes()))
                .RuleFor(u => u.PasswordHash, (f, u) => SecurityHelper.HashPassword(f.Internet.Password(12), Convert.FromBase64String(u.PasswordSalt)));

            var generatedGits = testGitFake.Generate(ENTITY_COUNT);

            return generatedGits;
        }
        
        public static ICollection<Image> GenerateRandomAvatars(out int lastimageId)
        {
            int imageId = 1;

            var testImageFake = new Faker<Image>()
                .RuleFor(i => i.Id, f => imageId++)
                .RuleFor(i => i.Url, f => f.Internet.Avatar());

            var generatedImages = testImageFake.Generate(USER_COUNT + 1);
            lastimageId = imageId;

            return generatedImages;
        }

        public static ICollection<Image> GenerateRandomImages(int imageId)
        {
            var testImageFake = new Faker<Image>()
                .RuleFor(i => i.Id, f => imageId++)
                .RuleFor(i => i.Url, f => f.Image.LoremFlickrUrl(640, 480));

            var generatedImages = testImageFake.Generate(ENTITY_COUNT);

            return generatedImages;
        }
    }
}
