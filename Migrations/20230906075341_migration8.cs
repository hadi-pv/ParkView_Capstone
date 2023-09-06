using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkView_Capstone.Migrations
{
    public partial class migration8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingCartItems_AspNetUsers_UserId",
                table: "BookingCartItems");

            migrationBuilder.DropIndex(
                name: "IX_BookingCartItems_UserId",
                table: "BookingCartItems");

            migrationBuilder.AddColumn<bool>(
                name: "IsCancelled",
                table: "RoomOccupied",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "RoomOccupied",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "RoomOccupied",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "BookingRoomDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "BookingRoomDetails",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "BookingCartItems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "BookingCartItems",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoomOccupied_UserId1",
                table: "RoomOccupied",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_BookingRoomDetails_UserId1",
                table: "BookingRoomDetails",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_BookingCartItems_UserId1",
                table: "BookingCartItems",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingCartItems_AspNetUsers_UserId1",
                table: "BookingCartItems",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingRoomDetails_AspNetUsers_UserId1",
                table: "BookingRoomDetails",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomOccupied_AspNetUsers_UserId1",
                table: "RoomOccupied",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingCartItems_AspNetUsers_UserId1",
                table: "BookingCartItems");

            migrationBuilder.DropForeignKey(
                name: "FK_BookingRoomDetails_AspNetUsers_UserId1",
                table: "BookingRoomDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomOccupied_AspNetUsers_UserId1",
                table: "RoomOccupied");

            migrationBuilder.DropIndex(
                name: "IX_RoomOccupied_UserId1",
                table: "RoomOccupied");

            migrationBuilder.DropIndex(
                name: "IX_BookingRoomDetails_UserId1",
                table: "BookingRoomDetails");

            migrationBuilder.DropIndex(
                name: "IX_BookingCartItems_UserId1",
                table: "BookingCartItems");

            migrationBuilder.DropColumn(
                name: "IsCancelled",
                table: "RoomOccupied");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "RoomOccupied");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "RoomOccupied");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "BookingRoomDetails");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "BookingRoomDetails");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "BookingCartItems");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "BookingCartItems",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_BookingCartItems_UserId",
                table: "BookingCartItems",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingCartItems_AspNetUsers_UserId",
                table: "BookingCartItems",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
