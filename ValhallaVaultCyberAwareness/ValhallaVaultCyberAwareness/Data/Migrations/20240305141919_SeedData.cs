using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ValhallaVaultCyberAwareness.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "id", "description", "name" },
                values: new object[,]
                {
                    { 1, null, "Att skydda sig mot bedrägerier" },
                    { 2, null, "Cybersäkerhet för företag" },
                    { 3, null, "Cyberspionage" }
                });

            migrationBuilder.InsertData(
                table: "Segments",
                columns: new[] { "id", "category_id", "description", "name" },
                values: new object[,]
                {
                    { 1, 1, null, "Del 1 - Att skydda sig mot bedrägerier" },
                    { 2, 1, null, "Del 2 - Att skydda sig mot bedrägerier" },
                    { 3, 1, null, "Del 3 - Att skydda sig mot bedrägerier" },
                    { 4, 2, null, "Del 1 - Cybersäkerhet för företag" },
                    { 5, 2, null, "Del 2 - Cybersäkerhet för företag" },
                    { 6, 2, null, "Del 3 - Cybersäkerhet för företag" },
                    { 7, 2, null, "Del 4 - Cybersäkerhet för företag" }
                });

            migrationBuilder.InsertData(
                table: "SubCategories",
                columns: new[] { "id", "description", "name", "segment_id" },
                values: new object[,]
                {
                    { 1, null, "Kreditkortsbedrägeri", 1 },
                    { 2, null, "Romansbedrägeri", 1 },
                    { 3, null, "Investeringsbedrägeri", 1 },
                    { 4, null, "Telefonbedrägeri", 1 },
                    { 5, null, "Bedrägerier i hemmet", 2 },
                    { 6, null, "Identitetsstöld", 2 },
                    { 7, null, "Nätfiske och bluffmejl", 2 },
                    { 8, null, "Investeringsbedrägeri på nätet", 2 },
                    { 9, null, "Abonnemangsfällor och falska fakturor", 3 },
                    { 10, null, "Ransomware", 3 },
                    { 11, null, "Statistik och förhållningssätt", 3 },
                    { 12, null, "Digital säkerhet på företag", 4 },
                    { 13, null, "Risker och beredskap", 4 },
                    { 14, null, "Aktörer inom cyberbrott", 4 },
                    { 15, null, "Ökad digital närvaro och distansarbete", 4 },
                    { 16, null, "Cyberangrepp mot känsliga sektorer", 4 },
                    { 17, null, "Cyberrånet mot Mersk", 4 },
                    { 18, null, "Social engineering", 5 },
                    { 19, null, "Nätfiske och skräppost", 5 },
                    { 20, null, "Vishing", 5 },
                    { 21, null, "Varning för vishing", 5 },
                    { 22, null, "Identifiera VD-mejl", 5 },
                    { 23, null, "Öneangrepp och presentkortsbluffar", 5 },
                    { 24, null, "Virus, maskar och trojaner", 6 },
                    { 25, null, "Så kan det gå till", 6 },
                    { 26, null, "Nätverksintrång", 6 },
                    { 27, null, "Dataintrång", 6 },
                    { 28, null, "Hackad!", 6 },
                    { 29, null, "Vägarna in", 6 },
                    { 30, null, "Utpressningsvirus", 7 },
                    { 31, null, "Attacker mot servrar", 7 },
                    { 32, null, "Cyberangrepp i Norden", 7 },
                    { 33, null, "It-brottslingarnas verktyg", 7 },
                    { 34, null, "Mirai, Wannacry och fallet Düsseldorf", 7 },
                    { 35, null, "De sårbara molnen", 7 }
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "id", "question", "subcategory_id" },
                values: new object[,]
                {
                    { 1, "Du får ett oväntat telefonsamtal från någon som påstår sig vara från din bank. Personen ber dig bekräfta ditt kontonummer och lösenord för att \"säkerställa din kontos säkerhet\" efter en påstådd säkerhetsincident. Hur bör du tolka denna situation?", 1 },
                    { 2, "Efter flera månader av daglig kommunikation med någon du träffade på en datingsida, börjar personen berätta om en plötslig finansiell kris och ber om din hjälp genom att överföra pengar. Vad indikerar detta mest sannolikt?", 2 },
                    { 3, "Du får ett e-postmeddelande/samtal om ett exklusivt erbjudande att investera i ett startup-företag som påstås ha en revolutionerande ny teknologi, med garantier om exceptionellt hög avkastning på mycket kort tid. Hur bör du förhålla dig till erbjudandet?", 3 },
                    { 4, "Efter en online-shoppingrunda märker du oidentifierade transaktioner på ditt kreditkortsutdrag från företag du aldrig handlat från. Vad indikerar detta mest sannolikt?", 4 },
                    { 5, "Inom företaget märker man att konfidentiella dokument regelbundet läcker ut till konkurrenter. Efter en intern granskning upptäcks det att en anställd omedvetet har installerat skadlig programvara genom att klicka på en länk i ett phishing-e-postmeddelande. Vilken åtgärd bör prioriteras för att förhindra framtida incidenter?", 5 },
                    { 6, "Inom företaget upptäckts det en sårbarhet i vår programvara som kunde möjliggöra obehörig åtkomst till användardata. Företaget har inte omedelbart en lösning. Vilken är den mest lämpliga första åtgärden?", 6 },
                    { 7, "Vårt företag blir måltavla för en DDoS-attack som överväldigar våra servrar och gör våra tjänster otillgängliga för kunder. Vilken typ av aktör är mest sannolikt ansvarig för denna typ av attack?", 7 },
                    { 8, "Med övergången till distansarbete upptäcker vårt företag en ökning av säkerhetsincidenter, inklusive obehörig åtkomst till företagsdata. Vilken åtgärd bör företaget vidta för att adressera denna nya riskmiljö?", 8 },
                    { 9, "Hälsovårdsmyndigheten utsätts för ett cyberangrepp som krypterar patientdata och kräver lösen för att återställa åtkomsten. Vilken typ av angrepp har de sannolikt blivit utsatta för?", 9 },
                    { 10, "Det globala fraktbolaget Maersk blev offer för ett omfattande cyberangrepp som avsevärt störde deras verksamhet världen över. Vilken typ av malware var primärt ansvarig för denna incident?", 10 }
                });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "id", "answer", "is_correct", "question_id" },
                values: new object[,]
                {
                    { 1, "Ett legitimt försök från banken att skydda ditt konto", false, 1 },
                    { 2, "En informationsinsamling för en marknadsundersökning", false, 1 },
                    { 3, "Ett potentiellt telefonbedrägeri", true, 1 },
                    { 4, "En legitim begäran om hjälp från en person i nöd", false, 2 },
                    { 5, "Ett romansbedrägeri", true, 2 },
                    { 6, "En tillfällig ekonomisk svårighet", false, 2 },
                    { 7, "Genomföra omedelbar investering för att inte missa möjligheten", false, 3 },
                    { 8, "Investeringsbedrägeri", true, 3 },
                    { 9, "Begära mer information för att utföra en noggrann \"due diligence\"", false, 3 },
                    { 10, "Ett misstag av kreditkortsföretaget", false, 4 },
                    { 11, "Kreditkortsbedrägeri", true, 4 },
                    { 12, "Obehöriga köp av en familjemedlem", false, 4 },
                    { 13, "Utbildning i digital säkerhet för alla anställda", true, 5 },
                    { 14, "Installera en starkare brandvägg", false, 5 },
                    { 15, "Byta ut all IT-utrustning", false, 5 },
                    { 16, "Informera alla användare om sårbarheten och rekommendera temporära skyddsåtgärder", true, 6 },
                    { 17, "Ignorera problemet tills en patch kan utvecklas", false, 6 },
                    { 18, "Stänga ner tjänsten tillfälligt", false, 6 },
                    { 19, "En enskild hackare med ett personligt vendetta", false, 7 },
                    { 20, "En konkurrerande företagsentitet", false, 7 },
                    { 21, "Organiserade cyberbrottsliga grupper", true, 7 },
                    { 22, "Återgå till kontorsarbete", false, 8 },
                    { 23, "Införa striktare lösenordspolicyer och tvåfaktorsautentisering för fjärråtkomst", true, 8 },
                    { 24, "Förbjuda användning av personliga enheter för arbete", false, 8 },
                    { 25, "Phishing", false, 9 },
                    { 26, "Ransomware", true, 9 },
                    { 27, "Spyware", false, 9 },
                    { 28, "Spyware", false, 10 },
                    { 29, "Ransomware", true, 10 },
                    { 30, "Adware", false, 10 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Segments",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Segments",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Segments",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Segments",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Segments",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Segments",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Segments",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "id",
                keyValue: 1);
        }
    }
}
