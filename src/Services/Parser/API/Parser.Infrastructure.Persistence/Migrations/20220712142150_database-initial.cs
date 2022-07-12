using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Parser.Infrastructure.Persistence.Migrations
{
    public partial class databaseinitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SitesDescriptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SiteName = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    SiteUrl = table.Column<string>(type: "text", nullable: true),
                    SiteSelector = table.Column<string>(type: "text", nullable: true),
                    SiteModelTypeName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SitesDescriptions", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SitesDescriptions_Id",
                table: "SitesDescriptions",
                column: "Id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SitesDescriptions");
        }
    }
}
