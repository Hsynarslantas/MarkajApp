using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FootballApps.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_add_column_playerstatistics_goalminutes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GoalMinutes",
                table: "PlayerMatchStatistics",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GoalMinutes",
                table: "PlayerMatchStatistics");
        }
    }
}
