using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Deal.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TableWithOwnerId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BookingState = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    AdId = table.Column<Guid>(type: "uuid", nullable: false),
                    TenantId = table.Column<string>(type: "text", nullable: false),
                    Dbeg = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Dend = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CancelAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Cost = table.Column<decimal>(type: "numeric", nullable: true),
                    OwnerId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContractStorages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DealId = table.Column<string>(type: "text", nullable: false),
                    TemplatePath = table.Column<string>(type: "text", nullable: false),
                    SignedByTenanPath = table.Column<string>(type: "text", nullable: false),
                    SignedByOwnerPath = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractStorages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Deals",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DealState = table.Column<int>(type: "integer", nullable: false),
                    Deposit = table.Column<decimal>(type: "numeric", nullable: false),
                    ChatId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    AdId = table.Column<Guid>(type: "uuid", nullable: false),
                    TenantId = table.Column<string>(type: "text", nullable: false),
                    Dbeg = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Dend = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CancelAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Cost = table.Column<decimal>(type: "numeric", nullable: true),
                    OwnerId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deals", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "ContractStorages");

            migrationBuilder.DropTable(
                name: "Deals");
        }
    }
}
