using Bogus;
using Humanizer;
using IDE.Common.Enums;
using IDE.Common.Security;
using IDE.DAL.Entities;
using IDE.DAL.Entities.NoSql;
using IDE.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
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
            if (context.Users.Count() == 0)
            {
                context.SeedWithCorrectData(settings);
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
        }

        public static void SeedWithCorrectData(this IdeContext context, IFileStorageNoSqlDbSettings settings)
        {
            var avatars = GenerateCorrectImages();
            context.Images.AddRange(avatars);
            var editorSettings = GenerateCorrectEditorSettings();
            context.EditorSettings.AddRange(editorSettings);
            context.SaveChanges();

            var users = GenerateCorrectUsers(context.Images.ToArray(), context.EditorSettings.ToArray());
            context.Users.AddRange(users);
            context.SaveChanges();

            var dBUsers = context.Users.ToArray();

            var projects = GenerateCorrectProjects(dBUsers, context.EditorSettings.ToArray());
            context.Projects.AddRange(projects);
            context.SaveChanges();

            var dBProjects = context.Projects.ToArray();

            var projectMembers = GenerateCorrectProjectMembers(dBProjects, dBUsers);
            context.ProjectMembers.AddRange(projectMembers);

            var favouriteProjects = GenerateCorrectFavouriteProjects(dBProjects, dBUsers);
            context.FavouriteProjects.AddRange(favouriteProjects);

            context.SaveChanges();

            EnsureNoSqlDbSeeded(settings, dBProjects);

            var builds = GenerateRandomBuilds(context.Users.ToList(), context.Projects.ToList());
            context.Builds.AddRange(builds);
            context.SaveChanges();
        }

        private static Image[] GenerateCorrectImages()
        {
            return new Image[]
            {
                new Image()
                {
                    Url = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTACMl9I3lcMYfz6RKTnHFsm6cGRel0IPA_PkwT7mn5GriUgSWiGw"
                },
                new Image()
                {
                    Url = "https://ichef.bbci.co.uk/news/660/cpsprodpb/1189D/production/_101673817_kendrick_reuters.jpg"
                },
                new Image()
                {
                    Url = "https://thenypost.files.wordpress.com/2017/08/shutterstock_157245107.jpg?quality=90&strip=all&w=618&h=410&crop=1"
                }
            };
        }
        private static EditorSetting[] GenerateCorrectEditorSettings()
        {
            return new EditorSetting[]
            {
                new EditorSetting()
                {
                    LineNumbers = "on",
                    RoundedSelection = false,
                    ScrollBeyondLastLine = false,
                    ReadOnly = false,
                    FontSize = 20,
                    TabSize = 5,
                    CursorStyle = "line",
                    LineHeight = 20,
                    Theme = "vs"
                },
                new EditorSetting()
                {
                    LineNumbers = "off",
                    RoundedSelection = false,
                    ScrollBeyondLastLine = false,
                    ReadOnly = false,
                    FontSize = 22,
                    TabSize = 5,
                    CursorStyle = "line",
                    LineHeight = 20,
                    Theme = "hc-black"
                }
            };
        }
        private static User[] GenerateCorrectUsers(Image[] images, EditorSetting[] settings)
        {
            var salt = Convert.ToBase64String(SecurityHelper.GetRandomBytes());

            return new User[]
            {
                new User()
                {   
                    AvatarId = images[0].Id,
                    Birthday = DateTime.Now.AddYears(-20),
                    EditorSettingsId = settings[0].Id,
                    Email  = "tania.gutiy@gmail.com",
                    EmailConfirmed = true,
                    FirstName = "Tatiana",
                    LastName = "Hutii",
                    LastActive = DateTime.Now,
                    NickName = "taniagutiy",
                    RegisteredAt = DateTime.Now.AddDays(-35),
                    PasswordHash = SecurityHelper.HashPassword("tania12345", Convert.FromBase64String(salt)),
                    PasswordSalt = salt
                },
                new User()
                {
                    AvatarId = images[1].Id,
                    Birthday = DateTime.Now.AddYears(-36),
                    EditorSettingsId = settings[1].Id,
                    Email  = "denchik.collab@gmail.com",
                    EmailConfirmed = true,
                    FirstName = "Danil",
                    LastName = "Agienko",
                    LastActive = DateTime.Now,
                    NickName = "Den4ik",
                    RegisteredAt = DateTime.Now.AddDays(-156),
                    PasswordHash = SecurityHelper.HashPassword("0987654321", Convert.FromBase64String(salt)),
                    PasswordSalt = salt
                },
                new User()
                {
                    AvatarId = images[2].Id,
                    Birthday = DateTime.Now.AddYears(-20),
                    EditorSettingsId = settings[0].Id,
                    Email  = "binary.studio@gmail.com",
                    EmailConfirmed = true,
                    FirstName = "Online",
                    LastName = "IDEAdmin",
                    LastActive = DateTime.Now,
                    NickName = "TheBestUser",
                    RegisteredAt = DateTime.Now.AddDays(-15),
                    PasswordHash = SecurityHelper.HashPassword("12345678", Convert.FromBase64String(salt)),
                    PasswordSalt = salt
                }
            };
        }
        private static Project[] GenerateCorrectProjects(User[] users, EditorSetting[] settings)
        {
            return new Project[]
            {
                new Project()
                {
                    Name = "Parking",
                    Description = "Parking is the act of stopping and disengaging a vehicle and leaving it unoccupied. Parking on one or both sides of a road is often permitted, though sometimes with restrictions. Some buildings have parking facilities for use of the buildings' users.",
                    AuthorId = users[0].Id,
                    Color = "#0000ff",
                    CreatedAt = DateTime.Now.AddDays(-13),
                    EditorProjectSettingsId = settings[0].Id,
                    AccessModifier = AccessModifier.Public,
                    CompilerType = CompilerType.CoreCLR,
                    Language = Language.CSharp,
                    ProjectType = ProjectType.Console,
                    CountOfBuildAttempts = 10,
                    CountOfSaveBuilds = 10
                },
                new Project()
                {
                    Name = "Sudoku",
                    Description = "Sudoku (数独 sūdoku, digit-single) (/suːˈdoʊkuː/, /-ˈdɒk-/, /sə-/, originally called Number Place) is a logic-based, combinatorial number-placement puzzle. The objective is to fill a 9×9 grid with digits so that each column, each row, and each of the nine 3×3 subgrids that compose the grid (also called \"boxes\", \"blocks\", or \"regions\") contain all of the digits from 1 to 9.",
                    AuthorId = users[0].Id,
                    Color = "#000000",
                    CreatedAt = DateTime.Now.AddDays(-22),
                    EditorProjectSettingsId = settings[0].Id,
                    AccessModifier = AccessModifier.Public,
                    CompilerType = CompilerType.CoreCLR,
                    Language = Language.CSharp,
                    ProjectType = ProjectType.Console,
                    CountOfBuildAttempts = 10,
                    CountOfSaveBuilds = 10
                },
                new Project()
                {
                    Name = "OnlineShopWebsite",
                    Description = "Online shopping is a form of electronic commerce which allows consumers to directly buy goods or services from a seller over the Internet using a web browser. Consumers find a product of interest by visiting the website of the retailer directly or by searching among alternative vendors using a shopping search engine, which displays the same product's availability and pricing at different e-retailers. As of 2016, customers can shop online using a range of different computers and devices, including desktop computers, laptops, tablet computers and smartphones.",
                    AuthorId = users[0].Id,
                    Color = "#ffd700",
                    CreatedAt = DateTime.Now.AddDays(-3),
                    EditorProjectSettingsId = settings[1].Id,
                    AccessModifier = AccessModifier.Public,
                    CompilerType = CompilerType.CoreCLR,
                    Language = Language.CSharp,
                    ProjectType = ProjectType.Console,
                    CountOfBuildAttempts = 10,
                    CountOfSaveBuilds = 10
                },
                new Project()
                {
                    Name = "BakeryStats",
                    Description = "A bakery (also baker's shop or bake shop) is an establishment that produces and sells flour-based food baked in an oven such as bread, cookies, cakes, pastries, and pies. Some retail bakeries are also cafés, serving coffee and tea to customers who wish to consume the baked goods on the premises.",
                    AuthorId = users[1].Id,
                    Color = "#8b008b",
                    CreatedAt = DateTime.Now.AddDays(-6),
                    EditorProjectSettingsId = settings[0].Id,
                    AccessModifier = AccessModifier.Public,
                    CompilerType = CompilerType.CoreCLR,
                    Language = Language.CSharp,
                    ProjectType = ProjectType.Console,
                    CountOfBuildAttempts = 10,
                    CountOfSaveBuilds = 10
                },
                new Project()
                {
                    Name = "OnlineCalendar",
                    Description = "A calendar is a system of organizing days for social, religious, commercial or administrative purposes. This is done by giving names to periods of time, typically days, weeks, months and years. ",
                    AuthorId = users[1].Id,
                    Color = "#778899",
                    CreatedAt = DateTime.Now.AddDays(-7),
                    EditorProjectSettingsId = settings[0].Id,
                    AccessModifier = AccessModifier.Public,
                    CompilerType = CompilerType.CoreCLR,
                    Language = Language.CSharp,
                    ProjectType = ProjectType.Console,
                    CountOfBuildAttempts = 10,
                    CountOfSaveBuilds = 10
                },
                new Project()
                {
                    Name = "DuckDuckGo",
                    Description = "DuckDuckGo (DDG) is an internet search engine that emphasizes protecting searchers' privacy and avoiding the filter bubble of personalized search results. DuckDuckGo distinguishes itself from other search engines by not profiling its users and by showing all users the same search results for a given search term.",
                    AuthorId = users[1].Id,
                    Color = "#ff8c00",
                    CreatedAt = DateTime.Now.AddDays(-4),
                    EditorProjectSettingsId = settings[1].Id,
                    AccessModifier = AccessModifier.Public,
                    CompilerType = CompilerType.CoreCLR,
                    Language = Language.CSharp,
                    ProjectType = ProjectType.Console,
                    CountOfBuildAttempts = 10,
                    CountOfSaveBuilds = 10
                },
                new Project()
                {
                    Name = "OnlineIDE",
                    Description = "Online IDE was created to save, build and run your projects from browser, without installing some special programms. Also it's great idea, because now programm work speed won't depend on characteristics of your PC or notebook.",
                    AuthorId = users[2].Id,
                    Color = "#0080ff",
                    CreatedAt = DateTime.Now.AddDays(-10),
                    EditorProjectSettingsId = settings[0].Id,
                    AccessModifier = AccessModifier.Public,
                    CompilerType = CompilerType.CoreCLR,
                    Language = Language.CSharp,
                    ProjectType = ProjectType.Console,
                    CountOfBuildAttempts = 10,
                    CountOfSaveBuilds = 10
                },
                new Project()
                {
                    Name = "ConsoleCalclator",
                    Description = "This project was created to use as simple calculator, so we wont need anything else near us, to sum, divide or multiply really huge numbers.",
                    AuthorId = users[2].Id,
                    Color = "#ff0000",
                    CreatedAt = DateTime.Now.AddDays(-12),
                    EditorProjectSettingsId = settings[1].Id,
                    AccessModifier = AccessModifier.Private,
                    CompilerType = CompilerType.CoreCLR,
                    Language = Language.CSharp,
                    ProjectType = ProjectType.Console,
                    CountOfBuildAttempts = 10,
                    CountOfSaveBuilds = 10
                }
            };
        }
        private static ProjectMember[] GenerateCorrectProjectMembers(Project[] projects, User[] users)
        {
            return new ProjectMember[]
            {
                new ProjectMember()
                {
                    ProjectId = projects[0].Id,
                    UserId = users[1].Id,
                    UserAccess = UserAccess.CanBuild
                },
                new ProjectMember()
                {
                    ProjectId = projects[0].Id,
                    UserId = users[2].Id,
                    UserAccess = UserAccess.CanRead
                },
                new ProjectMember()
                {
                    ProjectId = projects[1].Id,
                    UserId = users[1].Id,
                    UserAccess = UserAccess.CanBuild
                },
                new ProjectMember()
                {
                    ProjectId = projects[1].Id,
                    UserId = users[2].Id,
                    UserAccess = UserAccess.CanWrite
                },
                new ProjectMember()
                {
                    ProjectId = projects[2].Id,
                    UserId = users[1].Id,
                    UserAccess = UserAccess.CanBuild
                },
                new ProjectMember()
                {
                    ProjectId = projects[2].Id,
                    UserId = users[2].Id,
                    UserAccess = UserAccess.CanBuild
                },
                new ProjectMember()
                {
                    ProjectId = projects[3].Id,
                    UserId = users[0].Id,
                    UserAccess = UserAccess.CanBuild
                },
                new ProjectMember()
                {
                    ProjectId = projects[3].Id,
                    UserId = users[2].Id,
                    UserAccess = UserAccess.CanRun
                },
                new ProjectMember()
                {
                    ProjectId = projects[4].Id,
                    UserId = users[0].Id,
                    UserAccess = UserAccess.CanBuild
                },
                new ProjectMember()
                {
                    ProjectId = projects[5].Id,
                    UserId = users[0].Id,
                    UserAccess = UserAccess.CanBuild
                },
                new ProjectMember()
                {
                    ProjectId = projects[6].Id,
                    UserId = users[1].Id,
                    UserAccess = UserAccess.CanBuild
                },
                new ProjectMember()
                {
                    ProjectId = projects[7].Id,
                    UserId = users[1].Id,
                    UserAccess = UserAccess.CanBuild
                },
                new ProjectMember()
                {
                    ProjectId = projects[7].Id,
                    UserId = users[0].Id,
                    UserAccess = UserAccess.CanBuild
                },
            };
        }
        private static FavouriteProjects[] GenerateCorrectFavouriteProjects(Project[] projects, User[] users)
        {
            return new FavouriteProjects[]
            {
                new FavouriteProjects() //0
                {
                    ProjectId = projects[0].Id,
                    UserId = users[0].Id
                },
                new FavouriteProjects()
                {
                    ProjectId = projects[0].Id,
                    UserId = users[1].Id
                },
                new FavouriteProjects()
                {
                    ProjectId = projects[0].Id,
                    UserId = users[2].Id
                },
                new FavouriteProjects() //1
                {
                    ProjectId = projects[1].Id,
                    UserId = users[0].Id
                },
                new FavouriteProjects()
                {
                    ProjectId = projects[1].Id,
                    UserId = users[1].Id
                },
                new FavouriteProjects()
                {
                    ProjectId = projects[1].Id,
                    UserId = users[2].Id
                },
                new FavouriteProjects() //2
                {
                    ProjectId = projects[2].Id,
                    UserId = users[0].Id
                },
                new FavouriteProjects()
                {
                    ProjectId = projects[2].Id,
                    UserId = users[1].Id
                },
                new FavouriteProjects()
                {
                    ProjectId = projects[2].Id,
                    UserId = users[2].Id
                },
                new FavouriteProjects() //3
                {
                    ProjectId = projects[3].Id,
                    UserId = users[0].Id
                },
                new FavouriteProjects()
                {
                    ProjectId = projects[3].Id,
                    UserId = users[1].Id
                },
                new FavouriteProjects()
                {
                    ProjectId = projects[3].Id,
                    UserId = users[2].Id
                },
                new FavouriteProjects() //4
                {
                    ProjectId = projects[4].Id,
                    UserId = users[0].Id
                },
                new FavouriteProjects()
                {
                    ProjectId = projects[4].Id,
                    UserId = users[1].Id
                },
                new FavouriteProjects() //5
                {
                    ProjectId = projects[5].Id,
                    UserId = users[0].Id
                },

                new FavouriteProjects()
                {
                    ProjectId = projects[5].Id,
                    UserId = users[1].Id
                },
                new FavouriteProjects() //6
                {
                    ProjectId = projects[6].Id,
                    UserId = users[1].Id
                },
                new FavouriteProjects() //7
                {
                    ProjectId = projects[7].Id,
                    UserId = users[1].Id
                },
                new FavouriteProjects()
                {
                    ProjectId = projects[7].Id,
                    UserId = users[0].Id
                }
            };
        }

        private static void EnsureNoSqlDbSeeded(IFileStorageNoSqlDbSettings settings, ICollection<Project> projects)
        {
            IMongoCollection<ProjectStructure> projectStructureItems;
            IMongoCollection<File> filesItems;
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            var itemsCollectionName = GetProjectStructureItemsCollectionName();
            projectStructureItems = database.GetCollection<ProjectStructure>(itemsCollectionName);
            filesItems = database.GetCollection<File>(GetFileItemsCollectionName());

            foreach (var project in projects)
            {
                var fileStructure = new FileStructure()
                {
                    Id = Guid.NewGuid().ToString(),
                    Type = Common.ModelsDTO.Enums.TreeNodeType.Folder,
                    Details = "Project details",
                    Name = project.Name
                };
                File f1 = new File()
                {
                    Id = Guid.NewGuid().ToString("N").Substring(0, 24),
                    Name = "Program.cs",
                    Folder = project.Name,
                    CreatorId = 1,
                    ProjectId = project.Id,
                    CreatedAt = DateTime.Now,
                    Content = GetCSFileContent(project.Name),
                    Language = "csharp"
                };
                File f2 = new File()
                {
                    Id = Guid.NewGuid().ToString("N").Substring(0,24),
                    Name = project.Name + ".csproj",
                    Folder = project.Name,
                    CreatorId = 1,
                    ProjectId = project.Id,
                    CreatedAt = DateTime.Now,
                    Content = GetCSProjFileContent(),
                    Language = "xml"
                };
                fileStructure.NestedFiles.Add(new FileStructure()
                {
                    Id = f1.Id,
                    Name = "Program.cs",
                    Type = Common.ModelsDTO.Enums.TreeNodeType.File
                });
                fileStructure.NestedFiles.Add(new FileStructure()
                {
                    Id = f2.Id,
                    Name = project.Name + ".csproj",
                    Type = Common.ModelsDTO.Enums.TreeNodeType.File
                });

                var emptyStructure = new ProjectStructure();
                emptyStructure.Id = project.Id.ToString();
                emptyStructure.NestedFiles.Add(fileStructure);

                filesItems.InsertOne(f1);
                filesItems.InsertOne(f2);
                projectStructureItems.InsertOne(emptyStructure);
            }
        }

        private static string GetCSProjFileContent() => "<Project Sdk=\"Microsoft.NET.Sdk\">\n\n <PropertyGroup>\n    <OutputType>Exe</OutputType>\n" +
                                "    <TargetFramework>netcoreapp2.2</TargetFramework>\n  </PropertyGroup>\n\n</Project>";
        private static string GetCSFileContent(string projectName) => "using System;\n\nnamespace " + projectName + "\n{\n    class Program\n    {\n" +
                   "        static void Main(string[] args)\n        {\n            Console.WriteLine(\"Hello World!\");\n" +
                   "        }\n    }\n}\n";

        private static string GetProjectStructureItemsCollectionName()
        {
            var itemClassName = typeof(ProjectStructure).ToString().Split('.').Last();
            var itemsCollectionName = itemClassName.Pluralize();
            return itemsCollectionName;
        }
        private static string GetFileItemsCollectionName()
        {
            var itemClassName = typeof(File).ToString().Split('.').Last();
            var itemsCollectionName = itemClassName.Pluralize();
            return itemsCollectionName;
        }

        
        private static ICollection<Build> GenerateRandomBuilds(ICollection<User> users, ICollection<Project> projects)
        {
            var date = projects.OrderByDescending(p => p.CreatedAt).First().CreatedAt;
            var testBuildsFake = new Faker<Build>()
                .RuleFor(p => p.BuildFinished, f => f.Date.Between(date, DateTime.Now))
                .RuleFor(p => p.BuildMessage, f => f.Lorem.Sentence(10))
                .RuleFor(p => p.BuildStarted, f => f.Date.Between(date, DateTime.Now))
                .RuleFor(p => p.BuildStatus, f => f.PickRandom<BuildStatus>())
                .RuleFor(p => p.ProjectId, f => f.PickRandom(projects).Id)
                .RuleFor(p => p.UserId, f => f.PickRandom(users).Id);


            var generatedProjectMembers = testBuildsFake.Generate(ENTITY_COUNT * 2);

            return generatedProjectMembers;
        }
    }
}