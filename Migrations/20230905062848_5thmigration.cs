using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkView_Capstone.Migrations
{
    public partial class _5thmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingCartItems_BookingServiceDetails_BookingServiceDetailsId",
                table: "BookingCartItems");

            migrationBuilder.DropIndex(
                name: "IX_BookingCartItems_BookingServiceDetailsId",
                table: "BookingCartItems");

            migrationBuilder.DropColumn(
                name: "BookingServiceDetailsId",
                table: "BookingCartItems");

            migrationBuilder.DropColumn(
                name: "ServicePriceAmount",
                table: "BookingCartItems");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookingServiceDetailsId",
                table: "BookingCartItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "ServicePriceAmount",
                table: "BookingCartItems",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_BookingCartItems_BookingServiceDetailsId",
                table: "BookingCartItems",
                column: "BookingServiceDetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingCartItems_BookingServiceDetails_BookingServiceDetailsId",
                table: "BookingCartItems",
                column: "BookingServiceDetailsId",
                principalTable: "BookingServiceDetails",
                principalColumn: "BookingServiceDetailsId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
