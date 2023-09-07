using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkView_Capstone.Migrations
{
    public partial class migration19 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Hotel",
                keyColumn: "HotelId",
                keyValue: 2,
                column: "HotelImage",
                value: "/images/hotel3.jpeg");

            migrationBuilder.UpdateData(
                table: "Hotel",
                keyColumn: "HotelId",
                keyValue: 3,
                column: "HotelImage",
                value: "/images/hotel1.jpeg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Hotel",
                keyColumn: "HotelId",
                keyValue: 2,
                column: "HotelImage",
                value: "/images/hotel3.png");

            migrationBuilder.UpdateData(
                table: "Hotel",
                keyColumn: "HotelId",
                keyValue: 3,
                column: "HotelImage",
                value: "/images/hotel1.png");
        }
    }
}
