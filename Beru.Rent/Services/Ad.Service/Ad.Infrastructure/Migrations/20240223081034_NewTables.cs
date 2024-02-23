using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ad.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "ParentId", "Title" },
                values: new object[,]
                {
                    { new Guid("3746a8d0-3276-4037-8f51-8ca024437f9f"), new DateTime(2024, 2, 23, 11, 10, 33, 433, DateTimeKind.Local).AddTicks(8489), null, "Фотоаппаратура" },
                    { new Guid("4920055f-7e05-4af7-afee-8407a203038d"), new DateTime(2024, 2, 23, 11, 10, 33, 433, DateTimeKind.Local).AddTicks(8481), null, "Авто" },
                    { new Guid("4e3b5060-147b-409a-82ba-df32919f810c"), new DateTime(2024, 2, 23, 11, 10, 33, 433, DateTimeKind.Local).AddTicks(8483), null, "Инструменты" },
                    { new Guid("62611750-9b02-494a-a58a-3305b7d94596"), new DateTime(2024, 2, 23, 11, 10, 33, 433, DateTimeKind.Local).AddTicks(8414), null, "Игрушки" },
                    { new Guid("684b4a8c-f3af-476c-9810-82ecf2d22d03"), new DateTime(2024, 2, 23, 11, 10, 33, 433, DateTimeKind.Local).AddTicks(8495), null, "Земельный участок" },
                    { new Guid("7cc84187-cc32-4cf1-9cb1-35a089caed5b"), new DateTime(2024, 2, 23, 11, 10, 33, 433, DateTimeKind.Local).AddTicks(8491), null, "Одежда" },
                    { new Guid("8bf8ce89-3d59-487a-87fd-1d534d20b217"), new DateTime(2024, 2, 23, 11, 10, 33, 433, DateTimeKind.Local).AddTicks(8493), null, "Недвижимость" },
                    { new Guid("a3500d50-3335-4780-89c3-f163bfa460d1"), new DateTime(2024, 2, 23, 11, 10, 33, 433, DateTimeKind.Local).AddTicks(8485), null, "Техника" },
                    { new Guid("b19052d7-cdb1-4715-9617-13c4605c7a11"), new DateTime(2024, 2, 23, 11, 10, 33, 433, DateTimeKind.Local).AddTicks(8487), null, "Электроника" },
                    { new Guid("e6c9cd31-5e81-4609-af68-d083fa76da49"), new DateTime(2024, 2, 23, 11, 10, 33, 433, DateTimeKind.Local).AddTicks(8500), null, "Бьюти-товары" }
                });

            migrationBuilder.InsertData(
                table: "TimeUnits",
                columns: new[] { "Id", "CreatedAt", "Duration", "Title" },
                values: new object[,]
                {
                    { new Guid("15281c7e-645d-4cb5-a0b8-e26ff1ae7051"), new DateTime(2024, 2, 23, 11, 10, 33, 433, DateTimeKind.Local).AddTicks(8707), new TimeSpan(30, 0, 0, 0, 0), "Месяц" },
                    { new Guid("4effd2e6-fb66-45fa-bb10-5abbc3f7e421"), new DateTime(2024, 2, 23, 11, 10, 33, 433, DateTimeKind.Local).AddTicks(8704), new TimeSpan(7, 0, 0, 0, 0), "Неделя" },
                    { new Guid("52a09930-e3c0-4400-92d3-e28f8b176a4f"), new DateTime(2024, 2, 23, 11, 10, 33, 433, DateTimeKind.Local).AddTicks(8690), new TimeSpan(0, 1, 0, 0, 0), "Час" },
                    { new Guid("c5f3a77d-d49f-4de4-b4bf-ab6dad544b81"), new DateTime(2024, 2, 23, 11, 10, 33, 433, DateTimeKind.Local).AddTicks(8697), new TimeSpan(1, 0, 0, 0, 0), "Сутки" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("3746a8d0-3276-4037-8f51-8ca024437f9f"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("4920055f-7e05-4af7-afee-8407a203038d"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("4e3b5060-147b-409a-82ba-df32919f810c"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("62611750-9b02-494a-a58a-3305b7d94596"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("684b4a8c-f3af-476c-9810-82ecf2d22d03"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("7cc84187-cc32-4cf1-9cb1-35a089caed5b"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("8bf8ce89-3d59-487a-87fd-1d534d20b217"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a3500d50-3335-4780-89c3-f163bfa460d1"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b19052d7-cdb1-4715-9617-13c4605c7a11"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e6c9cd31-5e81-4609-af68-d083fa76da49"));

            migrationBuilder.DeleteData(
                table: "TimeUnits",
                keyColumn: "Id",
                keyValue: new Guid("15281c7e-645d-4cb5-a0b8-e26ff1ae7051"));

            migrationBuilder.DeleteData(
                table: "TimeUnits",
                keyColumn: "Id",
                keyValue: new Guid("4effd2e6-fb66-45fa-bb10-5abbc3f7e421"));

            migrationBuilder.DeleteData(
                table: "TimeUnits",
                keyColumn: "Id",
                keyValue: new Guid("52a09930-e3c0-4400-92d3-e28f8b176a4f"));

            migrationBuilder.DeleteData(
                table: "TimeUnits",
                keyColumn: "Id",
                keyValue: new Guid("c5f3a77d-d49f-4de4-b4bf-ab6dad544b81"));
        }
    }
}
