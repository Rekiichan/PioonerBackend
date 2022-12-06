using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PioneerBackend.Migrations
{
    /// <inheritdoc />
    public partial class updateRewardModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Mssv",
                table: "Rewards",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Rewards",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mssv",
                table: "Rewards");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Rewards");
        }
    }
}
