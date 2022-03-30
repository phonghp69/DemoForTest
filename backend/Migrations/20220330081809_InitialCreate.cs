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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    Role = table.Column<int>(type: "int", nullable: false),
                    JoindedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Asset",
                columns: table => new
                {
                    AssetId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    AssignmentId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssetStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssetState = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asset", x => x.AssetId);
                    table.ForeignKey(
                        name: "FK_Asset_Category_AssetId",
                        column: x => x.AssetId,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateTable(
                name: "Assignment",
                columns: table => new
                {
                    AssignmentId = table.Column<int>(type: "int", nullable: false),
                    AssignedToUserId = table.Column<int>(type: "int", nullable: false),
                    AssignedByUserId = table.Column<int>(type: "int", nullable: false),
                    AssetId = table.Column<int>(type: "int", nullable: false),
                    AssignedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignment", x => x.AssignmentId);
                    table.ForeignKey(
                        name: "FK_Assignment_Asset_AssignmentId",
                        column: x => x.AssignmentId,
                        principalTable: "Asset",
                        principalColumn: "AssetId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Assignment_ReturningRequest_AssignmentId",
                        column: x => x.AssignmentId,
                        principalTable: "ReturningRequest",
                        principalColumn: "RequestId",
                        onDelete: ReferentialAction.Restrict);
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

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "Name", "Perfix" },
                values: new object[,]
                {
                    { 1, "Technology", "......" },
                    { 2, "Personal items", "......" },
                    { 3, "Other", "......" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "FirstName", "JoindedDate", "LastName", "PasswordHash", "Role", "UserName" },
                values: new object[,]
                {
                    { 1, "Dao", new DateTime(2022, 3, 30, 15, 18, 9, 351, DateTimeKind.Local).AddTicks(4605), "Quy Vuong", "$2a$11$xcADNau7DOYvBmobsDgrpeaMs2dPzOyncFgridC4T6EKu2mWNplGO", 0, "Admin" },
                    { 2, "Bui", new DateTime(2022, 3, 30, 15, 18, 9, 557, DateTimeKind.Local).AddTicks(1822), "Chi Huong", "$2a$11$Vr.yDlPZ0KiMFDN07YpwhuDjaXrbYUYyw98GjkRrzcoAwwIQcOBLa", 1, "Staff" }
                });

            migrationBuilder.InsertData(
                table: "Asset",
                columns: new[] { "AssetId", "AssetState", "AssetStatus", "AssignmentId", "CategoryId", "Name" },
                values: new object[,]
                {
                    { 1, 2, ".......", 1, 1, "mouse keyboard" },
                    { 2, 0, ".......", 2, 2, "name tags" },
                    { 3, 1, ".......", 3, 3, "flowers" }
                });

            migrationBuilder.InsertData(
                table: "ReturningRequest",
                columns: new[] { "RequestId", "AssignmentId", "ProcessedByUserId", "RequestState", "RequestedByUserId" },
                values: new object[] { 1, 1, 1, 1, 2 });

            migrationBuilder.InsertData(
                table: "Assignment",
                columns: new[] { "AssignmentId", "AssetId", "AssignedByUserId", "AssignedDate", "AssignedToUserId", "Note", "RequestId" },
                values: new object[] { 1, 2, 1, new DateTime(2022, 3, 30, 15, 18, 9, 557, DateTimeKind.Local).AddTicks(2325), 2, "this is sample data", 0 });

            migrationBuilder.CreateIndex(
                name: "IX_Assignment_AssignedByUserId",
                table: "Assignment",
                column: "AssignedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Assignment_AssignedToUserId",
                table: "Assignment",
                column: "AssignedToUserId");

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
                name: "Assignment");

            migrationBuilder.DropTable(
                name: "Asset");

            migrationBuilder.DropTable(
                name: "ReturningRequest");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
