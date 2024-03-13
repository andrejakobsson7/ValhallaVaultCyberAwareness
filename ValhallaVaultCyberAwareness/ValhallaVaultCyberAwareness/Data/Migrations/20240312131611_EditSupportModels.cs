using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ValhallaVaultCyberAwareness.Migrations
{
    /// <inheritdoc />
    public partial class EditSupportModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "AspNetRoles",
            //    columns: table => new
            //    {
            //        Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
            //        NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
            //        ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetRoles", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUsers",
            //    columns: table => new
            //    {
            //        Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
            //        NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
            //        Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
            //        NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
            //        EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
            //        PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
            //        TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
            //        LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
            //        LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
            //        AccessFailedCount = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUsers", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Categories",
            //    columns: table => new
            //    {
            //        id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        name = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        description = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Categories", x => x.id);
            //    });

            migrationBuilder.CreateTable(
                name: "SupportQuestions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    question = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    is_public = table.Column<bool>(type: "bit", nullable: false),
                    is_open = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupportQuestions", x => x.id);
                });

            //migrationBuilder.CreateTable(
            //    name: "AspNetRoleClaims",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
            //            column: x => x.RoleId,
            //            principalTable: "AspNetRoles",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUserClaims",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_AspNetUserClaims_AspNetUsers_UserId",
            //            column: x => x.UserId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUserLogins",
            //    columns: table => new
            //    {
            //        LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
            //        table.ForeignKey(
            //            name: "FK_AspNetUserLogins_AspNetUsers_UserId",
            //            column: x => x.UserId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUserRoles",
            //    columns: table => new
            //    {
            //        UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
            //        table.ForeignKey(
            //            name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
            //            column: x => x.RoleId,
            //            principalTable: "AspNetRoles",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_AspNetUserRoles_AspNetUsers_UserId",
            //            column: x => x.UserId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUserTokens",
            //    columns: table => new
            //    {
            //        UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
            //        table.ForeignKey(
            //            name: "FK_AspNetUserTokens_AspNetUsers_UserId",
            //            column: x => x.UserId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Segments",
            //    columns: table => new
            //    {
            //        id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        name = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        description = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        category_id = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Segments", x => x.id);
            //        table.ForeignKey(
            //            name: "FK_Segments_Categories_category_id",
            //            column: x => x.category_id,
            //            principalTable: "Categories",
            //            principalColumn: "id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            migrationBuilder.CreateTable(
                name: "SupportResponses",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    response = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    supportquestion_id = table.Column<int>(type: "int", nullable: false),
                    created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    admin_name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupportResponses", x => x.id);
                    table.ForeignKey(
                        name: "FK_SupportResponses_SupportQuestions_supportquestion_id",
                        column: x => x.supportquestion_id,
                        principalTable: "SupportQuestions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            //migrationBuilder.CreateTable(
            //    name: "SubCategories",
            //    columns: table => new
            //    {
            //        id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        name = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        description = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        segment_id = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_SubCategories", x => x.id);
            //        table.ForeignKey(
            //            name: "FK_SubCategories_Segments_segment_id",
            //            column: x => x.segment_id,
            //            principalTable: "Segments",
            //            principalColumn: "id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Questions",
            //    columns: table => new
            //    {
            //        id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        question = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        subcategory_id = table.Column<int>(type: "int", nullable: false),
            //        explanation = table.Column<string>(type: "nvarchar(max)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Questions", x => x.id);
            //        table.ForeignKey(
            //            name: "FK_Questions_SubCategories_subcategory_id",
            //            column: x => x.subcategory_id,
            //            principalTable: "SubCategories",
            //            principalColumn: "id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Answers",
            //    columns: table => new
            //    {
            //        id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        answer = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        is_correct = table.Column<bool>(type: "bit", nullable: false),
            //        question_id = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Answers", x => x.id);
            //        table.ForeignKey(
            //            name: "FK_Answers_Questions_question_id",
            //            column: x => x.question_id,
            //            principalTable: "Questions",
            //            principalColumn: "id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "UserAnswers",
            //    columns: table => new
            //    {
            //        user_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        answer_id = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_UserAnswers", x => new { x.user_id, x.answer_id });
            //        table.ForeignKey(
            //            name: "FK_UserAnswers_Answers_answer_id",
            //            column: x => x.answer_id,
            //            principalTable: "Answers",
            //            principalColumn: "id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_UserAnswers_AspNetUsers_user_id",
            //            column: x => x.user_id,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.InsertData(
            //    table: "Categories",
            //    columns: new[] { "id", "description", "name" },
            //    values: new object[,]
            //    {
            //        { 1, null, "Att skydda sig mot bedrägerier" },
            //        { 2, null, "Cybersäkerhet för företag" },
            //        { 3, null, "Cyberspionage" }
            //    });

            //migrationBuilder.InsertData(
            //    table: "Segments",
            //    columns: new[] { "id", "category_id", "description", "name" },
            //    values: new object[,]
            //    {
            //        { 1, 1, null, "Del 1 - Att skydda sig mot bedrägerier" },
            //        { 2, 1, null, "Del 2 - Att skydda sig mot bedrägerier" },
            //        { 3, 1, null, "Del 3 - Att skydda sig mot bedrägerier" },
            //        { 4, 2, null, "Del 1 - Cybersäkerhet för företag" },
            //        { 5, 2, null, "Del 2 - Cybersäkerhet för företag" },
            //        { 6, 2, null, "Del 3 - Cybersäkerhet för företag" },
            //        { 7, 2, null, "Del 4 - Cybersäkerhet för företag" },
            //        { 8, 3, null, "Del 1 - Cyberspionage" },
            //        { 9, 3, null, "Del 2 - Cyberspionage" },
            //        { 10, 3, null, "Del 3 - Cyberspionage" }
            //    });

            //migrationBuilder.InsertData(
            //    table: "SubCategories",
            //    columns: new[] { "id", "description", "name", "segment_id" },
            //    values: new object[,]
            //    {
            //        { 1, null, "Kreditkortsbedrägeri", 1 },
            //        { 2, null, "Romansbedrägeri", 1 },
            //        { 3, null, "Investeringsbedrägeri", 1 },
            //        { 4, null, "Telefonbedrägeri", 1 },
            //        { 5, null, "Bedrägerier i hemmet", 2 },
            //        { 6, null, "Identitetsstöld", 2 },
            //        { 7, null, "Nätfiske och bluffmejl", 2 },
            //        { 8, null, "Investeringsbedrägeri på nätet", 2 },
            //        { 9, null, "Abonnemangsfällor och falska fakturor", 3 },
            //        { 10, null, "Ransomware", 3 },
            //        { 11, null, "Statistik och förhållningssätt", 3 },
            //        { 12, null, "Digital säkerhet på företag", 4 },
            //        { 13, null, "Risker och beredskap", 4 },
            //        { 14, null, "Aktörer inom cyberbrott", 4 },
            //        { 15, null, "Ökad digital närvaro och distansarbete", 4 },
            //        { 16, null, "Cyberangrepp mot känsliga sektorer", 4 },
            //        { 17, null, "Cyberrånet mot Mersk", 4 },
            //        { 18, null, "Social engineering", 5 },
            //        { 19, null, "Nätfiske och skräppost", 5 },
            //        { 20, null, "Vishing", 5 },
            //        { 21, null, "Varning för vishing", 5 },
            //        { 22, null, "Identifiera VD-mejl", 5 },
            //        { 23, null, "Öneangrepp och presentkortsbluffar", 5 },
            //        { 24, null, "Virus, maskar och trojaner", 6 },
            //        { 25, null, "Så kan det gå till", 6 },
            //        { 26, null, "Nätverksintrång", 6 },
            //        { 27, null, "Dataintrång", 6 },
            //        { 28, null, "Hackad!", 6 },
            //        { 29, null, "Vägarna in", 6 },
            //        { 30, null, "Utpressningsvirus", 7 },
            //        { 31, null, "Attacker mot servrar", 7 },
            //        { 32, null, "Cyberangrepp i Norden", 7 },
            //        { 33, null, "It-brottslingarnas verktyg", 7 },
            //        { 34, null, "Mirai, Wannacry och fallet Düsseldorf", 7 },
            //        { 35, null, "De sårbara molnen", 7 },
            //        { 36, null, "Allmänt om cyberspionage", 8 },
            //        { 37, null, "Metoder för cyberspionage", 8 },
            //        { 38, null, "Säkerhetsskyddslagen", 8 },
            //        { 39, null, "Cyberspionagets aktörer", 8 },
            //        { 40, null, "Värvningsförsök", 9 },
            //        { 41, null, "Affärsspionage", 9 },
            //        { 42, null, "Påverkanskampanjer", 9 },
            //        { 43, null, "Svensk underrättelsetjänst och cyberförsvar", 10 },
            //        { 44, null, "Signalspaning, informationssäkerhet och 5G", 10 },
            //        { 45, null, "Samverkan mot cyberspionage", 10 }
            //    });

            //migrationBuilder.InsertData(
            //    table: "Questions",
            //    columns: new[] { "id", "explanation", "question", "subcategory_id" },
            //    values: new object[,]
            //    {
            //        { 1, "Banker och andra finansiella institutioner begär aldrig känslig information såsom kontonummer eller lösenord via telefon. Detta är ett klassiskt tecken på telefonbedrägeri.", "Du får ett oväntat telefonsamtal från någon som påstår sig vara från din bank. Personen ber dig bekräfta ditt kontonummer och lösenord för att \"säkerställa din kontos säkerhet\" efter en påstådd säkerhetsincident. Hur bör du tolka denna situation?", 1 },
            //        { 2, "Begäran om pengar, särskilt under omständigheter där två personer aldrig har träffats fysiskt, är ett vanligt tecken på romansbedrägeri.", "Efter flera månader av daglig kommunikation med någon du träffade på en datingsida, börjar personen berätta om en plötslig finansiell kris och ber om din hjälp genom att överföra pengar. Vad indikerar detta mest sannolikt?", 2 },
            //        { 3, "Erbjudanden som lovar hög avkastning med liten eller ingen risk, särskilt via oönskade e-postmeddelanden, är ofta tecken på investeringsbedrägerier.", "Du får ett e-postmeddelande/samtal om ett exklusivt erbjudande att investera i ett startup-företag som påstås ha en revolutionerande ny teknologi, med garantier om exceptionellt hög avkastning på mycket kort tid. Hur bör du förhålla dig till erbjudandet?", 3 },
            //        { 4, "Oidentifierade transaktioner på ditt kreditkortsutdrag är en stark indikation på att ditt kortnummer har komprometterats och använts för obehöriga köp, vilket är typiskt för kreditkortsbedrägeri.", "Efter en online-shoppingrunda märker du oidentifierade transaktioner på ditt kreditkortsutdrag från företag du aldrig handlat från. Vad indikerar detta mest sannolikt?", 4 },
            //        { 5, "Utbildning i digital säkerhet är avgörande för att hjälpa anställda att känna igen och undvika säkerhetshot som phishing, vilket är en vanlig attackvektor.", "Inom företaget märker man att konfidentiella dokument regelbundet läcker ut till konkurrenter. Efter en intern granskning upptäcks det att en anställd omedvetet har installerat skadlig programvara genom att klicka på en länk i ett phishing-e-postmeddelande. Vilken åtgärd bör prioriteras för att förhindra framtida incidenter?", 5 },
            //        { 6, "Transparent kommunikation och rådgivning om tillfälliga åtgärder är avgörande för att skydda användarna medan en permanent lösning utvecklas.", "Inom företaget upptäckts det en sårbarhet i vår programvara som kunde möjliggöra obehörig åtkomst till användardata. Företaget har inte omedelbart en lösning. Vilken är den mest lämpliga första åtgärden?", 6 },
            //        { 7, "DDoS-attacker kräver ofta betydande resurser och koordinering, vilket är karakteristiskt för organiserade cyberbrottsliga grupper.", "Vårt företag blir måltavla för en DDoS-attack som överväldigar våra servrar och gör våra tjänster otillgängliga för kunder. Vilken typ av aktör är mest sannolikt ansvarig för denna typ av attack?", 7 },
            //        { 8, "Stärkt autentisering är kritisk för att säkra fjärråtkomst och skydda mot obehörig åtkomst i en distribuerad arbetsmiljö.", "Med övergången till distansarbete upptäcker vårt företag en ökning av säkerhetsincidenter, inklusive obehörig åtkomst till företagsdata. Vilken åtgärd bör företaget vidta för att adressera denna nya riskmiljö?", 8 },
            //        { 9, "Ransomware-angrepp involverar kryptering av offerdata och kräver lösen för dekryptering, vilket är särskilt skadligt för kritiska sektorer som hälsovård.", "Hälsovårdsmyndigheten utsätts för ett cyberangrepp som krypterar patientdata och kräver lösen för att återställa åtkomsten. Vilken typ av angrepp har de sannolikt blivit utsatta för?", 9 },
            //        { 10, "Maersk utsattes för NotPetya ransomware-angreppet, som ledde till omfattande störningar och förluster genom att kryptera företagets globala system. \r\n\r\nMaersk rapporterade att företaget led ekonomiska förluster på grund av NotPetya ransomware-angreppet som uppskattades till cirka 300 miljoner USD. Denna siffra reflekterar de omfattande kostnaderna för störningar i deras globala verksamheter, återställande av system och data, samt förlust av affärer under tiden systemen var nere. NotPetya-angreppet anses vara ett av de mest kostsamma cyberangreppen mot ett enskilt företag och tjänar som en kraftfull påminnelse om de potentiella konsekvenserna av cyberhot. ", "Det globala fraktbolaget Maersk blev offer för ett omfattande cyberangrepp som avsevärt störde deras verksamhet världen över. Vilken typ av malware var primärt ansvarig för denna incident?", 10 },
            //        { 11, "Cyberspionage avser aktiviteter där aktörer, ofta statliga, engagerar sig i övervakning och datainsamling genom cybermedel för att erhålla hemlig information utan målets medgivande, typiskt för politiska, militära eller ekonomiska fördelar.", "Regeringen upptäcker att känslig politisk kommunikation har läckt och misstänker elektronisk övervakning. Vilket fenomen beskriver bäst denna situation?", 36 },
            //        { 12, "Riktade cyberattacker som utnyttjar noll-dagars Zero-day sårbarheter är en avancerad metod för cyberspionage där angriparen specifikt riktar in sig på ett mål för att komma åt känslig information eller data genom att utnyttja tidigare okända sårbarheter i programvara.", "Regeringen blir varse om en sofistikerad skadeprogramskampanj som utnyttjar Zero-day sårbarheter för att infiltrera deras nätverk och stjäla oerhört viktig data. Vilken metod för cyberspionage används sannolikt här?", 37 },
            //        { 13, "Säkerhetsskyddslagen är en svensk lagstiftning som syftar till att skydda nationellt känslig information från spioneri, sabotage, terroristbrott och andra säkerhetshot. Lagen ställer krav på säkerhetsskyddsåtgärder för verksamheter av betydelse för Sveriges säkerhet.", "Regeringen i Sverige ökar sitt interna säkerhetsprotokoll för att skydda sig mot utländska underrättelsetjänsters infiltration. Vilken lagstiftning ger ramverket för detta skydd?", 38 },
            //        { 14, "Statssponsrade hackers är aktörer som arbetar på uppdrag av eller med stöd från en regering för att genomföra cyberspionage, ofta riktat mot utländska intressen, organisationer eller regeringar för att få strategiska fördelar.", "Lunds universitet upptäcker att forskningsdata om ny teknologi har stulits. Undersökningar tyder på en välorganiserad grupp med kopplingar till en utländsk stat. Vilken typ av aktör ligger sannolikt bakom detta?", 39 },
            //        { 15, "Klicka aldrig på länkar som uppges komma från banker via e-post.", "Du får ett e-postmeddelande som ser ut att komma från din bank. Det ber dig klicka på en länk och logga in på ditt konto för att uppdatera din information. Vad bör du göra?", 1 },
            //        { 16, "Skimming är en metod där bedragare placerar en enhet på en betalterminal för att stjäla kortinformation. Genom att inspektera terminalen kan du upptäcka ovanliga tillbehör eller lösa delar som kan indikera att skimming-enheten är närvarande.", "Du använder din kreditkort på en betalterminal i en butik. Någon har placerat en skimming-enhet på terminalen för att stjäla kortinformation. Vad bör du vara vaksam på?", 1 },
            //        { 17, "Om du ser en större transaktion på ditt kreditkort som du inte har gjort, bör du agera snabbt. Att kontakta din kreditkortsutgivare direkt hjälper till att förhindra ytterligare skada och identifiera eventuellt bedrägeri.", "Du får ett meddelande om en större transaktion på ditt kreditkort som du inte har gjort. Vad bör du göra?", 1 },
            //        { 18, "Att öppna bifogade fakturor från okända avsändare kan vara farligt. Radera e-postmeddelandet för att undvika att utsätta dig för skadlig kod eller bedrägeriförsök.", "Du får en e-post med en bifogad faktura från ett företag du inte känner till. Vad bör du göra?", 1 },
            //        { 19, "Att ta någon annans kreditkort och använda det är olagligt och oetiskt. Lämna kortet där du hittade det eller ge det till personalen för att returnera det till ägaren.", "Du ser någon slarvigt lämna sitt kreditkort på ett cafébord. Vad bör du göra?", 1 },
            //        { 20, "Om du byter kreditkort är det viktigt att uppdatera betalningsuppgifterna för alla automatiska betalningar. Annars kan du missa betalningar och få påminnelser eller avgifter.", "Du har flera automatiska betalningar kopplade till ditt kreditkort. Vad bör du göra om du byter kreditkort?", 1 },
            //        { 21, "Ett romansbedrägeri är när en bedragare inleder en romantisk relation med någon i syfte att lura hen på pengar. Det sker oftast på internet, till exempel på sociala medier samt dejtingsidor och dejtingappar.", "Vad är ett romansbedrägeri?", 2 },
            //        { 22, "Uppmärksamma typiska drag för en romansbedragare, såsom statusyrken, konstlade formuleringar eller slarvigt språkbruk.", "Vilka typiska drag bör du vara uppmärksam på hos en romansbedragare?", 2 },
            //        { 23, "Romansbedrägeri är brottsligt när någon inleder en kärleksrelation med dig för att lura dig på pengar. Åtal kan väckas om det finns bevis för detta bedrägeri.", "Vad krävs för att någon ska åtalas för romansbedrägeri?", 2 },
            //        { 24, "Om du blivit lurad av kärleken du träffat på nätet bör du lista ut vad du ska göra när du blivit utsatt och vart du ska vända dig för hjälp.", "Vad bör du göra om du misstänker att du blivit utsatt för romansbedrägeri på nätet?", 2 },
            //        { 25, "Det finns flera saker du kan göra för att skydda dig mot romansbedrägeri. Följ tips och råd om hur du kan undvika att bli lurad.", "Hur skyddar du dig mot romansbedrägeri?", 2 },
            //        { 26, "Ett investeringsbedrägeri innebär att någon lurar andra att köpa värdepapper som egentligen inte har något värde eller som är väldigt svåra att värdera. Det kan handla om investeringar i fonder, aktier, kryptovalutor samt metaller och ädelstenar.", "Vad är ett investeringsbedrägeri?", 3 },
            //        { 27, "Var uppmärksam på varningssignaler som hög avkastning utan risk, bristande dokumentation, och orealistiska löften. Bedragare lockar ofta med snabba vinster och undviker att ge tydlig information om investeringen.", "Vilka varningssignaler bör du vara uppmärksam på vid investeringserbjudanden?", 3 },
            //        { 28, "För att skydda dig mot investeringsbedrägeri bör du vara skeptisk mot orealistiska löften, göra grundlig research om investeringen, och undvika att agera impulsivt. Kontrollera även att företaget har tillstånd från Finansinspektionen.", "Hur kan du skydda dig mot investeringsbedrägeri?", 3 },
            //        { 29, "Om du misstänker att du blivit utsatt för investeringsbedrägeri bör du omedelbart kontakta Polisen och Finansinspektionen. Samla all relevant information och undvik att göra fler transaktioner med bedragaren.", "Vad bör du göra om du misstänker att du blivit utsatt för investeringsbedrägeri?", 3 }
            //    });

            //migrationBuilder.InsertData(
            //    table: "Answers",
            //    columns: new[] { "id", "answer", "is_correct", "question_id" },
            //    values: new object[,]
            //    {
            //        { 1, "Ett legitimt försök från banken att skydda ditt konto", false, 1 },
            //        { 2, "En informationsinsamling för en marknadsundersökning", false, 1 },
            //        { 3, "Ett potentiellt telefonbedrägeri", true, 1 },
            //        { 4, "En legitim begäran om hjälp från en person i nöd", false, 2 },
            //        { 5, "Ett romansbedrägeri", true, 2 },
            //        { 6, "En tillfällig ekonomisk svårighet", false, 2 },
            //        { 7, "Genomföra omedelbar investering för att inte missa möjligheten", false, 3 },
            //        { 8, "Investeringsbedrägeri", true, 3 },
            //        { 9, "Begära mer information för att utföra en noggrann \"due diligence\"", false, 3 },
            //        { 10, "Ett misstag av kreditkortsföretaget", false, 4 },
            //        { 11, "Kreditkortsbedrägeri", true, 4 },
            //        { 12, "Obehöriga köp av en familjemedlem", false, 4 },
            //        { 13, "Utbildning i digital säkerhet för alla anställda", true, 5 },
            //        { 14, "Installera en starkare brandvägg", false, 5 },
            //        { 15, "Byta ut all IT-utrustning", false, 5 },
            //        { 16, "Informera alla användare om sårbarheten och rekommendera temporära skyddsåtgärder", true, 6 },
            //        { 17, "Ignorera problemet tills en patch kan utvecklas", false, 6 },
            //        { 18, "Stänga ner tjänsten tillfälligt", false, 6 },
            //        { 19, "En enskild hackare med ett personligt vendetta", false, 7 },
            //        { 20, "En konkurrerande företagsentitet", false, 7 },
            //        { 21, "Organiserade cyberbrottsliga grupper", true, 7 },
            //        { 22, "Återgå till kontorsarbete", false, 8 },
            //        { 23, "Införa striktare lösenordspolicyer och tvåfaktorsautentisering för fjärråtkomst", true, 8 },
            //        { 24, "Förbjuda användning av personliga enheter för arbete", false, 8 },
            //        { 25, "Phishing", false, 9 },
            //        { 26, "Ransomware", true, 9 },
            //        { 27, "Spyware", false, 9 },
            //        { 28, "Spyware", false, 10 },
            //        { 29, "Ransomware", true, 10 },
            //        { 30, "Adware", false, 10 },
            //        { 31, "Cyberkriminalitet", false, 11 },
            //        { 32, "Cyberspionage", true, 11 },
            //        { 33, "Cyberterrorism", false, 11 },
            //        { 34, "Social ingenjörskonst", false, 12 },
            //        { 35, "Massövervakning", false, 12 },
            //        { 36, "Riktade cyberattacker", true, 12 },
            //        { 37, "GDPR", false, 13 },
            //        { 38, "Säkerhetsskyddslagen", true, 13 },
            //        { 39, "IT-säkerhetslagen", false, 13 },
            //        { 40, "Oberoende hackare", false, 14 },
            //        { 41, "Aktivistgrupper", false, 14 },
            //        { 42, "Statssponsrade hackers", true, 14 },
            //        { 43, "Klicka på länken och logga in för att uppdatera din information.", false, 15 },
            //        { 44, "Ignorera e-postmeddelandet och radera det omedelbart.", true, 15 },
            //        { 45, "Skicka ditt kontonummer och lösenord som begärt.", false, 15 },
            //        { 46, "Kontrollera att PIN-koden är synlig för andra.", false, 16 },
            //        { 47, "Inspektera terminalen för ovanliga tillbehör eller lösa delar.", true, 16 },
            //        { 48, "Använd kortet utan att oroa dig.", false, 16 },
            //        { 49, "Ignorera det och anta att det är en felaktighet.", false, 17 },
            //        { 50, "Kontakta din kreditkortsutgivare omedelbart för att rapportera misstänkt bedrägeri.", true, 17 },
            //        { 51, "Vänta och se om det löser sig av sig självt.", false, 17 },
            //        { 52, "Öppna fakturan och betala den om den verkar legitim.", false, 18 },
            //        { 53, "Kontakta din kreditkortsutgivare omedelbart för att rapportera misstänkt bedrägeri.", true, 18 },
            //        { 54, "Vänta och se om det löser sig av sig självt.", false, 18 },
            //        { 55, "Ta kortet och använd det för egna inköp.", false, 19 },
            //        { 56, "Ge kortet till personalen på caféet.", true, 19 },
            //        { 57, "Klipp sönder kortet.", false, 19 },
            //        { 58, "Glöm bort det och låt betalningarna fortsätta.", false, 20 },
            //        { 59, "Uppdatera betalningsuppgifterna hos varje tjänsteleverantör.", true, 20 },
            //        { 60, "Avbryt alla automatiska betalningar.", false, 20 },
            //        { 61, "Ett romansbedrägeri är när en bedragare inleder en romantisk relation med någon i syfte att lura hen på pengar. Det sker oftast på internet, till exempel på sociala medier samt dejtingsidor och dejtingappar.", true, 21 },
            //        { 62, "Det är när två personer fejkar en romantisk relation för att lura andra.", false, 21 },
            //        { 63, "Det handlar om att skapa en falsk identitet för att vinna någon annans förtroende.", false, 21 },
            //        { 64, "Statusyrken, konstlade formuleringar eller slarvigt språkbruk.", true, 22 },
            //        { 65, "Generös gåva av blommor eller choklad.", false, 22 },
            //        { 66, "Överdriven romantik och kärleksgestikulering.", false, 22 },
            //        { 67, "Bevis för att personen inlett en kärleksrelation för att lura på pengar.", true, 23 },
            //        { 68, "Att personen har skickat kärleksbrev eller romantiska meddelanden.", false, 23 },
            //        { 69, "Att personen har använt falsk identitet på sociala medier.", false, 23 },
            //        { 70, "Fortsätta kommunicera för att samla mer bevis.", false, 24 },
            //        { 71, "Avsluta all kontakt med personen och blockera dem.", true, 24 },
            //        { 72, "Dela personlig information för att testa deras äkthet.", false, 24 },
            //        { 73, "Öppet dela dina känslor och livshistoria med okända personer.", false, 25 },
            //        { 74, "Dela personlig information och bankuppgifter direkt.", false, 25 },
            //        { 75, "Var skeptisk mot snabba kärleksförklaringar och ekonomiska problem.", true, 25 },
            //        { 76, "Ett investeringsbedrägeri kan handla om investeringar i fonder, aktier, kryptovalutor samt metaller och ädelstenar.", false, 26 },
            //        { 77, "Det är när någon lurar andra att köpa värdepapper som egentligen inte har något värde eller är svåra att värdera.", true, 26 },
            //        { 78, "Investeringar som garanterar snabba vinster utan risk.", false, 26 },
            //        { 79, "Hög avkastning utan risk, bristande dokumentation, orealistiska löften.", true, 27 },
            //        { 80, "Tydlig information om investeringen, seriösa företag.", false, 27 },
            //        { 81, "Snabba vinster och impulsivt agerande.", false, 27 },
            //        { 82, "Var skeptisk mot orealistiska löften, gör grundlig research, undvik impulsiva beslut.", true, 28 },
            //        { 83, "Dela personlig information och bankuppgifter direkt.", false, 28 },
            //        { 84, "Lita på alla investeringsmöjligheter utan att kontrollera företaget.", false, 28 },
            //        { 85, "Dela personlig information för att testa deras äkthet.", false, 29 },
            //        { 86, "Fortsätta kommunicera för att samla mer bevis.", false, 29 },
            //        { 87, "Avsluta all kontakt med personen och blockera dem.", true, 29 }
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_Answers_question_id",
            //    table: "Answers",
            //    column: "question_id");

            //migrationBuilder.CreateIndex(
            //    name: "IX_AspNetRoleClaims_RoleId",
            //    table: "AspNetRoleClaims",
            //    column: "RoleId");

            //migrationBuilder.CreateIndex(
            //    name: "RoleNameIndex",
            //    table: "AspNetRoles",
            //    column: "NormalizedName",
            //    unique: true,
            //    filter: "[NormalizedName] IS NOT NULL");

            //migrationBuilder.CreateIndex(
            //    name: "IX_AspNetUserClaims_UserId",
            //    table: "AspNetUserClaims",
            //    column: "UserId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_AspNetUserLogins_UserId",
            //    table: "AspNetUserLogins",
            //    column: "UserId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_AspNetUserRoles_RoleId",
            //    table: "AspNetUserRoles",
            //    column: "RoleId");

            //migrationBuilder.CreateIndex(
            //    name: "EmailIndex",
            //    table: "AspNetUsers",
            //    column: "NormalizedEmail");

            //migrationBuilder.CreateIndex(
            //    name: "UserNameIndex",
            //    table: "AspNetUsers",
            //    column: "NormalizedUserName",
            //    unique: true,
            //    filter: "[NormalizedUserName] IS NOT NULL");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Questions_subcategory_id",
            //    table: "Questions",
            //    column: "subcategory_id");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Segments_category_id",
            //    table: "Segments",
            //    column: "category_id");

            //migrationBuilder.CreateIndex(
            //    name: "IX_SubCategories_segment_id",
            //    table: "SubCategories",
            //    column: "segment_id");

            migrationBuilder.CreateIndex(
                name: "IX_SupportResponses_supportquestion_id",
                table: "SupportResponses",
                column: "supportquestion_id");

            //migrationBuilder.CreateIndex(
            //    name: "IX_UserAnswers_answer_id",
            //    table: "UserAnswers",
            //    column: "answer_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "AspNetRoleClaims");

            //migrationBuilder.DropTable(
            //    name: "AspNetUserClaims");

            //migrationBuilder.DropTable(
            //    name: "AspNetUserLogins");

            //migrationBuilder.DropTable(
            //    name: "AspNetUserRoles");

            //migrationBuilder.DropTable(
            //    name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "SupportResponses");

            //migrationBuilder.DropTable(
            //    name: "UserAnswers");

            //migrationBuilder.DropTable(
            //    name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "SupportQuestions");

            //migrationBuilder.DropTable(
            //    name: "Answers");

            //migrationBuilder.DropTable(
            //    name: "AspNetUsers");

            //migrationBuilder.DropTable(
            //    name: "Questions");

            //migrationBuilder.DropTable(
            //    name: "SubCategories");

            //migrationBuilder.DropTable(
            //    name: "Segments");

            //migrationBuilder.DropTable(
            //    name: "Categories");
        }
    }
}
