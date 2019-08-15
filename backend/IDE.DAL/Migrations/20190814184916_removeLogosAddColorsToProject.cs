using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IDE.DAL.Migrations
{
    public partial class removeLogosAddColorsToProject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Images_LogoId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_LogoId",
                table: "Projects");

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
                keyValue: 14);

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
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "ProjectMembers",
                keyColumns: new[] { "ProjectId", "UserId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "ProjectMembers",
                keyColumns: new[] { "ProjectId", "UserId" },
                keyValues: new object[] { 8, 1 });

            migrationBuilder.DeleteData(
                table: "ProjectMembers",
                keyColumns: new[] { "ProjectId", "UserId" },
                keyValues: new object[] { 10, 3 });

            migrationBuilder.DeleteData(
                table: "ProjectMembers",
                keyColumns: new[] { "ProjectId", "UserId" },
                keyValues: new object[] { 17, 2 });

            migrationBuilder.DropColumn(
                name: "LogoId",
                table: "Projects");

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Projects",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BuildFinished", "BuildMessage", "BuildStarted", "BuildStatus", "UserId" },
                values: new object[] { new DateTime(2018, 10, 6, 2, 19, 39, 968, DateTimeKind.Unspecified).AddTicks(3908), "Eaque illo est numquam aut numquam et vel sed magnam.", new DateTime(2018, 9, 8, 5, 50, 22, 25, DateTimeKind.Unspecified).AddTicks(2329), 1, 2 });

            migrationBuilder.UpdateData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BuildFinished", "BuildMessage", "BuildStarted", "ProjectId", "UserId" },
                values: new object[] { new DateTime(2018, 10, 9, 17, 40, 33, 977, DateTimeKind.Unspecified).AddTicks(5471), "Non dolorem ipsam perspiciatis aperiam et perferendis modi ullam dicta.", new DateTime(2018, 9, 28, 14, 35, 0, 717, DateTimeKind.Unspecified).AddTicks(9132), 4, 1 });

            migrationBuilder.UpdateData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BuildFinished", "BuildMessage", "BuildStarted", "ProjectId", "UserId" },
                values: new object[] { new DateTime(2018, 10, 26, 5, 27, 56, 310, DateTimeKind.Unspecified).AddTicks(611), "Sint dolore itaque architecto et ipsum doloribus pariatur est sint.", new DateTime(2018, 9, 19, 14, 28, 45, 467, DateTimeKind.Unspecified).AddTicks(2025), 18, 3 });

            migrationBuilder.UpdateData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "BuildFinished", "BuildMessage", "BuildStarted", "ProjectId", "UserId" },
                values: new object[] { new DateTime(2018, 10, 16, 1, 23, 13, 476, DateTimeKind.Unspecified).AddTicks(7597), "In sint omnis consequatur beatae ex dolorem molestiae sed minus.", new DateTime(2018, 9, 1, 17, 8, 44, 496, DateTimeKind.Unspecified).AddTicks(8553), 7, 1 });

            migrationBuilder.UpdateData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "BuildFinished", "BuildMessage", "BuildStarted", "BuildStatus", "ProjectId" },
                values: new object[] { new DateTime(2018, 10, 28, 9, 42, 48, 485, DateTimeKind.Unspecified).AddTicks(2599), "Error nam labore nemo id asperiores nobis molestiae aperiam aut.", new DateTime(2018, 9, 29, 5, 11, 32, 829, DateTimeKind.Unspecified).AddTicks(7786), 0, 13 });

            migrationBuilder.UpdateData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "BuildFinished", "BuildMessage", "BuildStarted", "BuildStatus", "ProjectId", "UserId" },
                values: new object[] { new DateTime(2018, 10, 13, 20, 25, 37, 632, DateTimeKind.Unspecified).AddTicks(3029), "Molestias dolores rem vel est ea officiis consectetur et praesentium.", new DateTime(2018, 9, 11, 10, 58, 19, 255, DateTimeKind.Unspecified).AddTicks(4968), 1, 17, 2 });

            migrationBuilder.UpdateData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "BuildFinished", "BuildMessage", "BuildStarted", "ProjectId", "UserId" },
                values: new object[] { new DateTime(2018, 10, 15, 18, 46, 2, 848, DateTimeKind.Unspecified).AddTicks(9764), "Laboriosam soluta est aut hic tenetur est similique sit quos.", new DateTime(2018, 9, 22, 10, 25, 51, 131, DateTimeKind.Unspecified).AddTicks(4016), 15, 3 });

            migrationBuilder.UpdateData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "BuildFinished", "BuildMessage", "BuildStarted", "BuildStatus", "ProjectId" },
                values: new object[] { new DateTime(2018, 10, 5, 5, 3, 2, 944, DateTimeKind.Unspecified).AddTicks(6743), "Eaque ut in nihil tempora necessitatibus ea quos iusto deleniti.", new DateTime(2018, 9, 21, 16, 31, 18, 437, DateTimeKind.Unspecified).AddTicks(193), 0, 4 });

            migrationBuilder.UpdateData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "BuildFinished", "BuildMessage", "BuildStarted", "BuildStatus", "ProjectId", "UserId" },
                values: new object[] { new DateTime(2018, 10, 13, 0, 18, 44, 750, DateTimeKind.Unspecified).AddTicks(2466), "Dolor et qui natus assumenda quaerat deserunt qui beatae praesentium.", new DateTime(2018, 9, 25, 13, 4, 34, 389, DateTimeKind.Unspecified).AddTicks(7091), 1, 10, 1 });

            migrationBuilder.UpdateData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "BuildFinished", "BuildMessage", "BuildStarted", "BuildStatus", "ProjectId" },
                values: new object[] { new DateTime(2018, 10, 31, 5, 22, 48, 912, DateTimeKind.Unspecified).AddTicks(100), "Consequatur dolores exercitationem non quam consequatur esse fugit sed officia.", new DateTime(2018, 9, 30, 9, 57, 47, 39, DateTimeKind.Unspecified).AddTicks(3083), 0, 6 });

            migrationBuilder.UpdateData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "BuildFinished", "BuildMessage", "BuildStarted", "BuildStatus", "ProjectId" },
                values: new object[] { new DateTime(2018, 10, 9, 2, 53, 11, 978, DateTimeKind.Unspecified).AddTicks(9631), "Voluptatum sint quisquam harum ipsam pariatur aut sit consequuntur debitis.", new DateTime(2018, 9, 14, 8, 53, 31, 38, DateTimeKind.Unspecified).AddTicks(1737), 1, 7 });

            migrationBuilder.UpdateData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "BuildFinished", "BuildMessage", "BuildStarted", "ProjectId", "UserId" },
                values: new object[] { new DateTime(2018, 10, 13, 14, 55, 14, 971, DateTimeKind.Unspecified).AddTicks(5972), "Voluptatem voluptates ipsum praesentium tempore iste sit et molestiae culpa.", new DateTime(2018, 9, 23, 19, 12, 4, 443, DateTimeKind.Unspecified).AddTicks(2831), 10, 3 });

            migrationBuilder.UpdateData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "BuildFinished", "BuildMessage", "BuildStarted", "ProjectId", "UserId" },
                values: new object[] { new DateTime(2018, 10, 25, 11, 59, 45, 319, DateTimeKind.Unspecified).AddTicks(1502), "Quasi corporis et illum voluptatibus corporis nulla qui aut consequuntur.", new DateTime(2018, 9, 24, 23, 52, 5, 625, DateTimeKind.Unspecified).AddTicks(2644), 4, 1 });

            migrationBuilder.UpdateData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "BuildFinished", "BuildMessage", "BuildStarted", "BuildStatus", "ProjectId" },
                values: new object[] { new DateTime(2018, 10, 31, 4, 26, 25, 391, DateTimeKind.Unspecified).AddTicks(6764), "Sunt explicabo accusamus impedit ut architecto sit dolorem et nihil.", new DateTime(2018, 9, 9, 21, 30, 53, 735, DateTimeKind.Unspecified).AddTicks(7870), 0, 6 });

            migrationBuilder.UpdateData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "BuildFinished", "BuildMessage", "BuildStarted", "ProjectId", "UserId" },
                values: new object[] { new DateTime(2018, 10, 18, 4, 15, 26, 882, DateTimeKind.Unspecified).AddTicks(4336), "Explicabo perspiciatis numquam suscipit consequatur qui eius molestias quaerat aut.", new DateTime(2018, 9, 15, 6, 44, 19, 923, DateTimeKind.Unspecified).AddTicks(6244), 4, 2 });

            migrationBuilder.UpdateData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "BuildFinished", "BuildMessage", "BuildStarted", "ProjectId", "UserId" },
                values: new object[] { new DateTime(2018, 10, 28, 0, 32, 7, 869, DateTimeKind.Unspecified).AddTicks(1658), "Id aut consectetur blanditiis corrupti nam rerum possimus cumque porro.", new DateTime(2018, 9, 2, 11, 47, 36, 719, DateTimeKind.Unspecified).AddTicks(3602), 17, 1 });

            migrationBuilder.UpdateData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "BuildFinished", "BuildMessage", "BuildStarted", "BuildStatus", "ProjectId", "UserId" },
                values: new object[] { new DateTime(2018, 10, 22, 6, 55, 34, 427, DateTimeKind.Unspecified).AddTicks(9927), "Doloremque omnis assumenda blanditiis aperiam aliquam id fugiat et fugiat.", new DateTime(2018, 9, 27, 5, 19, 44, 682, DateTimeKind.Unspecified).AddTicks(8341), 1, 13, 2 });

            migrationBuilder.UpdateData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "BuildFinished", "BuildMessage", "BuildStarted", "ProjectId" },
                values: new object[] { new DateTime(2018, 10, 25, 13, 9, 31, 780, DateTimeKind.Unspecified).AddTicks(6530), "Maiores vero quos dolor aut veniam vitae quo error necessitatibus.", new DateTime(2018, 9, 7, 5, 57, 41, 936, DateTimeKind.Unspecified).AddTicks(2246), 11 });

            migrationBuilder.UpdateData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "BuildFinished", "BuildMessage", "BuildStarted", "BuildStatus", "ProjectId" },
                values: new object[] { new DateTime(2018, 10, 24, 12, 20, 38, 358, DateTimeKind.Unspecified).AddTicks(4617), "Nam quis in sunt architecto et voluptatem nihil corporis et.", new DateTime(2018, 9, 27, 0, 51, 14, 724, DateTimeKind.Unspecified).AddTicks(3419), 0, 19 });

            migrationBuilder.UpdateData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "BuildFinished", "BuildMessage", "BuildStarted", "BuildStatus", "ProjectId" },
                values: new object[] { new DateTime(2018, 10, 20, 0, 27, 23, 948, DateTimeKind.Unspecified).AddTicks(1952), "Beatae minima voluptatem voluptates minus consectetur maiores et aut ea.", new DateTime(2018, 9, 29, 10, 23, 54, 950, DateTimeKind.Unspecified).AddTicks(2172), 1, 5 });

            migrationBuilder.UpdateData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "BuildFinished", "BuildMessage", "BuildStarted", "BuildStatus", "ProjectId", "UserId" },
                values: new object[] { new DateTime(2018, 10, 26, 13, 34, 0, 756, DateTimeKind.Unspecified).AddTicks(695), "Totam modi eius corrupti ipsum quas amet aperiam provident accusamus.", new DateTime(2018, 9, 20, 23, 26, 17, 398, DateTimeKind.Unspecified).AddTicks(2158), 0, 4, 1 });

            migrationBuilder.UpdateData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "BuildFinished", "BuildMessage", "BuildStarted", "ProjectId" },
                values: new object[] { new DateTime(2018, 10, 8, 5, 20, 22, 700, DateTimeKind.Unspecified).AddTicks(4916), "Aut eos numquam hic consequatur non quidem id aut similique.", new DateTime(2018, 9, 21, 7, 30, 41, 232, DateTimeKind.Unspecified).AddTicks(1366), 8 });

            migrationBuilder.UpdateData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "BuildFinished", "BuildMessage", "BuildStarted", "ProjectId" },
                values: new object[] { new DateTime(2018, 10, 4, 21, 34, 52, 137, DateTimeKind.Unspecified).AddTicks(7127), "Quia fugit eos voluptatum ratione facilis a praesentium qui aut.", new DateTime(2018, 9, 27, 17, 54, 1, 190, DateTimeKind.Unspecified).AddTicks(5499), 13 });

            migrationBuilder.UpdateData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "BuildFinished", "BuildMessage", "BuildStarted", "BuildStatus", "ProjectId", "UserId" },
                values: new object[] { new DateTime(2018, 10, 3, 2, 8, 34, 208, DateTimeKind.Unspecified).AddTicks(6139), "Aperiam quibusdam ut omnis nostrum consequatur quas aliquam possimus saepe.", new DateTime(2018, 9, 26, 0, 24, 5, 580, DateTimeKind.Unspecified).AddTicks(7737), 1, 7, 3 });

            migrationBuilder.UpdateData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "BuildFinished", "BuildMessage", "BuildStarted", "ProjectId" },
                values: new object[] { new DateTime(2018, 10, 16, 6, 22, 33, 99, DateTimeKind.Unspecified).AddTicks(3300), "Sed quibusdam eos voluptate nam omnis sit quo sit officia.", new DateTime(2018, 9, 5, 12, 13, 39, 151, DateTimeKind.Unspecified).AddTicks(8035), 16 });

            migrationBuilder.UpdateData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "BuildFinished", "BuildMessage", "BuildStarted", "ProjectId", "UserId" },
                values: new object[] { new DateTime(2018, 10, 29, 10, 9, 16, 171, DateTimeKind.Unspecified).AddTicks(7606), "Nobis perferendis error illum provident aut in laborum debitis ipsam.", new DateTime(2018, 9, 22, 1, 29, 16, 616, DateTimeKind.Unspecified).AddTicks(8139), 8, 2 });

            migrationBuilder.UpdateData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "BuildFinished", "BuildMessage", "BuildStarted", "BuildStatus", "ProjectId", "UserId" },
                values: new object[] { new DateTime(2018, 10, 10, 16, 30, 14, 334, DateTimeKind.Unspecified).AddTicks(7719), "Voluptatem fuga ut sapiente et explicabo eum numquam autem sint.", new DateTime(2018, 9, 1, 13, 33, 52, 569, DateTimeKind.Unspecified).AddTicks(1898), 0, 18, 1 });

            migrationBuilder.UpdateData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "BuildFinished", "BuildMessage", "BuildStarted", "ProjectId" },
                values: new object[] { new DateTime(2018, 10, 5, 10, 11, 17, 4, DateTimeKind.Unspecified).AddTicks(966), "Magni maxime velit voluptas non illum inventore occaecati eum laborum.", new DateTime(2018, 9, 25, 1, 36, 15, 960, DateTimeKind.Unspecified).AddTicks(7074), 20 });

            migrationBuilder.UpdateData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "BuildFinished", "BuildMessage", "BuildStarted", "BuildStatus", "ProjectId" },
                values: new object[] { new DateTime(2018, 10, 30, 19, 21, 35, 117, DateTimeKind.Unspecified).AddTicks(9591), "Est quidem magni nihil similique non eos quibusdam recusandae dolorem.", new DateTime(2018, 9, 10, 0, 24, 32, 726, DateTimeKind.Unspecified).AddTicks(9552), 1, 4 });

            migrationBuilder.UpdateData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "BuildFinished", "BuildMessage", "BuildStarted", "BuildStatus", "UserId" },
                values: new object[] { new DateTime(2018, 10, 16, 22, 5, 53, 78, DateTimeKind.Unspecified).AddTicks(7764), "Et sint molestiae id sit a ducimus sed quis dolores.", new DateTime(2018, 9, 29, 20, 58, 55, 531, DateTimeKind.Unspecified).AddTicks(7468), 0, 2 });

            migrationBuilder.UpdateData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "BuildFinished", "BuildMessage", "BuildStarted", "BuildStatus", "ProjectId", "UserId" },
                values: new object[] { new DateTime(2018, 10, 4, 6, 8, 50, 126, DateTimeKind.Unspecified).AddTicks(9277), "Voluptates ea quia esse dolorem vel hic dolor et et.", new DateTime(2018, 9, 30, 20, 19, 4, 61, DateTimeKind.Unspecified).AddTicks(317), 1, 10, 1 });

            migrationBuilder.UpdateData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "BuildFinished", "BuildMessage", "BuildStarted", "BuildStatus", "ProjectId" },
                values: new object[] { new DateTime(2018, 10, 29, 4, 28, 20, 672, DateTimeKind.Unspecified).AddTicks(9663), "Sit officiis eius officiis vel quis possimus et et alias.", new DateTime(2018, 9, 8, 5, 18, 22, 892, DateTimeKind.Unspecified).AddTicks(6119), 0, 16 });

            migrationBuilder.UpdateData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "BuildFinished", "BuildMessage", "BuildStarted", "ProjectId" },
                values: new object[] { new DateTime(2018, 10, 19, 19, 2, 54, 8, DateTimeKind.Unspecified).AddTicks(3284), "Nihil voluptatibus ducimus eum sint eveniet cum est voluptatum dolores.", new DateTime(2018, 9, 26, 10, 44, 54, 104, DateTimeKind.Unspecified).AddTicks(1605), 17 });

            migrationBuilder.UpdateData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "BuildFinished", "BuildMessage", "BuildStarted", "ProjectId", "UserId" },
                values: new object[] { new DateTime(2018, 10, 6, 20, 26, 54, 239, DateTimeKind.Unspecified).AddTicks(7732), "Perferendis aut occaecati laudantium voluptatum sunt rerum veniam ut illum.", new DateTime(2018, 9, 5, 13, 8, 46, 801, DateTimeKind.Unspecified).AddTicks(9390), 5, 2 });

            migrationBuilder.UpdateData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "BuildFinished", "BuildMessage", "BuildStarted", "ProjectId", "UserId" },
                values: new object[] { new DateTime(2018, 10, 19, 3, 24, 38, 43, DateTimeKind.Unspecified).AddTicks(46), "Minima consectetur delectus aut adipisci perferendis dolores est aut aut.", new DateTime(2018, 9, 11, 3, 32, 43, 908, DateTimeKind.Unspecified).AddTicks(6455), 15, 3 });

            migrationBuilder.UpdateData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "BuildFinished", "BuildMessage", "BuildStarted", "BuildStatus", "ProjectId", "UserId" },
                values: new object[] { new DateTime(2018, 10, 30, 20, 47, 10, 926, DateTimeKind.Unspecified).AddTicks(3950), "Hic rerum quia porro doloribus ut qui exercitationem minus sint.", new DateTime(2018, 9, 17, 2, 4, 19, 619, DateTimeKind.Unspecified).AddTicks(4898), 1, 19, 1 });

            migrationBuilder.UpdateData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "BuildFinished", "BuildMessage", "BuildStarted", "BuildStatus", "ProjectId", "UserId" },
                values: new object[] { new DateTime(2018, 10, 24, 16, 35, 14, 470, DateTimeKind.Unspecified).AddTicks(7019), "Id praesentium ea necessitatibus at expedita quis et molestiae quia.", new DateTime(2018, 9, 16, 13, 39, 50, 442, DateTimeKind.Unspecified).AddTicks(3242), 0, 9, 2 });

            migrationBuilder.UpdateData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "BuildFinished", "BuildMessage", "BuildStarted", "BuildStatus", "ProjectId" },
                values: new object[] { new DateTime(2018, 10, 5, 7, 36, 54, 904, DateTimeKind.Unspecified).AddTicks(1393), "Doloribus qui perspiciatis in accusamus quia aperiam et nihil ipsam.", new DateTime(2018, 9, 21, 21, 46, 0, 845, DateTimeKind.Unspecified).AddTicks(1702), 1, 5 });

            migrationBuilder.UpdateData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "BuildFinished", "BuildMessage", "BuildStarted", "BuildStatus", "ProjectId" },
                values: new object[] { new DateTime(2018, 10, 21, 9, 13, 9, 903, DateTimeKind.Unspecified).AddTicks(3954), "Ipsam qui quidem laboriosam enim debitis quod vero rerum nemo.", new DateTime(2018, 9, 18, 10, 1, 32, 631, DateTimeKind.Unspecified).AddTicks(841), 0, 4 });

            migrationBuilder.UpdateData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "BuildFinished", "BuildMessage", "BuildStarted", "BuildStatus", "ProjectId" },
                values: new object[] { new DateTime(2018, 10, 15, 13, 31, 30, 420, DateTimeKind.Unspecified).AddTicks(7352), "Rerum dolorem nulla mollitia non qui voluptatem suscipit qui iste.", new DateTime(2018, 9, 22, 2, 43, 45, 852, DateTimeKind.Unspecified).AddTicks(6833), 1, 19 });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Login", "PasswordHash", "PasswordSalt", "Provider", "Url" },
                values: new object[] { "Rachelle.Bernier", "G+WmNnD0RfktxYR3BA5GsXHEUCGiAwc1EC/6bIvnNV4=", "AmXIPZy/Z2cFpHUbWgc3AjqY+kqoCjb+cYROb1o6Np4=", 1, "http://hellen.com" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Login", "PasswordHash", "PasswordSalt", "Provider", "Url" },
                values: new object[] { "Maribel.Bergstrom2", "yUNG8xBTSjh5Mnnfh3aWZbPrDtB7L19lqFzsHFfj1ig=", "A215Mi8nj+edv9SbjbdUsuAzJkzxULE9LBggoNLkUcE=", 2, "http://cyrus.info" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Login", "PasswordHash", "PasswordSalt", "Url" },
                values: new object[] { "Ian24", "sif6kasTnnfTAJn6VVamZ5TkIxS2XAd+THcJRkHanzw=", "gzltNXXt0p1igGUQqI3xify+EHmAuPOWSQFXTbUrybI=", "http://maximillia.biz" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Login", "PasswordHash", "PasswordSalt", "Provider", "Url" },
                values: new object[] { "Cassie_Kassulke10", "neYHnX3ccA3mft8eN+r9eT7Qr0RlQFkGveSv65fAFRM=", "7+sAigjk2/D3rIvSODkTz/dSusLJowTlrOyNL9BVAJo=", 1, "https://connie.com" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Login", "PasswordHash", "PasswordSalt", "Provider", "Url" },
                values: new object[] { "Hester75", "oSjUUDaRvfwAEOODEYN0GqP0eLy/OmHrXIOOqS3qZqo=", "1Lg4h1U/0kL/ZvCtG4s4hFGuODHO4+hFiB1CWpuWO38=", 0, "http://destini.com" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Login", "PasswordHash", "PasswordSalt", "Provider", "Url" },
                values: new object[] { "Zion34", "j/bpWtufCtZQ5VCL7tQSazIWwEgN8ZqC3zGxa0L6ZcU=", "rXk8nq529SFMdo0SEko+PpwKLv/Fy1kwOt+0Us1Mgn8=", 0, "https://ryan.com" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Login", "PasswordHash", "PasswordSalt", "Provider", "Url" },
                values: new object[] { "Koby.Goyette14", "fKiw6qkgQfUaE9pqNdmKQHGIf5pycpIKObDuXYJgaUI=", "qM1m+xlOLnpdBQnOYK4P4AvR3lVpmYtrEF/BxfRoaqA=", 1, "http://mathew.com" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Login", "PasswordHash", "PasswordSalt", "Provider", "Url" },
                values: new object[] { "Adrain.Watsica", "O6I04VPqqN9xcM//eSLjBKx5ZjwSZdZ960jJ+5gs3k0=", "Lb9qYKvcTjfESaZE6P2fpT+bVElmkHGzIr4AzI2IH1c=", 0, "https://madisen.com" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Login", "PasswordHash", "PasswordSalt", "Url" },
                values: new object[] { "Brandi0", "3Yj5YbBbIV6sW1y1pG84Ekg7dK7fBoYg9lSulT6GpH0=", "pLrMc2MLxEEOeWuOCgvweOx/bAVV4qBudlY1RFqOPfQ=", "https://nathanial.info" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Login", "PasswordHash", "PasswordSalt", "Provider", "Url" },
                values: new object[] { "Vince_Schmeler56", "mJQlr2QkGz1qjt8uQjdw+vabjhaW8ENNXPDY1t0XBjU=", "sRtqR52w3+GgZ8e6idyUCCSt76d92uBOdIhXQZ5nh98=", 1, "http://sim.info" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Login", "PasswordHash", "PasswordSalt", "Provider", "Url" },
                values: new object[] { "Samara23", "40T4uAGCWeQBxExbCmrmX+fJA8Btv69iOMT8Sqj1e5k=", "kzK9brD4jBUQuokO7n0rtbU0WwAApqmwCXORAt1t27U=", 2, "https://lamont.net" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Login", "PasswordHash", "PasswordSalt", "Provider", "Url" },
                values: new object[] { "Jada97", "/tvuC9uhQZi8qcf+qpyVHlmPwwfucO9g3KpqR8m+nGI=", "exJT2xH/OBCkobcdhkpZF4s55depkGCvZMaI8p5OYb0=", 0, "https://jannie.biz" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Login", "PasswordHash", "PasswordSalt", "Provider", "Url" },
                values: new object[] { "Cassie34", "rpLxlMV8Om50IqF9T4j0SfwSFHBwGFXsysaa2kuBdO4=", "BQRlQNDjafH79c4wOYft4p9SIM/t1BzySzgUzB/siI4=", 1, "https://schuyler.org" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Login", "PasswordHash", "PasswordSalt", "Url" },
                values: new object[] { "Willis_Romaguera", "qXtgJ28OTi3xeYFxFopudpBgb9mXfn/ReOV53dQZ/x0=", "yHTgS2Iv6onVtEgfHi9Jlo/6nmMY02rp1AajyYZ1qDg=", "https://bobbie.info" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Login", "PasswordHash", "PasswordSalt", "Url" },
                values: new object[] { "Aylin61", "PFLAN/H+hGS2/3xj8jdTuNgqpEjtJKjhi89eZ34tnzA=", "7N2LmPiD6OfCemvDVugT73y5DTYF729l0eZc/cPPW4c=", "https://briana.com" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Login", "PasswordHash", "PasswordSalt", "Url" },
                values: new object[] { "Edna.Hahn77", "WAuNnmdQym053hlwjfHdEQJQEedKU9Fg1e1y+bIbKwY=", "KetULUgNTmX4M7paNi9CKwmBPNnUmdV0EqKXHbVFki4=", "https://ashlynn.biz" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Login", "PasswordHash", "PasswordSalt", "Provider", "Url" },
                values: new object[] { "Titus91", "qdzZEdZDylpuaU0rdoc3+fitnNO05MNt5WSrEPs9j7A=", "PIs3Nv9gZpGT2Mh4ub7kjLGepoPTy3q0h6VUru8oUsg=", 0, "http://dwight.org" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Login", "PasswordHash", "PasswordSalt", "Provider", "Url" },
                values: new object[] { "Kassandra_Kemmer", "787UCvh/cUHGUncwZfceohIO8w7RDuaNLG3X23UqDFw=", "u7wVby+PaTST6jCv9kiH0E9GWpkR++k+Q9iW4EwB8Rk=", 1, "http://destiny.com" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Login", "PasswordHash", "PasswordSalt", "Url" },
                values: new object[] { "Leann_Jerde71", "8kp0akLeIuWJSzxuvBQURhj6z0LcB4vfoqLXYOusvMo=", "aTY344B1dmCbybBXs27E0ZcyZRpF8tPHJTvrCBxoXBo=", "http://scot.com" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "Login", "PasswordHash", "PasswordSalt", "Provider", "Url" },
                values: new object[] { "Rosa_Haley", "mL+10ltd8MqGywc29DNX/69/Op5WWj9/sOgmRBU9rog=", "5K38fT/beGtn7xeXf5PW9yps/s5o8W1gYp3Ax03WaDQ=", 0, "https://vivianne.net" });

            migrationBuilder.UpdateData(
                table: "ProjectMembers",
                keyColumns: new[] { "ProjectId", "UserId" },
                keyValues: new object[] { 20, 3 },
                column: "UserAccess",
                value: 1);

            migrationBuilder.InsertData(
                table: "ProjectMembers",
                columns: new[] { "ProjectId", "UserId", "UserAccess" },
                values: new object[,]
                {
                    { 10, 2, 0 },
                    { 4, 2, 2 },
                    { 18, 1, 3 },
                    { 2, 3, 1 }
                });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AccessModifier", "AuthorId", "Color", "CompilerType", "CountOfBuildAttempts", "CountOfSaveBuilds", "CreatedAt", "Description", "GitCredentialId", "Language", "Name", "ProjectLink", "ProjectType" },
                values: new object[] { 1, 2, "#458f86", 1, 6, 8, new DateTime(2018, 4, 19, 3, 8, 33, 91, DateTimeKind.Unspecified).AddTicks(866), "Quas animi cumque consequuntur dolorem.", 12, 0, "molestiae", "https://mohammed.biz", 0 });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AccessModifier", "AuthorId", "Color", "CompilerType", "CountOfBuildAttempts", "CreatedAt", "Description", "GitCredentialId", "Language", "Name", "ProjectLink", "ProjectType" },
                values: new object[] { 0, 1, "#7e1d83", 2, 9, new DateTime(2018, 6, 22, 22, 6, 56, 313, DateTimeKind.Unspecified).AddTicks(9595), "Non et voluptas aut voluptas.", 13, 2, "officiis", "http://ashlee.biz", 1 });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AuthorId", "Color", "CompilerType", "CountOfBuildAttempts", "CountOfSaveBuilds", "CreatedAt", "Description", "GitCredentialId", "Language", "Name", "ProjectLink" },
                values: new object[] { 2, "#577c66", 3, 9, 8, new DateTime(2018, 1, 16, 20, 20, 47, 250, DateTimeKind.Unspecified).AddTicks(8965), "Sit rerum repellendus eligendi ad.", 8, 2, "quam", "http://lucie.org" });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AuthorId", "Color", "CompilerType", "CountOfBuildAttempts", "CountOfSaveBuilds", "CreatedAt", "Description", "GitCredentialId", "Language", "Name", "ProjectLink" },
                values: new object[] { 1, "#6f638e", 3, 10, 7, new DateTime(2018, 1, 10, 7, 38, 41, 938, DateTimeKind.Unspecified).AddTicks(7227), "Iste rerum doloremque laudantium rerum.", 20, 3, "eaque", "https://savion.biz" });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AccessModifier", "AuthorId", "Color", "CompilerType", "CountOfBuildAttempts", "CountOfSaveBuilds", "CreatedAt", "Description", "GitCredentialId", "Language", "Name", "ProjectLink", "ProjectType" },
                values: new object[] { 1, 2, "#459489", 2, 6, 5, new DateTime(2018, 3, 23, 19, 24, 38, 67, DateTimeKind.Unspecified).AddTicks(7212), "Corporis voluptatem tempora dolores ducimus.", 7, 2, "at", "http://alfreda.net", 0 });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AccessModifier", "AuthorId", "Color", "CompilerType", "CountOfBuildAttempts", "CountOfSaveBuilds", "CreatedAt", "Description", "GitCredentialId", "Language", "Name", "ProjectLink", "ProjectType" },
                values: new object[] { 1, 1, "#654f71", 2, 7, 9, new DateTime(2018, 3, 10, 12, 43, 16, 828, DateTimeKind.Unspecified).AddTicks(4224), "Vel adipisci est qui assumenda.", 16, 3, "fugiat", "http://lavern.biz", 1 });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Color", "CountOfBuildAttempts", "CountOfSaveBuilds", "CreatedAt", "Description", "GitCredentialId", "Language", "Name", "ProjectLink", "ProjectType" },
                values: new object[] { "#308f88", 8, 6, new DateTime(2018, 2, 3, 10, 59, 6, 286, DateTimeKind.Unspecified).AddTicks(7846), "Sit et eaque cupiditate quo.", 9, 3, "dolor", "http://anya.info", 0 });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Color", "CompilerType", "CountOfBuildAttempts", "CountOfSaveBuilds", "CreatedAt", "Description", "GitCredentialId", "Name", "ProjectLink", "ProjectType" },
                values: new object[] { "#8d5274", 2, 8, 10, new DateTime(2018, 1, 4, 6, 48, 53, 297, DateTimeKind.Unspecified).AddTicks(5994), "Maxime ut sit assumenda odio.", 11, "a", "http://cleo.info", 1 });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "AuthorId", "Color", "CompilerType", "CountOfBuildAttempts", "CountOfSaveBuilds", "CreatedAt", "Description", "GitCredentialId", "Language", "Name", "ProjectLink" },
                values: new object[] { 1, "#7c5a26", 3, 7, 9, new DateTime(2018, 1, 10, 17, 3, 16, 509, DateTimeKind.Unspecified).AddTicks(3764), "Velit dolores dolorem aut cupiditate.", 16, 2, "voluptatem", "http://catherine.name" });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "AccessModifier", "AuthorId", "Color", "CompilerType", "CountOfSaveBuilds", "CreatedAt", "Description", "GitCredentialId", "Language", "Name", "ProjectLink", "ProjectType" },
                values: new object[] { 1, 3, "#587932", 1, 8, new DateTime(2018, 5, 29, 5, 40, 24, 537, DateTimeKind.Unspecified).AddTicks(9483), "Minima deleniti voluptatem sit debitis.", 1, 1, "rerum", "http://viola.biz", 0 });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "AccessModifier", "AuthorId", "Color", "CompilerType", "CountOfBuildAttempts", "CountOfSaveBuilds", "CreatedAt", "Description", "GitCredentialId", "Language", "Name", "ProjectLink", "ProjectType" },
                values: new object[] { 0, 3, "#3f5d53", 3, 9, 9, new DateTime(2018, 5, 5, 17, 27, 8, 121, DateTimeKind.Unspecified).AddTicks(6080), "Magni recusandae est delectus accusantium.", 18, 2, "et", "http://daren.com", 0 });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "AuthorId", "Color", "CompilerType", "CountOfBuildAttempts", "CountOfSaveBuilds", "CreatedAt", "Description", "GitCredentialId", "Name", "ProjectLink" },
                values: new object[] { 3, "#94562a", 2, 9, 5, new DateTime(2018, 3, 10, 5, 24, 46, 815, DateTimeKind.Unspecified).AddTicks(4140), "Minima voluptas et ut sed.", 6, "dolores", "https://breanne.com" });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "AccessModifier", "AuthorId", "Color", "CompilerType", "CountOfBuildAttempts", "CountOfSaveBuilds", "CreatedAt", "Description", "GitCredentialId", "Language", "Name", "ProjectLink", "ProjectType" },
                values: new object[] { 1, 1, "#843b1a", 3, 5, 10, new DateTime(2018, 1, 16, 9, 7, 28, 488, DateTimeKind.Unspecified).AddTicks(7112), "Adipisci numquam maxime repudiandae minus.", 4, 0, "nobis", "https://emanuel.org", 0 });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "AccessModifier", "AuthorId", "Color", "CompilerType", "CountOfBuildAttempts", "CountOfSaveBuilds", "CreatedAt", "Description", "GitCredentialId", "ProjectLink", "ProjectType" },
                values: new object[] { 1, 2, "#8d7e69", 3, 8, 7, new DateTime(2018, 2, 24, 20, 23, 59, 282, DateTimeKind.Unspecified).AddTicks(3233), "Laboriosam ab voluptatem iure aspernatur.", 20, "http://eldora.com", 1 });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "AuthorId", "Color", "CompilerType", "CountOfSaveBuilds", "CreatedAt", "Description", "GitCredentialId", "Language", "Name", "ProjectLink" },
                values: new object[] { 2, "#501c57", 1, 5, new DateTime(2018, 5, 27, 0, 31, 32, 303, DateTimeKind.Unspecified).AddTicks(4766), "Quia non magni eaque illum.", 6, 1, "quo", "https://osborne.org" });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Color", "CompilerType", "CountOfBuildAttempts", "CountOfSaveBuilds", "CreatedAt", "Description", "GitCredentialId", "Language", "Name", "ProjectLink", "ProjectType" },
                values: new object[] { "#304663", 2, 6, 8, new DateTime(2018, 4, 9, 23, 42, 11, 543, DateTimeKind.Unspecified).AddTicks(3929), "Recusandae deleniti vel expedita voluptatem.", 16, 2, "perspiciatis", "http://jerel.biz", 2 });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Color", "CompilerType", "CountOfBuildAttempts", "CountOfSaveBuilds", "CreatedAt", "Description", "GitCredentialId", "Language", "Name", "ProjectLink", "ProjectType" },
                values: new object[] { "#8d8484", 1, 9, 5, new DateTime(2018, 2, 23, 6, 26, 9, 561, DateTimeKind.Unspecified).AddTicks(2822), "Rem voluptas qui culpa excepturi.", 5, 1, "minus", "http://devon.biz", 2 });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "AccessModifier", "AuthorId", "Color", "CompilerType", "CountOfBuildAttempts", "CountOfSaveBuilds", "CreatedAt", "Description", "GitCredentialId", "Name", "ProjectLink", "ProjectType" },
                values: new object[] { 1, 2, "#2f465d", 3, 8, 9, new DateTime(2018, 2, 23, 0, 41, 47, 404, DateTimeKind.Unspecified).AddTicks(1840), "Magnam tempore et quae quis.", 13, "labore", "http://deontae.info", 2 });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "AuthorId", "Color", "CompilerType", "CountOfBuildAttempts", "CreatedAt", "Description", "GitCredentialId", "Name", "ProjectLink", "ProjectType" },
                values: new object[] { 1, "#94572c", 2, 8, new DateTime(2018, 5, 26, 18, 34, 49, 698, DateTimeKind.Unspecified).AddTicks(9761), "Ad occaecati quod aut incidunt.", 1, "iusto", "http://abbey.biz", 0 });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "AccessModifier", "AuthorId", "Color", "CountOfBuildAttempts", "CreatedAt", "Description", "GitCredentialId", "Name", "ProjectLink", "ProjectType" },
                values: new object[] { 0, 2, "#413e19", 8, new DateTime(2018, 3, 30, 18, 15, 20, 912, DateTimeKind.Unspecified).AddTicks(6779), "Qui atque nemo repellat consequatur.", 15, "sint", "https://jazmin.org", 0 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AvatarId", "Birthday", "Email", "FirstName", "GitHubUrl", "LastActive", "LastName", "NickName", "PasswordHash", "PasswordSalt", "RegisteredAt" },
                values: new object[] { 2, new DateTime(2000, 10, 4, 1, 1, 12, 644, DateTimeKind.Unspecified).AddTicks(2131), "Diamond.Vandervort76@yahoo.com", "Rosie", "http://jarrett.com", new DateTime(2018, 7, 8, 22, 2, 25, 300, DateTimeKind.Unspecified).AddTicks(2614), "Gutkowski", "Jena81", "3GSIpacdBihudKbIEmgQRkRRk+Boj0YgWhO7xL9ZJFU=", "9XX5FQ9abYwEzgqSPz4nWktBOv/JPYILsXXnGVc0Gy0=", new DateTime(2018, 4, 6, 4, 18, 48, 426, DateTimeKind.Unspecified).AddTicks(4220) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AvatarId", "Birthday", "Email", "FirstName", "GitHubUrl", "LastActive", "LastName", "NickName", "PasswordHash", "PasswordSalt", "RegisteredAt" },
                values: new object[] { 2, new DateTime(2000, 12, 26, 12, 40, 22, 178, DateTimeKind.Unspecified).AddTicks(7159), "Juanita0@gmail.com", "Maximillian", "http://berniece.name", new DateTime(2018, 7, 6, 20, 43, 52, 379, DateTimeKind.Unspecified).AddTicks(6948), "Terry", "Mara56", "3WJD/DIzNtX2Np9j0zeOPlLlQeKTfmybms/9lhhGxy0=", "sLcpTkl3/UJ0UgOfCwu22EkFgBP5t1yJ59ZPLbM8D0g=", new DateTime(2018, 1, 7, 23, 9, 50, 835, DateTimeKind.Unspecified).AddTicks(2704) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Birthday", "LastActive", "PasswordHash", "PasswordSalt", "RegisteredAt" },
                values: new object[] { new DateTime(2005, 8, 14, 21, 49, 15, 131, DateTimeKind.Local).AddTicks(8424), new DateTime(2019, 8, 14, 21, 49, 15, 134, DateTimeKind.Local).AddTicks(1520), "xaBvQnDbDbF8/NdeWV6HjWEmi/3X88R82pbdWkUOLOw=", "Z8iAiTSRAHlwTvLdWZGdrr3vd35kOdlD4MkCUqp+K2M=", new DateTime(2019, 8, 14, 21, 49, 15, 134, DateTimeKind.Local).AddTicks(1531) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProjectMembers",
                keyColumns: new[] { "ProjectId", "UserId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "ProjectMembers",
                keyColumns: new[] { "ProjectId", "UserId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "ProjectMembers",
                keyColumns: new[] { "ProjectId", "UserId" },
                keyValues: new object[] { 10, 2 });

            migrationBuilder.DeleteData(
                table: "ProjectMembers",
                keyColumns: new[] { "ProjectId", "UserId" },
                keyValues: new object[] { 18, 1 });

            migrationBuilder.DropColumn(
                name: "Color",
                table: "Projects");

            migrationBuilder.AddColumn<int>(
                name: "LogoId",
                table: "Projects",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BuildFinished", "BuildMessage", "BuildStarted", "BuildStatus", "UserId" },
                values: new object[] { new DateTime(2018, 10, 23, 15, 47, 9, 179, DateTimeKind.Unspecified).AddTicks(79), "Atque nemo repellat consequatur qui sit sint enim quis consequatur.", new DateTime(2018, 9, 16, 17, 23, 11, 478, DateTimeKind.Unspecified).AddTicks(8761), 0, 1 });

            migrationBuilder.UpdateData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BuildFinished", "BuildMessage", "BuildStarted", "ProjectId", "UserId" },
                values: new object[] { new DateTime(2018, 10, 6, 2, 19, 39, 968, DateTimeKind.Unspecified).AddTicks(3908), "Eaque illo est numquam aut numquam et vel sed magnam.", new DateTime(2018, 9, 8, 5, 50, 22, 25, DateTimeKind.Unspecified).AddTicks(2329), 20, 2 });

            migrationBuilder.UpdateData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BuildFinished", "BuildMessage", "BuildStarted", "ProjectId", "UserId" },
                values: new object[] { new DateTime(2018, 10, 9, 17, 40, 33, 977, DateTimeKind.Unspecified).AddTicks(5471), "Non dolorem ipsam perspiciatis aperiam et perferendis modi ullam dicta.", new DateTime(2018, 9, 28, 14, 35, 0, 717, DateTimeKind.Unspecified).AddTicks(9132), 4, 1 });

            migrationBuilder.UpdateData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "BuildFinished", "BuildMessage", "BuildStarted", "ProjectId", "UserId" },
                values: new object[] { new DateTime(2018, 10, 26, 5, 27, 56, 310, DateTimeKind.Unspecified).AddTicks(611), "Sint dolore itaque architecto et ipsum doloribus pariatur est sint.", new DateTime(2018, 9, 19, 14, 28, 45, 467, DateTimeKind.Unspecified).AddTicks(2025), 18, 3 });

            migrationBuilder.UpdateData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "BuildFinished", "BuildMessage", "BuildStarted", "BuildStatus", "ProjectId" },
                values: new object[] { new DateTime(2018, 10, 16, 1, 23, 13, 476, DateTimeKind.Unspecified).AddTicks(7597), "In sint omnis consequatur beatae ex dolorem molestiae sed minus.", new DateTime(2018, 9, 1, 17, 8, 44, 496, DateTimeKind.Unspecified).AddTicks(8553), 1, 7 });

            migrationBuilder.UpdateData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "BuildFinished", "BuildMessage", "BuildStarted", "BuildStatus", "ProjectId", "UserId" },
                values: new object[] { new DateTime(2018, 10, 28, 9, 42, 48, 485, DateTimeKind.Unspecified).AddTicks(2599), "Error nam labore nemo id asperiores nobis molestiae aperiam aut.", new DateTime(2018, 9, 29, 5, 11, 32, 829, DateTimeKind.Unspecified).AddTicks(7786), 0, 13, 1 });

            migrationBuilder.UpdateData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "BuildFinished", "BuildMessage", "BuildStarted", "ProjectId", "UserId" },
                values: new object[] { new DateTime(2018, 10, 13, 20, 25, 37, 632, DateTimeKind.Unspecified).AddTicks(3029), "Molestias dolores rem vel est ea officiis consectetur et praesentium.", new DateTime(2018, 9, 11, 10, 58, 19, 255, DateTimeKind.Unspecified).AddTicks(4968), 17, 2 });

            migrationBuilder.UpdateData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "BuildFinished", "BuildMessage", "BuildStarted", "BuildStatus", "ProjectId" },
                values: new object[] { new DateTime(2018, 10, 15, 18, 46, 2, 848, DateTimeKind.Unspecified).AddTicks(9764), "Laboriosam soluta est aut hic tenetur est similique sit quos.", new DateTime(2018, 9, 22, 10, 25, 51, 131, DateTimeKind.Unspecified).AddTicks(4016), 1, 15 });

            migrationBuilder.UpdateData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "BuildFinished", "BuildMessage", "BuildStarted", "BuildStatus", "ProjectId", "UserId" },
                values: new object[] { new DateTime(2018, 10, 5, 5, 3, 2, 944, DateTimeKind.Unspecified).AddTicks(6743), "Eaque ut in nihil tempora necessitatibus ea quos iusto deleniti.", new DateTime(2018, 9, 21, 16, 31, 18, 437, DateTimeKind.Unspecified).AddTicks(193), 0, 4, 3 });

            migrationBuilder.UpdateData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "BuildFinished", "BuildMessage", "BuildStarted", "BuildStatus", "ProjectId" },
                values: new object[] { new DateTime(2018, 10, 13, 0, 18, 44, 750, DateTimeKind.Unspecified).AddTicks(2466), "Dolor et qui natus assumenda quaerat deserunt qui beatae praesentium.", new DateTime(2018, 9, 25, 13, 4, 34, 389, DateTimeKind.Unspecified).AddTicks(7091), 1, 10 });

            migrationBuilder.UpdateData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "BuildFinished", "BuildMessage", "BuildStarted", "BuildStatus", "ProjectId" },
                values: new object[] { new DateTime(2018, 10, 31, 5, 22, 48, 912, DateTimeKind.Unspecified).AddTicks(100), "Consequatur dolores exercitationem non quam consequatur esse fugit sed officia.", new DateTime(2018, 9, 30, 9, 57, 47, 39, DateTimeKind.Unspecified).AddTicks(3083), 0, 6 });

            migrationBuilder.UpdateData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "BuildFinished", "BuildMessage", "BuildStarted", "ProjectId", "UserId" },
                values: new object[] { new DateTime(2018, 10, 9, 2, 53, 11, 978, DateTimeKind.Unspecified).AddTicks(9631), "Voluptatum sint quisquam harum ipsam pariatur aut sit consequuntur debitis.", new DateTime(2018, 9, 14, 8, 53, 31, 38, DateTimeKind.Unspecified).AddTicks(1737), 7, 1 });

            migrationBuilder.UpdateData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "BuildFinished", "BuildMessage", "BuildStarted", "ProjectId", "UserId" },
                values: new object[] { new DateTime(2018, 10, 13, 14, 55, 14, 971, DateTimeKind.Unspecified).AddTicks(5972), "Voluptatem voluptates ipsum praesentium tempore iste sit et molestiae culpa.", new DateTime(2018, 9, 23, 19, 12, 4, 443, DateTimeKind.Unspecified).AddTicks(2831), 10, 3 });

            migrationBuilder.UpdateData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "BuildFinished", "BuildMessage", "BuildStarted", "BuildStatus", "ProjectId" },
                values: new object[] { new DateTime(2018, 10, 25, 11, 59, 45, 319, DateTimeKind.Unspecified).AddTicks(1502), "Quasi corporis et illum voluptatibus corporis nulla qui aut consequuntur.", new DateTime(2018, 9, 24, 23, 52, 5, 625, DateTimeKind.Unspecified).AddTicks(2644), 1, 4 });

            migrationBuilder.UpdateData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "BuildFinished", "BuildMessage", "BuildStarted", "ProjectId", "UserId" },
                values: new object[] { new DateTime(2018, 10, 31, 4, 26, 25, 391, DateTimeKind.Unspecified).AddTicks(6764), "Sunt explicabo accusamus impedit ut architecto sit dolorem et nihil.", new DateTime(2018, 9, 9, 21, 30, 53, 735, DateTimeKind.Unspecified).AddTicks(7870), 6, 1 });

            migrationBuilder.UpdateData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "BuildFinished", "BuildMessage", "BuildStarted", "ProjectId", "UserId" },
                values: new object[] { new DateTime(2018, 10, 18, 4, 15, 26, 882, DateTimeKind.Unspecified).AddTicks(4336), "Explicabo perspiciatis numquam suscipit consequatur qui eius molestias quaerat aut.", new DateTime(2018, 9, 15, 6, 44, 19, 923, DateTimeKind.Unspecified).AddTicks(6244), 4, 2 });

            migrationBuilder.UpdateData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "BuildFinished", "BuildMessage", "BuildStarted", "BuildStatus", "ProjectId", "UserId" },
                values: new object[] { new DateTime(2018, 10, 28, 0, 32, 7, 869, DateTimeKind.Unspecified).AddTicks(1658), "Id aut consectetur blanditiis corrupti nam rerum possimus cumque porro.", new DateTime(2018, 9, 2, 11, 47, 36, 719, DateTimeKind.Unspecified).AddTicks(3602), 0, 17, 1 });

            migrationBuilder.UpdateData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "BuildFinished", "BuildMessage", "BuildStarted", "ProjectId" },
                values: new object[] { new DateTime(2018, 10, 22, 6, 55, 34, 427, DateTimeKind.Unspecified).AddTicks(9927), "Doloremque omnis assumenda blanditiis aperiam aliquam id fugiat et fugiat.", new DateTime(2018, 9, 27, 5, 19, 44, 682, DateTimeKind.Unspecified).AddTicks(8341), 13 });

            migrationBuilder.UpdateData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "BuildFinished", "BuildMessage", "BuildStarted", "BuildStatus", "ProjectId" },
                values: new object[] { new DateTime(2018, 10, 25, 13, 9, 31, 780, DateTimeKind.Unspecified).AddTicks(6530), "Maiores vero quos dolor aut veniam vitae quo error necessitatibus.", new DateTime(2018, 9, 7, 5, 57, 41, 936, DateTimeKind.Unspecified).AddTicks(2246), 1, 11 });

            migrationBuilder.UpdateData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "BuildFinished", "BuildMessage", "BuildStarted", "BuildStatus", "ProjectId" },
                values: new object[] { new DateTime(2018, 10, 24, 12, 20, 38, 358, DateTimeKind.Unspecified).AddTicks(4617), "Nam quis in sunt architecto et voluptatem nihil corporis et.", new DateTime(2018, 9, 27, 0, 51, 14, 724, DateTimeKind.Unspecified).AddTicks(3419), 0, 19 });

            migrationBuilder.UpdateData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "BuildFinished", "BuildMessage", "BuildStarted", "BuildStatus", "ProjectId", "UserId" },
                values: new object[] { new DateTime(2018, 10, 20, 0, 27, 23, 948, DateTimeKind.Unspecified).AddTicks(1952), "Beatae minima voluptatem voluptates minus consectetur maiores et aut ea.", new DateTime(2018, 9, 29, 10, 23, 54, 950, DateTimeKind.Unspecified).AddTicks(2172), 1, 5, 2 });

            migrationBuilder.UpdateData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "BuildFinished", "BuildMessage", "BuildStarted", "ProjectId" },
                values: new object[] { new DateTime(2018, 10, 26, 13, 34, 0, 756, DateTimeKind.Unspecified).AddTicks(695), "Totam modi eius corrupti ipsum quas amet aperiam provident accusamus.", new DateTime(2018, 9, 20, 23, 26, 17, 398, DateTimeKind.Unspecified).AddTicks(2158), 4 });

            migrationBuilder.UpdateData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "BuildFinished", "BuildMessage", "BuildStarted", "ProjectId" },
                values: new object[] { new DateTime(2018, 10, 8, 5, 20, 22, 700, DateTimeKind.Unspecified).AddTicks(4916), "Aut eos numquam hic consequatur non quidem id aut similique.", new DateTime(2018, 9, 21, 7, 30, 41, 232, DateTimeKind.Unspecified).AddTicks(1366), 8 });

            migrationBuilder.UpdateData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "BuildFinished", "BuildMessage", "BuildStarted", "BuildStatus", "ProjectId", "UserId" },
                values: new object[] { new DateTime(2018, 10, 4, 21, 34, 52, 137, DateTimeKind.Unspecified).AddTicks(7127), "Quia fugit eos voluptatum ratione facilis a praesentium qui aut.", new DateTime(2018, 9, 27, 17, 54, 1, 190, DateTimeKind.Unspecified).AddTicks(5499), 0, 13, 1 });

            migrationBuilder.UpdateData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "BuildFinished", "BuildMessage", "BuildStarted", "ProjectId" },
                values: new object[] { new DateTime(2018, 10, 3, 2, 8, 34, 208, DateTimeKind.Unspecified).AddTicks(6139), "Aperiam quibusdam ut omnis nostrum consequatur quas aliquam possimus saepe.", new DateTime(2018, 9, 26, 0, 24, 5, 580, DateTimeKind.Unspecified).AddTicks(7737), 7 });

            migrationBuilder.UpdateData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "BuildFinished", "BuildMessage", "BuildStarted", "ProjectId", "UserId" },
                values: new object[] { new DateTime(2018, 10, 16, 6, 22, 33, 99, DateTimeKind.Unspecified).AddTicks(3300), "Sed quibusdam eos voluptate nam omnis sit quo sit officia.", new DateTime(2018, 9, 5, 12, 13, 39, 151, DateTimeKind.Unspecified).AddTicks(8035), 16, 3 });

            migrationBuilder.UpdateData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "BuildFinished", "BuildMessage", "BuildStarted", "BuildStatus", "ProjectId", "UserId" },
                values: new object[] { new DateTime(2018, 10, 29, 10, 9, 16, 171, DateTimeKind.Unspecified).AddTicks(7606), "Nobis perferendis error illum provident aut in laborum debitis ipsam.", new DateTime(2018, 9, 22, 1, 29, 16, 616, DateTimeKind.Unspecified).AddTicks(8139), 1, 8, 2 });

            migrationBuilder.UpdateData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "BuildFinished", "BuildMessage", "BuildStarted", "ProjectId" },
                values: new object[] { new DateTime(2018, 10, 10, 16, 30, 14, 334, DateTimeKind.Unspecified).AddTicks(7719), "Voluptatem fuga ut sapiente et explicabo eum numquam autem sint.", new DateTime(2018, 9, 1, 13, 33, 52, 569, DateTimeKind.Unspecified).AddTicks(1898), 18 });

            migrationBuilder.UpdateData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "BuildFinished", "BuildMessage", "BuildStarted", "BuildStatus", "ProjectId" },
                values: new object[] { new DateTime(2018, 10, 5, 10, 11, 17, 4, DateTimeKind.Unspecified).AddTicks(966), "Magni maxime velit voluptas non illum inventore occaecati eum laborum.", new DateTime(2018, 9, 25, 1, 36, 15, 960, DateTimeKind.Unspecified).AddTicks(7074), 0, 20 });

            migrationBuilder.UpdateData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "BuildFinished", "BuildMessage", "BuildStarted", "BuildStatus", "UserId" },
                values: new object[] { new DateTime(2018, 10, 30, 19, 21, 35, 117, DateTimeKind.Unspecified).AddTicks(9591), "Est quidem magni nihil similique non eos quibusdam recusandae dolorem.", new DateTime(2018, 9, 10, 0, 24, 32, 726, DateTimeKind.Unspecified).AddTicks(9552), 1, 1 });

            migrationBuilder.UpdateData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "BuildFinished", "BuildMessage", "BuildStarted", "BuildStatus", "ProjectId", "UserId" },
                values: new object[] { new DateTime(2018, 10, 16, 22, 5, 53, 78, DateTimeKind.Unspecified).AddTicks(7764), "Et sint molestiae id sit a ducimus sed quis dolores.", new DateTime(2018, 9, 29, 20, 58, 55, 531, DateTimeKind.Unspecified).AddTicks(7468), 0, 4, 2 });

            migrationBuilder.UpdateData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "BuildFinished", "BuildMessage", "BuildStarted", "BuildStatus", "ProjectId" },
                values: new object[] { new DateTime(2018, 10, 4, 6, 8, 50, 126, DateTimeKind.Unspecified).AddTicks(9277), "Voluptates ea quia esse dolorem vel hic dolor et et.", new DateTime(2018, 9, 30, 20, 19, 4, 61, DateTimeKind.Unspecified).AddTicks(317), 1, 10 });

            migrationBuilder.UpdateData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "BuildFinished", "BuildMessage", "BuildStarted", "ProjectId" },
                values: new object[] { new DateTime(2018, 10, 29, 4, 28, 20, 672, DateTimeKind.Unspecified).AddTicks(9663), "Sit officiis eius officiis vel quis possimus et et alias.", new DateTime(2018, 9, 8, 5, 18, 22, 892, DateTimeKind.Unspecified).AddTicks(6119), 16 });

            migrationBuilder.UpdateData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "BuildFinished", "BuildMessage", "BuildStarted", "ProjectId", "UserId" },
                values: new object[] { new DateTime(2018, 10, 19, 19, 2, 54, 8, DateTimeKind.Unspecified).AddTicks(3284), "Nihil voluptatibus ducimus eum sint eveniet cum est voluptatum dolores.", new DateTime(2018, 9, 26, 10, 44, 54, 104, DateTimeKind.Unspecified).AddTicks(1605), 17, 1 });

            migrationBuilder.UpdateData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "BuildFinished", "BuildMessage", "BuildStarted", "ProjectId", "UserId" },
                values: new object[] { new DateTime(2018, 10, 6, 20, 26, 54, 239, DateTimeKind.Unspecified).AddTicks(7732), "Perferendis aut occaecati laudantium voluptatum sunt rerum veniam ut illum.", new DateTime(2018, 9, 5, 13, 8, 46, 801, DateTimeKind.Unspecified).AddTicks(9390), 5, 2 });

            migrationBuilder.UpdateData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "BuildFinished", "BuildMessage", "BuildStarted", "BuildStatus", "ProjectId", "UserId" },
                values: new object[] { new DateTime(2018, 10, 19, 3, 24, 38, 43, DateTimeKind.Unspecified).AddTicks(46), "Minima consectetur delectus aut adipisci perferendis dolores est aut aut.", new DateTime(2018, 9, 11, 3, 32, 43, 908, DateTimeKind.Unspecified).AddTicks(6455), 0, 15, 3 });

            migrationBuilder.UpdateData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "BuildFinished", "BuildMessage", "BuildStarted", "BuildStatus", "ProjectId", "UserId" },
                values: new object[] { new DateTime(2018, 10, 30, 20, 47, 10, 926, DateTimeKind.Unspecified).AddTicks(3950), "Hic rerum quia porro doloribus ut qui exercitationem minus sint.", new DateTime(2018, 9, 17, 2, 4, 19, 619, DateTimeKind.Unspecified).AddTicks(4898), 1, 19, 1 });

            migrationBuilder.UpdateData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "BuildFinished", "BuildMessage", "BuildStarted", "BuildStatus", "ProjectId" },
                values: new object[] { new DateTime(2018, 10, 24, 16, 35, 14, 470, DateTimeKind.Unspecified).AddTicks(7019), "Id praesentium ea necessitatibus at expedita quis et molestiae quia.", new DateTime(2018, 9, 16, 13, 39, 50, 442, DateTimeKind.Unspecified).AddTicks(3242), 0, 9 });

            migrationBuilder.UpdateData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "BuildFinished", "BuildMessage", "BuildStarted", "BuildStatus", "ProjectId" },
                values: new object[] { new DateTime(2018, 10, 5, 7, 36, 54, 904, DateTimeKind.Unspecified).AddTicks(1393), "Doloribus qui perspiciatis in accusamus quia aperiam et nihil ipsam.", new DateTime(2018, 9, 21, 21, 46, 0, 845, DateTimeKind.Unspecified).AddTicks(1702), 1, 5 });

            migrationBuilder.UpdateData(
                table: "Builds",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "BuildFinished", "BuildMessage", "BuildStarted", "BuildStatus", "ProjectId" },
                values: new object[] { new DateTime(2018, 10, 21, 9, 13, 9, 903, DateTimeKind.Unspecified).AddTicks(3954), "Ipsam qui quidem laboriosam enim debitis quod vero rerum nemo.", new DateTime(2018, 9, 18, 10, 1, 32, 631, DateTimeKind.Unspecified).AddTicks(841), 0, 4 });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Login", "PasswordHash", "PasswordSalt", "Provider", "Url" },
                values: new object[] { "Tamara34", "3wzx48I7qnjXwaIoW+02/zCOnbmcMhkeCRQz8oO+kzA=", "FtA/Cv2sHAdVh+tOHw4i2uBvEvZPU4hbZRf2aIT61JM=", 2, "https://jayda.net" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Login", "PasswordHash", "PasswordSalt", "Provider", "Url" },
                values: new object[] { "Maximillia.Donnelly", "SQme5Tncvc+JRCafmAUPskRjRxU3FAKooGZDNNxvskQ=", "RqGXIBZFGjpPJB1zkSu3wElmuu99woioXsUlDVshTb0=", 0, "https://mazie.com" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Login", "PasswordHash", "PasswordSalt", "Url" },
                values: new object[] { "Connie42", "IiUbUuSRdg4RtHH6I3iNVj+53BvYvPZT5QT1P2Qjnio=", "aZ3bppk0dx1abcVFlraTXSyXuKwTJAw/d9ZLssg/FFQ=", "https://gunnar.net" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Login", "PasswordHash", "PasswordSalt", "Provider", "Url" },
                values: new object[] { "Destini.Conroy", "XcFWuZcsFs7OEe8H8gKIe8iK5hlKiVaNmSzo+oVIOJ4=", "MUVCUVETSIEBBV++jCJo1lbtXR3xAvLIsMJUPkljX8g=", 0, "http://felix.info" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Login", "PasswordHash", "PasswordSalt", "Provider", "Url" },
                values: new object[] { "Maeve.Stroman", "8ZVUGM6edsaLbC2ar2GRXDeXU2gCMqDBCUupXI1q0Z0=", "ORd2AHI/bmZh+oH+BQocG+avWY/YofpS4mGb8z/1P6I=", 1, "https://annamarie.com" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Login", "PasswordHash", "PasswordSalt", "Provider", "Url" },
                values: new object[] { "Chauncey_Nitzsche33", "RHdx9oigR6S5bsPVgrbxHrF3lLZnXc+sFJgJFRihopI=", "CCqz3ld1WkWGkYIHDvhECd9qEIP5+MITtVXKWAndL3E=", 2, "http://roosevelt.net" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Login", "PasswordHash", "PasswordSalt", "Provider", "Url" },
                values: new object[] { "John.Carroll8", "JTO3v1SQWnF8PsJWy+fHo8wDaiGEJsQ7XLEOkiruvKw=", "02FcxBiUi4JR5qylTKO8Fp8BK1w84UbFWSAEgkZqWl8=", 2, "http://arnoldo.org" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Login", "PasswordHash", "PasswordSalt", "Provider", "Url" },
                values: new object[] { "Niko.Crooks", "EnwVfR4E8gq9b4JO2PxGCJ58Swk+1JTDtnZKzHq86VE=", "bIw3y9OvKlMmy8H6MoPstXDV1Ri1EU17taNxfQbU1VE=", 1, "https://ambrose.com" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Login", "PasswordHash", "PasswordSalt", "Url" },
                values: new object[] { "Pearlie.Graham96", "9ha+uX29wlDAZ7KNrhOF5BZ9KVYHslTGXapb92Qs7hw=", "insHX/zgyqcP+ceVgHOM3565QMjPgLiQ7L6Bw7bUlnM=", "http://neil.name" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Login", "PasswordHash", "PasswordSalt", "Provider", "Url" },
                values: new object[] { "Sonny_McLaughlin23", "FrY5XhWo+Ieuu0px+HLwOKWlqigKFqF43GLHso3oZLA=", "bgoDHPEHjEyYqA0aVuI3aXjfW+I3O1C4t8ZvYgFr6Cw=", 0, "https://rhoda.info" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Login", "PasswordHash", "PasswordSalt", "Provider", "Url" },
                values: new object[] { "Jannie.Goldner", "qzIqTbnRoZyjATHJWkiDXuzn209cBov/S70QKcuDwdU=", "2rc9CGEn8kTOLtE0xxHWVJrRFG8En9I0NpZmT7ynNps=", 0, "http://marcelina.org" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Login", "PasswordHash", "PasswordSalt", "Provider", "Url" },
                values: new object[] { "Cassie34", "rx94l4ohA70Bs+BeFJIRk9aGJ2/hqI+AcZBZyjG2Mx0=", "g9g6ps/UDSt3qNly67T8WjsptTL6Eq6ikZNov8h180o=", 1, "https://schuyler.org" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Login", "PasswordHash", "PasswordSalt", "Provider", "Url" },
                values: new object[] { "Willis_Romaguera", "F8Va3SXcTDuLQ+Eux4dM+pg7sTOy2m92/z43gDkkan8=", "LYE8YKDAYqYGAh0RIcHz239CiGLKnyjfPM9auU8kWLk=", 0, "https://bobbie.info" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Login", "PasswordHash", "PasswordSalt", "Url" },
                values: new object[] { "Aylin61", "HHdG9nqytomms/SRdX822D7OXshwWj0ep6Q7JtGXtCg=", "16zIqWirCxlA4Y+tXsB4Hgtn9dyC9OPPAWxbnEOWAp0=", "https://briana.com" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Login", "PasswordHash", "PasswordSalt", "Url" },
                values: new object[] { "Edna.Hahn77", "sRr1sh4mwKlV1kimhFNAEbql6l+Mf/M6K5juXn/A1yc=", "Am2Em1pgl1YlqCoLX9POFRlreAPXczihLQ9imOx+rNs=", "https://ashlynn.biz" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Login", "PasswordHash", "PasswordSalt", "Url" },
                values: new object[] { "Titus91", "tpTtNVGMGYZOBQlI469PUwMOSZXGq+rZedcGEwnEslw=", "SdsNPEpv3A5+zHVFxV1i54fnTNf/SILG+oKaYrkl3eM=", "http://dwight.org" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Login", "PasswordHash", "PasswordSalt", "Provider", "Url" },
                values: new object[] { "Kassandra_Kemmer", "ojn+YeoVM3pqvgAgEptXDPDzmXSHBY1qP/c86JxasAI=", "RPAsGrH0V9ZZl/zLwKhWr9cWfjlHqe1gTQ1C2tsS44o=", 1, "http://destiny.com" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Login", "PasswordHash", "PasswordSalt", "Provider", "Url" },
                values: new object[] { "Leann_Jerde71", "lXNGr1fjfUjp1bcrT3d5e/tN6OJpktl44SKsulDUUtU=", "2uOGs7ZSyNmKXFwYZ0/t1ppFigdA2qSBg4cFldvMNYo=", 0, "http://scot.com" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Login", "PasswordHash", "PasswordSalt", "Url" },
                values: new object[] { "Rosa_Haley", "rnRJeI+wqrgelvXslfkbRCDmBaOyE7se73njOq66LKg=", "vE/SgLHLf89hOnErg3pbbnn7QAXpt7StWsNFnJHuNHc=", "https://vivianne.net" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "Login", "PasswordHash", "PasswordSalt", "Provider", "Url" },
                values: new object[] { "Emmett_McClure", "7+piVP+AgJ4JFMyYDT9IeWbZZOVUrosuTUdE/1voC64=", "Q4atzTMyM0KcPhj9BXOsDeA5mMRa0u9XcAAuNG8Oiqk=", 1, "https://juanita.biz" });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Url" },
                values: new object[,]
                {
                    { 23, "https://loremflickr.com/640/480?lock=245164000" },
                    { 22, "https://loremflickr.com/640/480?lock=639109103" },
                    { 21, "https://loremflickr.com/640/480?lock=2009551175" },
                    { 20, "https://loremflickr.com/640/480?lock=666130004" },
                    { 19, "https://loremflickr.com/640/480?lock=251969388" },
                    { 18, "https://loremflickr.com/640/480?lock=1619135858" },
                    { 17, "https://loremflickr.com/640/480?lock=1627246728" },
                    { 16, "https://loremflickr.com/640/480?lock=105575879" },
                    { 15, "https://loremflickr.com/640/480?lock=1126424437" },
                    { 14, "https://loremflickr.com/640/480?lock=2045055810" },
                    { 9, "https://loremflickr.com/640/480?lock=750228139" },
                    { 12, "https://loremflickr.com/640/480?lock=795639316" },
                    { 13, "https://loremflickr.com/640/480?lock=1143379573" },
                    { 5, "https://loremflickr.com/640/480?lock=1822844665" },
                    { 6, "https://loremflickr.com/640/480?lock=647665779" },
                    { 7, "https://loremflickr.com/640/480?lock=1129885050" },
                    { 4, "https://loremflickr.com/640/480?lock=1480224036" },
                    { 10, "https://loremflickr.com/640/480?lock=1022100058" },
                    { 11, "https://loremflickr.com/640/480?lock=249167178" },
                    { 8, "https://loremflickr.com/640/480?lock=1915200731" }
                });

            migrationBuilder.UpdateData(
                table: "ProjectMembers",
                keyColumns: new[] { "ProjectId", "UserId" },
                keyValues: new object[] { 20, 3 },
                column: "UserAccess",
                value: 2);

            migrationBuilder.InsertData(
                table: "ProjectMembers",
                columns: new[] { "ProjectId", "UserId", "UserAccess" },
                values: new object[,]
                {
                    { 10, 3, 0 },
                    { 17, 2, 2 },
                    { 8, 1, 1 },
                    { 3, 2, 2 }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AvatarId", "Birthday", "Email", "FirstName", "GitHubUrl", "LastActive", "LastName", "NickName", "PasswordHash", "PasswordSalt", "RegisteredAt" },
                values: new object[] { 1, new DateTime(1999, 12, 22, 6, 3, 47, 369, DateTimeKind.Unspecified).AddTicks(42), "Ezekiel72@hotmail.com", "Hassan", "http://jacques.biz", new DateTime(2018, 7, 6, 10, 43, 59, 584, DateTimeKind.Unspecified).AddTicks(7620), "Runolfsdottir", "Flavie.Muller8", "g/wZD2+HTAmK4ZFKflq8TYBMvjEy065KwEaa0gwBtP0=", "PK+GSOrHsjiInlpJW6zHXurdqh3eI2ZqCmXkX4uaIH8=", new DateTime(2018, 5, 13, 3, 31, 36, 66, DateTimeKind.Unspecified).AddTicks(845) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AvatarId", "Birthday", "Email", "FirstName", "GitHubUrl", "LastActive", "LastName", "NickName", "PasswordHash", "PasswordSalt", "RegisteredAt" },
                values: new object[] { 3, new DateTime(2000, 4, 11, 4, 54, 17, 251, DateTimeKind.Unspecified).AddTicks(2470), "Anne_Jakubowski81@gmail.com", "Shanna", "http://juanita.biz", new DateTime(2018, 7, 2, 3, 4, 30, 418, DateTimeKind.Unspecified).AddTicks(1723), "Olson", "Delphia98", "QLoYYcbp91N/iM6A//10yISmiGRZTYgnbSi+MRfp3p4=", "3uy3PlgwEGpcaytaFALfezrXASwpmw4Th+Pt06mx5Gg=", new DateTime(2018, 6, 10, 15, 10, 29, 523, DateTimeKind.Unspecified).AddTicks(7483) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Birthday", "LastActive", "PasswordHash", "PasswordSalt", "RegisteredAt" },
                values: new object[] { new DateTime(2005, 8, 13, 22, 13, 23, 745, DateTimeKind.Local).AddTicks(8552), new DateTime(2019, 8, 13, 22, 13, 23, 747, DateTimeKind.Local).AddTicks(2205), "nfvtBf3+bafnwsS//lRSnX+0XSYhqin2VP66R/ey9xs=", "d2rjrKDMC01HEMX5rCqTWyFBgWsvVhtJdoefzG/Pq1A=", new DateTime(2019, 8, 13, 22, 13, 23, 747, DateTimeKind.Local).AddTicks(2211) });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AccessModifier", "AuthorId", "CompilerType", "CountOfBuildAttempts", "CountOfSaveBuilds", "CreatedAt", "Description", "GitCredentialId", "Language", "LogoId", "Name", "ProjectLink", "ProjectType" },
                values: new object[] { 0, 3, 0, 10, 6, new DateTime(2018, 1, 21, 1, 18, 19, 295, DateTimeKind.Unspecified).AddTicks(3740), "Voluptas fuga soluta officiis temporibus.", 1, 1, 11, "dicta", "http://fabian.biz", 1 });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AccessModifier", "AuthorId", "CompilerType", "CountOfBuildAttempts", "CreatedAt", "Description", "GitCredentialId", "Language", "LogoId", "Name", "ProjectLink", "ProjectType" },
                values: new object[] { 1, 3, 0, 5, new DateTime(2018, 6, 9, 18, 2, 26, 825, DateTimeKind.Unspecified).AddTicks(6672), "Repellendus eligendi ad vel officia.", 9, 0, 19, "animi", "http://lucie.org", 2 });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AuthorId", "CompilerType", "CountOfBuildAttempts", "CountOfSaveBuilds", "CreatedAt", "Description", "GitCredentialId", "Language", "LogoId", "Name", "ProjectLink" },
                values: new object[] { 1, 0, 10, 7, new DateTime(2018, 1, 10, 7, 38, 41, 938, DateTimeKind.Unspecified).AddTicks(7227), "Iste rerum doloremque laudantium rerum.", 20, 1, 4, "cum", "https://talia.net" });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AuthorId", "CompilerType", "CountOfBuildAttempts", "CountOfSaveBuilds", "CreatedAt", "Description", "GitCredentialId", "Language", "LogoId", "Name", "ProjectLink" },
                values: new object[] { 3, 0, 7, 8, new DateTime(2018, 2, 14, 5, 7, 25, 717, DateTimeKind.Unspecified).AddTicks(3791), "Explicabo blanditiis corporis voluptatem tempora.", 3, 0, 10, "laborum", "https://everett.org" });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AccessModifier", "AuthorId", "CompilerType", "CountOfBuildAttempts", "CountOfSaveBuilds", "CreatedAt", "Description", "GitCredentialId", "Language", "LogoId", "Name", "ProjectLink", "ProjectType" },
                values: new object[] { 0, 1, 0, 5, 9, new DateTime(2018, 2, 11, 18, 36, 16, 185, DateTimeKind.Unspecified).AddTicks(2502), "Quidem vel nobis vel vel.", 4, 1, 15, "assumenda", "https://nicklaus.org", 1 });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AccessModifier", "AuthorId", "CompilerType", "CountOfBuildAttempts", "CountOfSaveBuilds", "CreatedAt", "Description", "GitCredentialId", "Language", "LogoId", "Name", "ProjectLink", "ProjectType" },
                values: new object[] { 0, 3, 0, 8, 6, new DateTime(2018, 4, 23, 9, 19, 52, 199, DateTimeKind.Unspecified).AddTicks(611), "Et voluptas consectetur nam nostrum.", 4, 0, 16, "eaque", "https://rocky.info", 2 });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CountOfBuildAttempts", "CountOfSaveBuilds", "CreatedAt", "Description", "GitCredentialId", "Language", "LogoId", "Name", "ProjectLink", "ProjectType" },
                values: new object[] { 10, 7, new DateTime(2018, 1, 14, 6, 41, 21, 239, DateTimeKind.Unspecified).AddTicks(2988), "Quos et sed omnis soluta.", 12, 1, 4, "maxime", "https://christelle.net", 1 });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CompilerType", "CountOfBuildAttempts", "CountOfSaveBuilds", "CreatedAt", "Description", "GitCredentialId", "LogoId", "Name", "ProjectLink", "ProjectType" },
                values: new object[] { 0, 10, 7, new DateTime(2018, 5, 9, 19, 46, 19, 882, DateTimeKind.Unspecified).AddTicks(648), "Qui adipisci deleniti culpa et.", 2, 11, "omnis", "http://hardy.info", 2 });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "AuthorId", "CompilerType", "CountOfBuildAttempts", "CountOfSaveBuilds", "CreatedAt", "Description", "GitCredentialId", "Language", "LogoId", "Name", "ProjectLink" },
                values: new object[] { 2, 0, 8, 6, new DateTime(2018, 5, 20, 10, 58, 40, 94, DateTimeKind.Unspecified).AddTicks(1285), "Excepturi odit et dolorem officia.", 2, 1, 19, "qui", "https://leda.net" });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "AccessModifier", "AuthorId", "CompilerType", "CountOfSaveBuilds", "CreatedAt", "Description", "GitCredentialId", "Language", "LogoId", "Name", "ProjectLink", "ProjectType" },
                values: new object[] { 0, 1, 0, 5, new DateTime(2018, 3, 29, 10, 40, 16, 430, DateTimeKind.Unspecified).AddTicks(9934), "Rerum dolores placeat sed vitae.", 20, 0, 4, "ea", "https://taylor.net", 2 });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "AccessModifier", "AuthorId", "CompilerType", "CountOfBuildAttempts", "CountOfSaveBuilds", "CreatedAt", "Description", "GitCredentialId", "Language", "LogoId", "Name", "ProjectLink", "ProjectType" },
                values: new object[] { 1, 1, 0, 8, 10, new DateTime(2018, 1, 5, 21, 33, 57, 552, DateTimeKind.Unspecified).AddTicks(4525), "Necessitatibus quas et ullam provident.", 10, 0, 8, "dolores", "http://marguerite.org", 1 });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "AuthorId", "CompilerType", "CountOfBuildAttempts", "CountOfSaveBuilds", "CreatedAt", "Description", "GitCredentialId", "LogoId", "Name", "ProjectLink" },
                values: new object[] { 1, 0, 6, 9, new DateTime(2018, 6, 12, 22, 50, 26, 607, DateTimeKind.Unspecified).AddTicks(9898), "Ut sed aliquam aperiam dolores.", 20, 6, "repellendus", "http://callie.name" });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "AccessModifier", "AuthorId", "CompilerType", "CountOfBuildAttempts", "CountOfSaveBuilds", "CreatedAt", "Description", "GitCredentialId", "Language", "LogoId", "Name", "ProjectLink", "ProjectType" },
                values: new object[] { 0, 3, 0, 10, 5, new DateTime(2018, 2, 4, 18, 40, 56, 195, DateTimeKind.Unspecified).AddTicks(3590), "Numquam maxime repudiandae minus velit.", 1, 1, 20, "enim", "http://nathaniel.biz", 2 });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "AccessModifier", "AuthorId", "CompilerType", "CountOfBuildAttempts", "CountOfSaveBuilds", "CreatedAt", "Description", "GitCredentialId", "LogoId", "ProjectLink", "ProjectType" },
                values: new object[] { 0, 3, 0, 9, 8, new DateTime(2018, 3, 26, 22, 22, 44, 164, DateTimeKind.Unspecified).AddTicks(6224), "Corporis laboriosam ab voluptatem iure.", 2, 13, "https://pearlie.name", 0 });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "AuthorId", "CompilerType", "CountOfSaveBuilds", "CreatedAt", "Description", "GitCredentialId", "Language", "LogoId", "Name", "ProjectLink" },
                values: new object[] { 1, 0, 7, new DateTime(2018, 3, 26, 12, 1, 51, 384, DateTimeKind.Unspecified).AddTicks(1676), "Illo aut consequatur quia non.", 3, 0, 20, "ullam", "http://rodolfo.info" });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CompilerType", "CountOfBuildAttempts", "CountOfSaveBuilds", "CreatedAt", "Description", "GitCredentialId", "Language", "LogoId", "Name", "ProjectLink", "ProjectType" },
                values: new object[] { 0, 10, 5, new DateTime(2018, 3, 18, 21, 40, 33, 377, DateTimeKind.Unspecified).AddTicks(9460), "Cupiditate harum numquam omnis unde.", 19, 0, 11, "expedita", "http://norbert.name", 1 });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CompilerType", "CountOfBuildAttempts", "CountOfSaveBuilds", "CreatedAt", "Description", "GitCredentialId", "Language", "LogoId", "Name", "ProjectLink", "ProjectType" },
                values: new object[] { 0, 7, 7, new DateTime(2018, 2, 9, 2, 30, 22, 730, DateTimeKind.Unspecified).AddTicks(6661), "Voluptas amet ut veniam nobis.", 2, 0, 13, "voluptas", "http://kristina.name", 0 });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "AccessModifier", "AuthorId", "CompilerType", "CountOfBuildAttempts", "CountOfSaveBuilds", "CreatedAt", "Description", "GitCredentialId", "LogoId", "Name", "ProjectLink", "ProjectType" },
                values: new object[] { 0, 3, 0, 10, 10, new DateTime(2018, 3, 23, 20, 43, 12, 521, DateTimeKind.Unspecified).AddTicks(3312), "Voluptatem consectetur minus facere eum.", 16, 19, "exercitationem", "http://margarita.org", 0 });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "AuthorId", "CompilerType", "CountOfBuildAttempts", "CreatedAt", "Description", "GitCredentialId", "LogoId", "Name", "ProjectLink", "ProjectType" },
                values: new object[] { 2, 0, 6, new DateTime(2018, 3, 5, 4, 14, 28, 816, DateTimeKind.Unspecified).AddTicks(7658), "Provident praesentium aliquam laudantium quo.", 5, 14, "non", "http://ralph.biz", 1 });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "AccessModifier", "AuthorId", "CountOfBuildAttempts", "CreatedAt", "Description", "GitCredentialId", "LogoId", "Name", "ProjectLink", "ProjectType" },
                values: new object[] { 1, 1, 5, new DateTime(2018, 3, 20, 10, 47, 29, 908, DateTimeKind.Unspecified).AddTicks(5458), "Sapiente corrupti voluptatem laboriosam alias.", 5, 8, "sed", "http://lavina.com", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Projects_LogoId",
                table: "Projects",
                column: "LogoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Images_LogoId",
                table: "Projects",
                column: "LogoId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
