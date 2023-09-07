using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkView_Capstone.Migrations
{
    public partial class migration20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Hotel",
                keyColumn: "HotelId",
                keyValue: 3,
                column: "HotelImage",
                value: "/images/hotell1.jpeg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Hotel",
                keyColumn: "HotelId",
                keyValue: 3,
                column: "HotelImage",
                value: "/images/hotel1.jpeg");
        }
    }
}
