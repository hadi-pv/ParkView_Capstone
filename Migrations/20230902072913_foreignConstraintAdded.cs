using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkView_Capstone.Migrations
{
    public partial class foreignConstraintAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Bookings",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_RoomOccupied_RoomTypeId",
                table: "RoomOccupied",
                column: "RoomTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomLocked_RoomTypeId",
                table: "RoomLocked",
                column: "RoomTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_FacilityApply_FacilityTypeId",
                table: "FacilityApply",
                column: "FacilityTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_FacilityApply_RoomTypeId",
                table: "FacilityApply",
                column: "RoomTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingServiceDetails_BookingId",
                table: "BookingServiceDetails",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingServiceDetails_ServiceId",
                table: "BookingServiceDetails",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_UserId",
                table: "Bookings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingRoomDetails_BookingId",
                table: "BookingRoomDetails",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingRoomDetails_RoomTypeId",
                table: "BookingRoomDetails",
                column: "RoomTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingRoomDetails_Bookings_BookingId",
                table: "BookingRoomDetails",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "BookingId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookingRoomDetails_RoomType_RoomTypeId",
                table: "BookingRoomDetails",
                column: "RoomTypeId",
                principalTable: "RoomType",
                principalColumn: "RoomTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_AspNetUsers_UserId",
                table: "Bookings",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookingServiceDetails_Bookings_BookingId",
                table: "BookingServiceDetails",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "BookingId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookingServiceDetails_Services_ServiceId",
                table: "BookingServiceDetails",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "ServiceId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FacilityApply_FacilityType_FacilityTypeId",
                table: "FacilityApply",
                column: "FacilityTypeId",
                principalTable: "FacilityType",
                principalColumn: "FacilityTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FacilityApply_RoomType_RoomTypeId",
                table: "FacilityApply",
                column: "RoomTypeId",
                principalTable: "RoomType",
                principalColumn: "RoomTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomLocked_RoomType_RoomTypeId",
                table: "RoomLocked",
                column: "RoomTypeId",
                principalTable: "RoomType",
                principalColumn: "RoomTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomOccupied_RoomType_RoomTypeId",
                table: "RoomOccupied",
                column: "RoomTypeId",
                principalTable: "RoomType",
                principalColumn: "RoomTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingRoomDetails_Bookings_BookingId",
                table: "BookingRoomDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_BookingRoomDetails_RoomType_RoomTypeId",
                table: "BookingRoomDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_AspNetUsers_UserId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_BookingServiceDetails_Bookings_BookingId",
                table: "BookingServiceDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_BookingServiceDetails_Services_ServiceId",
                table: "BookingServiceDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_FacilityApply_FacilityType_FacilityTypeId",
                table: "FacilityApply");

            migrationBuilder.DropForeignKey(
                name: "FK_FacilityApply_RoomType_RoomTypeId",
                table: "FacilityApply");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomLocked_RoomType_RoomTypeId",
                table: "RoomLocked");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomOccupied_RoomType_RoomTypeId",
                table: "RoomOccupied");

            migrationBuilder.DropIndex(
                name: "IX_RoomOccupied_RoomTypeId",
                table: "RoomOccupied");

            migrationBuilder.DropIndex(
                name: "IX_RoomLocked_RoomTypeId",
                table: "RoomLocked");

            migrationBuilder.DropIndex(
                name: "IX_FacilityApply_FacilityTypeId",
                table: "FacilityApply");

            migrationBuilder.DropIndex(
                name: "IX_FacilityApply_RoomTypeId",
                table: "FacilityApply");

            migrationBuilder.DropIndex(
                name: "IX_BookingServiceDetails_BookingId",
                table: "BookingServiceDetails");

            migrationBuilder.DropIndex(
                name: "IX_BookingServiceDetails_ServiceId",
                table: "BookingServiceDetails");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_UserId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_BookingRoomDetails_BookingId",
                table: "BookingRoomDetails");

            migrationBuilder.DropIndex(
                name: "IX_BookingRoomDetails_RoomTypeId",
                table: "BookingRoomDetails");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Bookings",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
