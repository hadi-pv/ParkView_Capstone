using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkView_Capstone.Migrations
{
    public partial class added_checkincheckoutdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "RoomCheckIn",
                table: "RoomOccupied",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "RoomCheckOut",
                table: "RoomOccupied",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "RoomCheckIn",
                table: "RoomLocked",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "RoomCheckOut",
                table: "RoomLocked",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoomCheckIn",
                table: "RoomOccupied");

            migrationBuilder.DropColumn(
                name: "RoomCheckOut",
                table: "RoomOccupied");

            migrationBuilder.DropColumn(
                name: "RoomCheckIn",
                table: "RoomLocked");

            migrationBuilder.DropColumn(
                name: "RoomCheckOut",
                table: "RoomLocked");
        }
    }
}
