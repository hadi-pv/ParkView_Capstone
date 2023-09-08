using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkView_Capstone.Migrations
{
    public partial class mig5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingServiceItem");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookingServiceItem",
                columns: table => new
                {
                    BookingServiceItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingServiceDetailsId = table.Column<int>(type: "int", nullable: false),
                    BookedDate = table.Column<DateTime>(type: "date", nullable: false),
                    BookingCartId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SericePriceFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingServiceItem", x => x.BookingServiceItemId);
                    table.ForeignKey(
                        name: "FK_BookingServiceItem_BookingServiceDetails_BookingServiceDetailsId",
                        column: x => x.BookingServiceDetailsId,
                        principalTable: "BookingServiceDetails",
                        principalColumn: "BookingServiceDetailsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookingServiceItem_BookingServiceDetailsId",
                table: "BookingServiceItem",
                column: "BookingServiceDetailsId");
        }
    }
}
