using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkView_Capstone.Migrations
{
    public partial class mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingServiceItem_BookingRoomDetails_BookingServiceDetailsId",
                table: "BookingServiceItem");

            migrationBuilder.AddColumn<string>(
                name: "RP_Order_id",
                table: "RoomOccupied",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RP_Payment_id",
                table: "RoomOccupied",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RP_Signature_id",
                table: "RoomOccupied",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingServiceItem_BookingServiceDetails_BookingServiceDetailsId",
                table: "BookingServiceItem",
                column: "BookingServiceDetailsId",
                principalTable: "BookingServiceDetails",
                principalColumn: "BookingServiceDetailsId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingServiceItem_BookingServiceDetails_BookingServiceDetailsId",
                table: "BookingServiceItem");

            migrationBuilder.DropColumn(
                name: "RP_Order_id",
                table: "RoomOccupied");

            migrationBuilder.DropColumn(
                name: "RP_Payment_id",
                table: "RoomOccupied");

            migrationBuilder.DropColumn(
                name: "RP_Signature_id",
                table: "RoomOccupied");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingServiceItem_BookingRoomDetails_BookingServiceDetailsId",
                table: "BookingServiceItem",
                column: "BookingServiceDetailsId",
                principalTable: "BookingRoomDetails",
                principalColumn: "BookingRoomDetailsId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
