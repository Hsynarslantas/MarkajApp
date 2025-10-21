using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FootballApps.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_add_column_player_add_goals : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Goals",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Goals",
                table: "Players");
        }
    }
}
