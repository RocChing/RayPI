using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RayPI.Repository.EFRepository.Migrations
{
    public partial class AddPermission : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RolePermissionRelate",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    CreateName = table.Column<string>(maxLength: 128, nullable: true),
                    CreateId = table.Column<long>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    UpdateName = table.Column<string>(maxLength: 128, nullable: true),
                    UpdateId = table.Column<long>(nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleteTime = table.Column<DateTime>(nullable: true),
                    RoleCode = table.Column<string>(nullable: true),
                    PermissionCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermissionRelate", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RolePermissionRelate");
        }
    }
}
