using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ValhallaVaultCyberAwareness.Migrations
{
    /// <inheritdoc />
    public partial class SeedMoreQuestionsAndAnswers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "explanation",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "id",
                keyValue: 1,
                column: "explanation",
                value: "Banker och andra finansiella institutioner begär aldrig känslig information såsom kontonummer eller lösenord via telefon. Detta är ett klassiskt tecken på telefonbedrägeri.");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "id",
                keyValue: 2,
                column: "explanation",
                value: "Begäran om pengar, särskilt under omständigheter där två personer aldrig har träffats fysiskt, är ett vanligt tecken på romansbedrägeri.");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "id",
                keyValue: 3,
                column: "explanation",
                value: "Erbjudanden som lovar hög avkastning med liten eller ingen risk, särskilt via oönskade e-postmeddelanden, är ofta tecken på investeringsbedrägerier.");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "id",
                keyValue: 4,
                column: "explanation",
                value: "Oidentifierade transaktioner på ditt kreditkortsutdrag är en stark indikation på att ditt kortnummer har komprometterats och använts för obehöriga köp, vilket är typiskt för kreditkortsbedrägeri.");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "id",
                keyValue: 5,
                column: "explanation",
                value: "Utbildning i digital säkerhet är avgörande för att hjälpa anställda att känna igen och undvika säkerhetshot som phishing, vilket är en vanlig attackvektor.");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "id",
                keyValue: 6,
                column: "explanation",
                value: "Transparent kommunikation och rådgivning om tillfälliga åtgärder är avgörande för att skydda användarna medan en permanent lösning utvecklas.");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "id",
                keyValue: 7,
                column: "explanation",
                value: "DDoS-attacker kräver ofta betydande resurser och koordinering, vilket är karakteristiskt för organiserade cyberbrottsliga grupper.");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "id",
                keyValue: 8,
                column: "explanation",
                value: "Stärkt autentisering är kritisk för att säkra fjärråtkomst och skydda mot obehörig åtkomst i en distribuerad arbetsmiljö.");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "id",
                keyValue: 9,
                column: "explanation",
                value: "Ransomware-angrepp involverar kryptering av offerdata och kräver lösen för dekryptering, vilket är särskilt skadligt för kritiska sektorer som hälsovård.");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "id",
                keyValue: 10,
                column: "explanation",
                value: "Maersk utsattes för NotPetya ransomware-angreppet, som ledde till omfattande störningar och förluster genom att kryptera företagets globala system. \r\n\r\nMaersk rapporterade att företaget led ekonomiska förluster på grund av NotPetya ransomware-angreppet som uppskattades till cirka 300 miljoner USD. Denna siffra reflekterar de omfattande kostnaderna för störningar i deras globala verksamheter, återställande av system och data, samt förlust av affärer under tiden systemen var nere. NotPetya-angreppet anses vara ett av de mest kostsamma cyberangreppen mot ett enskilt företag och tjänar som en kraftfull påminnelse om de potentiella konsekvenserna av cyberhot. ");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "id",
                keyValue: 11,
                column: "explanation",
                value: "Cyberspionage avser aktiviteter där aktörer, ofta statliga, engagerar sig i övervakning och datainsamling genom cybermedel för att erhålla hemlig information utan målets medgivande, typiskt för politiska, militära eller ekonomiska fördelar.");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "id",
                keyValue: 12,
                column: "explanation",
                value: "Riktade cyberattacker som utnyttjar noll-dagars Zero-day sårbarheter är en avancerad metod för cyberspionage där angriparen specifikt riktar in sig på ett mål för att komma åt känslig information eller data genom att utnyttja tidigare okända sårbarheter i programvara.");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "id",
                keyValue: 13,
                column: "explanation",
                value: "Säkerhetsskyddslagen är en svensk lagstiftning som syftar till att skydda nationellt känslig information från spioneri, sabotage, terroristbrott och andra säkerhetshot. Lagen ställer krav på säkerhetsskyddsåtgärder för verksamheter av betydelse för Sveriges säkerhet.");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "id",
                keyValue: 14,
                column: "explanation",
                value: "Statssponsrade hackers är aktörer som arbetar på uppdrag av eller med stöd från en regering för att genomföra cyberspionage, ofta riktat mot utländska intressen, organisationer eller regeringar för att få strategiska fördelar.");

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "id", "explanation", "question", "subcategory_id" },
                values: new object[,]
                {
                    { 15, "Klicka aldrig på länkar som uppges komma från banker via e-post.", "Du får ett e-postmeddelande som ser ut att komma från din bank. Det ber dig klicka på en länk och logga in på ditt konto för att “uppdatera din information”. Vad bör du göra?", 1 },
                    { 16, "Skimming är en metod där bedragare placerar en enhet på en betalterminal för att stjäla kortinformation. Genom att inspektera terminalen kan du upptäcka ovanliga tillbehör eller lösa delar som kan indikera att skimming-enheten är närvarande.", "Du använder din kreditkort på en betalterminal i en butik. Någon har placerat en skimming-enhet på terminalen för att stjäla kortinformation. Vad bör du vara vaksam på?", 1 },
                    { 17, "Om du ser en större transaktion på ditt kreditkort som du inte har gjort, bör du agera snabbt. Att kontakta din kreditkortsutgivare direkt hjälper till att förhindra ytterligare skada och identifiera eventuellt bedrägeri.", "Du får ett meddelande om en större transaktion på ditt kreditkort som du inte har gjort. Vad bör du göra?", 1 },
                    { 18, "Att öppna bifogade fakturor från okända avsändare kan vara farligt. Radera e-postmeddelandet för att undvika att utsätta dig för skadlig kod eller bedrägeriförsök.", "Du får en e-post med en bifogad faktura från ett företag du inte känner till. Vad bör du göra?", 1 },
                    { 19, "Att ta någon annans kreditkort och använda det är olagligt och oetiskt. Lämna kortet där du hittade det eller ge det till personalen för att returnera det till ägaren.", "Du ser någon slarvigt lämna sitt kreditkort på ett cafébord. Vad bör du göra?", 1 },
                    { 20, "Om du byter kreditkort är det viktigt att uppdatera betalningsuppgifterna för alla automatiska betalningar. Annars kan du missa betalningar och få påminnelser eller avgifter.", "Du har flera automatiska betalningar kopplade till ditt kreditkort. Vad bör du göra om du byter kreditkort?", 1 },
                    { 21, "Ett romansbedrägeri är när en bedragare inleder en romantisk relation med någon i syfte att lura hen på pengar. Det sker oftast på internet, till exempel på sociala medier samt dejtingsidor och dejtingappar.", "Vad är ett romansbedrägeri?", 2 },
                    { 22, "Uppmärksamma typiska drag för en romansbedragare, såsom statusyrken, konstlade formuleringar eller slarvigt språkbruk.", "Vilka typiska drag bör du vara uppmärksam på hos en romansbedragare?", 2 },
                    { 23, "Romansbedrägeri är brottsligt när någon inleder en kärleksrelation med dig för att lura dig på pengar. Åtal kan väckas om det finns bevis för detta bedrägeri.", "Vad krävs för att någon ska åtalas för romansbedrägeri?", 2 },
                    { 24, "Om du blivit lurad av kärleken du träffat på nätet bör du lista ut vad du ska göra när du blivit utsatt och vart du ska vända dig för hjälp.", "Vad bör du göra om du misstänker att du blivit utsatt för romansbedrägeri på nätet?", 2 },
                    { 25, "Det finns flera saker du kan göra för att skydda dig mot romansbedrägeri. Följ tips och råd om hur du kan undvika att bli lurad.", "Hur skyddar du dig mot romansbedrägeri?", 2 },
                    { 26, "Ett investeringsbedrägeri innebär att någon lurar andra att köpa värdepapper som egentligen inte har något värde eller som är väldigt svåra att värdera. Det kan handla om investeringar i fonder, aktier, kryptovalutor samt metaller och ädelstenar.", "Vad är ett investeringsbedrägeri?", 3 },
                    { 27, "Var uppmärksam på varningssignaler som hög avkastning utan risk, bristande dokumentation, och orealistiska löften. Bedragare lockar ofta med snabba vinster och undviker att ge tydlig information om investeringen.", "Vilka varningssignaler bör du vara uppmärksam på vid investeringserbjudanden?", 3 },
                    { 28, "För att skydda dig mot investeringsbedrägeri bör du vara skeptisk mot orealistiska löften, göra grundlig research om investeringen, och undvika att agera impulsivt. Kontrollera även att företaget har tillstånd från Finansinspektionen.", "Hur kan du skydda dig mot investeringsbedrägeri?", 3 },
                    { 29, "Om du misstänker att du blivit utsatt för investeringsbedrägeri bör du omedelbart kontakta Polisen och Finansinspektionen. Samla all relevant information och undvik att göra fler transaktioner med bedragaren.", "Vad bör du göra om du misstänker att du blivit utsatt för investeringsbedrägeri?", 3 }
                });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "id", "answer", "is_correct", "question_id" },
                values: new object[,]
                {
                    { 43, "Klicka på länken och logga in för att uppdatera din information.", false, 15 },
                    { 44, "Ignorera e-postmeddelandet och radera det omedelbart.", true, 15 },
                    { 45, "Skicka ditt kontonummer och lösenord som begärt.", false, 15 },
                    { 46, "Kontrollera att PIN-koden är synlig för andra.", false, 16 },
                    { 47, "Inspektera terminalen för ovanliga tillbehör eller lösa delar.", true, 16 },
                    { 48, "Använd kortet utan att oroa dig.", false, 16 },
                    { 49, "Ignorera det och anta att det är en felaktighet.", false, 17 },
                    { 50, "Kontakta din kreditkortsutgivare omedelbart för att rapportera misstänkt bedrägeri.", true, 17 },
                    { 51, "Vänta och se om det löser sig av sig självt.", false, 17 },
                    { 52, "Öppna fakturan och betala den om den verkar legitim.", false, 18 },
                    { 53, "Kontakta din kreditkortsutgivare omedelbart för att rapportera misstänkt bedrägeri.", true, 18 },
                    { 54, "Vänta och se om det löser sig av sig självt.", false, 18 },
                    { 55, "Ta kortet och använd det för egna inköp.", false, 19 },
                    { 56, "Ge kortet till personalen på caféet.", true, 19 },
                    { 57, "Klipp sönder kortet.", false, 19 },
                    { 58, "Glöm bort det och låt betalningarna fortsätta.", false, 20 },
                    { 59, "Uppdatera betalningsuppgifterna hos varje tjänsteleverantör.", true, 20 },
                    { 60, "Avbryt alla automatiska betalningar.", false, 20 },
                    { 61, "Ett romansbedrägeri är när en bedragare inleder en romantisk relation med någon i syfte att lura hen på pengar. Det sker oftast på internet, till exempel på sociala medier samt dejtingsidor och dejtingappar.", true, 21 },
                    { 62, "Det är när två personer fejkar en romantisk relation för att lura andra.", false, 21 },
                    { 63, "Det handlar om att skapa en falsk identitet för att vinna någon annans förtroende.", false, 21 },
                    { 64, "Statusyrken, konstlade formuleringar eller slarvigt språkbruk.", true, 22 },
                    { 65, "Generös gåva av blommor eller choklad.", false, 22 },
                    { 66, "Överdriven romantik och kärleksgestikulering.", false, 22 },
                    { 67, "Bevis för att personen inlett en kärleksrelation för att lura på pengar.", true, 23 },
                    { 68, "Att personen har skickat kärleksbrev eller romantiska meddelanden.", false, 23 },
                    { 69, "Att personen har använt falsk identitet på sociala medier.", false, 23 },
                    { 70, "Fortsätta kommunicera för att samla mer bevis.", false, 24 },
                    { 71, "Avsluta all kontakt med personen och blockera dem.", true, 24 },
                    { 72, "Dela personlig information för att testa deras äkthet.", false, 24 },
                    { 73, "Öppet dela dina känslor och livshistoria med okända personer.", false, 25 },
                    { 74, "Dela personlig information och bankuppgifter direkt.", false, 25 },
                    { 75, "Var skeptisk mot snabba kärleksförklaringar och ekonomiska problem.", true, 25 },
                    { 76, "Ett investeringsbedrägeri kan handla om investeringar i fonder, aktier, kryptovalutor samt metaller och ädelstenar.", false, 26 },
                    { 77, "Det är när någon lurar andra att köpa värdepapper som egentligen inte har något värde eller är svåra att värdera.", true, 26 },
                    { 78, "Investeringar som garanterar snabba vinster utan risk.", false, 26 },
                    { 79, "Hög avkastning utan risk, bristande dokumentation, orealistiska löften.", true, 27 },
                    { 80, "Tydlig information om investeringen, seriösa företag.", false, 27 },
                    { 81, "Snabba vinster och impulsivt agerande.", false, 27 },
                    { 82, "Var skeptisk mot orealistiska löften, gör grundlig research, undvik impulsiva beslut.", true, 28 },
                    { 83, "Dela personlig information och bankuppgifter direkt.", false, 28 },
                    { 84, "Lita på alla investeringsmöjligheter utan att kontrollera företaget.", false, 28 },
                    { 85, "Dela personlig information för att testa deras äkthet.", false, 29 },
                    { 86, "Fortsätta kommunicera för att samla mer bevis.", false, 29 },
                    { 87, "Avsluta all kontakt med personen och blockera dem.", true, 29 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "id",
                keyValue: 29);

            migrationBuilder.DropColumn(
                name: "explanation",
                table: "Questions");
        }
    }
}
