using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kamenici.Data.Migrations
{
    public partial class novo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Available",
                table: "Frames",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<int>(
                name: "CreateOrderViewModelOrderId",
                table: "Frames",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CreateOrderViewModel",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FrameId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreateOrderViewModel", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_CreateOrderViewModel_Frames_FrameId",
                        column: x => x.FrameId,
                        principalTable: "Frames",
                        principalColumn: "FrameId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeleteFrameViewModel",
                columns: table => new
                {
                    FrameId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Width = table.Column<int>(type: "int", nullable: false),
                    Height = table.Column<int>(type: "int", nullable: false),
                    Available = table.Column<bool>(type: "bit", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeleteFrameViewModel", x => x.FrameId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Frames_CreateOrderViewModelOrderId",
                table: "Frames",
                column: "CreateOrderViewModelOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_CreateOrderViewModel_FrameId",
                table: "CreateOrderViewModel",
                column: "FrameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Frames_CreateOrderViewModel_CreateOrderViewModelOrderId",
                table: "Frames",
                column: "CreateOrderViewModelOrderId",
                principalTable: "CreateOrderViewModel",
                principalColumn: "OrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Frames_CreateOrderViewModel_CreateOrderViewModelOrderId",
                table: "Frames");

            migrationBuilder.DropTable(
                name: "CreateOrderViewModel");

            migrationBuilder.DropTable(
                name: "DeleteFrameViewModel");

            migrationBuilder.DropIndex(
                name: "IX_Frames_CreateOrderViewModelOrderId",
                table: "Frames");

            migrationBuilder.DropColumn(
                name: "CreateOrderViewModelOrderId",
                table: "Frames");

            migrationBuilder.AlterColumn<bool>(
                name: "Available",
                table: "Frames",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);
        }
    }
}
