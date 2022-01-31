using Microsoft.EntityFrameworkCore.Migrations;

namespace RealEstate.Properties.Domain.Migrations
{
    public partial class AddedPropertyImageFileName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FileName",
                schema: "dbo",
                table: "PropertyImage",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileName",
                schema: "dbo",
                table: "PropertyImage");
        }
    }
}
