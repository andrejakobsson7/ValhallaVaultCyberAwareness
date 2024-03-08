using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ValhallaVaultCyberAwareness.Migrations
{
    /// <inheritdoc />
    public partial class seedMoreData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Segments",
                columns: new[] { "id", "category_id", "description", "name" },
                values: new object[,]
                {
                    { 8, 3, null, "Del 1 - Cyberspionage" },
                    { 9, 3, null, "Del 2 - Cyberspionage" },
                    { 10, 3, null, "Del 3 - Cyberspionage" }
                });

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

            migrationBuilder.InsertData(
                table: "SubCategories",
                columns: new[] { "id", "description", "name", "segment_id" },
                values: new object[,]
                {
                    { 36, null, "Allmänt om cyberspionage", 8 },
                    { 37, null, "Metoder för cyberspionage", 8 },
                    { 38, null, "Säkerhetsskyddslagen", 8 },
                    { 39, null, "Cyberspionagets aktörer", 8 },
                    { 40, null, "Värvningsförsök", 9 },
                    { 41, null, "Affärsspionage", 9 },
                    { 42, null, "Påverkanskampanjer", 9 },
                    { 43, null, "Svensk underrättelsetjänst och cyberförsvar", 10 },
                    { 44, null, "Signalspaning, informationssäkerhet och 5G", 10 },
                    { 45, null, "Samverkan mot cyberspionage", 10 }
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "id", "question", "subcategory_id" },
                values: new object[,]
                {
                    { 11, "Regeringen upptäcker att känslig politisk kommunikation har läckt och misstänker elektronisk övervakning. Vilket fenomen beskriver bäst denna situation?", 36 },
                    { 12, "Regeringen blir varse om en sofistikerad skadeprogramskampanj som utnyttjar Zero-day sårbarheter för att infiltrera deras nätverk och stjäla oerhört viktig data. Vilken metod för cyberspionage används sannolikt här?", 37 },
                    { 13, "Regeringen i Sverige ökar sitt interna säkerhetsprotokoll för att skydda sig mot utländska underrättelsetjänsters infiltration. Vilken lagstiftning ger ramverket för detta skydd?", 38 },
                    { 14, "Lunds universitet upptäcker att forskningsdata om ny teknologi har stulits. Undersökningar tyder på en välorganiserad grupp med kopplingar till en utländsk stat. Vilken typ av aktör ligger sannolikt bakom detta?", 39 }
                });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "id", "answer", "is_correct", "question_id" },
                values: new object[,]
                {
                    { 31, "Cyberkriminalitet", false, 11 },
                    { 32, "Cyberspionage", true, 11 },
                    { 33, "Cyberterrorism", false, 11 },
                    { 34, "Social ingenjörskonst", false, 12 },
                    { 35, "Massövervakning", false, 12 },
                    { 36, "Riktade cyberattacker", true, 12 },
                    { 37, "GDPR", false, 13 },
                    { 38, "Säkerhetsskyddslagen", true, 13 },
                    { 39, "IT-säkerhetslagen", false, 13 },
                    { 40, "Oberoende hackare", false, 14 },
                    { 41, "Aktivistgrupper", false, 14 },
                    { 42, "Statssponsrade hackers", true, 14 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "id",
                keyValue: 45);

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

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Segments",
                keyColumn: "id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Segments",
                keyColumn: "id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Segments",
                keyColumn: "id",
                keyValue: 8);
        }
    }
}
