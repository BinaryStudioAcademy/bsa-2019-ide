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
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavouriteProjects", x => new { x.ProjectId, x.UserId });
                    table.ForeignKey(
                        name: "FK_FavouriteProjects_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavouriteProjects_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "3wzx48I7qnjXwaIoW+02/zCOnbmcMhkeCRQz8oO+kzA=", "FtA/Cv2sHAdVh+tOHw4i2uBvEvZPU4hbZRf2aIT61JM=" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "SQme5Tncvc+JRCafmAUPskRjRxU3FAKooGZDNNxvskQ=", "RqGXIBZFGjpPJB1zkSu3wElmuu99woioXsUlDVshTb0=" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "IiUbUuSRdg4RtHH6I3iNVj+53BvYvPZT5QT1P2Qjnio=", "aZ3bppk0dx1abcVFlraTXSyXuKwTJAw/d9ZLssg/FFQ=" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "XcFWuZcsFs7OEe8H8gKIe8iK5hlKiVaNmSzo+oVIOJ4=", "MUVCUVETSIEBBV++jCJo1lbtXR3xAvLIsMJUPkljX8g=" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "8ZVUGM6edsaLbC2ar2GRXDeXU2gCMqDBCUupXI1q0Z0=", "ORd2AHI/bmZh+oH+BQocG+avWY/YofpS4mGb8z/1P6I=" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "RHdx9oigR6S5bsPVgrbxHrF3lLZnXc+sFJgJFRihopI=", "CCqz3ld1WkWGkYIHDvhECd9qEIP5+MITtVXKWAndL3E=" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "JTO3v1SQWnF8PsJWy+fHo8wDaiGEJsQ7XLEOkiruvKw=", "02FcxBiUi4JR5qylTKO8Fp8BK1w84UbFWSAEgkZqWl8=" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "EnwVfR4E8gq9b4JO2PxGCJ58Swk+1JTDtnZKzHq86VE=", "bIw3y9OvKlMmy8H6MoPstXDV1Ri1EU17taNxfQbU1VE=" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "9ha+uX29wlDAZ7KNrhOF5BZ9KVYHslTGXapb92Qs7hw=", "insHX/zgyqcP+ceVgHOM3565QMjPgLiQ7L6Bw7bUlnM=" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "FrY5XhWo+Ieuu0px+HLwOKWlqigKFqF43GLHso3oZLA=", "bgoDHPEHjEyYqA0aVuI3aXjfW+I3O1C4t8ZvYgFr6Cw=" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "qzIqTbnRoZyjATHJWkiDXuzn209cBov/S70QKcuDwdU=", "2rc9CGEn8kTOLtE0xxHWVJrRFG8En9I0NpZmT7ynNps=" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "rx94l4ohA70Bs+BeFJIRk9aGJ2/hqI+AcZBZyjG2Mx0=", "g9g6ps/UDSt3qNly67T8WjsptTL6Eq6ikZNov8h180o=" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "F8Va3SXcTDuLQ+Eux4dM+pg7sTOy2m92/z43gDkkan8=", "LYE8YKDAYqYGAh0RIcHz239CiGLKnyjfPM9auU8kWLk=" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "HHdG9nqytomms/SRdX822D7OXshwWj0ep6Q7JtGXtCg=", "16zIqWirCxlA4Y+tXsB4Hgtn9dyC9OPPAWxbnEOWAp0=" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "sRr1sh4mwKlV1kimhFNAEbql6l+Mf/M6K5juXn/A1yc=", "Am2Em1pgl1YlqCoLX9POFRlreAPXczihLQ9imOx+rNs=" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "tpTtNVGMGYZOBQlI469PUwMOSZXGq+rZedcGEwnEslw=", "SdsNPEpv3A5+zHVFxV1i54fnTNf/SILG+oKaYrkl3eM=" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "ojn+YeoVM3pqvgAgEptXDPDzmXSHBY1qP/c86JxasAI=", "RPAsGrH0V9ZZl/zLwKhWr9cWfjlHqe1gTQ1C2tsS44o=" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "lXNGr1fjfUjp1bcrT3d5e/tN6OJpktl44SKsulDUUtU=", "2uOGs7ZSyNmKXFwYZ0/t1ppFigdA2qSBg4cFldvMNYo=" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "rnRJeI+wqrgelvXslfkbRCDmBaOyE7se73njOq66LKg=", "vE/SgLHLf89hOnErg3pbbnn7QAXpt7StWsNFnJHuNHc=" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "7+piVP+AgJ4JFMyYDT9IeWbZZOVUrosuTUdE/1voC64=", "Q4atzTMyM0KcPhj9BXOsDeA5mMRa0u9XcAAuNG8Oiqk=" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "g/wZD2+HTAmK4ZFKflq8TYBMvjEy065KwEaa0gwBtP0=", "PK+GSOrHsjiInlpJW6zHXurdqh3eI2ZqCmXkX4uaIH8=" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "QLoYYcbp91N/iM6A//10yISmiGRZTYgnbSi+MRfp3p4=", "3uy3PlgwEGpcaytaFALfezrXASwpmw4Th+Pt06mx5Gg=" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Birthday", "LastActive", "PasswordHash", "PasswordSalt", "RegisteredAt" },
                values: new object[] { new DateTime(2005, 8, 13, 22, 13, 23, 745, DateTimeKind.Local).AddTicks(8552), new DateTime(2019, 8, 13, 22, 13, 23, 747, DateTimeKind.Local).AddTicks(2205), "nfvtBf3+bafnwsS//lRSnX+0XSYhqin2VP66R/ey9xs=", "d2rjrKDMC01HEMX5rCqTWyFBgWsvVhtJdoefzG/Pq1A=", new DateTime(2019, 8, 13, 22, 13, 23, 747, DateTimeKind.Local).AddTicks(2211) });

            migrationBuilder.CreateIndex(
                name: "IX_FavouriteProjects_UserId",
                table: "FavouriteProjects",
                column: "UserId");

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
