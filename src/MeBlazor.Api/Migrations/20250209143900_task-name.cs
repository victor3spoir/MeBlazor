using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeBlazor.Api.Migrations
{
    /// <inheritdoc />
    public partial class taskname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "title",
                table: "TaskItems",
                newName: "name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "name",
                table: "TaskItems",
                newName: "title");
        }
    }
}
