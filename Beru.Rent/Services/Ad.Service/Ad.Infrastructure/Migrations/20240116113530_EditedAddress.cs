using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ad.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EditedAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AddressExtras_AddressMains_AddressMainId",
                table: "AddressExtras");

            migrationBuilder.DropIndex(
                name: "IX_AddressExtras_AddressMainId",
                table: "AddressExtras");

            migrationBuilder.DropColumn(
                name: "AddressMainId",
                table: "AddressExtras");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "AddressExtras",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "AddressExtras",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostIndex",
                table: "AddressExtras",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Region",
                table: "AddressExtras",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "AddressExtras");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "AddressExtras");

            migrationBuilder.DropColumn(
                name: "PostIndex",
                table: "AddressExtras");

            migrationBuilder.DropColumn(
                name: "Region",
                table: "AddressExtras");

            migrationBuilder.AddColumn<Guid>(
                name: "AddressMainId",
                table: "AddressExtras",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_AddressExtras_AddressMainId",
                table: "AddressExtras",
                column: "AddressMainId");

            migrationBuilder.AddForeignKey(
                name: "FK_AddressExtras_AddressMains_AddressMainId",
                table: "AddressExtras",
                column: "AddressMainId",
                principalTable: "AddressMains",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
