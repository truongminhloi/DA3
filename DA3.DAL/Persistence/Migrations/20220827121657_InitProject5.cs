using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DA3.DAL.Persistence.Migrations
{
    public partial class InitProject5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Store",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Store");
        }
    }
}
