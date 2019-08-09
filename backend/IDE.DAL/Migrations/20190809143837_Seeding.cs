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
                    { 1, "Soledad_Pfeffer24", "zgiQ+MpZcpo5TgV/EF8Dd8tu45bvAfIBGs0JHRv9GCg=", "UcVFYNQfJRkkuluC4m6+LGPnNMEkJg39Xyy1DPKQba8=", 2, "http://anne.info" },
                    { 20, "Ransom.Nitzsche", "YBv0ClxhAIbS6LOYUH9QkYqEQXjLIJFNeXZeAzzrQs8=", "ADN+6xvgmFYhv61Pa0ROrC59S3zjUusov/PWlFsI+58=", 2, "https://adrain.net" },
                    { 19, "Brannon52", "xHTbp3buUfw7EVPXOFq/Y5ioZy9CcqWynbqn/QgKQ8E=", "kuZoQytRoNRtalhf5REsaHiRF0+XMElHMpNX5ZsH8r4=", 0, "http://roman.info" },
                    { 18, "Luis_Hyatt", "fPErDRxfJh6qmeswS8wAXIMBjnYxcrKYfXe5h8vhQSY=", "Inj12yc8mF+melzlTROxiwzv+mtNwAfh0n/wmDN6d6o=", 0, "http://estel.com" },
                    { 17, "Leora13", "Q9F6k0qupSGrabboaCkLpfuZEfyF7f5dCorFa7vn3RM=", "kFgO0XZWBDzaBYQx4h3MNPQ6ZjdTPrL9xvExqJQyz4M=", 1, "http://kaleigh.net" },
                    { 16, "Nia24", "ww8rpxzI4Cqhhtzli4lsFbnMMYwLP354/HfgFxPWHeE=", "sOmsi1W6KSD9lCkjHOaTuV5ind1agApzY4S4PEh4Gt4=", 0, "https://rosalia.info" },
                    { 14, "Briana83", "BNCLX14i7szfa+XCbJyG99wgwSeG2EiXapdX6PhoGu4=", "lLKLIGwwz9D8+0tmOMCpCp2l353G81ZEaUbNJH7Tda0=", 0, "http://keenan.org" },
                    { 13, "Jonathan_Cartwright", "AlRUlZQlw7xbI09IlTo7YukrI9TSS+0w8iUFGO+LYHo=", "livk4D56cTBFexxNbJudswStEa1wQyUWKWeVpYLvgTI=", 2, "https://ethelyn.info" },
                    { 12, "Nyasia_Fadel", "gkGjQTUQH8ogFNXVTSvW1BjkoTEfmjlTkdBDo8FL1mI=", "85SKqk3ZUr/knmaFRqy74fdOY9nwbKdwBw+aPLtjs/E=", 2, "https://dawn.net" },
                    { 11, "Mohamed34", "NRxTIealqDiEs2/sLICArOzk7JcVADGXNKBlL05s4RI=", "QgOW4SfQ4M8zvWCJGQhN2YLQwjGXy5KAkd+uFLB7TbA=", 2, "https://jordan.name" },
                    { 15, "Zetta28", "TkAMNOYHVwsakszvFr2xacfUKzofhJM06SANrz0PMDI=", "T0t3+VkiruPi4759YyXRwraV3icCT3iaU5mAYz5Lxtw=", 0, "https://felipe.name" },
                    { 9, "Freida_Rogahn", "q9JuN4RcwkwcII69quk8y8XxWWjn8IwTORmX7Eyg5A4=", "AFIic/GKqCn3WZnA/Yx1WdcyrEVeYuyVCRlL8CZFVog=", 0, "https://shaylee.info" },
                    { 8, "Aditya_Mueller5", "Sym6oPAbeZq4WwNRNCEtRvx4PIY37hprDoKBaLT4+6w=", "5baTgBdktrOp8n7hz0hooZLgbqTbU7iD3HO29xlojH8=", 0, "http://loren.name" },
                    { 7, "Arnoldo.Yost", "exdgShdBlYf+WhMUR6bQ+GVG/xBHHdTukrFSzk5GwJc=", "U+XrtnNwSfOoV6/wIecZRSUSnXUDR7uoZ/AOYbHDCBY=", 2, "https://julie.com" },
                    { 6, "Carrie.Spinka64", "dxv7wIMbMNOUrIn5i/uUwk59zL/lGwKnWnEtTcDQJkM=", "t9YupSt6ejALt+pbPJ+a8bMFu3nf3709EH9O8j9nzWs=", 2, "http://mireya.biz" },
                    { 5, "Cordie2", "4BfSukoVcpl9Aqc98aDX93YmmJ1ppS3vPheih3VJaGo=", "RYSeRH79z4UKPCXmZANXqbxKdGiofqVZyUe17iXHNrA=", 1, "http://jevon.name" },
                    { 4, "Ebba_Ortiz53", "xf8pZozFzmtrOaDy4+E/Jte+3fFDBVeB0BQwb9XHBXw=", "cW7kBeejcWaCzdzbgcwVzi/BTv2F36WS3s9ZQ7a3Grg=", 0, "http://rick.info" },
                    { 3, "Alison_Kovacek", "0DDmOyOIMgkGvTTJHZ9xta+BDqUpeSo0nn+LnW/HAq4=", "tE7ZE2pBffmbiwX96Zs36BjHNdHrGgMbqaRSNbErowg=", 1, "http://cedrick.org" },
                    { 2, "Maynard.Haley", "D70nYsNWdA4QaJAKgV7fM2Yv04FAzu6YA/MAWNuTBW4=", "U01NvULQdz/hiA5OBRXBnufY0M8SgRZYh8ccWXpIQ+8=", 2, "http://estelle.net" },
                    { 10, "Patrick_Pouros", "rWUxcY3qsU30FPLaS1Pib5zFUx8Gr4TNxd9p748nKPA=", "Nyn7b+IbU8c7xlGDfhnqb+8OKBhuiNIK19ivgkN8m18=", 1, "http://dawson.info" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Url" },
                values: new object[,]
                {
                    { 14, "https://loremflickr.com/640/480?lock=2045055810" },
                    { 15, "https://loremflickr.com/640/480?lock=1126424437" },
                    { 16, "https://loremflickr.com/640/480?lock=105575879" },
                    { 17, "https://loremflickr.com/640/480?lock=1627246728" },
                    { 21, "https://loremflickr.com/640/480?lock=2009551175" },
                    { 19, "https://loremflickr.com/640/480?lock=251969388" },
                    { 20, "https://loremflickr.com/640/480?lock=666130004" },
                    { 13, "https://loremflickr.com/640/480?lock=1143379573" },
                    { 18, "https://loremflickr.com/640/480?lock=1619135858" },
                    { 12, "https://loremflickr.com/640/480?lock=795639316" },
                    { 2, "https://s3.amazonaws.com/uifaces/faces/twitter/normanbox/128.jpg" },
                    { 10, "https://loremflickr.com/640/480?lock=1022100058" },
                    { 9, "https://loremflickr.com/640/480?lock=750228139" },
                    { 8, "https://loremflickr.com/640/480?lock=1915200731" },
                    { 7, "https://loremflickr.com/640/480?lock=1129885050" },
                    { 6, "https://loremflickr.com/640/480?lock=647665779" },
                    { 5, "https://loremflickr.com/640/480?lock=1822844665" },
                    { 4, "https://loremflickr.com/640/480?lock=1480224036" },
                    { 3, "https://s3.amazonaws.com/uifaces/faces/twitter/digitalmaverick/128.jpg" },
                    { 22, "https://loremflickr.com/640/480?lock=639109103" },
                    { 1, "https://s3.amazonaws.com/uifaces/faces/twitter/imammuht/128.jpg" },
                    { 11, "https://loremflickr.com/640/480?lock=249167178" },
                    { 23, "https://loremflickr.com/640/480?lock=245164000" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AvatarId", "Birthday", "Email", "FirstName", "GitHubUrl", "LastActive", "LastName", "NickName", "PasswordHash", "PasswordSalt", "RegisteredAt" },
                values: new object[] { 3, 1, new DateTime(2005, 8, 9, 17, 38, 36, 425, DateTimeKind.Local).AddTicks(2510), "test@gmail.com", "testUser", null, new DateTime(2019, 8, 9, 17, 38, 36, 425, DateTimeKind.Local).AddTicks(2541), "testUser", null, "4WeLPDrDhomjXFSH/cnp839qu5HKfW1LDvCss5oBttQ=", "7585mBdsT9MzwnDQajiKzUiPGMwWDqhHGulF+KtPjuo=", new DateTime(2019, 8, 9, 17, 38, 36, 425, DateTimeKind.Local).AddTicks(2546) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AvatarId", "Birthday", "Email", "FirstName", "GitHubUrl", "LastActive", "LastName", "NickName", "PasswordHash", "PasswordSalt", "RegisteredAt" },
                values: new object[] { 1, 2, new DateTime(2012, 3, 18, 3, 46, 49, 194, DateTimeKind.Local).AddTicks(7887), "Berniece90@yahoo.com", "Hassan", "https://luisa.biz", new DateTime(2019, 8, 9, 17, 38, 36, 339, DateTimeKind.Local).AddTicks(1141), "Runolfsdottir", "Nichole.Aufderhar35", "ixLMaVg872GUeDwhSKb0C2554ghwbVKLb7McwV4di8s=", "k/QVpbeac6UgC6088iO6pJWuoGrhgHz8uYqKJGP3dsg=", new DateTime(2019, 8, 9, 17, 38, 36, 338, DateTimeKind.Local).AddTicks(9568) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AvatarId", "Birthday", "Email", "FirstName", "GitHubUrl", "LastActive", "LastName", "NickName", "PasswordHash", "PasswordSalt", "RegisteredAt" },
                values: new object[] { 2, 2, new DateTime(2010, 3, 28, 18, 35, 20, 298, DateTimeKind.Local).AddTicks(1904), "Rachelle.Bernier@gmail.com", "Princess", "http://keshaun.org", new DateTime(2019, 8, 9, 17, 38, 36, 411, DateTimeKind.Local).AddTicks(2527), "Goodwin", "Ericka_Bruen", "DlvBFwsO4v3Nk8mXhWOPN7moHfwsIO+8d/WmoQ4GQZY=", "i+FQKNE6aN9PozlAJ47CkdIr21piqOnPibq7xBrsQ4s=", new DateTime(2019, 8, 9, 17, 38, 36, 411, DateTimeKind.Local).AddTicks(2511) });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "AccessModifier", "AuthorId", "CompilerType", "CountOfBuildAttempts", "CountOfSaveBuilds", "CreatedAt", "Description", "GitCredentialId", "Language", "LogoId", "Name", "ProjectLink", "ProjectType" },
                values: new object[,]
                {
                    { 1, 1, 3, 0, 6, 6, new DateTime(2019, 8, 9, 17, 38, 36, 586, DateTimeKind.Local).AddTicks(1989), "Aperiam non quisquam ipsam sapiente.", 11, 1, 10, "aut", "https://linnea.net", 2 },
                    { 18, 0, 2, 0, 9, 8, new DateTime(2019, 8, 9, 17, 38, 36, 594, DateTimeKind.Local).AddTicks(6547), "Perspiciatis sit ex culpa laudantium.", 10, 0, 20, "amet", "http://ebba.net", 0 },
                    { 17, 0, 2, 0, 7, 5, new DateTime(2019, 8, 9, 17, 38, 36, 594, DateTimeKind.Local).AddTicks(6459), "Corrupti molestias dolor at neque.", 9, 1, 16, "numquam", "https://katheryn.org", 1 },
                    { 14, 1, 2, 0, 10, 5, new DateTime(2019, 8, 9, 17, 38, 36, 594, DateTimeKind.Local).AddTicks(6161), "Voluptatibus dicta adipisci numquam maxime.", 19, 1, 7, "accusantium", "https://rodrigo.biz", 0 },
                    { 10, 1, 2, 0, 9, 8, new DateTime(2019, 8, 9, 17, 38, 36, 594, DateTimeKind.Local).AddTicks(5657), "Odit et dolorem officia architecto.", 18, 1, 11, "eveniet", "https://ressie.biz", 1 },
                    { 9, 1, 2, 0, 7, 6, new DateTime(2019, 8, 9, 17, 38, 36, 594, DateTimeKind.Local).AddTicks(5570), "Deleniti culpa et inventore non.", 8, 1, 5, "velit", "http://reuben.org", 1 },
                    { 6, 1, 2, 0, 7, 9, new DateTime(2019, 8, 9, 17, 38, 36, 594, DateTimeKind.Local).AddTicks(5261), "Adipisci est qui assumenda omnis.", 16, 1, 15, "nihil", "https://gerhard.name", 0 },
                    { 4, 0, 2, 0, 10, 10, new DateTime(2019, 8, 9, 17, 38, 36, 594, DateTimeKind.Local).AddTicks(5076), "Eaque cum in voluptates soluta.", 18, 0, 23, "ut", "http://kelvin.biz", 0 },
                    { 3, 0, 2, 0, 7, 9, new DateTime(2019, 8, 9, 17, 38, 36, 594, DateTimeKind.Local).AddTicks(4886), "Animi voluptatem rerum reiciendis minus.", 8, 0, 23, "itaque", "http://amely.name", 2 },
                    { 15, 1, 1, 0, 6, 9, new DateTime(2019, 8, 9, 17, 38, 36, 594, DateTimeKind.Local).AddTicks(6248), "Et dolorem quidem rem corporis.", 7, 0, 10, "iure", "http://wilson.info", 0 },
                    { 12, 1, 1, 0, 8, 10, new DateTime(2019, 8, 9, 17, 38, 36, 594, DateTimeKind.Local).AddTicks(5935), "Accusantium necessitatibus quas et ullam.", 11, 0, 7, "incidunt", "http://ahmed.net", 2 },
                    { 11, 0, 1, 0, 5, 7, new DateTime(2019, 8, 9, 17, 38, 36, 594, DateTimeKind.Local).AddTicks(5827), "Rerum dolores placeat sed vitae.", 20, 0, 4, "ea", "https://taylor.net", 2 },
                    { 8, 0, 1, 0, 5, 8, new DateTime(2019, 8, 9, 17, 38, 36, 594, DateTimeKind.Local).AddTicks(5482), "Omnis soluta iste vero sit.", 15, 1, 7, "assumenda", "http://juana.info", 2 },
                    { 5, 0, 1, 0, 6, 5, new DateTime(2019, 8, 9, 17, 38, 36, 594, DateTimeKind.Local).AddTicks(5174), "Ducimus suscipit laborum at nisi.", 20, 1, 7, "eaque", "https://aaliyah.net", 0 },
                    { 2, 1, 1, 0, 7, 5, new DateTime(2019, 8, 9, 17, 38, 36, 594, DateTimeKind.Local).AddTicks(4141), "Enim ut tempora ea hic.", 17, 1, 5, "sit", "https://pansy.net", 0 },
                    { 16, 1, 3, 0, 5, 6, new DateTime(2019, 8, 9, 17, 38, 36, 594, DateTimeKind.Local).AddTicks(6336), "Dicta unde nesciunt iusto totam.", 2, 0, 20, "quia", "http://breanne.com", 2 },
                    { 13, 1, 3, 0, 7, 6, new DateTime(2019, 8, 9, 17, 38, 36, 594, DateTimeKind.Local).AddTicks(6022), "Voluptas et ut sed aliquam.", 1, 0, 23, "deleniti", "http://ozella.com", 0 },
                    { 7, 1, 3, 0, 6, 8, new DateTime(2019, 8, 9, 17, 38, 36, 594, DateTimeKind.Local).AddTicks(5390), "Nostrum amet sit et eaque.", 11, 1, 12, "reiciendis", "https://christophe.org", 2 },
                    { 19, 0, 2, 0, 5, 8, new DateTime(2019, 8, 9, 17, 38, 36, 594, DateTimeKind.Local).AddTicks(6634), "Excepturi ut iure minus voluptates.", 17, 1, 13, "voluptatem", "http://mossie.net", 1 },
                    { 20, 1, 2, 0, 6, 6, new DateTime(2019, 8, 9, 17, 38, 36, 594, DateTimeKind.Local).AddTicks(6752), "Tempore et quae quis quidem.", 7, 0, 7, "aliquid", "https://jada.biz", 1 }
                });

            migrationBuilder.InsertData(
                table: "Builds",
                columns: new[] { "Id", "BuildFinished", "BuildMessage", "BuildStarted", "BuildStatus", "ProjectId", "UserId" },
                values: new object[,]
                {
                    { 5, new DateTime(2019, 8, 9, 17, 38, 36, 610, DateTimeKind.Local).AddTicks(923), "Sed magnam et dolorum repellat sed veniam non dolorem ipsam.", new DateTime(2019, 8, 9, 17, 38, 36, 610, DateTimeKind.Local).AddTicks(959), 1, 1, 2 },
                    { 34, new DateTime(2019, 8, 9, 17, 38, 36, 610, DateTimeKind.Local).AddTicks(3591), "Cumque eos vel culpa enim voluptatem fuga ut sapiente et.", new DateTime(2019, 8, 9, 17, 38, 36, 610, DateTimeKind.Local).AddTicks(3642), 0, 8, 1 },
                    { 27, new DateTime(2019, 8, 9, 17, 38, 36, 610, DateTimeKind.Local).AddTicks(2866), "Ea rerum porro sed similique dolorem totam modi eius corrupti.", new DateTime(2019, 8, 9, 17, 38, 36, 610, DateTimeKind.Local).AddTicks(2917), 0, 11, 1 },
                    { 13, new DateTime(2019, 8, 9, 17, 38, 36, 610, DateTimeKind.Local).AddTicks(1534), "Quos iusto deleniti est voluptatum quia pariatur iure dolor et.", new DateTime(2019, 8, 9, 17, 38, 36, 610, DateTimeKind.Local).AddTicks(1570), 1, 12, 3 },
                    { 8, new DateTime(2019, 8, 9, 17, 38, 36, 610, DateTimeKind.Local).AddTicks(1159), "Omnis consequatur beatae ex dolorem molestiae sed minus voluptatem eum.", new DateTime(2019, 8, 9, 17, 38, 36, 610, DateTimeKind.Local).AddTicks(1195), 0, 3, 3 },
                    { 14, new DateTime(2019, 8, 9, 17, 38, 36, 610, DateTimeKind.Local).AddTicks(1591), "Quaerat deserunt qui beatae praesentium illum similique qui quia aut.", new DateTime(2019, 8, 9, 17, 38, 36, 610, DateTimeKind.Local).AddTicks(1627), 1, 3, 1 },
                    { 29, new DateTime(2019, 8, 9, 17, 38, 36, 610, DateTimeKind.Local).AddTicks(3087), "Non quidem id aut similique cum corporis iure ipsum consequuntur.", new DateTime(2019, 8, 9, 17, 38, 36, 610, DateTimeKind.Local).AddTicks(3138), 0, 3, 1 },
                    { 36, new DateTime(2019, 8, 9, 17, 38, 36, 610, DateTimeKind.Local).AddTicks(3771), "Inventore occaecati eum laborum et amet voluptatibus sunt sapiente est.", new DateTime(2019, 8, 9, 17, 38, 36, 610, DateTimeKind.Local).AddTicks(3868), 1, 3, 3 },
                    { 21, new DateTime(2019, 8, 9, 17, 38, 36, 610, DateTimeKind.Local).AddTicks(2233), "Eius molestias quaerat aut voluptatum dicta nesciunt suscipit officiis id.", new DateTime(2019, 8, 9, 17, 38, 36, 610, DateTimeKind.Local).AddTicks(2352), 0, 4, 2 },
                    { 32, new DateTime(2019, 8, 9, 17, 38, 36, 610, DateTimeKind.Local).AddTicks(3364), "Quos sed quibusdam eos voluptate nam omnis sit quo sit.", new DateTime(2019, 8, 9, 17, 38, 36, 610, DateTimeKind.Local).AddTicks(3462), 1, 4, 3 },
                    { 3, new DateTime(2019, 8, 9, 17, 38, 36, 610, DateTimeKind.Local).AddTicks(717), "Et quos qui atque nemo repellat consequatur qui sit sint.", new DateTime(2019, 8, 9, 17, 38, 36, 610, DateTimeKind.Local).AddTicks(820), 0, 6, 1 },
                    { 15, new DateTime(2019, 8, 9, 17, 38, 36, 610, DateTimeKind.Local).AddTicks(1647), "Non quam consequatur esse fugit sed officia voluptatibus consectetur quis.", new DateTime(2019, 8, 9, 17, 38, 36, 610, DateTimeKind.Local).AddTicks(1714), 0, 6, 2 },
                    { 10, new DateTime(2019, 8, 9, 17, 38, 36, 610, DateTimeKind.Local).AddTicks(1277), "Doloremque esse molestias dolores rem vel est ea officiis consectetur.", new DateTime(2019, 8, 9, 17, 38, 36, 610, DateTimeKind.Local).AddTicks(1313), 0, 10, 2 },
                    { 20, new DateTime(2019, 8, 9, 17, 38, 36, 610, DateTimeKind.Local).AddTicks(2043), "Et nihil exercitationem enim nostrum ab omnis explicabo perspiciatis numquam.", new DateTime(2019, 8, 9, 17, 38, 36, 610, DateTimeKind.Local).AddTicks(2156), 0, 17, 1 },
                    { 4, new DateTime(2019, 8, 9, 17, 38, 36, 610, DateTimeKind.Local).AddTicks(856), "Cupiditate atque aut sequi neque eaque illo est numquam aut.", new DateTime(2019, 8, 9, 17, 38, 36, 610, DateTimeKind.Local).AddTicks(902), 0, 18, 2 },
                    { 12, new DateTime(2019, 8, 9, 17, 38, 36, 610, DateTimeKind.Local).AddTicks(1473), "Quos quo deserunt quod eveniet dolores eaque ut in nihil.", new DateTime(2019, 8, 9, 17, 38, 36, 610, DateTimeKind.Local).AddTicks(1514), 0, 18, 2 },
                    { 33, new DateTime(2019, 8, 9, 17, 38, 36, 610, DateTimeKind.Local).AddTicks(3503), "Omnis voluptas sint nobis perferendis error illum provident aut in.", new DateTime(2019, 8, 9, 17, 38, 36, 610, DateTimeKind.Local).AddTicks(3555), 1, 18, 1 },
                    { 6, new DateTime(2019, 8, 9, 17, 38, 36, 610, DateTimeKind.Local).AddTicks(1000), "Perferendis modi ullam dicta et et velit qui vel sint.", new DateTime(2019, 8, 9, 17, 38, 36, 610, DateTimeKind.Local).AddTicks(1041), 0, 19, 1 },
                    { 39, new DateTime(2019, 8, 9, 17, 38, 36, 610, DateTimeKind.Local).AddTicks(4223), "Voluptates ea quia esse dolorem vel hic dolor et et.", new DateTime(2019, 8, 9, 17, 38, 36, 610, DateTimeKind.Local).AddTicks(4279), 1, 19, 2 },
                    { 28, new DateTime(2019, 8, 9, 17, 38, 36, 610, DateTimeKind.Local).AddTicks(2948), "Aperiam provident accusamus nam sequi consectetur dolorem ut aut eos.", new DateTime(2019, 8, 9, 17, 38, 36, 610, DateTimeKind.Local).AddTicks(3046), 0, 20, 3 },
                    { 7, new DateTime(2019, 8, 9, 17, 38, 36, 610, DateTimeKind.Local).AddTicks(1061), "Et ipsum doloribus pariatur est sint dolorum molestiae debitis facere.", new DateTime(2019, 8, 9, 17, 38, 36, 610, DateTimeKind.Local).AddTicks(1133), 0, 8, 2 },
                    { 35, new DateTime(2019, 8, 9, 17, 38, 36, 610, DateTimeKind.Local).AddTicks(3683), "Autem sint sit vitae rerum amet qui magni maxime velit.", new DateTime(2019, 8, 9, 17, 38, 36, 610, DateTimeKind.Local).AddTicks(3735), 1, 5, 3 },
                    { 11, new DateTime(2019, 8, 9, 17, 38, 36, 610, DateTimeKind.Local).AddTicks(1334), "Illum illum nisi voluptatum laboriosam soluta est aut hic tenetur.", new DateTime(2019, 8, 9, 17, 38, 36, 610, DateTimeKind.Local).AddTicks(1447), 1, 12, 1 },
                    { 1, new DateTime(2019, 8, 9, 17, 38, 36, 604, DateTimeKind.Local).AddTicks(6592), "Quo ut architecto molestias non ut consequatur ad occaecati quod.", new DateTime(2019, 8, 9, 17, 38, 36, 605, DateTimeKind.Local).AddTicks(5383), 0, 5, 1 },
                    { 18, new DateTime(2019, 8, 9, 17, 38, 36, 610, DateTimeKind.Local).AddTicks(1853), "Totam ut temporibus quasi corporis et illum voluptatibus corporis nulla.", new DateTime(2019, 8, 9, 17, 38, 36, 610, DateTimeKind.Local).AddTicks(1889), 1, 1, 1 },
                    { 19, new DateTime(2019, 8, 9, 17, 38, 36, 610, DateTimeKind.Local).AddTicks(1910), "Et hic ipsum illo aut sunt explicabo accusamus impedit ut.", new DateTime(2019, 8, 9, 17, 38, 36, 610, DateTimeKind.Local).AddTicks(1940), 0, 1, 3 },
                    { 22, new DateTime(2019, 8, 9, 17, 38, 36, 610, DateTimeKind.Local).AddTicks(2403), "Corrupti nam rerum possimus cumque porro ab deleniti pariatur aut.", new DateTime(2019, 8, 9, 17, 38, 36, 610, DateTimeKind.Local).AddTicks(2460), 1, 1, 2 },
                    { 40, new DateTime(2019, 8, 9, 17, 38, 36, 610, DateTimeKind.Local).AddTicks(4326), "Sit voluptates sit officiis eius officiis vel quis possimus et.", new DateTime(2019, 8, 9, 17, 38, 36, 610, DateTimeKind.Local).AddTicks(4495), 1, 1, 1 },
                    { 9, new DateTime(2019, 8, 9, 17, 38, 36, 610, DateTimeKind.Local).AddTicks(1216), "Error nam labore nemo id asperiores nobis molestiae aperiam aut.", new DateTime(2019, 8, 9, 17, 38, 36, 610, DateTimeKind.Local).AddTicks(1252), 1, 7, 2 },
                    { 16, new DateTime(2019, 8, 9, 17, 38, 36, 610, DateTimeKind.Local).AddTicks(1740), "Sint quisquam harum ipsam pariatur aut sit consequuntur debitis dignissimos.", new DateTime(2019, 8, 9, 17, 38, 36, 610, DateTimeKind.Local).AddTicks(1776), 1, 7, 1 },
                    { 31, new DateTime(2019, 8, 9, 17, 38, 36, 610, DateTimeKind.Local).AddTicks(3267), "Quibusdam ut omnis nostrum consequatur quas aliquam possimus saepe fugiat.", new DateTime(2019, 8, 9, 17, 38, 36, 610, DateTimeKind.Local).AddTicks(3328), 1, 7, 3 },
                    { 38, new DateTime(2019, 8, 9, 17, 38, 36, 610, DateTimeKind.Local).AddTicks(4069), "Molestiae id sit a ducimus sed quis dolores sapiente odit.", new DateTime(2019, 8, 9, 17, 38, 36, 610, DateTimeKind.Local).AddTicks(4182), 0, 7, 1 },
                    { 2, new DateTime(2019, 8, 9, 17, 38, 36, 610, DateTimeKind.Local).AddTicks(116), "Odit iusto sapiente corrupti voluptatem laboriosam alias modi sunt labore.", new DateTime(2019, 8, 9, 17, 38, 36, 610, DateTimeKind.Local).AddTicks(347), 1, 5, 2 },
                    { 25, new DateTime(2019, 8, 9, 17, 38, 36, 610, DateTimeKind.Local).AddTicks(2701), "Et possimus nam quis in sunt architecto et voluptatem nihil.", new DateTime(2019, 8, 9, 17, 38, 36, 610, DateTimeKind.Local).AddTicks(2748), 0, 13, 3 },
                    { 23, new DateTime(2019, 8, 9, 17, 38, 36, 610, DateTimeKind.Local).AddTicks(2496), "Assumenda blanditiis aperiam aliquam id fugiat et fugiat officiis qui.", new DateTime(2019, 8, 9, 17, 38, 36, 610, DateTimeKind.Local).AddTicks(2542), 1, 13, 3 },
                    { 30, new DateTime(2019, 8, 9, 17, 38, 36, 610, DateTimeKind.Local).AddTicks(3179), "Voluptatum ratione facilis a praesentium qui aut necessitatibus dolore dolorum.", new DateTime(2019, 8, 9, 17, 38, 36, 610, DateTimeKind.Local).AddTicks(3231), 0, 2, 1 },
                    { 24, new DateTime(2019, 8, 9, 17, 38, 36, 610, DateTimeKind.Local).AddTicks(2619), "Maiores vero quos dolor aut veniam vitae quo error necessitatibus.", new DateTime(2019, 8, 9, 17, 38, 36, 610, DateTimeKind.Local).AddTicks(2665), 0, 16, 2 },
                    { 37, new DateTime(2019, 8, 9, 17, 38, 36, 610, DateTimeKind.Local).AddTicks(3909), "Similique non eos quibusdam recusandae dolorem ullam et amet ullam.", new DateTime(2019, 8, 9, 17, 38, 36, 610, DateTimeKind.Local).AddTicks(3997), 1, 16, 2 },
                    { 17, new DateTime(2019, 8, 9, 17, 38, 36, 610, DateTimeKind.Local).AddTicks(1797), "Voluptate voluptatem voluptates ipsum praesentium tempore iste sit et molestiae.", new DateTime(2019, 8, 9, 17, 38, 36, 610, DateTimeKind.Local).AddTicks(1833), 1, 16, 3 },
                    { 26, new DateTime(2019, 8, 9, 17, 38, 36, 610, DateTimeKind.Local).AddTicks(2778), "Quia rerum fuga laborum beatae minima voluptatem voluptates minus consectetur.", new DateTime(2019, 8, 9, 17, 38, 36, 610, DateTimeKind.Local).AddTicks(2830), 1, 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "ProjectMembers",
                columns: new[] { "ProjectId", "UserId", "UserAccess" },
                values: new object[,]
                {
                    { 13, 2, 3 },
                    { 2, 3, 1 },
                    { 11, 2, 1 },
                    { 18, 3, 3 },
                    { 11, 3, 0 },
                    { 1, 2, 2 },
                    { 20, 1, 0 },
                    { 12, 1, 0 },
                    { 9, 3, 3 },
                    { 6, 2, 1 },
                    { 15, 2, 2 },
                    { 7, 3, 0 },
                    { 4, 1, 3 },
                    { 3, 1, 1 },
                    { 3, 3, 0 },
                    { 10, 1, 3 },
                    { 20, 3, 3 }
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
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 6);

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
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 17);

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
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "ProjectMembers",
                keyColumns: new[] { "ProjectId", "UserId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "ProjectMembers",
                keyColumns: new[] { "ProjectId", "UserId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "ProjectMembers",
                keyColumns: new[] { "ProjectId", "UserId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "ProjectMembers",
                keyColumns: new[] { "ProjectId", "UserId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "ProjectMembers",
                keyColumns: new[] { "ProjectId", "UserId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "ProjectMembers",
                keyColumns: new[] { "ProjectId", "UserId" },
                keyValues: new object[] { 6, 2 });

            migrationBuilder.DeleteData(
                table: "ProjectMembers",
                keyColumns: new[] { "ProjectId", "UserId" },
                keyValues: new object[] { 7, 3 });

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
                keyValues: new object[] { 11, 2 });

            migrationBuilder.DeleteData(
                table: "ProjectMembers",
                keyColumns: new[] { "ProjectId", "UserId" },
                keyValues: new object[] { 11, 3 });

            migrationBuilder.DeleteData(
                table: "ProjectMembers",
                keyColumns: new[] { "ProjectId", "UserId" },
                keyValues: new object[] { 12, 1 });

            migrationBuilder.DeleteData(
                table: "ProjectMembers",
                keyColumns: new[] { "ProjectId", "UserId" },
                keyValues: new object[] { 13, 2 });

            migrationBuilder.DeleteData(
                table: "ProjectMembers",
                keyColumns: new[] { "ProjectId", "UserId" },
                keyValues: new object[] { 15, 2 });

            migrationBuilder.DeleteData(
                table: "ProjectMembers",
                keyColumns: new[] { "ProjectId", "UserId" },
                keyValues: new object[] { 18, 3 });

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
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 19);

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
                keyValue: 7);

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
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 11);

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
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 11);

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
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 23);

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
                keyValue: 2);
        }
    }
}
