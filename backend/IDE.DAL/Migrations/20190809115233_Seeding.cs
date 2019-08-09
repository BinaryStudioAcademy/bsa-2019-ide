using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IDE.DAL.Migrations
{
    public partial class Seeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "GitCredentials",
                columns: new[] { "Id", "Login", "PasswordHash", "PasswordSalt", "Provider", "Url" },
                values: new object[,]
                {
                    { 1, "Antoinette42", "FoLx0E2SvyMtkI2gtR4wkII+O890SFvqBOWEn/Zvqeo=", "1LBNk2cV7bgeTDj4e3ZuOgNcwv1HZape9UfT/6Y4X3E=", 0, "http://armando.net" },
                    { 19, "Leann_Jerde71", "0kkgeL6bCkZWVuy+ZHCK2gG+xSnSf9Tigh1o6Ykn/OE=", "N/+FZ0+b/u0XWBfl+kQU2c6d0z5AVvRZ+7wr32WgR5w=", 0, "http://scot.com" },
                    { 18, "Kassandra_Kemmer", "eNFc8H7NdqBo//xXn47WsnD71kJ43aYPQOg7EddM1so=", "o1d2kIffwwax196atvFbr3iNvGz/32PeFm7x9RxmsHI=", 1, "http://destiny.com" },
                    { 17, "Titus91", "af/daPvGEKmnAiYkVbqf2g9vrs5UcerPSStWgx4O8yU=", "ovuNc9in5GgWby4Eml6rZCuTbHhQZCpzKr+8HaEZAMI=", 0, "http://dwight.org" },
                    { 16, "Edna.Hahn77", "Rb2wkBHTugDVYj1c0sERs7V6y896twJTK0kvAYZXM3M=", "QsKmmqV0MTCjn4k7JI1uNhmKBY/rpovUes9JpfG95Wo=", 0, "https://ashlynn.biz" },
                    { 15, "Aylin61", "cCk6yaJa7YB3IDgnjgeBjjUmZk9FATUuGgM1zcfVHw8=", "YKKfpBjlzAMzvsTA5EIckGBuQ0ps6Wt+VulDPdFZNZQ=", 0, "https://briana.com" },
                    { 14, "Willis_Romaguera", "QqVHC8ru00/ayUoq7WdHjo4kH7GNZ7zZiRZFAdl/O+Y=", "hg23yenvU+76koD8/vmln0fyf7pBIrnI1XNFRVoWq/A=", 0, "https://bobbie.info" },
                    { 13, "Cassie34", "7mgmOiiBj5T6w0UYC0A2BGQHesog5hqPIRrOp1Hhxvc=", "2uSWR9FTZN9Vbzh3VU7HLuIZzwMx2DhQ8wt6L/C0DH0=", 1, "https://schuyler.org" },
                    { 12, "Jada97", "eRTfvuDcft+sKKLtVMYWGG4m4TqvKJ8y8qSPFLOM8Ik=", "/2q135IVYT4BxBSQtbztgTIpwMtNZku/aNgG+bHuuLk=", 0, "https://jannie.biz" },
                    { 11, "Samara23", "sUOTHytLYxiKTZAJndKzeLV4OyRSetTW/PAdKc5QoWA=", "hiJautuGx0P9Xb80WqPLrUpiE75Sy+8XtjomKm0avR8=", 2, "https://lamont.net" },
                    { 20, "Rosa_Haley", "XyIEElbH3HQM6h+04fP3dzPrLqIpcBr79JR97eQvV2w=", "S4RD1Y+lNM1WqYPiKAsx89sTef87XVBB7S1lYwzvtjk=", 0, "https://vivianne.net" },
                    { 9, "Brandi0", "Mdn3HNZnznFYgdJo1FSEUKS6JP+05Ez5XFdsFqY+1bY=", "vvNMkAMdaYmuPQjiOO8UetSQ28C2cOFW5D/ssu9XCms=", 2, "https://nathanial.info" },
                    { 8, "Adrain.Watsica", "GhulOqoskaI92DH1RL/xngc2YatNN0aMNPKfsZ3DOi4=", "7qinCo0k9A0cFwb11qOGE/JWKm7ouAhqrGL4gVqNYGE=", 0, "https://madisen.com" },
                    { 7, "Koby.Goyette14", "kB/hEEHlLDYHTekwlVtvDbAAr3eQ1pMAuHxLnZSs5/E=", "xRsWBLUdCXD8HLKVAeoWx1mE6N/TaioxK9/Om9VM99I=", 1, "http://mathew.com" },
                    { 6, "Zion34", "pfPMQEJDA9NrxJZTbEiwrZSclC6IT0teWBguA9V6YnY=", "B2dy5XIJ2S1JYvu3XwYV5k6LCu2kS2dPMsNMht/B2ko=", 0, "https://ryan.com" },
                    { 5, "Hester75", "pZDZiGUVHtVIA8VMcr03Pgp3Zmzhb4MaB/8t5W5zT3k=", "sfLAbCCiVRK9pyaD+RMik6PoGEM60ikBgwgX6M7NZZc=", 0, "http://destini.com" },
                    { 4, "Cassie_Kassulke10", "2PCzoalSUaXCDlF/8k91yf6HPmzKPutYhN05rPotIRw=", "H1zX+fI335EvNC2QTZkMNhESyN/TCfCeJA2FKcTjJMY=", 1, "https://connie.com" },
                    { 3, "Ian24", "X5+ZUMy+m5l1Uzt+M96rIusPwiaCai8MtoVAQts11TY=", "PORy8o9V7C/dQnYkTLYeKQXlKnqH1dgC022Rr+Cvkk4=", 2, "http://maximillia.biz" },
                    { 2, "Maribel.Bergstrom2", "nf5Qj4c8DBil/cT/jqIfmG7FMGM+LlmAtdw62jnL0RM=", "vMjmerM+M08pU6pPsBr7st4rydqtppY4e5z47936k8Y=", 2, "http://cyrus.info" },
                    { 10, "Vince_Schmeler56", "64jqCP6ahNssExpiBuNk7H52tGnCF0nR5kFzPG3zeVM=", "Cz16RCTWcXqLYQEw/hC81qdrn5bZoylPz1LhnITSGbk=", 1, "http://sim.info" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Url" },
                values: new object[,]
                {
                    { 12, "https://picsum.photos/640/480/?image=401" },
                    { 13, "https://picsum.photos/640/480/?image=577" },
                    { 14, "https://picsum.photos/640/480/?image=1033" },
                    { 18, "https://picsum.photos/640/480/?image=818" },
                    { 16, "https://picsum.photos/640/480/?image=53" },
                    { 17, "https://picsum.photos/640/480/?image=822" },
                    { 11, "https://picsum.photos/640/480/?image=125" },
                    { 15, "https://picsum.photos/640/480/?image=569" },
                    { 10, "https://picsum.photos/640/480/?image=516" },
                    { 6, "https://picsum.photos/640/480/?image=327" },
                    { 8, "https://picsum.photos/640/480/?image=967" },
                    { 7, "https://picsum.photos/640/480/?image=570" },
                    { 5, "https://picsum.photos/640/480/?image=920" },
                    { 4, "https://picsum.photos/640/480/?image=747" },
                    { 3, "https://picsum.photos/640/480/?image=320" },
                    { 2, "https://picsum.photos/640/480/?image=801" },
                    { 1, "https://picsum.photos/640/480/?image=708" },
                    { 19, "https://picsum.photos/640/480/?image=127" },
                    { 9, "https://picsum.photos/640/480/?image=379" },
                    { 20, "https://picsum.photos/640/480/?image=336" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AvatarId", "Birthday", "Email", "FirstName", "GitHubUrl", "LastActive", "LastName", "PasswordHash", "PasswordSalt", "RegisteredAt" },
                values: new object[] { 3, 1, new DateTime(2005, 8, 9, 14, 52, 32, 549, DateTimeKind.Local).AddTicks(1672), "test@gmail.com", "testUser", null, new DateTime(2019, 8, 9, 14, 52, 32, 549, DateTimeKind.Local).AddTicks(1693), "testUser", "nDTD8rc6+J+jdWxkvear98SjScUULQZoVgiIjKWRImY=", "cCYNcAyoUUvEGeYaaDXHcCF6o/JjfUIBUjeVa6zrnWw=", new DateTime(2019, 8, 9, 14, 52, 32, 549, DateTimeKind.Local).AddTicks(1698) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AvatarId", "Birthday", "Email", "FirstName", "GitHubUrl", "LastActive", "LastName", "PasswordHash", "PasswordSalt", "RegisteredAt" },
                values: new object[] { 2, 5, new DateTime(2016, 4, 2, 1, 25, 12, 680, DateTimeKind.Local).AddTicks(1011), "Keely.Orn56@gmail.com", "Stuart", "https://aileen.net", new DateTime(2019, 8, 9, 14, 52, 32, 536, DateTimeKind.Local).AddTicks(4095), "Hegmann", "I9gAvQllWWXBDFe5tL/ODCI7dwybxgmKNVOblYwcRXg=", "NPruXrCT44kyJuRoLs2vZw7G/jGRjj1URHrWDbogTZ4=", new DateTime(2019, 8, 9, 14, 52, 32, 536, DateTimeKind.Local).AddTicks(4085) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AvatarId", "Birthday", "Email", "FirstName", "GitHubUrl", "LastActive", "LastName", "PasswordHash", "PasswordSalt", "RegisteredAt" },
                values: new object[] { 1, 11, new DateTime(2005, 7, 27, 11, 17, 51, 342, DateTimeKind.Local).AddTicks(6360), "Alexie.Pfannerstill@hotmail.com", "Eli", "http://hassan.net", new DateTime(2019, 8, 9, 14, 52, 32, 474, DateTimeKind.Local).AddTicks(4318), "Bruen", "9uTPd7mj/z+SYU7XaaKToshH97UvpSBu2x73XIVl2bE=", "AwnD5Ti7RB6EnPN7oqPgWWFfg1XLUQF8A8+1FLTwVWY=", new DateTime(2019, 8, 9, 14, 52, 32, 474, DateTimeKind.Local).AddTicks(3527) });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "AccessModifier", "AuthorId", "CompilerType", "CountOfBuildAttempts", "CountOfSaveBuilds", "CreatedAt", "Description", "GitCredentialId", "Language", "LogoId", "Name", "ProjectLink", "ProjectType" },
                values: new object[,]
                {
                    { 3, 0, 3, 0, 5, 6, new DateTime(2019, 8, 9, 14, 52, 32, 703, DateTimeKind.Local).AddTicks(3850), "Ut tempora ea hic consequatur.", 13, 0, 7, "rerum", "https://mattie.biz", 1 },
                    { 14, 1, 1, 0, 6, 9, new DateTime(2019, 8, 9, 14, 52, 32, 703, DateTimeKind.Local).AddTicks(5002), "Et ut sed aliquam aperiam.", 10, 1, 10, "eos", "https://breanne.com", 1 },
                    { 11, 1, 1, 0, 8, 5, new DateTime(2019, 8, 9, 14, 52, 32, 703, DateTimeKind.Local).AddTicks(4673), "Et dolorem officia architecto at.", 16, 0, 18, "id", "https://dusty.info", 0 },
                    { 8, 1, 1, 0, 8, 6, new DateTime(2019, 8, 9, 14, 52, 32, 703, DateTimeKind.Local).AddTicks(4411), "Amet sit et eaque cupiditate.", 17, 0, 20, "dolor", "http://tiana.org", 1 },
                    { 6, 0, 1, 0, 5, 7, new DateTime(2019, 8, 9, 14, 52, 32, 703, DateTimeKind.Local).AddTicks(4205), "Suscipit laborum at nisi sapiente.", 18, 0, 1, "omnis", "http://nils.biz", 1 },
                    { 2, 1, 1, 0, 6, 5, new DateTime(2019, 8, 9, 14, 52, 32, 703, DateTimeKind.Local).AddTicks(3347), "Non quisquam ipsam sapiente non.", 18, 0, 3, "voluptas", "https://mario.org", 2 },
                    { 17, 1, 2, 0, 6, 5, new DateTime(2019, 8, 9, 14, 52, 32, 703, DateTimeKind.Local).AddTicks(5285), "Unde nesciunt iusto totam illo.", 1, 1, 3, "non", "http://alivia.net", 0 },
                    { 9, 0, 2, 0, 8, 8, new DateTime(2019, 8, 9, 14, 52, 32, 703, DateTimeKind.Local).AddTicks(4503), "Soluta iste vero sit maxime.", 11, 0, 16, "odio", "https://garrick.org", 2 },
                    { 5, 0, 2, 0, 10, 5, new DateTime(2019, 8, 9, 14, 52, 32, 703, DateTimeKind.Local).AddTicks(4113), "Cum in voluptates soluta officiis.", 4, 1, 11, "esse", "https://dejuan.com", 1 },
                    { 4, 1, 2, 0, 9, 8, new DateTime(2019, 8, 9, 14, 52, 32, 703, DateTimeKind.Local).AddTicks(3969), "Voluptatem rerum reiciendis minus quis.", 1, 1, 19, "deleniti", "http://kayla.org", 0 },
                    { 1, 1, 2, 0, 6, 8, new DateTime(2019, 8, 9, 14, 52, 32, 697, DateTimeKind.Local).AddTicks(7212), "Animi quas animi cumque consequuntur.", 17, 1, 4, "molestiae", "http://tia.org", 2 },
                    { 20, 0, 3, 0, 8, 8, new DateTime(2019, 8, 9, 14, 52, 32, 703, DateTimeKind.Local).AddTicks(5557), "Ut iure minus voluptates quo.", 17, 0, 6, "consectetur", "https://neva.info", 2 },
                    { 18, 0, 3, 0, 5, 7, new DateTime(2019, 8, 9, 14, 52, 32, 703, DateTimeKind.Local).AddTicks(5403), "Molestias dolor at neque molestiae.", 11, 1, 5, "omnis", "https://torrey.info", 1 },
                    { 16, 0, 3, 0, 9, 8, new DateTime(2019, 8, 9, 14, 52, 32, 703, DateTimeKind.Local).AddTicks(5197), "Dolorem quidem rem corporis laboriosam.", 2, 0, 8, "aspernatur", "https://janiya.com", 2 },
                    { 13, 0, 3, 0, 10, 5, new DateTime(2019, 8, 9, 14, 52, 32, 703, DateTimeKind.Local).AddTicks(4915), "Necessitatibus quas et ullam provident.", 10, 0, 5, "dolores", "http://marguerite.org", 1 },
                    { 12, 0, 3, 0, 7, 10, new DateTime(2019, 8, 9, 14, 52, 32, 703, DateTimeKind.Local).AddTicks(4832), "Dolores placeat sed vitae delectus.", 7, 0, 8, "quibusdam", "https://noe.net", 2 },
                    { 10, 0, 3, 0, 6, 7, new DateTime(2019, 8, 9, 14, 52, 32, 703, DateTimeKind.Local).AddTicks(4591), "Culpa et inventore non ex.", 16, 0, 9, "dolores", "https://webster.name", 2 },
                    { 7, 0, 3, 0, 9, 6, new DateTime(2019, 8, 9, 14, 52, 32, 703, DateTimeKind.Local).AddTicks(4303), "Est qui assumenda omnis facere.", 17, 1, 9, "est", "http://lavern.biz", 1 },
                    { 15, 1, 1, 0, 5, 10, new DateTime(2019, 8, 9, 14, 52, 32, 703, DateTimeKind.Local).AddTicks(5115), "Dicta adipisci numquam maxime repudiandae.", 15, 0, 1, "nobis", "https://donato.com", 2 },
                    { 19, 1, 1, 0, 8, 8, new DateTime(2019, 8, 9, 14, 52, 32, 703, DateTimeKind.Local).AddTicks(5480), "Sit ex culpa laudantium quos.", 5, 1, 4, "ut", "http://marlene.com", 0 }
                });

            migrationBuilder.InsertData(
                table: "Builds",
                columns: new[] { "Id", "BuildFinished", "BuildMessage", "BuildStarted", "BuildStatus", "ProjectId", "UserId" },
                values: new object[,]
                {
                    { 7, new DateTime(2019, 8, 9, 14, 52, 32, 713, DateTimeKind.Local).AddTicks(6513), "Ipsam perspiciatis aperiam et perferendis modi ullam dicta et et.", new DateTime(2019, 8, 9, 14, 52, 32, 713, DateTimeKind.Local).AddTicks(6554), 0, 3, 3 },
                    { 19, new DateTime(2019, 8, 9, 14, 52, 32, 713, DateTimeKind.Local).AddTicks(7278), "Molestiae culpa omnis facere totam ut temporibus quasi corporis et.", new DateTime(2019, 8, 9, 14, 52, 32, 713, DateTimeKind.Local).AddTicks(7314), 1, 20, 1 },
                    { 13, new DateTime(2019, 8, 9, 14, 52, 32, 713, DateTimeKind.Local).AddTicks(6883), "Tenetur est similique sit quos quo deserunt quod eveniet dolores.", new DateTime(2019, 8, 9, 14, 52, 32, 713, DateTimeKind.Local).AddTicks(6914), 0, 11, 2 },
                    { 33, new DateTime(2019, 8, 9, 14, 52, 32, 713, DateTimeKind.Local).AddTicks(8111), "Fugiat dolorum suscipit sint quos sed quibusdam eos voluptate nam.", new DateTime(2019, 8, 9, 14, 52, 32, 713, DateTimeKind.Local).AddTicks(8142), 1, 1, 3 },
                    { 30, new DateTime(2019, 8, 9, 14, 52, 32, 713, DateTimeKind.Local).AddTicks(7921), "Eos numquam hic consequatur non quidem id aut similique cum.", new DateTime(2019, 8, 9, 14, 52, 32, 713, DateTimeKind.Local).AddTicks(7983), 0, 8, 1 },
                    { 14, new DateTime(2019, 8, 9, 14, 52, 32, 713, DateTimeKind.Local).AddTicks(6971), "Nihil tempora necessitatibus ea quos iusto deleniti est voluptatum quia.", new DateTime(2019, 8, 9, 14, 52, 32, 713, DateTimeKind.Local).AddTicks(7016), 1, 8, 1 },
                    { 1, new DateTime(2019, 8, 9, 14, 52, 32, 710, DateTimeKind.Local).AddTicks(3937), "Sed possimus exercitationem magnam tempore et quae quis quidem quia.", new DateTime(2019, 8, 9, 14, 52, 32, 711, DateTimeKind.Local).AddTicks(1448), 0, 4, 2 },
                    { 18, new DateTime(2019, 8, 9, 14, 52, 32, 713, DateTimeKind.Local).AddTicks(7222), "Dignissimos porro quia et voluptate voluptatem voluptates ipsum praesentium tempore.", new DateTime(2019, 8, 9, 14, 52, 32, 713, DateTimeKind.Local).AddTicks(7258), 1, 4, 1 },
                    { 40, new DateTime(2019, 8, 9, 14, 52, 32, 713, DateTimeKind.Local).AddTicks(8579), "Odit sequi aliquid odit voluptates ea quia esse dolorem vel.", new DateTime(2019, 8, 9, 14, 52, 32, 713, DateTimeKind.Local).AddTicks(8605), 1, 4, 2 },
                    { 27, new DateTime(2019, 8, 9, 14, 52, 32, 713, DateTimeKind.Local).AddTicks(7767), "Nihil corporis et accusamus quia rerum fuga laborum beatae minima.", new DateTime(2019, 8, 9, 14, 52, 32, 713, DateTimeKind.Local).AddTicks(7798), 0, 19, 3 },
                    { 3, new DateTime(2019, 8, 9, 14, 52, 32, 713, DateTimeKind.Local).AddTicks(6205), "Quod aut incidunt accusantium odit iusto sapiente corrupti voluptatem laboriosam.", new DateTime(2019, 8, 9, 14, 52, 32, 713, DateTimeKind.Local).AddTicks(6256), 0, 5, 1 },
                    { 28, new DateTime(2019, 8, 9, 14, 52, 32, 713, DateTimeKind.Local).AddTicks(7818), "Consectetur maiores et aut ea rerum porro sed similique dolorem.", new DateTime(2019, 8, 9, 14, 52, 32, 713, DateTimeKind.Local).AddTicks(7849), 0, 5, 1 },
                    { 29, new DateTime(2019, 8, 9, 14, 52, 32, 713, DateTimeKind.Local).AddTicks(7870), "Corrupti ipsum quas amet aperiam provident accusamus nam sequi consectetur.", new DateTime(2019, 8, 9, 14, 52, 32, 713, DateTimeKind.Local).AddTicks(7900), 0, 5, 1 },
                    { 2, new DateTime(2019, 8, 9, 14, 52, 32, 713, DateTimeKind.Local).AddTicks(5845), "Provident praesentium aliquam laudantium quo ut architecto molestias non ut.", new DateTime(2019, 8, 9, 14, 52, 32, 713, DateTimeKind.Local).AddTicks(5953), 1, 6, 2 },
                    { 11, new DateTime(2019, 8, 9, 14, 52, 32, 713, DateTimeKind.Local).AddTicks(6770), "Aut earum voluptatem et doloremque esse molestias dolores rem vel.", new DateTime(2019, 8, 9, 14, 52, 32, 713, DateTimeKind.Local).AddTicks(6806), 1, 9, 3 },
                    { 37, new DateTime(2019, 8, 9, 14, 52, 32, 713, DateTimeKind.Local).AddTicks(8389), "Velit voluptas non illum inventore occaecati eum laborum et amet.", new DateTime(2019, 8, 9, 14, 52, 32, 713, DateTimeKind.Local).AddTicks(8420), 1, 2, 3 },
                    { 21, new DateTime(2019, 8, 9, 14, 52, 32, 713, DateTimeKind.Local).AddTicks(7386), "Ut architecto sit dolorem et nihil exercitationem enim nostrum ab.", new DateTime(2019, 8, 9, 14, 52, 32, 713, DateTimeKind.Local).AddTicks(7422), 1, 2, 2 },
                    { 12, new DateTime(2019, 8, 9, 14, 52, 32, 713, DateTimeKind.Local).AddTicks(6827), "Consectetur et praesentium ut illum illum nisi voluptatum laboriosam soluta.", new DateTime(2019, 8, 9, 14, 52, 32, 713, DateTimeKind.Local).AddTicks(6863), 1, 17, 3 },
                    { 24, new DateTime(2019, 8, 9, 14, 52, 32, 713, DateTimeKind.Local).AddTicks(7577), "Aut nobis doloremque omnis assumenda blanditiis aperiam aliquam id fugiat.", new DateTime(2019, 8, 9, 14, 52, 32, 713, DateTimeKind.Local).AddTicks(7607), 0, 17, 3 },
                    { 25, new DateTime(2019, 8, 9, 14, 52, 32, 713, DateTimeKind.Local).AddTicks(7628), "Qui est id autem maiores vero quos dolor aut veniam.", new DateTime(2019, 8, 9, 14, 52, 32, 713, DateTimeKind.Local).AddTicks(7659), 0, 17, 2 },
                    { 38, new DateTime(2019, 8, 9, 14, 52, 32, 713, DateTimeKind.Local).AddTicks(8440), "Est quidem magni nihil similique non eos quibusdam recusandae dolorem.", new DateTime(2019, 8, 9, 14, 52, 32, 713, DateTimeKind.Local).AddTicks(8502), 0, 17, 1 },
                    { 34, new DateTime(2019, 8, 9, 14, 52, 32, 713, DateTimeKind.Local).AddTicks(8173), "Sit officia voluptatem cum omnis voluptas sint nobis perferendis error.", new DateTime(2019, 8, 9, 14, 52, 32, 713, DateTimeKind.Local).AddTicks(8265), 1, 11, 3 },
                    { 16, new DateTime(2019, 8, 9, 14, 52, 32, 713, DateTimeKind.Local).AddTicks(7088), "Aut consequatur dolores exercitationem non quam consequatur esse fugit sed.", new DateTime(2019, 8, 9, 14, 52, 32, 713, DateTimeKind.Local).AddTicks(7124), 1, 20, 1 },
                    { 31, new DateTime(2019, 8, 9, 14, 52, 32, 713, DateTimeKind.Local).AddTicks(8008), "Consequuntur quia fugit eos voluptatum ratione facilis a praesentium qui.", new DateTime(2019, 8, 9, 14, 52, 32, 713, DateTimeKind.Local).AddTicks(8044), 0, 18, 1 },
                    { 15, new DateTime(2019, 8, 9, 14, 52, 32, 713, DateTimeKind.Local).AddTicks(7037), "Et qui natus assumenda quaerat deserunt qui beatae praesentium illum.", new DateTime(2019, 8, 9, 14, 52, 32, 713, DateTimeKind.Local).AddTicks(7073), 1, 10, 1 },
                    { 23, new DateTime(2019, 8, 9, 14, 52, 32, 713, DateTimeKind.Local).AddTicks(7525), "Id aut consectetur blanditiis corrupti nam rerum possimus cumque porro.", new DateTime(2019, 8, 9, 14, 52, 32, 713, DateTimeKind.Local).AddTicks(7556), 0, 10, 3 },
                    { 39, new DateTime(2019, 8, 9, 14, 52, 32, 713, DateTimeKind.Local).AddTicks(8528), "Ullam excepturi et sint molestiae id sit a ducimus sed.", new DateTime(2019, 8, 9, 14, 52, 32, 713, DateTimeKind.Local).AddTicks(8558), 0, 10, 3 },
                    { 35, new DateTime(2019, 8, 9, 14, 52, 32, 713, DateTimeKind.Local).AddTicks(8286), "In laborum debitis ipsam cumque eos vel culpa enim voluptatem.", new DateTime(2019, 8, 9, 14, 52, 32, 713, DateTimeKind.Local).AddTicks(8317), 1, 11, 3 },
                    { 10, new DateTime(2019, 8, 9, 14, 52, 32, 713, DateTimeKind.Local).AddTicks(6714), "Eum nemo consequuntur rerum error nam labore nemo id asperiores.", new DateTime(2019, 8, 9, 14, 52, 32, 713, DateTimeKind.Local).AddTicks(6750), 1, 19, 1 },
                    { 9, new DateTime(2019, 8, 9, 14, 52, 32, 713, DateTimeKind.Local).AddTicks(6631), "Facere atque in sint omnis consequatur beatae ex dolorem molestiae.", new DateTime(2019, 8, 9, 14, 52, 32, 713, DateTimeKind.Local).AddTicks(6693), 0, 15, 1 },
                    { 6, new DateTime(2019, 8, 9, 14, 52, 32, 713, DateTimeKind.Local).AddTicks(6451), "Aut numquam et vel sed magnam et dolorum repellat sed.", new DateTime(2019, 8, 9, 14, 52, 32, 713, DateTimeKind.Local).AddTicks(6493), 0, 19, 1 },
                    { 4, new DateTime(2019, 8, 9, 14, 52, 32, 713, DateTimeKind.Local).AddTicks(6292), "Labore sed tempora mollitia et quos qui atque nemo repellat.", new DateTime(2019, 8, 9, 14, 52, 32, 713, DateTimeKind.Local).AddTicks(6333), 0, 15, 1 },
                    { 5, new DateTime(2019, 8, 9, 14, 52, 32, 713, DateTimeKind.Local).AddTicks(6354), "Sint enim quis consequatur cupiditate atque aut sequi neque eaque.", new DateTime(2019, 8, 9, 14, 52, 32, 713, DateTimeKind.Local).AddTicks(6431), 0, 13, 1 },
                    { 26, new DateTime(2019, 8, 9, 14, 52, 32, 713, DateTimeKind.Local).AddTicks(7679), "Necessitatibus quia repellendus excepturi et possimus nam quis in sunt.", new DateTime(2019, 8, 9, 14, 52, 32, 713, DateTimeKind.Local).AddTicks(7746), 0, 19, 1 },
                    { 32, new DateTime(2019, 8, 9, 14, 52, 32, 713, DateTimeKind.Local).AddTicks(8060), "Dolorum eaque et aperiam quibusdam ut omnis nostrum consequatur quas.", new DateTime(2019, 8, 9, 14, 52, 32, 713, DateTimeKind.Local).AddTicks(8091), 0, 16, 3 },
                    { 36, new DateTime(2019, 8, 9, 14, 52, 32, 713, DateTimeKind.Local).AddTicks(8337), "Et explicabo eum numquam autem sint sit vitae rerum amet.", new DateTime(2019, 8, 9, 14, 52, 32, 713, DateTimeKind.Local).AddTicks(8373), 0, 3, 3 },
                    { 17, new DateTime(2019, 8, 9, 14, 52, 32, 713, DateTimeKind.Local).AddTicks(7145), "Quis quia voluptatem voluptatum sint quisquam harum ipsam pariatur aut.", new DateTime(2019, 8, 9, 14, 52, 32, 713, DateTimeKind.Local).AddTicks(7176), 0, 3, 3 },
                    { 20, new DateTime(2019, 8, 9, 14, 52, 32, 713, DateTimeKind.Local).AddTicks(7335), "Nulla qui aut consequuntur et hic ipsum illo aut sunt.", new DateTime(2019, 8, 9, 14, 52, 32, 713, DateTimeKind.Local).AddTicks(7366), 0, 18, 3 },
                    { 22, new DateTime(2019, 8, 9, 14, 52, 32, 713, DateTimeKind.Local).AddTicks(7443), "Numquam suscipit consequatur qui eius molestias quaerat aut voluptatum dicta.", new DateTime(2019, 8, 9, 14, 52, 32, 713, DateTimeKind.Local).AddTicks(7505), 0, 7, 3 },
                    { 8, new DateTime(2019, 8, 9, 14, 52, 32, 713, DateTimeKind.Local).AddTicks(6575), "Sint dolore itaque architecto et ipsum doloribus pariatur est sint.", new DateTime(2019, 8, 9, 14, 52, 32, 713, DateTimeKind.Local).AddTicks(6611), 1, 19, 3 }
                });

            migrationBuilder.InsertData(
                table: "ProjectMembers",
                columns: new[] { "ProjectId", "UserId", "UserAccess" },
                values: new object[,]
                {
                    { 15, 2, 1 },
                    { 6, 1, 3 },
                    { 14, 3, 1 },
                    { 8, 3, 3 },
                    { 11, 2, 2 },
                    { 15, 3, 3 },
                    { 17, 1, 0 },
                    { 4, 2, 1 },
                    { 9, 2, 0 },
                    { 3, 3, 1 },
                    { 7, 3, 3 },
                    { 7, 2, 2 },
                    { 7, 1, 3 },
                    { 10, 1, 3 },
                    { 10, 2, 0 },
                    { 12, 1, 2 },
                    { 12, 3, 0 },
                    { 13, 3, 3 },
                    { 16, 1, 3 },
                    { 18, 3, 1 },
                    { 18, 1, 2 },
                    { 20, 3, 0 },
                    { 20, 1, 2 },
                    { 1, 3, 0 },
                    { 1, 1, 0 },
                    { 1, 2, 0 },
                    { 5, 2, 2 },
                    { 9, 3, 1 },
                    { 17, 3, 3 },
                    { 19, 1, 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "ProjectMembers",
                keyColumns: new[] { "ProjectId", "UserId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "ProjectMembers",
                keyColumns: new[] { "ProjectId", "UserId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "ProjectMembers",
                keyColumns: new[] { "ProjectId", "UserId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "ProjectMembers",
                keyColumns: new[] { "ProjectId", "UserId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "ProjectMembers",
                keyColumns: new[] { "ProjectId", "UserId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "ProjectMembers",
                keyColumns: new[] { "ProjectId", "UserId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "ProjectMembers",
                keyColumns: new[] { "ProjectId", "UserId" },
                keyValues: new object[] { 6, 1 });

            migrationBuilder.DeleteData(
                table: "ProjectMembers",
                keyColumns: new[] { "ProjectId", "UserId" },
                keyValues: new object[] { 7, 1 });

            migrationBuilder.DeleteData(
                table: "ProjectMembers",
                keyColumns: new[] { "ProjectId", "UserId" },
                keyValues: new object[] { 7, 2 });

            migrationBuilder.DeleteData(
                table: "ProjectMembers",
                keyColumns: new[] { "ProjectId", "UserId" },
                keyValues: new object[] { 7, 3 });

            migrationBuilder.DeleteData(
                table: "ProjectMembers",
                keyColumns: new[] { "ProjectId", "UserId" },
                keyValues: new object[] { 8, 3 });

            migrationBuilder.DeleteData(
                table: "ProjectMembers",
                keyColumns: new[] { "ProjectId", "UserId" },
                keyValues: new object[] { 9, 2 });

            migrationBuilder.DeleteData(
                table: "ProjectMembers",
                keyColumns: new[] { "ProjectId", "UserId" },
                keyValues: new object[] { 9, 3 });

            migrationBuilder.DeleteData(
                table: "ProjectMembers",
                keyColumns: new[] { "ProjectId", "UserId" },
                keyValues: new object[] { 10, 1 });

            migrationBuilder.DeleteData(
                table: "ProjectMembers",
                keyColumns: new[] { "ProjectId", "UserId" },
                keyValues: new object[] { 10, 2 });

            migrationBuilder.DeleteData(
                table: "ProjectMembers",
                keyColumns: new[] { "ProjectId", "UserId" },
                keyValues: new object[] { 11, 2 });

            migrationBuilder.DeleteData(
                table: "ProjectMembers",
                keyColumns: new[] { "ProjectId", "UserId" },
                keyValues: new object[] { 12, 1 });

            migrationBuilder.DeleteData(
                table: "ProjectMembers",
                keyColumns: new[] { "ProjectId", "UserId" },
                keyValues: new object[] { 12, 3 });

            migrationBuilder.DeleteData(
                table: "ProjectMembers",
                keyColumns: new[] { "ProjectId", "UserId" },
                keyValues: new object[] { 13, 3 });

            migrationBuilder.DeleteData(
                table: "ProjectMembers",
                keyColumns: new[] { "ProjectId", "UserId" },
                keyValues: new object[] { 14, 3 });

            migrationBuilder.DeleteData(
                table: "ProjectMembers",
                keyColumns: new[] { "ProjectId", "UserId" },
                keyValues: new object[] { 15, 2 });

            migrationBuilder.DeleteData(
                table: "ProjectMembers",
                keyColumns: new[] { "ProjectId", "UserId" },
                keyValues: new object[] { 15, 3 });

            migrationBuilder.DeleteData(
                table: "ProjectMembers",
                keyColumns: new[] { "ProjectId", "UserId" },
                keyValues: new object[] { 16, 1 });

            migrationBuilder.DeleteData(
                table: "ProjectMembers",
                keyColumns: new[] { "ProjectId", "UserId" },
                keyValues: new object[] { 17, 1 });

            migrationBuilder.DeleteData(
                table: "ProjectMembers",
                keyColumns: new[] { "ProjectId", "UserId" },
                keyValues: new object[] { 17, 3 });

            migrationBuilder.DeleteData(
                table: "ProjectMembers",
                keyColumns: new[] { "ProjectId", "UserId" },
                keyValues: new object[] { 18, 1 });

            migrationBuilder.DeleteData(
                table: "ProjectMembers",
                keyColumns: new[] { "ProjectId", "UserId" },
                keyValues: new object[] { 18, 3 });

            migrationBuilder.DeleteData(
                table: "ProjectMembers",
                keyColumns: new[] { "ProjectId", "UserId" },
                keyValues: new object[] { 19, 1 });

            migrationBuilder.DeleteData(
                table: "ProjectMembers",
                keyColumns: new[] { "ProjectId", "UserId" },
                keyValues: new object[] { 20, 1 });

            migrationBuilder.DeleteData(
                table: "ProjectMembers",
                keyColumns: new[] { "ProjectId", "UserId" },
                keyValues: new object[] { 20, 3 });

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 11);
        }
    }
}
