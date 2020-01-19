using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RayPI.Repository.EFRepository.Migrations
{
    public partial class Order : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_Order",
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
                    OrderType = table.Column<int>(nullable: false),
                    OrderTypeName = table.Column<string>(maxLength: 100, nullable: false),
                    DesktopName = table.Column<string>(nullable: true),
                    CustomerCount = table.Column<int>(nullable: false),
                    OrderNo = table.Column<string>(maxLength: 100, nullable: false),
                    Operator = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Order", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_OrderDetail",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    OrderId = table.Column<long>(nullable: false),
                    GoodsName = table.Column<string>(maxLength: 200, nullable: false),
                    Number = table.Column<int>(nullable: false),
                    Unit = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_OrderDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_T_OrderDetail_T_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "T_Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_OrderDetail_OrderId",
                table: "T_OrderDetail",
                column: "OrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_OrderDetail");

            migrationBuilder.DropTable(
                name: "T_Order");
        }
    }
}
