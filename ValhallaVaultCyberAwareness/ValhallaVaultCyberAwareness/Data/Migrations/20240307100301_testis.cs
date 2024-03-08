using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ValhallaVaultCyberAwareness.Migrations
{
    /// <inheritdoc />
    public partial class testis : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserAnswers",
                keyColumns: new[] { "answer_id", "user_id" },
                keyValues: new object[] { 2, "e547fd1c-ec07-49e1-b2ce-0d326f467c01" });

            migrationBuilder.DeleteData(
                table: "UserAnswers",
                keyColumns: new[] { "answer_id", "user_id" },
                keyValues: new object[] { 4, "e547fd1c-ec07-49e1-b2ce-0d326f467c01" });

            migrationBuilder.DeleteData(
                table: "UserAnswers",
                keyColumns: new[] { "answer_id", "user_id" },
                keyValues: new object[] { 8, "e547fd1c-ec07-49e1-b2ce-0d326f467c01" });

            migrationBuilder.DeleteData(
                table: "UserAnswers",
                keyColumns: new[] { "answer_id", "user_id" },
                keyValues: new object[] { 11, "e547fd1c-ec07-49e1-b2ce-0d326f467c01" });

            migrationBuilder.InsertData(
                table: "UserAnswers",
                columns: new[] { "answer_id", "user_id" },
                values: new object[,]
                {
                    { 2, "1872fec2-27e0-4aa2-b876-5de387b62fbc" },
                    { 4, "1872fec2-27e0-4aa2-b876-5de387b62fbc" },
                    { 8, "1872fec2-27e0-4aa2-b876-5de387b62fbc" },
                    { 11, "1872fec2-27e0-4aa2-b876-5de387b62fbc" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserAnswers",
                keyColumns: new[] { "answer_id", "user_id" },
                keyValues: new object[] { 2, "1872fec2-27e0-4aa2-b876-5de387b62fbc" });

            migrationBuilder.DeleteData(
                table: "UserAnswers",
                keyColumns: new[] { "answer_id", "user_id" },
                keyValues: new object[] { 4, "1872fec2-27e0-4aa2-b876-5de387b62fbc" });

            migrationBuilder.DeleteData(
                table: "UserAnswers",
                keyColumns: new[] { "answer_id", "user_id" },
                keyValues: new object[] { 8, "1872fec2-27e0-4aa2-b876-5de387b62fbc" });

            migrationBuilder.DeleteData(
                table: "UserAnswers",
                keyColumns: new[] { "answer_id", "user_id" },
                keyValues: new object[] { 11, "1872fec2-27e0-4aa2-b876-5de387b62fbc" });

            migrationBuilder.InsertData(
                table: "UserAnswers",
                columns: new[] { "answer_id", "user_id" },
                values: new object[,]
                {
                    { 2, "e547fd1c-ec07-49e1-b2ce-0d326f467c01" },
                    { 4, "e547fd1c-ec07-49e1-b2ce-0d326f467c01" },
                    { 8, "e547fd1c-ec07-49e1-b2ce-0d326f467c01" },
                    { 11, "e547fd1c-ec07-49e1-b2ce-0d326f467c01" }
                });
        }
    }
}
