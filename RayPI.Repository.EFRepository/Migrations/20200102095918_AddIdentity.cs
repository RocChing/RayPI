using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RayPI.Repository.EFRepository.Migrations
{
    public partial class AddIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Role",
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
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Remark = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserAccount",
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
                    UserId = table.Column<long>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    RealName = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    EffectiveTime = table.Column<DateTime>(nullable: false),
                    ExpiredTime = table.Column<DateTime>(nullable: false),
                    IsDisable = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccount", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRoleRelate",
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
                    UserId = table.Column<long>(nullable: false),
                    RoleId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoleRelate", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "UserAccount");

            migrationBuilder.DropTable(
                name: "UserRoleRelate");
        }
    }
}
