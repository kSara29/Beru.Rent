using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ad.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AddressExtras",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Country = table.Column<string>(type: "text", nullable: true),
                    City = table.Column<string>(type: "text", nullable: true),
                    Region = table.Column<string>(type: "text", nullable: true),
                    PostIndex = table.Column<string>(type: "text", nullable: true),
                    Latitude = table.Column<string>(type: "text", nullable: true),
                    Longitude = table.Column<string>(type: "text", nullable: true),
                    Street = table.Column<string>(type: "text", nullable: false),
                    House = table.Column<string>(type: "text", nullable: true),
                    Floor = table.Column<byte>(type: "smallint", nullable: true),
                    Apartment = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressExtras", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    ParentId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tariffs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Duration = table.Column<TimeSpan>(type: "interval", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tariffs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TimeUnits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Duration = table.Column<TimeSpan>(type: "interval", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeUnits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ads",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    ExtraConditions = table.Column<string>(type: "text", nullable: true),
                    NeededDeposit = table.Column<bool>(type: "boolean", nullable: true),
                    MinDeposit = table.Column<decimal>(type: "numeric", nullable: true),
                    State = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    TimeUnitId = table.Column<Guid>(type: "uuid", nullable: false),
                    ContractType = table.Column<int>(type: "integer", nullable: false),
                    AddressExtraId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ads_AddressExtras_AddressExtraId",
                        column: x => x.AddressExtraId,
                        principalTable: "AddressExtras",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ads_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ads_TimeUnits_TimeUnitId",
                        column: x => x.TimeUnitId,
                        principalTable: "TimeUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OriginFileName = table.Column<string>(type: "text", nullable: false),
                    MinioFileName = table.Column<string>(type: "text", nullable: true),
                    AdId = table.Column<Guid>(type: "uuid", nullable: false),
                    BucketName = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Files_Ads_AdId",
                        column: x => x.AdId,
                        principalTable: "Ads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    AdvertisementId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tags_Ads_AdvertisementId",
                        column: x => x.AdvertisementId,
                        principalTable: "Ads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AddressExtras",
                columns: new[] { "Id", "Apartment", "City", "Country", "CreatedAt", "Floor", "House", "Latitude", "Longitude", "PostIndex", "Region", "Street" },
                values: new object[] { new Guid("4a4042f8-1621-4653-9bec-87d20cc5fa82"), "5", "Алматы", "Казахстан", new DateTime(2024, 2, 23, 15, 19, 33, 692, DateTimeKind.Local).AddTicks(3472), (byte)2, "90", "43.232808", "76.879196", "S19B5T8", "Алматы", "улица Каныша Сатпаева" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "ParentId", "Title" },
                values: new object[,]
                {
                    { new Guid("2e582a42-15aa-4b3b-8390-8b20467f9c83"), new DateTime(2024, 2, 23, 15, 19, 33, 692, DateTimeKind.Local).AddTicks(3163), null, "Бьюти-товары" },
                    { new Guid("622b90e8-6e20-436d-a2f5-2c38afc53ba6"), new DateTime(2024, 2, 23, 15, 19, 33, 692, DateTimeKind.Local).AddTicks(3159), null, "Недвижимость" },
                    { new Guid("62611750-9b02-494a-a58a-3305b7d94596"), new DateTime(2024, 2, 23, 15, 19, 33, 692, DateTimeKind.Local).AddTicks(3091), null, "Игрушки" },
                    { new Guid("72461ae9-f852-4d98-96ab-1ccfc1b9de3b"), new DateTime(2024, 2, 23, 15, 19, 33, 692, DateTimeKind.Local).AddTicks(3161), null, "Земельный участок" },
                    { new Guid("90c969dd-d5f9-4247-8b98-4a3b7f61fa4c"), new DateTime(2024, 2, 23, 15, 19, 33, 692, DateTimeKind.Local).AddTicks(3153), null, "Техника" },
                    { new Guid("92951fa4-e638-4dbf-aae6-dd91a38aa6e7"), new DateTime(2024, 2, 23, 15, 19, 33, 692, DateTimeKind.Local).AddTicks(3156), null, "Фотоаппаратура" },
                    { new Guid("af1b97dd-fe43-4642-88f1-f0d96e1f4024"), new DateTime(2024, 2, 23, 15, 19, 33, 692, DateTimeKind.Local).AddTicks(3139), null, "Авто" },
                    { new Guid("b502faa7-d947-4ff6-b398-3513900e95c9"), new DateTime(2024, 2, 23, 15, 19, 33, 692, DateTimeKind.Local).AddTicks(3158), null, "Одежда" },
                    { new Guid("d28ba237-231e-4191-8f15-f9f4f5d41bf6"), new DateTime(2024, 2, 23, 15, 19, 33, 692, DateTimeKind.Local).AddTicks(3155), null, "Электроника" },
                    { new Guid("e682d4f4-8f46-4cab-a05e-e938130be774"), new DateTime(2024, 2, 23, 15, 19, 33, 692, DateTimeKind.Local).AddTicks(3141), null, "Инструменты" }
                });

            migrationBuilder.InsertData(
                table: "TimeUnits",
                columns: new[] { "Id", "CreatedAt", "Duration", "Title" },
                values: new object[,]
                {
                    { new Guid("252841cf-1e52-41d6-b274-a32754245cd7"), new DateTime(2024, 2, 23, 15, 19, 33, 692, DateTimeKind.Local).AddTicks(3389), new TimeSpan(1, 0, 0, 0, 0), "Сутки" },
                    { new Guid("465c4f5f-fa65-47f1-84eb-0e2799a421b1"), new DateTime(2024, 2, 23, 15, 19, 33, 692, DateTimeKind.Local).AddTicks(3398), new TimeSpan(30, 0, 0, 0, 0), "Месяц" },
                    { new Guid("52a09930-e3c0-4400-92d3-e28f8b176a4f"), new DateTime(2024, 2, 23, 15, 19, 33, 692, DateTimeKind.Local).AddTicks(3318), new TimeSpan(0, 1, 0, 0, 0), "Час" },
                    { new Guid("b69ab690-1a63-49a0-91b2-b7e6c8e1cefb"), new DateTime(2024, 2, 23, 15, 19, 33, 692, DateTimeKind.Local).AddTicks(3396), new TimeSpan(7, 0, 0, 0, 0), "Неделя" }
                });

            migrationBuilder.InsertData(
                table: "Ads",
                columns: new[] { "Id", "AddressExtraId", "CategoryId", "ContractType", "CreatedAt", "Description", "ExtraConditions", "MinDeposit", "NeededDeposit", "Price", "State", "TimeUnitId", "Title", "UpdatedAt", "UserId" },
                values: new object[] { new Guid("83c607b9-228c-43fc-a2b5-84f21e6aea13"), new Guid("4a4042f8-1621-4653-9bec-87d20cc5fa82"), new Guid("62611750-9b02-494a-a58a-3305b7d94596"), 0, new DateTime(2024, 2, 23, 15, 19, 43, 697, DateTimeKind.Local).AddTicks(3048), "Достоинства: 1. Хорошая модель мотоцикла; 2. Движущиеся детали; 3. Наличие альтернативной модели; 4. Легко собирается; 5. Понятная инструкция; 6. Запасные части; 7. Оригинальный ЛЕГО; 8. Качественный пластик; 9. Детали хорошо подходят друг к другу; 10. Не маленькая модель; 11. Наклейки. Недостатки: 1. Можно конечно заркала добавить и приборную панель. Хотя и так вполне себе. Комментарий: У мотоцикла поворачивается руль, крутятся колёса, крутится цепь и двигаются цилиндры. Хороший конструктор с движущимися механизмами. Много деталей в наборе. Упакованы в 3 пакетика. Шины лежали без пакета. Запасные детали как всегда в наличии. Стоит на двух колёсах и не падает. Шины из резинового материала", "нет", null, false, 1400m, 0, new Guid("52a09930-e3c0-4400-92d3-e28f8b176a4f"), "Игрушечный мотоцикл", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ecab5681-aa11-4f85-b5d5-72dd1705d767" });

            migrationBuilder.InsertData(
                table: "Files",
                columns: new[] { "Id", "AdId", "BucketName", "CreatedAt", "MinioFileName", "OriginFileName" },
                values: new object[] { new Guid("39134ea5-9144-48e5-bd28-f45b934faf7f"), new Guid("83c607b9-228c-43fc-a2b5-84f21e6aea13"), "83c607b9-228c-43fc-a2b5-84f21e6aea13", new DateTime(2024, 2, 23, 15, 19, 43, 697, DateTimeKind.Local).AddTicks(3346), "83c607b9-228c-43fc-a2b5-84f21e6aea13.png", "83c607b9-228c-43fc-a2b5-84f21e6aea13.png" });

            migrationBuilder.CreateIndex(
                name: "IX_Ads_AddressExtraId",
                table: "Ads",
                column: "AddressExtraId");

            migrationBuilder.CreateIndex(
                name: "IX_Ads_CategoryId",
                table: "Ads",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Ads_TimeUnitId",
                table: "Ads",
                column: "TimeUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Files_AdId",
                table: "Files",
                column: "AdId");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_AdvertisementId",
                table: "Tags",
                column: "AdvertisementId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Tariffs");

            migrationBuilder.DropTable(
                name: "Ads");

            migrationBuilder.DropTable(
                name: "AddressExtras");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "TimeUnits");
        }
    }
}
