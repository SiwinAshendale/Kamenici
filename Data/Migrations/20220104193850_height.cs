using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kamenici.Data.Migrations
{
    public partial class height : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Length",
                table: "Frames",
                newName: "Height");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Height",
                table: "Frames",
                newName: "Length");
        }
    }
}
