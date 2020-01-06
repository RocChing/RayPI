using Microsoft.EntityFrameworkCore.Migrations;

namespace RayPI.Repository.EFRepository.Migrations
{
    public partial class UapdeIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "UserAccount");

            migrationBuilder.AddColumn<string>(
                name: "PwdHash",
                table: "UserAccount",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsAdminRole",
                table: "Role",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PwdHash",
                table: "UserAccount");

            migrationBuilder.DropColumn(
                name: "IsAdminRole",
                table: "Role");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "UserAccount",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
