using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Perfix = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsFirstLogin = table.Column<bool>(type: "bit", nullable: false),
                    StaffCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    JoindedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Asset",
                columns: table => new
                {
                    AssetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssetName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssetCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Specification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InstalledDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AssetState = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asset", x => x.AssetId);
                    table.ForeignKey(
                        name: "FK_Asset_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Assignment",
                columns: table => new
                {
                    AssignmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssignedToUserId = table.Column<int>(type: "int", nullable: false),
                    AssignedByUserId = table.Column<int>(type: "int", nullable: false),
                    AssetId = table.Column<int>(type: "int", nullable: false),
                    AssignedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignment", x => x.AssignmentId);
                    table.ForeignKey(
                        name: "FK_Assignment_Asset_AssetId",
                        column: x => x.AssetId,
                        principalTable: "Asset",
                        principalColumn: "AssetId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Assignment_User_AssignedByUserId",
                        column: x => x.AssignedByUserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Assignment_User_AssignedToUserId",
                        column: x => x.AssignedToUserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReturningRequest",
                columns: table => new
                {
                    RequestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestedByUserId = table.Column<int>(type: "int", nullable: false),
                    ProcessedByUserId = table.Column<int>(type: "int", nullable: false),
                    AssignmentId = table.Column<int>(type: "int", nullable: false),
                    RequestState = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReturningRequest", x => x.RequestId);
                    table.ForeignKey(
                        name: "FK_ReturningRequest_Assignment_AssignmentId",
                        column: x => x.AssignmentId,
                        principalTable: "Assignment",
                        principalColumn: "AssignmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReturningRequest_User_ProcessedByUserId",
                        column: x => x.ProcessedByUserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReturningRequest_User_RequestedByUserId",
                        column: x => x.RequestedByUserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "CategoryName", "Perfix" },
                values: new object[,]
                {
                    { 1, "Laptop", "LA" },
                    { 2, "Monitor", "MO" },
                    { 3, "Personal Computer", "PC" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "DateOfBirth", "FirstName", "Gender", "IsFirstLogin", "JoindedDate", "LastName", "Location", "PasswordHash", "Role", "StaffCode", "UserName" },
                values: new object[,]
                {
                    { 1, new DateTime(2000, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dao", 0, true, new DateTime(2022, 4, 2, 14, 59, 59, 662, DateTimeKind.Local).AddTicks(3434), "Quy Vuong", "Ha Noi", "$2a$11$9VZfHhpXAaWWnEWfYkKhxuZ5IsEP48xL/FG.AhOyFhkYxFx/jdx0K", 0, "AD1", "Admin" },
                    { 2, new DateTime(1999, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bui", 0, true, new DateTime(2022, 4, 2, 14, 59, 59, 855, DateTimeKind.Local).AddTicks(6545), "Chi Huong", "Bac Giang", "$2a$11$uXSGsUWNVQmG/gCFh69hMuSKKCzhTvQQi0uvrOeEk9cWAP0PHRUPC", 1, "US2", "Staff" },
                    { 3, new DateTime(2001, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bui", 2, true, new DateTime(2022, 4, 2, 15, 0, 0, 49, DateTimeKind.Local).AddTicks(9531), "Chi Huong", "Cao Bang", "$2a$11$mSHmk7mLFbdwO6KHw0O3U.CtYjETdpQFxXmV8EjygrGprYSb0BDPO", 1, "........", "Huong" }
                });

            migrationBuilder.InsertData(
                table: "Asset",
                columns: new[] { "AssetId", "AssetCode", "AssetName", "AssetState", "CategoryId", "CategoryName", "InstalledDate", "Specification" },
                values: new object[] { 1, "LA1", "HP Zenbook8", 0, 1, "Laptop", new DateTime(2022, 4, 2, 14, 59, 59, 459, DateTimeKind.Local).AddTicks(7657), "this is sample data" });

            migrationBuilder.InsertData(
                table: "Asset",
                columns: new[] { "AssetId", "AssetCode", "AssetName", "AssetState", "CategoryId", "CategoryName", "InstalledDate", "Specification" },
                values: new object[] { 2, "MO1", "Dell UltralSharp", 0, 2, "Monitor", new DateTime(2022, 4, 2, 14, 59, 59, 459, DateTimeKind.Local).AddTicks(7686), "this is sample data" });

            migrationBuilder.InsertData(
                table: "Asset",
                columns: new[] { "AssetId", "AssetCode", "AssetName", "AssetState", "CategoryId", "CategoryName", "InstalledDate", "Specification" },
                values: new object[] { 3, "PC1", "HP PC", 0, 3, "Personal Computer", new DateTime(2022, 4, 2, 14, 59, 59, 459, DateTimeKind.Local).AddTicks(7689), "this is sample data" });

            migrationBuilder.InsertData(
                table: "Assignment",
                columns: new[] { "AssignmentId", "AssetId", "AssignedByUserId", "AssignedDate", "AssignedToUserId", "Note" },
                values: new object[] { 1, 2, 1, new DateTime(2022, 4, 2, 15, 0, 0, 50, DateTimeKind.Local).AddTicks(4), 2, "this is sample data" });

            migrationBuilder.InsertData(
                table: "ReturningRequest",
                columns: new[] { "RequestId", "AssignmentId", "ProcessedByUserId", "RequestState", "RequestedByUserId" },
                values: new object[] { 1, 1, 1, 1, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Asset_CategoryId",
                table: "Asset",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Assignment_AssetId",
                table: "Assignment",
                column: "AssetId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Assignment_AssignedByUserId",
                table: "Assignment",
                column: "AssignedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Assignment_AssignedToUserId",
                table: "Assignment",
                column: "AssignedToUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ReturningRequest_AssignmentId",
                table: "ReturningRequest",
                column: "AssignmentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReturningRequest_ProcessedByUserId",
                table: "ReturningRequest",
                column: "ProcessedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ReturningRequest_RequestedByUserId",
                table: "ReturningRequest",
                column: "RequestedByUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReturningRequest");

            migrationBuilder.DropTable(
                name: "Assignment");

            migrationBuilder.DropTable(
                name: "Asset");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
