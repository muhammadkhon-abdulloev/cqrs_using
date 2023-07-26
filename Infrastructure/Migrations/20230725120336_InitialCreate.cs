using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "order",
                type: "timestamptz",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 25, 12, 3, 36, 180, DateTimeKind.Utc).AddTicks(5960),
                oldClrType: typeof(DateTime),
                oldType: "timestamptz",
                oldDefaultValue: new DateTime(2023, 7, 25, 11, 59, 14, 790, DateTimeKind.Utc).AddTicks(8090));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "city",
                type: "timestamptz",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 25, 12, 3, 36, 179, DateTimeKind.Utc).AddTicks(4780),
                oldClrType: typeof(DateTime),
                oldType: "timestamptz",
                oldDefaultValue: new DateTime(2023, 7, 25, 11, 59, 14, 789, DateTimeKind.Utc).AddTicks(6930));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "order",
                type: "timestamptz",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 25, 11, 59, 14, 790, DateTimeKind.Utc).AddTicks(8090),
                oldClrType: typeof(DateTime),
                oldType: "timestamptz",
                oldDefaultValue: new DateTime(2023, 7, 25, 12, 3, 36, 180, DateTimeKind.Utc).AddTicks(5960));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "city",
                type: "timestamptz",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 25, 11, 59, 14, 789, DateTimeKind.Utc).AddTicks(6930),
                oldClrType: typeof(DateTime),
                oldType: "timestamptz",
                oldDefaultValue: new DateTime(2023, 7, 25, 12, 3, 36, 179, DateTimeKind.Utc).AddTicks(4780));
        }
    }
}
