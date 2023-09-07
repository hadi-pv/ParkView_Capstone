using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkView_Capstone.Migrations
{
    public partial class migration18 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "BookingCartId",
                table: "BookingRoomDetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Hotel",
                keyColumn: "HotelId",
                keyValue: 1,
                column: "HotelImage",
                value: "/images/hotel2.png");

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

            migrationBuilder.UpdateData(
                table: "RoomType",
                keyColumn: "RoomTypeId",
                keyValue: 1,
                column: "RoomTypeImage",
                value: "/images/room-1.png");

            migrationBuilder.UpdateData(
                table: "RoomType",
                keyColumn: "RoomTypeId",
                keyValue: 2,
                column: "RoomTypeImage",
                value: "/images/room-2.png");

            migrationBuilder.UpdateData(
                table: "RoomType",
                keyColumn: "RoomTypeId",
                keyValue: 3,
                column: "RoomTypeImage",
                value: "/images/room-3.png");

            migrationBuilder.UpdateData(
                table: "RoomType",
                keyColumn: "RoomTypeId",
                keyValue: 4,
                column: "RoomTypeImage",
                value: "/images/room-5.png");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "BookingCartId",
                table: "BookingRoomDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Hotel",
                keyColumn: "HotelId",
                keyValue: 1,
                column: "HotelImage",
                value: "");

            migrationBuilder.UpdateData(
                table: "Hotel",
                keyColumn: "HotelId",
                keyValue: 2,
                column: "HotelImage",
                value: "");

            migrationBuilder.UpdateData(
                table: "Hotel",
                keyColumn: "HotelId",
                keyValue: 3,
                column: "HotelImage",
                value: "");

            migrationBuilder.UpdateData(
                table: "RoomType",
                keyColumn: "RoomTypeId",
                keyValue: 1,
                column: "RoomTypeImage",
                value: "");

            migrationBuilder.UpdateData(
                table: "RoomType",
                keyColumn: "RoomTypeId",
                keyValue: 2,
                column: "RoomTypeImage",
                value: "");

            migrationBuilder.UpdateData(
                table: "RoomType",
                keyColumn: "RoomTypeId",
                keyValue: 3,
                column: "RoomTypeImage",
                value: "");

            migrationBuilder.UpdateData(
                table: "RoomType",
                keyColumn: "RoomTypeId",
                keyValue: 4,
                column: "RoomTypeImage",
                value: "");
        }
    }
}
