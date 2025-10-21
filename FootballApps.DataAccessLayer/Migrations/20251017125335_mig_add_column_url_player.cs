using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FootballApps.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_add_column_url_player : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PlayerVideoUrl",
                table: "Players",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlayerVideoUrl",
                table: "Players");
        }
    }
}
