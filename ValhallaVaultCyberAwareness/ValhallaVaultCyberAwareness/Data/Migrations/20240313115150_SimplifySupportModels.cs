using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ValhallaVaultCyberAwareness.Migrations
{
    /// <inheritdoc />
    public partial class SimplifySupportModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "is_open",
                table: "SupportQuestions");

            migrationBuilder.DropColumn(
                name: "is_public",
                table: "SupportQuestions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "is_open",
                table: "SupportQuestions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "is_public",
                table: "SupportQuestions",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
