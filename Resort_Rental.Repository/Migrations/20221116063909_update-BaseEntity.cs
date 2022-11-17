using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resort_Rental.Repository.Migrations
{
    public partial class updateBaseEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UpdatedByUser",
                table: "User",
                type: "varchar(20)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedByUser",
                table: "User",
                type: "varchar(20)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedByUser",
                table: "Service",
                type: "varchar(20)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedByUser",
                table: "Service",
                type: "varchar(20)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedByUser",
                table: "Room",
                type: "varchar(20)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedByUser",
                table: "Room",
                type: "varchar(20)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedByUser",
                table: "Guest",
                type: "varchar(20)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedByUser",
                table: "Guest",
                type: "varchar(20)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedByUser",
                table: "ContractDetail",
                type: "varchar(20)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedByUser",
                table: "ContractDetail",
                type: "varchar(20)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedByUser",
                table: "Contract",
                type: "varchar(20)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedByUser",
                table: "Contract",
                type: "varchar(20)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedByUser",
                table: "BillDetail",
                type: "varchar(20)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedByUser",
                table: "BillDetail",
                type: "varchar(20)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedByUser",
                table: "Bill",
                type: "varchar(20)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedByUser",
                table: "Bill",
                type: "varchar(20)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UpdatedByUser",
                keyValue: null,
                column: "UpdatedByUser",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedByUser",
                table: "User",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "CreatedByUser",
                keyValue: null,
                column: "CreatedByUser",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedByUser",
                table: "User",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "UpdatedByUser",
                keyValue: null,
                column: "UpdatedByUser",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedByUser",
                table: "Service",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "CreatedByUser",
                keyValue: null,
                column: "CreatedByUser",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedByUser",
                table: "Service",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "UpdatedByUser",
                keyValue: null,
                column: "UpdatedByUser",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedByUser",
                table: "Room",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "CreatedByUser",
                keyValue: null,
                column: "CreatedByUser",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedByUser",
                table: "Room",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Guest",
                keyColumn: "UpdatedByUser",
                keyValue: null,
                column: "UpdatedByUser",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedByUser",
                table: "Guest",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Guest",
                keyColumn: "CreatedByUser",
                keyValue: null,
                column: "CreatedByUser",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedByUser",
                table: "Guest",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "ContractDetail",
                keyColumn: "UpdatedByUser",
                keyValue: null,
                column: "UpdatedByUser",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedByUser",
                table: "ContractDetail",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "ContractDetail",
                keyColumn: "CreatedByUser",
                keyValue: null,
                column: "CreatedByUser",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedByUser",
                table: "ContractDetail",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Contract",
                keyColumn: "UpdatedByUser",
                keyValue: null,
                column: "UpdatedByUser",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedByUser",
                table: "Contract",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Contract",
                keyColumn: "CreatedByUser",
                keyValue: null,
                column: "CreatedByUser",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedByUser",
                table: "Contract",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "BillDetail",
                keyColumn: "UpdatedByUser",
                keyValue: null,
                column: "UpdatedByUser",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedByUser",
                table: "BillDetail",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "BillDetail",
                keyColumn: "CreatedByUser",
                keyValue: null,
                column: "CreatedByUser",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedByUser",
                table: "BillDetail",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Bill",
                keyColumn: "UpdatedByUser",
                keyValue: null,
                column: "UpdatedByUser",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedByUser",
                table: "Bill",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Bill",
                keyColumn: "CreatedByUser",
                keyValue: null,
                column: "CreatedByUser",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedByUser",
                table: "Bill",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
