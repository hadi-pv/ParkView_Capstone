using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkView_Capstone.Migrations
{
    public partial class _3rdmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "FacilityType",
                columns: new[] { "FacilityTypeId", "FacilityDescription", "FacilityImage", "FacilityName" },
                values: new object[,]
                {
                    { 1, "It is a infinity pool", "", "Pool" },
                    { 2, "High Speed Wi Fi", "", "Wifi" },
                    { 3, "Very Spacious Parking Space", "", "Parking" },
                    { 4, "World Class Room Service", "", "Room Service" },
                    { 5, "Can manage any types of fabrics and cloth types.", "", "Laundry" },
                    { 6, "World Class Gym", "", "Gym" },
                    { 7, "Cab Services to most of tourist and transport places.", "", "Cab Service" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FacilityType",
                keyColumn: "FacilityTypeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FacilityType",
                keyColumn: "FacilityTypeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "FacilityType",
                keyColumn: "FacilityTypeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "FacilityType",
                keyColumn: "FacilityTypeId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "FacilityType",
                keyColumn: "FacilityTypeId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "FacilityType",
                keyColumn: "FacilityTypeId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "FacilityType",
                keyColumn: "FacilityTypeId",
                keyValue: 7);
        }
    }
}
