using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ValhallaVaultCyberAwareness.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "subcategory_id",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Questions_subcategory_id",
                table: "Questions",
                column: "subcategory_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_SubCategories_subcategory_id",
                table: "Questions",
                column: "subcategory_id",
                principalTable: "SubCategories",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_SubCategories_subcategory_id",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_subcategory_id",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "subcategory_id",
                table: "Questions");
        }
    }
}
