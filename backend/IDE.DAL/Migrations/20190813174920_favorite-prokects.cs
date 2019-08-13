using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IDE.DAL.Migrations
{
    public partial class favoriteprokects : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Project",
                table: "FavouriteProjects");

            migrationBuilder.DropColumn(
                name: "User",
                table: "FavouriteProjects");

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "JDIhBnVdfIc9OyAhK3FROe80gMyQAYM3Zeq+hFXrX1s=", "GbN7HL49UiwKcFD90QWUQOZsAxe1Utcv449BwAP/meA=" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "A+aQLthreHdDzR/DdHEgOHBNexjZNIfRg3JtGpltdSA=", "nnUzSjdnNZwboNwfAy0FqT5Y3s7E3VKSZBo8Yd8BHnI=" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "dTENSK+/AJGAJLsG69q5CL3QiM0QU7FKSyNm3bB/I9o=", "u3wt3+bl1+7WKBUDJlYR25nYJ2q9WEsrvRKLTf9IuTk=" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "BiXldI6tUzCg73QaXMv+eKRa36DAPz0O5wZCQB998aU=", "gw6F6XB1LCm2etZMogt8x7vem+bDkrYknkzptiEoj4c=" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "/O7B5i5pTL9Yk2cFM1pVVzvNasHzvXGgS1W4Atb+G0s=", "nMzmt4Jv4MGkYCaPfG59yBpKG5pMZv1ULJtOsg9SRB4=" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "i7m/IwIE4+FNrVK5pePV/wl8lLHFFdBArlmZwOdldYg=", "CHsQZ+gii7j/5ddWofxlWy3XI9+oL5oDtUOMSwAwKGQ=" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "JUerwVy36TXHv9Vb1SODkWLjmKQRH0liDvBPITBTyBE=", "Xbeis8MeOl2wrjpKz57wWNH9mqCk33QZJfsfsFLeWUE=" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "gTSBOKzWqhFpN9UlALvKTGtF2/i6+vVeSAV/cMckHDg=", "D4/Mk/TxYPiHqj8JWGZpipM+XRWl8rr1fVigJbDFqyU=" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "u/RMmwZo1syVT1DGchsUvGe5C3F+1no3FNHEXLtjbAI=", "pZemydlRVmQJ/MuG79C5lEQ6gPAXKxNnvSQFlMKRPl8=" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "ACV2Afu7KnNyvdvQZEY7zt+/gLapFEQKqHXlCni+oso=", "1MJZyveAeodgzOfIqdBJrHs0OYDe9hJXphXI/teq3qI=" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "o1fDdK0iclf7NvRUKxYpkiEmWJtMsu0FY5h9hDK7yKQ=", "96inT4hP7bPxWDKIDN94XmzZnZ6v6uwVeQVDOA6WsAE=" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "mssSINGPyitA8V6BM8W3uCLRWHPWPD39UK5x3S1kda4=", "JSSI8Z32FILY9I0d5gfBU6sJLGHuAT872mGm0CUHVQ8=" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "f3/ZW9iyX8qON/n63ZSTylqpQcHaGc9r1zi2yPCuKxU=", "kbrgtnuTe4nYh+v34BhRH22bkS2ywJSMB9hDDqgRrag=" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "CnjxMwFmNGa6spVredHbE6fJ1jNMZC0LcYJBF1kPYQ4=", "c8cbtHkLUmiRghz+rsHJEgLpvvVl+S2lwa0WZYnOz68=" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "8hq6JqdtBDqALpDkeIhmKCywNYH/oudVsHUpDNW7qQM=", "1TSXmLg4ULbnnjEvRrqOWhAlcX+ndVg+Z1RO+C3MYk8=" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "GtIMYEDTjoA0Oe+sIx2PiOydoMEYlZvlzGKOqZ6waVY=", "f8PimrlwUJAkNDtNo7+70W9dRfgzNXlgppnZAfqF5A0=" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "6+GhpGhnCmcYorUna3VKg+rX5VxGqkHbEHasnYlx6xM=", "xxKjDjrP495hrxUvU9O7IRedQK2wII4MVAyXsKSrh9g=" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "JpEwGDKEvwNS3mke9l2SN0fXCx9DU+J4/oNusa2HDMQ=", "9nT+bq5cc9TEyKLiph4n69D3dpvQ3kupEAmONxFngCQ=" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "2S1QiU5ZNUzguRYGpGS7005CLSQ7bXFjdxnR7F8BiPE=", "fZmbnbW/OBGu6oPN2ETDXSzFKGp/exzgb7PVGFLxo80=" });

            migrationBuilder.UpdateData(
                table: "GitCredentials",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "UKMKylIzBRz51ZPv3U5H/sLY4qJwe/ZqocRpi3WWKHo=", "f1pBpYugoZ2ZBCCrRjdCRy258tkhsh7XF/HuOxyJLyM=" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "Hp11AlLcQ0c7LiKzFelp69IQanx8//tsc86DhjhjWsw=", "baXEvI99hl5S9uDLpqhdc8YI/vvm2olTik+1VJUjbAM=" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "TOmDpcbuCVjSCn+YK4Em7Wqm/Vk7L0SBGJaUzCTLHHs=", "z94QLf2X4vJwH883ySpwgwEApNepS07GQ+vMyyBpmjo=" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Birthday", "LastActive", "PasswordHash", "PasswordSalt", "RegisteredAt" },
                values: new object[] { new DateTime(2005, 8, 13, 20, 49, 19, 223, DateTimeKind.Local).AddTicks(2273), new DateTime(2019, 8, 13, 20, 49, 19, 226, DateTimeKind.Local).AddTicks(587), "fyVh1+GcR7zREWZDpOd6u9aTtkU6b1io6tgO11kl94k=", "5z5u3yLGhbf5lZGWw61Xy+WfeTv0VnX94EPtpsElrD8=", new DateTime(2019, 8, 13, 20, 49, 19, 226, DateTimeKind.Local).AddTicks(601) });

            migrationBuilder.CreateIndex(
                name: "IX_FavouriteProjects_UserId",
                table: "FavouriteProjects",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_FavouriteProjects_Projects_ProjectId",
                table: "FavouriteProjects",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FavouriteProjects_Users_UserId",
                table: "FavouriteProjects",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavouriteProjects_Projects_ProjectId",
                table: "FavouriteProjects");

            migrationBuilder.DropForeignKey(
                name: "FK_FavouriteProjects_Users_UserId",
                table: "FavouriteProjects");

            migrationBuilder.DropIndex(
                name: "IX_FavouriteProjects_UserId",
                table: "FavouriteProjects");

            migrationBuilder.AddColumn<int>(
                name: "Project",
                table: "FavouriteProjects",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "User",
                table: "FavouriteProjects",
                nullable: false,
                defaultValue: 0);

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
        }
    }
}
