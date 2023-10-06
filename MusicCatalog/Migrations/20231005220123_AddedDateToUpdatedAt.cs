using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicCatalog.Migrations
{
    /// <inheritdoc />
    public partial class AddedDateToUpdatedAt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Reviews",
                type: "datetime(6)",
                nullable: false,
                defaultValueSql: "curdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Reviews",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValueSql: "curdate()");
        }
    }
}
