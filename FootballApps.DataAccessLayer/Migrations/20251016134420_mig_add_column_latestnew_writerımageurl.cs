using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FootballApps.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_add_column_latestnew_writerımageurl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "WriterImageUrl",
                table: "LatestNews",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WriterImageUrl",
                table: "LatestNews");
        }
    }
}
