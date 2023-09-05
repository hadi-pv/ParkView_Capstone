using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkView_Capstone.Migrations
{
    public partial class _4thmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingRoomDetails_Bookings_BookingId",
                table: "BookingRoomDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_BookingRoomDetails_RoomType_RoomTypeId",
                table: "BookingRoomDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_BookingServiceDetails_Bookings_BookingId",
                table: "BookingServiceDetails");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_BookingServiceDetails_BookingId",
                table: "BookingServiceDetails");

            migrationBuilder.DropIndex(
                name: "IX_BookingRoomDetails_BookingId",
                table: "BookingRoomDetails");

            migrationBuilder.DropColumn(
                name: "BookingId",
                table: "BookingServiceDetails");

            migrationBuilder.RenameColumn(
                name: "RoomTypeId",
                table: "BookingRoomDetails",
                newName: "RoomId");

            migrationBuilder.RenameColumn(
                name: "RoomPriceAmount",
                table: "BookingRoomDetails",
                newName: "RoomPrice");

            migrationBuilder.RenameColumn(
                name: "BookingId",
                table: "BookingRoomDetails",
                newName: "ChildrenNo");

            migrationBuilder.RenameColumn(
                name: "BookingDate",
                table: "BookingRoomDetails",
                newName: "CheckOutDate");

            migrationBuilder.RenameIndex(
                name: "IX_BookingRoomDetails_RoomTypeId",
                table: "BookingRoomDetails",
                newName: "IX_BookingRoomDetails_RoomId");

            migrationBuilder.AddColumn<int>(
                name: "AdultNo",
                table: "BookingRoomDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CheckInDate",
                table: "BookingRoomDetails",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "BookingCartItems",
                columns: table => new
                {
                    BookingCartItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingCartId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServicePriceAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RoomPriceFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BookingRoomDetailsId = table.Column<int>(type: "int", nullable: false),
                    BookingServiceDetailsId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingCartItems", x => x.BookingCartItemId);
                    table.ForeignKey(
                        name: "FK_BookingCartItems_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BookingCartItems_BookingRoomDetails_BookingRoomDetailsId",
                        column: x => x.BookingRoomDetailsId,
                        principalTable: "BookingRoomDetails",
                        principalColumn: "BookingRoomDetailsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookingCartItems_BookingServiceDetails_BookingServiceDetailsId",
                        column: x => x.BookingServiceDetailsId,
                        principalTable: "BookingServiceDetails",
                        principalColumn: "BookingServiceDetailsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookingCartItems_BookingRoomDetailsId",
                table: "BookingCartItems",
                column: "BookingRoomDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingCartItems_BookingServiceDetailsId",
                table: "BookingCartItems",
                column: "BookingServiceDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingCartItems_UserId",
                table: "BookingCartItems",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingRoomDetails_Room_RoomId",
                table: "BookingRoomDetails",
                column: "RoomId",
                principalTable: "Room",
                principalColumn: "RoomId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingRoomDetails_Room_RoomId",
                table: "BookingRoomDetails");

            migrationBuilder.DropTable(
                name: "BookingCartItems");

            migrationBuilder.DropColumn(
                name: "AdultNo",
                table: "BookingRoomDetails");

            migrationBuilder.DropColumn(
                name: "CheckInDate",
                table: "BookingRoomDetails");

            migrationBuilder.RenameColumn(
                name: "RoomPrice",
                table: "BookingRoomDetails",
                newName: "RoomPriceAmount");

            migrationBuilder.RenameColumn(
                name: "RoomId",
                table: "BookingRoomDetails",
                newName: "RoomTypeId");

            migrationBuilder.RenameColumn(
                name: "ChildrenNo",
                table: "BookingRoomDetails",
                newName: "BookingId");

            migrationBuilder.RenameColumn(
                name: "CheckOutDate",
                table: "BookingRoomDetails",
                newName: "BookingDate");

            migrationBuilder.RenameIndex(
                name: "IX_BookingRoomDetails_RoomId",
                table: "BookingRoomDetails",
                newName: "IX_BookingRoomDetails_RoomTypeId");

            migrationBuilder.AddColumn<int>(
                name: "BookingId",
                table: "BookingServiceDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    BookingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BookingLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CheckInDate = table.Column<DateTime>(type: "date", nullable: false),
                    CheckOutDate = table.Column<DateTime>(type: "date", nullable: false),
                    NumberOfAdults = table.Column<int>(type: "int", nullable: false),
                    NumberOfChildren = table.Column<int>(type: "int", nullable: false),
                    RoomPriceFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ServicePriceAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.BookingId);
                    table.ForeignKey(
                        name: "FK_Bookings_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookingServiceDetails_BookingId",
                table: "BookingServiceDetails",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingRoomDetails_BookingId",
                table: "BookingRoomDetails",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_UserId",
                table: "Bookings",
                column: "UserId");

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
                name: "FK_BookingServiceDetails_Bookings_BookingId",
                table: "BookingServiceDetails",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "BookingId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
