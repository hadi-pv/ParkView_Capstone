using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkView_Capstone.Migrations
{
    public partial class migration15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "RoomGst",
                table: "RoomType",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "BookingRoomDetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "RoomType",
                keyColumn: "RoomTypeId",
                keyValue: 1,
                column: "RoomGst",
                value: 18m);

            migrationBuilder.UpdateData(
                table: "RoomType",
                keyColumn: "RoomTypeId",
                keyValue: 2,
                column: "RoomGst",
                value: 18m);

            migrationBuilder.UpdateData(
                table: "RoomType",
                keyColumn: "RoomTypeId",
                keyValue: 3,
                column: "RoomGst",
                value: 12m);

            migrationBuilder.UpdateData(
                table: "RoomType",
                keyColumn: "RoomTypeId",
                keyValue: 4,
                column: "RoomGst",
                value: 12m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoomGst",
                table: "RoomType");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "BookingRoomDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
