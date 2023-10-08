using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicCatalog.Migrations
{
    /// <inheritdoc />
    public partial class AddedSongIdToReview : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SongId",
                table: "Reviews",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SongId",
                table: "Reviews");
        }
    }
}
