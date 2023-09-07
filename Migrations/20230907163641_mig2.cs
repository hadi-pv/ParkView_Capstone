using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkView_Capstone.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RP_Order_id",
                table: "RoomOccupied");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RP_Order_id",
                table: "RoomOccupied",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
