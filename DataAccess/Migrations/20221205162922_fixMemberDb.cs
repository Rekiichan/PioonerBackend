using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PioneerBackend.Migrations
{
    /// <inheritdoc />
    public partial class fixMemberDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Members_ProjectId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Rewards_Members_RewardId",
                table: "Rewards");

            migrationBuilder.DropIndex(
                name: "IX_Rewards_RewardId",
                table: "Rewards");

            migrationBuilder.DropIndex(
                name: "IX_Projects_ProjectId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "RewardId",
                table: "Rewards");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "RewardId",
                table: "Members");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RewardId",
                table: "Rewards",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "Projects",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "Members",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RewardId",
                table: "Members",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Rewards_RewardId",
                table: "Rewards",
                column: "RewardId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ProjectId",
                table: "Projects",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Members_ProjectId",
                table: "Projects",
                column: "ProjectId",
                principalTable: "Members",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rewards_Members_RewardId",
                table: "Rewards",
                column: "RewardId",
                principalTable: "Members",
                principalColumn: "Id");
        }
    }
}
