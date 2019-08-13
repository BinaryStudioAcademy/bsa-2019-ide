using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IDE.DAL.Migrations
{
    public partial class FavouriteProjects : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_GitCredentials_GitCredentialId",
                table: "Projects");

            migrationBuilder.AlterColumn<int>(
                name: "GitCredentialId",
                table: "Projects",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateTable(
                name: "FavouriteProjects",
                columns: table => new
                {
                    ProjectId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    Project = table.Column<int>(nullable: false),
                    User = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavouriteProjects", x => new { x.ProjectId, x.UserId });
                });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "0DU4mOt9dkGOXRkG3Tbc+eYj6831cPBr0D5az50rOcI=", "HgV1nqHvXRvDNGHK713HpTjCtD3xpOqXBCc4aYX8FgQ=" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "Ks+tysZ7aZmXCFsfHuUhapWTJgTg52uPT/uRB+OD3Ng=", "NUyLd743d4LGQMuK1yR1sSnQi6GW32CmGngij31yng0=" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "cBCJ+t6yECuSDTOeOFSgdTCFkGvIlsOWTBbnWYRE+QM=", "E5pAQKzy7jYfS7xVXOR5NLGDAJERbCkxfpld0wrWBks=" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "SXLg73NGe5RPFGX6uu0Z5TI7mXI6zSvPLKNRC+HtimM=", "NAsek2QtFGtCK3wXgtr5m19k0Tt3jTBgotc78xtNvck=" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "4mR1eEZ6o1TE/Q5fJBxmBMwWnWI7JOYwPPZH6bG4/Ek=", "ylL/VIIRcOlBEYt2j5d48Qrb6PK9yy8DDlKkz3yKmQM=" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "U+lomJsA4WRMBSrEbESASpLVftGSF9xGLE6oe29cjSQ=", "eZL5qCP+Rv+mWSX1n7Nl54uK7tw03shofgg9kWfV93M=" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "BO5G+3bRgFaaLbO3EVrPy16bJQnkA1yMXXiCOJ1Kb+g=", "8FtuGW/G76q5z94lr0wLBqbleSZgcFmW7QshrLVBVJI=" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "/A26HJk/tv3gWQ95ThSu+xOiFkLq77LXbQAVUTpM+FY=", "JzC5KxuuQLc/nqN790yeIdp0RK7u/SGWmGxcGkVN/e0=" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "GDmeirGXsMgZ1Tt5eSkpk8X8Khqdab953rb4ABCZ4L0=", "OUYvg0BaXIEHunwFm7pBWJRzH9zi5hLC/sdt0YeXnwE=" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "mqcEUSBPuS24GNQDTaWKLSI5ePrcI/12FOIlJ1jJAqo=", "hjWrBVltouJUKwdj8eWyMOtUb6ZaSWsbjNNjx+fXgJM=" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "hXZIPOJbNmxu49c2JSZiqecOmuEyV7Szj/oBeeEw9cY=", "vNKObysYyikeaCcQziecBIGDrG6PnJzhzTDdK5TufM0=" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "xfB4RACgQcIRVqWxyH9piFe/Xky1x1pfmf1uHY1wYvg=", "Dqu8WTH7eMSrIr28NKtrFnldEIJi3f+FXv6FAwmdCOM=" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "W2ervuA2oEQ5eJ6V5Kq5ZepnjY2hU67ulrapPjBbdUk=", "Q8PyxVJeUnuVg4AFr/g5080TPC4dyCj/PL/Pvn98yBA=" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "ucbFLtX+yUU/VfRaJkyiJ8wIDfoTavz8twMnqHW9Kiw=", "ghG4MWN/WrsCcBbLiXBr0awvHOxEEdtm34CfearFQgg=" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "TKhVbFWQ2CzZgM89A4ziAI0ihQDaFpZb0gdh4xMQzTE=", "kZsE93iPJurCbL4+nFPA41FbinyySwo9KCbmnzw0U7U=" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "IOSXIoGY6+URyi5DI7zCZyFqJvbpvZ7Gqa4+TofpLFc=", "bgfCrNIFcaqQn7MO/9Cf+VtNKYfukOyHrvak/2VjDe0=" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "/P/JzxtBdmPnzaaUQFGTXiokl9okszNPJSn1A3ZWK4o=", "8s3e2bV/WPR1VY2Fw3IJJCLncRnvDSBSqk72zfooAs4=" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "fnxitI2O6OIQWyygR4hIBmNm83NzdT8TdMLbRsTXZno=", "dODHOaYRJzaW2xdKIPIZXCb2KmpHpQ+qaqGxVUsMAKU=" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "ECpdXCQkiEA8kXRx9K3M8wOtPVa8erDM9WksHwNpiYU=", "1u0dTC2uhaAlcc5Ag3rXFiRu3mT7Sy/PQCBGdFHJip0=" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "A80ineU26bdtqCdOnBRNZyXxuhPhelNaTv2kgToJZaw=", "bKPf3KTbqXfzZHxaZK96+yHxasWEd8JUsCXx9OEKgd8=" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "2T9qJ4m5F4Dy44cJzT0+iq68Ys2FAoeO8cVZB9D1KPw=", "x4DDnS6JKM7vM5s0o3n69qrmTnyfZ7n3foe3Gg/9B3g=" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "RteDRFv1VzrGn28TE3M32P0BwoBmJnAWVmKIe4QUpZA=", "douRlWvZCuikHSyacBXAFBfDxZEMhKRal6T3EMhgVTc=" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Birthday", "LastActive", "PasswordHash", "PasswordSalt", "RegisteredAt" },
                values: new object[] { new DateTime(2005, 8, 13, 16, 7, 5, 324, DateTimeKind.Local).AddTicks(7023), new DateTime(2019, 8, 13, 16, 7, 5, 326, DateTimeKind.Local).AddTicks(790), "4PPcOT/MT8E0fCTJSAV2Oz6ZaTuAQP3Gnw1cYlIyIVA=", "tvcRPhzCfm0tJ7KrJhrIwVgkKCufo80G6LM+tb+Alls=", new DateTime(2019, 8, 13, 16, 7, 5, 326, DateTimeKind.Local).AddTicks(790) });

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_GitCredentials_GitCredentialId",
                table: "Projects",
                column: "GitCredentialId",
                principalTable: "GitCredentials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_GitCredentials_GitCredentialId",
                table: "Projects");

            migrationBuilder.DropTable(
                name: "FavouriteProjects");

            migrationBuilder.AlterColumn<int>(
                name: "GitCredentialId",
                table: "Projects",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "ePzYL+IhCHJMEY9L2FEaVcmJXo6t2R4Rk/eElUKQQx0=", "mLVE0foaF3oayRqP5PM4Z5RgBWpVhPc/kmKvoKrQ2NE=" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "yPnBn9T3Y80haqLZdpK45aQHJs6E4CN/BDmBhWAUSCo=", "u1JqD5xAc/PJOdzmPI1SGCPB6iOVfGvQC9nwkGqgkt8=" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "362/5hApxPktORE8aKCsDRWPBl9QFhcRSI32hiaBxR4=", "KJy4wekrcp71AqXYcbY3fUfGI8uhBiSAGfaf6iHJqoo=" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "Z/L7ZiFW4ePV7PjsUhGUAsRViHbeF1GmA2jtkXc74EU=", "4TTwsE0OecoZkFJA32NZC4UIDdQmBPsdDOcy5E3/LBU=" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "oNZuRutg4qKkILP84stbKGzlqSx4DoTcx0prNNxxsEI=", "ih9UIJ51pZW65BTdguhtREEeCQscuCfhpPueTl/IMEA=" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "mbQh2YyMuQDMzNGg5VLwGbZamy3CPfo4/9DXqshcJHA=", "xcPqAuTKF5NubbalzRz4udtXuK8SjEJpT/P92m6WUog=" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "xTaFbzMFcFu1/d8NrV1dA3jK7AxmBBF8TlwAI/zMTQU=", "9hYaCJJKQsa0ipxc0AvXa2/L0VyDJFqmNmJ/ZRthxlI=" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "MoGnYwqE5CzfjDb6T5z/viXoxAVzL+3H3Kajxo3w0vw=", "d/deHr+5Aon4L72Y6vd3e1R7ZgO89UJUzoTvv4CPw2E=" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "vW7ukGM6s0GrPSDZPzgkJlmsn3PwA78ODiXdnvbKwaI=", "AKnIT8pt8IjWwWLuTYpla5pPTurKc1DtkiKrzOiLjro=" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "7qi74UQQp/jimhSOojDntvJBikNzsSTokV/0kuBSkLM=", "BYQRIE3XayLJ8vsCXPgw7vUmxegl4aPVqTnYzwDhgng=" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "ujzhxyvQwf6cyXaalLdIipKpvZlVkLszMVtc57TB918=", "4pMXFZLt//fZPHgLC/iRxvfuK08ovMmquKgZMGmau4I=" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "rRf/tSz2mX7BA5BczVlVgOQhSoDZHoigo1ASJsMyXZw=", "QtmpDeb7D9ZQ/ulpAJgLd8Cgz0JIT9mwolWYsjsgBak=" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "751E/zh6vqDqKcfyb3poJb9rgSEo6dazWB/yIgx+VIo=", "fYmSLX0Y6arp9ghDLF9B161AijXmtV/gb+q2cjTh+ro=" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "1sVPjZWszR0KIJ5sI554rCbrYOFyKXV40IPgY1ntH8A=", "FluHzvwfHtq27lMD9zp3OMpheF+Vc0aV0GddPAWdIhI=" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "wacWwAJvWwpbw2D4zSyeRKGl5qdPy86/CRvZh8x+4g0=", "I6MBSUCmj7rHkNv08eR2Dw/CTHFLDrKCCuuTFRsMM0s=" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "GtFhOG0KxeW1cjU9AGHent3QU/ykJb3cxVJorVDFN1c=", "i8QRBE/MQRYp3VvjLc+u8fvpvyswM3QTbjXwpZR/HBY=" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "0z0TR5h5WZRCatJyzzK0l2Tv6zYA9bESyeChDp8OWrg=", "QTuOhHKvURnuq/+9yiLFalEr4lnrK0Gk9g67H57D2XE=" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "0iVuSXRID4lzoB+SmjUnQsA4FZNFXlKlUtSfHw+Xj+o=", "W3nb1sZIlIaoQOGo2+iO7AKGRswtW8ITmL8L45cqs2g=" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "ojGhC3uq438DXLJVGLppyunYSLS+srXoXri0OnwZrRA=", "dMTE/VlNcvCI+EPAeZzWhJhPOZKO9O+SfRXWxS+gNx8=" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "VKWSrpP7skuB6OOkL0jlvuoGQUtcyXA0hg83FLQP9iY=", "wrt+ejXippJadfHS9LHYqSRZkHFZOkrO4Ql3skKw8Lw=" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "ndpGP32HpVWIDvXcv5z/IGpg7El/tQTxKJM+HhcE9fk=", "jjwwUexi++6lxsmJ12YsIZ1PEHx+GXMl3qrf6SQZWFs=" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "tNeIIDnnichhPhQoNIID6SELudfbNzFJScIBZqsh8Go=", "r9pDsjS/TTd3uRk7MKXkHI85BetOmuq7fBNbtL1CjG4=" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Birthday", "LastActive", "PasswordHash", "PasswordSalt", "RegisteredAt" },
                values: new object[] { new DateTime(2005, 8, 10, 11, 41, 6, 744, DateTimeKind.Local).AddTicks(2122), new DateTime(2019, 8, 10, 11, 41, 6, 747, DateTimeKind.Local).AddTicks(7987), "9uc96U2HkKj1NjgZUdhWnVu4QeAxUCOHsQqmLq8+1Is=", "2lDXocoFbjEDk5eW8BojnQpGy8tjusJCVR5qR9Oemnc=", new DateTime(2019, 8, 10, 11, 41, 6, 747, DateTimeKind.Local).AddTicks(7997) });

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_GitCredentials_GitCredentialId",
                table: "Projects",
                column: "GitCredentialId",
                principalTable: "GitCredentials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
