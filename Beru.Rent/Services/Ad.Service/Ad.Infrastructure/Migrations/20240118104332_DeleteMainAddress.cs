using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ad.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DeleteMainAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ads_AddressExtras_AddressExtraId",
                table: "Ads");

            migrationBuilder.DropTable(
                name: "AddressMains");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "TimeUnits",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<Guid>(
                name: "AddressExtraId",
                table: "Ads",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Ads_AddressExtras_AddressExtraId",
                table: "Ads",
                column: "AddressExtraId",
                principalTable: "AddressExtras",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ads_AddressExtras_AddressExtraId",
                table: "Ads");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "TimeUnits",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "AddressExtraId",
                table: "Ads",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "AddressMains",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    Country = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PostIndex = table.Column<string>(type: "text", nullable: true),
                    Region = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressMains", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Ads_AddressExtras_AddressExtraId",
                table: "Ads",
                column: "AddressExtraId",
                principalTable: "AddressExtras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
