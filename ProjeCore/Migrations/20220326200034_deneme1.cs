using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjeCore.Migrations
{
    public partial class deneme1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Birim",
                table: "Personels");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Birim",
                table: "Personels",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
