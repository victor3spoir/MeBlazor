using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeBlazor.Api.Migrations
{
    /// <inheritdoc />
    public partial class updatetasks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "taskname",
                table: "TaskItems",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "iscomplete",
                table: "TaskItems",
                newName: "status");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "TaskItems",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isdone",
                table: "TaskItems",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "TaskItems");

            migrationBuilder.DropColumn(
                name: "isdone",
                table: "TaskItems");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "TaskItems",
                newName: "taskname");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "TaskItems",
                newName: "iscomplete");
        }
    }
}
