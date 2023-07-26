using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddInitProject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "city",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamptz", nullable: false, defaultValue: new DateTime(2023, 7, 25, 11, 59, 14, 789, DateTimeKind.Utc).AddTicks(6930))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_city", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "order",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    sender_city_id = table.Column<int>(type: "integer", nullable: false),
                    sender_address = table.Column<string>(type: "text", nullable: false),
                    receiver_city_id = table.Column<int>(type: "integer", nullable: false),
                    receiver_address = table.Column<string>(type: "text", nullable: false),
                    cargo_weight = table.Column<double>(type: "numeric", nullable: false),
                    pickup_date = table.Column<DateOnly>(type: "date", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamptz", nullable: false, defaultValue: new DateTime(2023, 7, 25, 11, 59, 14, 790, DateTimeKind.Utc).AddTicks(8090))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order", x => x.id);
                    table.ForeignKey(
                        name: "FK_order_city_receiver_city_id",
                        column: x => x.receiver_city_id,
                        principalTable: "city",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_order_city_sender_city_id",
                        column: x => x.sender_city_id,
                        principalTable: "city",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "CityIdIndex",
                table: "city",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_order_receiver_city_id",
                table: "order",
                column: "receiver_city_id");

            migrationBuilder.CreateIndex(
                name: "IX_order_sender_city_id",
                table: "order",
                column: "sender_city_id");

            migrationBuilder.CreateIndex(
                name: "OrderIdIndex",
                table: "order",
                column: "id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "order");

            migrationBuilder.DropTable(
                name: "city");
        }
    }
}
