using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Movies.Migrations
{
    public partial class AddedMPA : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MPARATING",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MPARATING",
                table: "Movies");
        }
    }
}
