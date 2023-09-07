using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkView_Capstone.Migrations
{
    public partial class services : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookingServiceItem",
                columns: table => new
                {
                    BookingServiceItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingServiceDetailsId = table.Column<int>(type: "int", nullable: false),
                    BookingCartId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SericePriceFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookedDate = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingServiceItem", x => x.BookingServiceItemId);
                    table.ForeignKey(
                        name: "FK_BookingServiceItem_BookingRoomDetails_BookingServiceDetailsId",
                        column: x => x.BookingServiceDetailsId,
                        principalTable: "BookingRoomDetails",
                        principalColumn: "BookingRoomDetailsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookingServiceItem_BookingServiceDetailsId",
                table: "BookingServiceItem",
                column: "BookingServiceDetailsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingServiceItem");
        }
    }
}
