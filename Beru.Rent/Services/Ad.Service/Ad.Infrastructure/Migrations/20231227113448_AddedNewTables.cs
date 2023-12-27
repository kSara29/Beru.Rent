using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ad.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedNewTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "Duration",
                table: "TimeUnits",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "interval");

            migrationBuilder.AlterColumn<long>(
                name: "Duration",
                table: "Tariffs",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "interval");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "Duration",
                table: "TimeUnits",
                type: "interval",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "Duration",
                table: "Tariffs",
                type: "interval",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }
    }
}
