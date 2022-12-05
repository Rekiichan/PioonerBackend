using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PioneerBackend.Migrations
{
    /// <inheritdoc />
    public partial class removeContactTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_ContactInfos_ContactInfoId",
                table: "Members");

            migrationBuilder.DropTable(
                name: "ContactInfos");

            migrationBuilder.DropIndex(
                name: "IX_Members_ContactInfoId",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "ContactInfoId",
                table: "Members");

            migrationBuilder.AddColumn<string>(
                name: "CV",
                table: "Members",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Facebook",
                table: "Members",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "GitHub",
                table: "Members",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Gmail",
                table: "Members",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Linkedin",
                table: "Members",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CV",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "Facebook",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "GitHub",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "Gmail",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "Linkedin",
                table: "Members");

            migrationBuilder.AddColumn<int>(
                name: "ContactInfoId",
                table: "Members",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ContactInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CV = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Facebook = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GitHub = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Linkedin = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactInfos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Members_ContactInfoId",
                table: "Members",
                column: "ContactInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Members_ContactInfos_ContactInfoId",
                table: "Members",
                column: "ContactInfoId",
                principalTable: "ContactInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
