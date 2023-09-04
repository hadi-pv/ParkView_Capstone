using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkView_Capstone.Migrations
{
    public partial class _2ndmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Hotel",
                columns: new[] { "HotelId", "HotelDescription", "HotelImage", "HotelLocation", "HotelName" },
                values: new object[] { 1, "In the center of city", "", "Mumbai", "ParkView Bombay" });

            migrationBuilder.InsertData(
                table: "Hotel",
                columns: new[] { "HotelId", "HotelDescription", "HotelImage", "HotelLocation", "HotelName" },
                values: new object[] { 2, "In the center of city", "", "Bengaluru", "ParkView Bangalore" });

            migrationBuilder.InsertData(
                table: "Hotel",
                columns: new[] { "HotelId", "HotelDescription", "HotelImage", "HotelLocation", "HotelName" },
                values: new object[] { 3, "In the center of city", "", "Chennai", "ParkView Chennai" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hotel",
                keyColumn: "HotelId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Hotel",
                keyColumn: "HotelId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Hotel",
                keyColumn: "HotelId",
                keyValue: 3);
        }
    }
}
