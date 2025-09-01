using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArchiNote.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class StatuscolumnaddedtoProjectstable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "status",
                schema: "public",
                table: "projects",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "status",
                schema: "public",
                table: "projects");
        }
    }
}
