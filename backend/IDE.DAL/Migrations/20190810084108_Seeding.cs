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
                    { 1, "Tamara34", "ePzYL+IhCHJMEY9L2FEaVcmJXo6t2R4Rk/eElUKQQx0=", "mLVE0foaF3oayRqP5PM4Z5RgBWpVhPc/kmKvoKrQ2NE=", 2, "https://jayda.net" },
                    { 20, "Emmett_McClure", "VKWSrpP7skuB6OOkL0jlvuoGQUtcyXA0hg83FLQP9iY=", "wrt+ejXippJadfHS9LHYqSRZkHFZOkrO4Ql3skKw8Lw=", 1, "https://juanita.biz" },
                    { 19, "Rosa_Haley", "ojGhC3uq438DXLJVGLppyunYSLS+srXoXri0OnwZrRA=", "dMTE/VlNcvCI+EPAeZzWhJhPOZKO9O+SfRXWxS+gNx8=", 0, "https://vivianne.net" },
                    { 18, "Leann_Jerde71", "0iVuSXRID4lzoB+SmjUnQsA4FZNFXlKlUtSfHw+Xj+o=", "W3nb1sZIlIaoQOGo2+iO7AKGRswtW8ITmL8L45cqs2g=", 0, "http://scot.com" },
                    { 17, "Kassandra_Kemmer", "0z0TR5h5WZRCatJyzzK0l2Tv6zYA9bESyeChDp8OWrg=", "QTuOhHKvURnuq/+9yiLFalEr4lnrK0Gk9g67H57D2XE=", 1, "http://destiny.com" },
                    { 16, "Titus91", "GtFhOG0KxeW1cjU9AGHent3QU/ykJb3cxVJorVDFN1c=", "i8QRBE/MQRYp3VvjLc+u8fvpvyswM3QTbjXwpZR/HBY=", 0, "http://dwight.org" },
                    { 14, "Aylin61", "1sVPjZWszR0KIJ5sI554rCbrYOFyKXV40IPgY1ntH8A=", "FluHzvwfHtq27lMD9zp3OMpheF+Vc0aV0GddPAWdIhI=", 0, "https://briana.com" },
                    { 13, "Willis_Romaguera", "751E/zh6vqDqKcfyb3poJb9rgSEo6dazWB/yIgx+VIo=", "fYmSLX0Y6arp9ghDLF9B161AijXmtV/gb+q2cjTh+ro=", 0, "https://bobbie.info" },
                    { 12, "Cassie34", "rRf/tSz2mX7BA5BczVlVgOQhSoDZHoigo1ASJsMyXZw=", "QtmpDeb7D9ZQ/ulpAJgLd8Cgz0JIT9mwolWYsjsgBak=", 1, "https://schuyler.org" },
                    { 11, "Jannie.Goldner", "ujzhxyvQwf6cyXaalLdIipKpvZlVkLszMVtc57TB918=", "4pMXFZLt//fZPHgLC/iRxvfuK08ovMmquKgZMGmau4I=", 0, "http://marcelina.org" },
                    { 15, "Edna.Hahn77", "wacWwAJvWwpbw2D4zSyeRKGl5qdPy86/CRvZh8x+4g0=", "I6MBSUCmj7rHkNv08eR2Dw/CTHFLDrKCCuuTFRsMM0s=", 0, "https://ashlynn.biz" },
                    { 9, "Pearlie.Graham96", "vW7ukGM6s0GrPSDZPzgkJlmsn3PwA78ODiXdnvbKwaI=", "AKnIT8pt8IjWwWLuTYpla5pPTurKc1DtkiKrzOiLjro=", 2, "http://neil.name" },
                    { 8, "Niko.Crooks", "MoGnYwqE5CzfjDb6T5z/viXoxAVzL+3H3Kajxo3w0vw=", "d/deHr+5Aon4L72Y6vd3e1R7ZgO89UJUzoTvv4CPw2E=", 1, "https://ambrose.com" },
                    { 7, "John.Carroll8", "xTaFbzMFcFu1/d8NrV1dA3jK7AxmBBF8TlwAI/zMTQU=", "9hYaCJJKQsa0ipxc0AvXa2/L0VyDJFqmNmJ/ZRthxlI=", 2, "http://arnoldo.org" },
                    { 6, "Chauncey_Nitzsche33", "mbQh2YyMuQDMzNGg5VLwGbZamy3CPfo4/9DXqshcJHA=", "xcPqAuTKF5NubbalzRz4udtXuK8SjEJpT/P92m6WUog=", 2, "http://roosevelt.net" },
                    { 5, "Maeve.Stroman", "oNZuRutg4qKkILP84stbKGzlqSx4DoTcx0prNNxxsEI=", "ih9UIJ51pZW65BTdguhtREEeCQscuCfhpPueTl/IMEA=", 1, "https://annamarie.com" },
                    { 4, "Destini.Conroy", "Z/L7ZiFW4ePV7PjsUhGUAsRViHbeF1GmA2jtkXc74EU=", "4TTwsE0OecoZkFJA32NZC4UIDdQmBPsdDOcy5E3/LBU=", 0, "http://felix.info" },
                    { 3, "Connie42", "362/5hApxPktORE8aKCsDRWPBl9QFhcRSI32hiaBxR4=", "KJy4wekrcp71AqXYcbY3fUfGI8uhBiSAGfaf6iHJqoo=", 2, "https://gunnar.net" },
                    { 2, "Maximillia.Donnelly", "yPnBn9T3Y80haqLZdpK45aQHJs6E4CN/BDmBhWAUSCo=", "u1JqD5xAc/PJOdzmPI1SGCPB6iOVfGvQC9nwkGqgkt8=", 0, "https://mazie.com" },
                    { 10, "Sonny_McLaughlin23", "7qi74UQQp/jimhSOojDntvJBikNzsSTokV/0kuBSkLM=", "BYQRIE3XayLJ8vsCXPgw7vUmxegl4aPVqTnYzwDhgng=", 0, "https://rhoda.info" }
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
                values: new object[] { 1, 1, new DateTime(1999, 12, 22, 6, 3, 47, 369, DateTimeKind.Unspecified).AddTicks(42), "Ezekiel72@hotmail.com", "Hassan", "http://jacques.biz", new DateTime(2018, 7, 6, 10, 43, 59, 584, DateTimeKind.Unspecified).AddTicks(7620), "Runolfsdottir", "Flavie.Muller8", "ndpGP32HpVWIDvXcv5z/IGpg7El/tQTxKJM+HhcE9fk=", "jjwwUexi++6lxsmJ12YsIZ1PEHx+GXMl3qrf6SQZWFs=", new DateTime(2018, 5, 13, 3, 31, 36, 66, DateTimeKind.Unspecified).AddTicks(845) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AvatarId", "Birthday", "Email", "FirstName", "GitHubUrl", "LastActive", "LastName", "NickName", "PasswordHash", "PasswordSalt", "RegisteredAt" },
                values: new object[] { 3, 1, new DateTime(2005, 8, 10, 11, 41, 6, 744, DateTimeKind.Local).AddTicks(2122), "test@gmail.com", "testUser", null, new DateTime(2019, 8, 10, 11, 41, 6, 747, DateTimeKind.Local).AddTicks(7987), "testUser", "TheBestUser", "9uc96U2HkKj1NjgZUdhWnVu4QeAxUCOHsQqmLq8+1Is=", "2lDXocoFbjEDk5eW8BojnQpGy8tjusJCVR5qR9Oemnc=", new DateTime(2019, 8, 10, 11, 41, 6, 747, DateTimeKind.Local).AddTicks(7997) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AvatarId", "Birthday", "Email", "FirstName", "GitHubUrl", "LastActive", "LastName", "NickName", "PasswordHash", "PasswordSalt", "RegisteredAt" },
                values: new object[] { 2, 3, new DateTime(2000, 4, 11, 4, 54, 17, 251, DateTimeKind.Unspecified).AddTicks(2470), "Anne_Jakubowski81@gmail.com", "Shanna", "http://juanita.biz", new DateTime(2018, 7, 2, 3, 4, 30, 418, DateTimeKind.Unspecified).AddTicks(1723), "Olson", "Delphia98", "tNeIIDnnichhPhQoNIID6SELudfbNzFJScIBZqsh8Go=", "r9pDsjS/TTd3uRk7MKXkHI85BetOmuq7fBNbtL1CjG4=", new DateTime(2018, 6, 10, 15, 10, 29, 523, DateTimeKind.Unspecified).AddTicks(7483) });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "AccessModifier", "AuthorId", "CompilerType", "CountOfBuildAttempts", "CountOfSaveBuilds", "CreatedAt", "Description", "GitCredentialId", "Language", "Name", "ProjectLink", "ProjectType", "Color" },
                values: new object[,]
                {
                    { 3, 0, 1, 0, 10, 7, new DateTime(2018, 1, 10, 7, 38, 41, 938, DateTimeKind.Unspecified).AddTicks(7227), "Iste rerum doloremque laudantium rerum.", 20, 1, "cum", "https://talia.net", 2, "#ff0000" },
                    { 16, 0, 2, 0, 10, 5, new DateTime(2018, 3, 18, 21, 40, 33, 377, DateTimeKind.Unspecified).AddTicks(9460), "Cupiditate harum numquam omnis unde.", 19, 0, "expedita", "http://norbert.name", 1, "#000000"},
                    { 9, 1, 2, 0, 8, 6, new DateTime(2018, 5, 20, 10, 58, 40, 94, DateTimeKind.Unspecified).AddTicks(1285), "Excepturi odit et dolorem officia.", 2, 1,  "qui", "https://leda.net", 0, "#0080ff" },
                    { 8, 1, 2, 0, 10, 7, new DateTime(2018, 5, 9, 19, 46, 19, 882, DateTimeKind.Unspecified).AddTicks(648), "Qui adipisci deleniti culpa et.", 2, 1, "omnis", "http://hardy.info", 2, "#bf00ff" },
                    { 18, 0, 3, 0, 10, 10, new DateTime(2018, 3, 23, 20, 43, 12, 521, DateTimeKind.Unspecified).AddTicks(3312), "Voluptatem consectetur minus facere eum.", 16, 1, "exercitationem", "http://margarita.org", 0, "#00ffff" },
                    { 14, 0, 3, 0, 9, 8, new DateTime(2018, 3, 26, 22, 22, 44, 164, DateTimeKind.Unspecified).AddTicks(6224), "Corporis laboriosam ab voluptatem iure.", 2, 1,  "dolores", "https://pearlie.name", 0, "#8b008b" },
                    { 13, 0, 3, 0, 10, 5, new DateTime(2018, 2, 4, 18, 40, 56, 195, DateTimeKind.Unspecified).AddTicks(3590), "Numquam maxime repudiandae minus velit.", 1, 1,  "enim", "http://nathaniel.biz", 2, "#ff8c00" },
                    { 6, 0, 3, 0, 8, 6, new DateTime(2018, 4, 23, 9, 19, 52, 199, DateTimeKind.Unspecified).AddTicks(611), "Et voluptas consectetur nam nostrum.", 4, 0, "eaque", "https://rocky.info", 2, "#ffd700" },
                    { 4, 0, 3, 0, 7, 8, new DateTime(2018, 2, 14, 5, 7, 25, 717, DateTimeKind.Unspecified).AddTicks(3791), "Explicabo blanditiis corporis voluptatem tempora.", 3, 0, "laborum", "https://everett.org", 2, "#008000" },
                    { 2, 1, 3, 0, 5, 6, new DateTime(2018, 6, 9, 18, 2, 26, 825, DateTimeKind.Unspecified).AddTicks(6672), "Repellendus eligendi ad vel officia.", 9, 0, "animi", "http://lucie.org", 2, "#778899" },
                    { 1, 0, 3, 0, 10, 6, new DateTime(2018, 1, 21, 1, 18, 19, 295, DateTimeKind.Unspecified).AddTicks(3740), "Voluptas fuga soluta officiis temporibus.", 1, 1, "dicta", "http://fabian.biz", 1, "#ff0000" },
                    { 20, 1, 1, 0, 5, 5, new DateTime(2018, 3, 20, 10, 47, 29, 908, DateTimeKind.Unspecified).AddTicks(5458), "Sapiente corrupti voluptatem laboriosam alias.", 5, 0, "sed", "http://lavina.com", 1, "#000000" },
                    { 15, 0, 1, 0, 5, 7, new DateTime(2018, 3, 26, 12, 1, 51, 384, DateTimeKind.Unspecified).AddTicks(1676), "Illo aut consequatur quia non.", 3, 0, "ullam", "http://rodolfo.info", 0, "#00ffff"  },
                    { 12, 1, 1, 0, 6, 9, new DateTime(2018, 6, 12, 22, 50, 26, 607, DateTimeKind.Unspecified).AddTicks(9898), "Ut sed aliquam aperiam dolores.", 20, 0, "repellendus", "http://callie.name", 1, "#bf00ff" },
                    { 11, 1, 1, 0, 8, 10, new DateTime(2018, 1, 5, 21, 33, 57, 552, DateTimeKind.Unspecified).AddTicks(4525), "Necessitatibus quas et ullam provident.", 10, 0, "dolores", "http://marguerite.org", 1, "#00ffff" },
                    { 10, 0, 1, 0, 10, 5, new DateTime(2018, 3, 29, 10, 40, 16, 430, DateTimeKind.Unspecified).AddTicks(9934), "Rerum dolores placeat sed vitae.", 20, 0, "ea", "https://taylor.net", 2, "#000000" },
                    { 7, 1, 1, 0, 10, 7, new DateTime(2018, 1, 14, 6, 41, 21, 239, DateTimeKind.Unspecified).AddTicks(2988), "Quos et sed omnis soluta.", 12, 1, "maxime", "https://christelle.net", 1, "#0080ff" },
                    { 5, 0, 1, 0, 5, 9, new DateTime(2018, 2, 11, 18, 36, 16, 185, DateTimeKind.Unspecified).AddTicks(2502), "Quidem vel nobis vel vel.", 4, 1, "assumenda", "https://nicklaus.org", 1, "#8b008b" },
                    { 17, 0, 2, 0, 7, 7, new DateTime(2018, 2, 9, 2, 30, 22, 730, DateTimeKind.Unspecified).AddTicks(6661), "Voluptas amet ut veniam nobis.", 2, 0, "voluptas", "http://kristina.name", 0, "#778899" },
                    { 19, 0, 2, 0, 6, 6, new DateTime(2018, 3, 5, 4, 14, 28, 816, DateTimeKind.Unspecified).AddTicks(7658), "Provident praesentium aliquam laudantium quo.", 5, 0, "non", "http://ralph.biz", 1, "#ffd700" }
                });

            migrationBuilder.InsertData(
                table: "Builds",
                columns: new[] { "Id", "BuildFinished", "BuildMessage", "BuildStarted", "BuildStatus", "ProjectId", "UserId" },
                values: new object[,]
                {
                    { 30, new DateTime(2018, 10, 30, 19, 21, 35, 117, DateTimeKind.Unspecified).AddTicks(9591), "Est quidem magni nihil similique non eos quibusdam recusandae dolorem.", new DateTime(2018, 9, 10, 0, 24, 32, 726, DateTimeKind.Unspecified).AddTicks(9552), 1, 4, 1 },
                    { 26, new DateTime(2018, 10, 16, 6, 22, 33, 99, DateTimeKind.Unspecified).AddTicks(3300), "Sed quibusdam eos voluptate nam omnis sit quo sit officia.", new DateTime(2018, 9, 5, 12, 13, 39, 151, DateTimeKind.Unspecified).AddTicks(8035), 1, 16, 3 },
                    { 3, new DateTime(2018, 10, 9, 17, 40, 33, 977, DateTimeKind.Unspecified).AddTicks(5471), "Non dolorem ipsam perspiciatis aperiam et perferendis modi ullam dicta.", new DateTime(2018, 9, 28, 14, 35, 0, 717, DateTimeKind.Unspecified).AddTicks(9132), 1, 4, 1 },
                    { 9, new DateTime(2018, 10, 5, 5, 3, 2, 944, DateTimeKind.Unspecified).AddTicks(6743), "Eaque ut in nihil tempora necessitatibus ea quos iusto deleniti.", new DateTime(2018, 9, 21, 16, 31, 18, 437, DateTimeKind.Unspecified).AddTicks(193), 0, 4, 3 },
                    { 14, new DateTime(2018, 10, 25, 11, 59, 45, 319, DateTimeKind.Unspecified).AddTicks(1502), "Quasi corporis et illum voluptatibus corporis nulla qui aut consequuntur.", new DateTime(2018, 9, 24, 23, 52, 5, 625, DateTimeKind.Unspecified).AddTicks(2644), 1, 4, 1 },
                    { 16, new DateTime(2018, 10, 18, 4, 15, 26, 882, DateTimeKind.Unspecified).AddTicks(4336), "Explicabo perspiciatis numquam suscipit consequatur qui eius molestias quaerat aut.", new DateTime(2018, 9, 15, 6, 44, 19, 923, DateTimeKind.Unspecified).AddTicks(6244), 0, 4, 2 },
                    { 22, new DateTime(2018, 10, 26, 13, 34, 0, 756, DateTimeKind.Unspecified).AddTicks(695), "Totam modi eius corrupti ipsum quas amet aperiam provident accusamus.", new DateTime(2018, 9, 20, 23, 26, 17, 398, DateTimeKind.Unspecified).AddTicks(2158), 0, 4, 1 },
                    { 37, new DateTime(2018, 10, 30, 20, 47, 10, 926, DateTimeKind.Unspecified).AddTicks(3950), "Hic rerum quia porro doloribus ut qui exercitationem minus sint.", new DateTime(2018, 9, 17, 2, 4, 19, 619, DateTimeKind.Unspecified).AddTicks(4898), 1, 19, 1 },
                    { 31, new DateTime(2018, 10, 16, 22, 5, 53, 78, DateTimeKind.Unspecified).AddTicks(7764), "Et sint molestiae id sit a ducimus sed quis dolores.", new DateTime(2018, 9, 29, 20, 58, 55, 531, DateTimeKind.Unspecified).AddTicks(7468), 0, 4, 2 },
                    { 40, new DateTime(2018, 10, 21, 9, 13, 9, 903, DateTimeKind.Unspecified).AddTicks(3954), "Ipsam qui quidem laboriosam enim debitis quod vero rerum nemo.", new DateTime(2018, 9, 18, 10, 1, 32, 631, DateTimeKind.Unspecified).AddTicks(841), 0, 4, 2 },
                    { 38, new DateTime(2018, 10, 24, 16, 35, 14, 470, DateTimeKind.Unspecified).AddTicks(7019), "Id praesentium ea necessitatibus at expedita quis et molestiae quia.", new DateTime(2018, 9, 16, 13, 39, 50, 442, DateTimeKind.Unspecified).AddTicks(3242), 0, 9, 2 },
                    { 11, new DateTime(2018, 10, 31, 5, 22, 48, 912, DateTimeKind.Unspecified).AddTicks(100), "Consequatur dolores exercitationem non quam consequatur esse fugit sed officia.", new DateTime(2018, 9, 30, 9, 57, 47, 39, DateTimeKind.Unspecified).AddTicks(3083), 0, 6, 1 },
                    { 15, new DateTime(2018, 10, 31, 4, 26, 25, 391, DateTimeKind.Unspecified).AddTicks(6764), "Sunt explicabo accusamus impedit ut architecto sit dolorem et nihil.", new DateTime(2018, 9, 9, 21, 30, 53, 735, DateTimeKind.Unspecified).AddTicks(7870), 0, 6, 1 },
                    { 27, new DateTime(2018, 10, 29, 10, 9, 16, 171, DateTimeKind.Unspecified).AddTicks(7606), "Nobis perferendis error illum provident aut in laborum debitis ipsam.", new DateTime(2018, 9, 22, 1, 29, 16, 616, DateTimeKind.Unspecified).AddTicks(8139), 1, 8, 2 },
                    { 23, new DateTime(2018, 10, 8, 5, 20, 22, 700, DateTimeKind.Unspecified).AddTicks(4916), "Aut eos numquam hic consequatur non quidem id aut similique.", new DateTime(2018, 9, 21, 7, 30, 41, 232, DateTimeKind.Unspecified).AddTicks(1366), 0, 8, 1 },
                    { 28, new DateTime(2018, 10, 10, 16, 30, 14, 334, DateTimeKind.Unspecified).AddTicks(7719), "Voluptatem fuga ut sapiente et explicabo eum numquam autem sint.", new DateTime(2018, 9, 1, 13, 33, 52, 569, DateTimeKind.Unspecified).AddTicks(1898), 0, 18, 1 },
                    { 6, new DateTime(2018, 10, 28, 9, 42, 48, 485, DateTimeKind.Unspecified).AddTicks(2599), "Error nam labore nemo id asperiores nobis molestiae aperiam aut.", new DateTime(2018, 9, 29, 5, 11, 32, 829, DateTimeKind.Unspecified).AddTicks(7786), 0, 13, 1 },
                    { 18, new DateTime(2018, 10, 22, 6, 55, 34, 427, DateTimeKind.Unspecified).AddTicks(9927), "Doloremque omnis assumenda blanditiis aperiam aliquam id fugiat et fugiat.", new DateTime(2018, 9, 27, 5, 19, 44, 682, DateTimeKind.Unspecified).AddTicks(8341), 1, 13, 2 },
                    { 24, new DateTime(2018, 10, 4, 21, 34, 52, 137, DateTimeKind.Unspecified).AddTicks(7127), "Quia fugit eos voluptatum ratione facilis a praesentium qui aut.", new DateTime(2018, 9, 27, 17, 54, 1, 190, DateTimeKind.Unspecified).AddTicks(5499), 0, 13, 1 },
                    { 29, new DateTime(2018, 10, 5, 10, 11, 17, 4, DateTimeKind.Unspecified).AddTicks(966), "Magni maxime velit voluptas non illum inventore occaecati eum laborum.", new DateTime(2018, 9, 25, 1, 36, 15, 960, DateTimeKind.Unspecified).AddTicks(7074), 0, 20, 1 },
                    { 33, new DateTime(2018, 10, 29, 4, 28, 20, 672, DateTimeKind.Unspecified).AddTicks(9663), "Sit officiis eius officiis vel quis possimus et et alias.", new DateTime(2018, 9, 8, 5, 18, 22, 892, DateTimeKind.Unspecified).AddTicks(6119), 0, 16, 1 },
                    { 1, new DateTime(2018, 10, 23, 15, 47, 9, 179, DateTimeKind.Unspecified).AddTicks(79), "Atque nemo repellat consequatur qui sit sint enim quis consequatur.", new DateTime(2018, 9, 16, 17, 23, 11, 478, DateTimeKind.Unspecified).AddTicks(8761), 0, 20, 1 },
                    { 21, new DateTime(2018, 10, 20, 0, 27, 23, 948, DateTimeKind.Unspecified).AddTicks(1952), "Beatae minima voluptatem voluptates minus consectetur maiores et aut ea.", new DateTime(2018, 9, 29, 10, 23, 54, 950, DateTimeKind.Unspecified).AddTicks(2172), 1, 5, 2 },
                    { 35, new DateTime(2018, 10, 6, 20, 26, 54, 239, DateTimeKind.Unspecified).AddTicks(7732), "Perferendis aut occaecati laudantium voluptatum sunt rerum veniam ut illum.", new DateTime(2018, 9, 5, 13, 8, 46, 801, DateTimeKind.Unspecified).AddTicks(9390), 0, 5, 2 },
                    { 39, new DateTime(2018, 10, 5, 7, 36, 54, 904, DateTimeKind.Unspecified).AddTicks(1393), "Doloribus qui perspiciatis in accusamus quia aperiam et nihil ipsam.", new DateTime(2018, 9, 21, 21, 46, 0, 845, DateTimeKind.Unspecified).AddTicks(1702), 1, 5, 2 },
                    { 20, new DateTime(2018, 10, 24, 12, 20, 38, 358, DateTimeKind.Unspecified).AddTicks(4617), "Nam quis in sunt architecto et voluptatem nihil corporis et.", new DateTime(2018, 9, 27, 0, 51, 14, 724, DateTimeKind.Unspecified).AddTicks(3419), 0, 19, 2 },
                    { 5, new DateTime(2018, 10, 16, 1, 23, 13, 476, DateTimeKind.Unspecified).AddTicks(7597), "In sint omnis consequatur beatae ex dolorem molestiae sed minus.", new DateTime(2018, 9, 1, 17, 8, 44, 496, DateTimeKind.Unspecified).AddTicks(8553), 1, 7, 1 },
                    { 12, new DateTime(2018, 10, 9, 2, 53, 11, 978, DateTimeKind.Unspecified).AddTicks(9631), "Voluptatum sint quisquam harum ipsam pariatur aut sit consequuntur debitis.", new DateTime(2018, 9, 14, 8, 53, 31, 38, DateTimeKind.Unspecified).AddTicks(1737), 1, 7, 1 },
                    { 25, new DateTime(2018, 10, 3, 2, 8, 34, 208, DateTimeKind.Unspecified).AddTicks(6139), "Aperiam quibusdam ut omnis nostrum consequatur quas aliquam possimus saepe.", new DateTime(2018, 9, 26, 0, 24, 5, 580, DateTimeKind.Unspecified).AddTicks(7737), 1, 7, 3 },
                    { 2, new DateTime(2018, 10, 6, 2, 19, 39, 968, DateTimeKind.Unspecified).AddTicks(3908), "Eaque illo est numquam aut numquam et vel sed magnam.", new DateTime(2018, 9, 8, 5, 50, 22, 25, DateTimeKind.Unspecified).AddTicks(2329), 1, 20, 2 },
                    { 10, new DateTime(2018, 10, 13, 0, 18, 44, 750, DateTimeKind.Unspecified).AddTicks(2466), "Dolor et qui natus assumenda quaerat deserunt qui beatae praesentium.", new DateTime(2018, 9, 25, 13, 4, 34, 389, DateTimeKind.Unspecified).AddTicks(7091), 1, 10, 1 },
                    { 32, new DateTime(2018, 10, 4, 6, 8, 50, 126, DateTimeKind.Unspecified).AddTicks(9277), "Voluptates ea quia esse dolorem vel hic dolor et et.", new DateTime(2018, 9, 30, 20, 19, 4, 61, DateTimeKind.Unspecified).AddTicks(317), 1, 10, 1 },
                    { 34, new DateTime(2018, 10, 19, 19, 2, 54, 8, DateTimeKind.Unspecified).AddTicks(3284), "Nihil voluptatibus ducimus eum sint eveniet cum est voluptatum dolores.", new DateTime(2018, 9, 26, 10, 44, 54, 104, DateTimeKind.Unspecified).AddTicks(1605), 0, 17, 1 },
                    { 19, new DateTime(2018, 10, 25, 13, 9, 31, 780, DateTimeKind.Unspecified).AddTicks(6530), "Maiores vero quos dolor aut veniam vitae quo error necessitatibus.", new DateTime(2018, 9, 7, 5, 57, 41, 936, DateTimeKind.Unspecified).AddTicks(2246), 1, 11, 2 },
                    { 17, new DateTime(2018, 10, 28, 0, 32, 7, 869, DateTimeKind.Unspecified).AddTicks(1658), "Id aut consectetur blanditiis corrupti nam rerum possimus cumque porro.", new DateTime(2018, 9, 2, 11, 47, 36, 719, DateTimeKind.Unspecified).AddTicks(3602), 0, 17, 1 },
                    { 7, new DateTime(2018, 10, 13, 20, 25, 37, 632, DateTimeKind.Unspecified).AddTicks(3029), "Molestias dolores rem vel est ea officiis consectetur et praesentium.", new DateTime(2018, 9, 11, 10, 58, 19, 255, DateTimeKind.Unspecified).AddTicks(4968), 1, 17, 2 },
                    { 8, new DateTime(2018, 10, 15, 18, 46, 2, 848, DateTimeKind.Unspecified).AddTicks(9764), "Laboriosam soluta est aut hic tenetur est similique sit quos.", new DateTime(2018, 9, 22, 10, 25, 51, 131, DateTimeKind.Unspecified).AddTicks(4016), 1, 15, 3 },
                    { 36, new DateTime(2018, 10, 19, 3, 24, 38, 43, DateTimeKind.Unspecified).AddTicks(46), "Minima consectetur delectus aut adipisci perferendis dolores est aut aut.", new DateTime(2018, 9, 11, 3, 32, 43, 908, DateTimeKind.Unspecified).AddTicks(6455), 0, 15, 3 },
                    { 13, new DateTime(2018, 10, 13, 14, 55, 14, 971, DateTimeKind.Unspecified).AddTicks(5972), "Voluptatem voluptates ipsum praesentium tempore iste sit et molestiae culpa.", new DateTime(2018, 9, 23, 19, 12, 4, 443, DateTimeKind.Unspecified).AddTicks(2831), 1, 10, 3 },
                    { 4, new DateTime(2018, 10, 26, 5, 27, 56, 310, DateTimeKind.Unspecified).AddTicks(611), "Sint dolore itaque architecto et ipsum doloribus pariatur est sint.", new DateTime(2018, 9, 19, 14, 28, 45, 467, DateTimeKind.Unspecified).AddTicks(2025), 1, 18, 3 }
                });

            migrationBuilder.InsertData(
                table: "ProjectMembers",
                columns: new[] { "ProjectId", "UserId", "UserAccess" },
                values: new object[,]
                {
                    { 17, 2, 2 },
                    { 8, 1, 1 },
                    { 9, 3, 3 },
                    { 3, 2, 2 },
                    { 6, 3, 2 },
                    { 6, 1, 3 },
                    { 6, 2, 1 },
                    { 4, 1, 0 },
                    { 4, 3, 0 },
                    { 2, 2, 1 },
                    { 20, 1, 0 },
                    { 20, 3, 2 },
                    { 12, 3, 3 },
                    { 11, 1, 2 },
                    { 10, 3, 0 },
                    { 7, 1, 3 },
                    { 5, 2, 3 },
                    { 14, 2, 1 },
                    { 19, 3, 0 }
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
                keyValue: 6);

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
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 15);

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
                keyValue: 2);

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
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 12);

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
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "ProjectMembers",
                keyColumns: new[] { "ProjectId", "UserId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "ProjectMembers",
                keyColumns: new[] { "ProjectId", "UserId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "ProjectMembers",
                keyColumns: new[] { "ProjectId", "UserId" },
                keyValues: new object[] { 4, 3 });

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
                keyValues: new object[] { 6, 2 });

            migrationBuilder.DeleteData(
                table: "ProjectMembers",
                keyColumns: new[] { "ProjectId", "UserId" },
                keyValues: new object[] { 6, 3 });

            migrationBuilder.DeleteData(
                table: "ProjectMembers",
                keyColumns: new[] { "ProjectId", "UserId" },
                keyValues: new object[] { 7, 1 });

            migrationBuilder.DeleteData(
                table: "ProjectMembers",
                keyColumns: new[] { "ProjectId", "UserId" },
                keyValues: new object[] { 8, 1 });

            migrationBuilder.DeleteData(
                table: "ProjectMembers",
                keyColumns: new[] { "ProjectId", "UserId" },
                keyValues: new object[] { 9, 3 });

            migrationBuilder.DeleteData(
                table: "ProjectMembers",
                keyColumns: new[] { "ProjectId", "UserId" },
                keyValues: new object[] { 10, 3 });

            migrationBuilder.DeleteData(
                table: "ProjectMembers",
                keyColumns: new[] { "ProjectId", "UserId" },
                keyValues: new object[] { 11, 1 });

            migrationBuilder.DeleteData(
                table: "ProjectMembers",
                keyColumns: new[] { "ProjectId", "UserId" },
                keyValues: new object[] { 12, 3 });

            migrationBuilder.DeleteData(
                table: "ProjectMembers",
                keyColumns: new[] { "ProjectId", "UserId" },
                keyValues: new object[] { 14, 2 });

            migrationBuilder.DeleteData(
                table: "ProjectMembers",
                keyColumns: new[] { "ProjectId", "UserId" },
                keyValues: new object[] { 17, 2 });

            migrationBuilder.DeleteData(
                table: "ProjectMembers",
                keyColumns: new[] { "ProjectId", "UserId" },
                keyValues: new object[] { 19, 3 });

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
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 16);

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
                keyValue: 4);

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
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 11);

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
                keyValue: 3);
        }
    }
}
