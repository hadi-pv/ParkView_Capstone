using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkView_Capstone.Migrations
{
    public partial class migration16 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BookingCartId",
                table: "BookingRoomDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookingCartId",
                table: "BookingRoomDetails");
        }
    }
}
