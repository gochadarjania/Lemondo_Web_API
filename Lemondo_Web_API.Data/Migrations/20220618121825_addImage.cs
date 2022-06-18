using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lemondo_Web_API.Data.Migrations
{
    public partial class addImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StatementDetails",
                columns: table => new
                {
                    StatementDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatementDetails", x => x.StatementDetailId);
                });

            migrationBuilder.CreateTable(
                name: "Statements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageData = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    StatementDetailId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Statements_StatementDetails_StatementDetailId",
                        column: x => x.StatementDetailId,
                        principalTable: "StatementDetails",
                        principalColumn: "StatementDetailId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "StatementDetails",
                columns: new[] { "StatementDetailId", "Description", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "NET is a developer platform with tools and libraries for building any type of app, including web, mobile, desktop, games, IoT, cloud, and microservices.", "+995 556 52 26 36" },
                    { 2, "NET is a developer platform with tools and libraries for building any type of app, including web, mobile, desktop, games, IoT, cloud, and microservices.", "+995 556 52 26 36" },
                    { 3, "NET is a developer platform with tools and libraries for building any type of app, including web, mobile, desktop, games, IoT, cloud, and microservices.", "+995 556 52 26 36" },
                    { 4, "NET is a developer platform with tools and libraries for building any type of app, including web, mobile, desktop, games, IoT, cloud, and microservices.", "+995 556 52 26 36" },
                    { 5, "NET is a developer platform with tools and libraries for building any type of app, including web, mobile, desktop, games, IoT, cloud, and microservices.", "+995 556 52 26 36" }
                });

            migrationBuilder.InsertData(
                table: "Statements",
                columns: new[] { "Id", "ImageData", "ImageTitle", "StatementDetailId", "Title" },
                values: new object[,]
                {
                    { 1, null, null, 1, "Phil Murphy " },
                    { 2, null, null, 2, "Phil Murphy " },
                    { 3, null, null, 3, "Phil Murphy " },
                    { 4, null, null, 4, "Phil Murphy " },
                    { 5, null, null, 5, "Phil Murphy " }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Statements_StatementDetailId",
                table: "Statements",
                column: "StatementDetailId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Statements");

            migrationBuilder.DropTable(
                name: "StatementDetails");
        }
    }
}
