using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resort_Rental.Repository.Migrations
{
    public partial class Seeding_DataRoom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Room",
                columns: new[] { "Id", "CreatedByUser", "CreationTime", "Description", "ElectricCounter", "LastUpdateTime", "Price", "RoomNumber", "Square", "Status", "UpdatedByUser", "WaterCounter" },
                values: new object[] { 1L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1 phòng ngủ, 1 phòng khách, 1 giường 2m, tủ quần áo, điều hòa, bếp gas", 0, null, 5000000.0, "P101", 50.0, 0, null, 0 });

            migrationBuilder.InsertData(
                table: "Room",
                columns: new[] { "Id", "CreatedByUser", "CreationTime", "Description", "ElectricCounter", "LastUpdateTime", "Price", "RoomNumber", "Square", "Status", "UpdatedByUser", "WaterCounter" },
                values: new object[] { 2L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1 phòng ngủ, Tủ quần áo, Điều hòa, Tủ lạnh, Bếp gas", 102, null, 4500000.0, "P102", 40.0, 0, null, 301 });

            migrationBuilder.InsertData(
                table: "Room",
                columns: new[] { "Id", "CreatedByUser", "CreationTime", "Description", "ElectricCounter", "LastUpdateTime", "Price", "RoomNumber", "Square", "Status", "UpdatedByUser", "WaterCounter" },
                values: new object[] { 3L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1 phòng ngủ, 1 phòng khách, ban công, full nội thất", 0, null, 4750000.0, "P103", 45.0, 1, null, 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "Id",
                keyValue: 3L);
        }
    }
}
