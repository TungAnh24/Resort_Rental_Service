using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resort_Rental.Repository.Migrations
{
    public partial class a : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdateTime",
                table: "User",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdateTime",
                table: "Service",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdateTime",
                table: "Room",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdateTime",
                table: "Guest",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdateTime",
                table: "ContractDetail",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdateTime",
                table: "Contract",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdateTime",
                table: "BillDetail",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdateTime",
                table: "Bill",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreationTime", "LastUpdateTime" },
                values: new object[] { new DateTime(2022, 11, 16, 16, 58, 32, 514, DateTimeKind.Local).AddTicks(6432), new DateTime(2022, 11, 16, 16, 58, 32, 514, DateTimeKind.Local).AddTicks(6441) });

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreationTime", "LastUpdateTime" },
                values: new object[] { new DateTime(2022, 11, 16, 16, 58, 32, 514, DateTimeKind.Local).AddTicks(6443), new DateTime(2022, 11, 16, 16, 58, 32, 514, DateTimeKind.Local).AddTicks(6444) });

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreationTime", "LastUpdateTime" },
                values: new object[] { new DateTime(2022, 11, 16, 16, 58, 32, 514, DateTimeKind.Local).AddTicks(6445), new DateTime(2022, 11, 16, 16, 58, 32, 514, DateTimeKind.Local).AddTicks(6446) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdateTime",
                table: "User",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdateTime",
                table: "Service",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdateTime",
                table: "Room",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdateTime",
                table: "Guest",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdateTime",
                table: "ContractDetail",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdateTime",
                table: "Contract",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdateTime",
                table: "BillDetail",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdateTime",
                table: "Bill",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreationTime", "LastUpdateTime" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreationTime", "LastUpdateTime" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreationTime", "LastUpdateTime" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });
        }
    }
}
