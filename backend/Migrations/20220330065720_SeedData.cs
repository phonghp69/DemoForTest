using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "JoindedDate", "PasswordHash" },
                values: new object[] { new DateTime(2022, 3, 30, 13, 57, 20, 122, DateTimeKind.Local).AddTicks(2961), "$2a$11$oKB6JkUuc/vUxU6IsL2RpenCefPj7FG3wLJDmDsOSC40ypLZGdl0K" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "JoindedDate", "PasswordHash" },
                values: new object[] { new DateTime(2022, 3, 30, 13, 57, 20, 354, DateTimeKind.Local).AddTicks(6492), "$2a$11$rWDOXzpAAN.v2tJhsAvniO3yOg917INJAbcM2Ii4BdxejameLx1Y6" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "JoindedDate", "PasswordHash" },
                values: new object[] { new DateTime(2022, 3, 29, 17, 29, 11, 707, DateTimeKind.Local).AddTicks(9056), "$2a$11$br2gVrH1P0i0XLjDWcpcIeuqbCDdY/iLsGDq4VFM3fE.as76ZLB5u" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "JoindedDate", "PasswordHash" },
                values: new object[] { new DateTime(2022, 3, 29, 17, 29, 11, 900, DateTimeKind.Local).AddTicks(7619), "$2a$11$u80ZbCPxLTlj8JfB8jK.K./FAMXs6o0TPlg0pxLFfE3bIVIDPR6Dq" });
        }
    }
}
