using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkView_Capstone.Migrations
{
    public partial class mig4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookedServices",
                columns: table => new
                {
                    BookedServiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookedServiceDetailsId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookingServiceDetailsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookedServices", x => x.BookedServiceId);
                    table.ForeignKey(
                        name: "FK_BookedServices_BookingServiceDetails_BookingServiceDetailsId",
                        column: x => x.BookingServiceDetailsId,
                        principalTable: "BookingServiceDetails",
                        principalColumn: "BookingServiceDetailsId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookedServices_BookingServiceDetailsId",
                table: "BookedServices",
                column: "BookingServiceDetailsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookedServices");
        }
    }
}
