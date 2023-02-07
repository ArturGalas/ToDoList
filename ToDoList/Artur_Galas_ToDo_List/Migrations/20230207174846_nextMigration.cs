using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArturGalasToDoList.Migrations
{
    /// <inheritdoc />
    public partial class nextMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "tasks",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "tasks",
                newName: "Data końcowa");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "tasks",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Data końcowa",
                table: "tasks",
                newName: "EndDate");
        }
    }
}
