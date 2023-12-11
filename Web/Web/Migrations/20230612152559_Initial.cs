using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FavoriteFoods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FoodId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Creator = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteFoods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FoodMaterials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FoodId = table.Column<int>(type: "int", nullable: false),
                    MaterialId = table.Column<int>(type: "int", nullable: false),
                    MaterialCount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Creator = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodMaterials", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Foods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FoodName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FoodImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FoodCountForPeople = table.Column<int>(type: "int", nullable: false),
                    FoodCountForPeopleText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FoodPreparingTime = table.Column<int>(type: "int", nullable: false),
                    FoodPreparingTimeText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FoodCookingTime = table.Column<int>(type: "int", nullable: false),
                    FoodCookingTimeText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FoodRecipe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Creator = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Materials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaterialName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaterialImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Creator = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfileImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ForgotPassword = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Creator = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "FoodMaterials",
                columns: new[] { "Id", "CreateDate", "Creator", "FoodId", "MaterialCount", "MaterialId", "UpdateDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6643), 1, 1, "3", 20, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6643) },
                    { 2, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6646), 1, 1, "2", 21, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6646) },
                    { 3, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6647), 1, 1, "1", 2, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6648) },
                    { 4, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6648), 1, 1, "1", 22, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6649) },
                    { 5, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6649), 1, 1, "2", 14, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6649) },
                    { 6, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6650), 1, 1, "1", 24, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6650) },
                    { 7, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6651), 1, 1, "2", 25, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6651) },
                    { 8, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6653), 1, 1, "8", 26, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6653) },
                    { 9, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6654), 1, 2, "8", 15, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6654) },
                    { 10, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6655), 1, 2, "1", 2, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6655) },
                    { 11, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6656), 1, 2, "4", 14, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6656) },
                    { 12, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6656), 1, 2, "3", 16, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6657) },
                    { 13, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6657), 1, 2, "1", 18, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6658) },
                    { 14, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6658), 1, 2, "3", 13, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6659) },
                    { 15, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6659), 1, 3, "1/2paket", 28, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6660) },
                    { 16, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6660), 1, 3, "1 tatlı kaşığı", 21, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6661) },
                    { 17, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6661), 1, 3, "1 paket", 19, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6662) },
                    { 18, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6662), 1, 3, "1/2 çay kaşığı", 6, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6662) },
                    { 19, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6663), 1, 3, "1 çay kaşığı", 5, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6663) },
                    { 20, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6664), 1, 4, "2 su bardağı", 30, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6664) },
                    { 21, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6665), 1, 4, "1 adet", 2, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6665) },
                    { 22, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6666), 1, 4, "3 su bardağı", 11, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6666) },
                    { 23, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6667), 1, 4, "2 yemek kaşığı", 21, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6667) },
                    { 24, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6667), 1, 4, "1 yemek kaşığı", 29, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6668) },
                    { 25, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6668), 1, 4, "1 çay kaşığı", 12, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6669) },
                    { 26, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6669), 1, 4, "1 çay kaşığı", 6, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6670) },
                    { 27, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6670), 1, 4, "1 çay kaşığı", 5, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6670) },
                    { 28, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6671), 1, 5, "2 su bardağı", 3, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6671) },
                    { 29, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6672), 1, 5, "2 yemek kaşığı", 31, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6672) },
                    { 30, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6673), 1, 5, "2,5 su bardağı kaynar ", 27, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6673) },
                    { 31, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6674), 1, 5, "2 yemek kaşığı ", 21, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6674) },
                    { 32, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6675), 1, 5, "1 yemek kaşığı ", 13, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6675) },
                    { 33, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6676), 1, 5, "1 tatlı kaşığı ", 5, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6676) },
                    { 34, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6676), 1, 5, "3 damla ", 17, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6677) },
                    { 35, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6677), 1, 5, "1/2 çay kaşığı ", 32, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6678) },
                    { 36, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6678), 1, 6, "9 adet büyük boy ", 33, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6679) },
                    { 37, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6679), 1, 6, "5 diş ", 14, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6680) },
                    { 38, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6680), 1, 6, "5 yemek kaşığı ", 20, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6681) },
                    { 39, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6681), 1, 6, "1 adet orta boy ", 2, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6681) },
                    { 40, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6683), 1, 6, "5 su bardağı sıcak  ", 27, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6683) },
                    { 41, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6683), 1, 6, "1 yemek kaşığı  ", 24, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6684) },
                    { 42, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6684), 1, 6, "1 çay kaşığı  ", 5, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6685) }
                });

            migrationBuilder.InsertData(
                table: "FoodMaterials",
                columns: new[] { "Id", "CreateDate", "Creator", "FoodId", "MaterialCount", "MaterialId", "UpdateDate" },
                values: new object[] { 43, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6685), 1, 6, "1 çay kaşığı  ", 6, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6686) });

            migrationBuilder.InsertData(
                table: "Foods",
                columns: new[] { "Id", "CreateDate", "Creator", "FoodCookingTime", "FoodCookingTimeText", "FoodCountForPeople", "FoodCountForPeopleText", "FoodImage", "FoodName", "FoodPreparingTime", "FoodPreparingTimeText", "FoodRecipe", "UpdateDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6623), 1, 30, "Dakika", 4, "Kişilik", "/images/tavuklu-bulgur-pilavi-yemekcom-1.jpg", "Fırında Tavuklu Bulgur Kapama", 15, "Dakika", "İlk olarak soğan, havuç, biber ve kabağı ufak küpler halinde doğrayıp ayrı ayrı kenarda bekletin.\r\n    Geniş bir tava ya da tencereye zeytinyağını, tereyağını koyup soğanları tencereye ekleyin ve orta ateşte hafif tuzlayarak yumuşayana kadar pişirin.\r\n    Tavaya sırasıyla havuçları, biberleri, bir diş doğranmış sarımsağı ve son olarak kabakları ekleyip soteleyin.\r\n    Tavaya tuzu ve baharatların ardından salçayı da ekleyin, 1 dakika kadar kavurduktan sonra bulgurları da ekleyip tüm malzeme bütünleşene kadar 3-4 dakika daha kavurun.\r\n    Karışımı fırın tepsisine aktarın, haşlanmış tavukları üzerine dizin, sıcak suyu da ekleyip üstünü folyoyla kaplayın.\r\n    Yemeği 200 derecelik sıcak fırında 20 dakika pişirdikten sonra folyoyu alın ve üzeri kızarana kadar 10 dakika daha pişirin. Servis edene kadar kapalı fırında demlenmeye bırakabilirsiniz. Afiyet olsun.", new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6624) },
                    { 2, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6626), 1, 20, "Dakika", 4, "Kişilik", "/images/kori-soslu-tavuk-yemekcom.jpg", "Köri Soslu Tavuk", 30, "Dakika", "Tavuk kalçalarını ufak lokmalık parçalar halinde kesin. Bir kasenin içinde tavukları, soğan rendesi, sarımsak, yoğurt, limon suyu, tuz, karabiber ve köri ile karıştırın. Kaseyi streçleyin ve buzdolabında 3 saat dinlendirin.\r\n    Geniş bir tavayı ısıtın ve tavukları önlü arkalı az yağda 3-4 dakika kızartın. Kızaran tavukların üstüne krema ve köriyi de ekleyip ateşin altını en kısık konuma getirin.\r\n\r\n    Sos koyulaşınca ocaktan alın ve yemeğin üstüne ince kıyılmış kişniş ya da maydanoz serperek servis edin. Afiyet olsun.", new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6627) },
                    { 3, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6628), 1, 15, "Dakika", 2, "Kişilik", "/images/kremali-spagetti-sunum-yemekcom.webp", "Kremalı Spagetti", 5, "Dakika", "Tencereye 2 litre kadar su ekleyin ve güzelce ısıtın. Üzerine spagettileri ekleyin. Haşlanana kadar 10-11 dakika civarı pişirin.\r\n\r\n    Kremayı ve tereyağını tencereye alın. Fokurdayana kadar güzelce pişirin.\r\n \r\n    Üzerine süzdüğünüz spagettileri ilave edin. Tuzunu ve karabiberini ekleyin.\r\n\r\n    Kıyılmış maydanoz ve cherry domatesle süsleyebilirsiniz. Afiyet olsun!\r\n ", new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6628) },
                    { 4, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6629), 1, 40, "Dakika", 4, "Kişilik", "/images/sutlu-kurufasulye-yeni-onecikan.jpg", "Sütlü Kuru Fasulye", 15, "Dakika", "Geceden ıslatmış olduğunuz fasulyelerin suyunu süzün ve tencereye alın. Süt ve suyu karıştırarak üzerini geçene kadar ekleyin ve kaynamaya bırakın.Biraz kaynadıktan sonra süzgeç yardımıyla süzün. Tencereye yağ ve küp küp doğranmış soğanları ekleyip kavurun. Soğanların rengi dönünce salça ve fasulyeleri ekleyerek kavurun. Hizasını geçene kadar su ekleyip baharatlarını ilave edin. Süt ile kaynatıldığı için pişme süresi yarı yarıya kısalıyor,kontrollü pişirmekte fayda var. Piştikten sonra biraz dinlendirin. Ardından servis edin. Afiyetler olsun!    ", new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6630) },
                    { 5, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6631), 1, 20, "Dakika", 4, "Kişilik", "/images/tel-sehriyeli-pirinc-pilavi-onecikan.jpg", "Tel Şehriyeli Pirinç Pilav", 10, "Dakika", "Pirincinizi iyice yıkadıktan sonra tuzlu sıcak suda yarım saat nişastasını atması için bekletin Şehriyeyi pilav tenceresine alarak tereyağı ve sıvı yağını ekleyip rengi dönene kadar kavurun. Pirinci ekleyin, bir miktar daha kavurun. Bu aşamada limon suyu ve şekeri ekleyip üzerine suyunu ekleyin. Tuzunu da ekleyip karıştırdıktan sonra kapağını kapatın, kısık ateşte pişmeye bırakın. Suyunu çeken pilavın üzerine bir bez kapatın ve kapağını kapatarak demlenmesi için bekleyin. Tel şehriyeli pirinç pilavı hazır, afiyetler olsun.", new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6631) },
                    { 6, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6632), 1, 30, "Dakika", 4, "Kişilik", "/images/kozlenmis-domates-corbasi-one-cikan.webp", "Közlenmiş Domates Çorbası ", 20, "Dakika", "Fırınınızı 180 derecede ısıtmaya başlayın.Domatesleri iyice yıkayın ve kabuklarını soymadan ortadan ikiye bölün.Fırın tepsinize yağlı kağıt serin ve ortadan ikiye kestiğiniz domatesleri dizin. Üzerine biraz zeytinyağı gezdirin. Önceden ısıtılmış fırında yaklaşık 30 dakika kadar pişirin. Sarımsakları domatesleri fırına attıktan 15 dakika sonra atın.Közlenen domates ve sarımsakları fırından alın. Kabuklarını soyun. Sarımsakları ezin. Soğanı minik küpler halinde doğrayın. Bir tencerenin içerisine alın. Üzerine zeytinyağı ve salçayı ilave edin.Soğanlar iyice kavrulana kadar pişirmeye devam edin. Pişince içerisine ezdiğiniz sarımsakları ekleyin. Birkaç kez daha çevirin. Ardından közlenmiş domatesleri ve sıcak suyu ekleyin. Domatesler iyice eriyene kadar pişirin. Orta ateşte domatesler iyice eriyene kadar pişirin. Tuz ve baharatlarını ilave edin. Kıvam almaya başladığında ocaktan alın ve karışımı blenderdan geçirin. Üzerini dilediğiniz gibi süsleyerek sıcak sıcak servis edin. Afiyet olsun.", new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6632) }
                });

            migrationBuilder.InsertData(
                table: "Materials",
                columns: new[] { "Id", "CreateDate", "Creator", "MaterialImage", "MaterialName", "UpdateDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6537), 1, "", "Dana Kıyma", new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6538) },
                    { 2, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6539), 1, "", "Soğan", new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6540) },
                    { 3, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6541), 1, "", "Pirinç", new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6541) },
                    { 4, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6541), 1, "", "Maydanoz", new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6542) },
                    { 5, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6542), 1, "", "Tuz", new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6543) },
                    { 6, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6543), 1, "", "Karabiber", new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6544) },
                    { 7, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6545), 1, "", "Pul biber", new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6545) },
                    { 8, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6546), 1, "", "Yumurta", new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6546) },
                    { 9, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6547), 1, "", "Un", new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6548) },
                    { 10, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6549), 1, "", "Galeta Unu", new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6549) },
                    { 11, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6550), 1, "", "Süt", new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6551) },
                    { 12, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6551), 1, "", "Kimyon", new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6551) },
                    { 13, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6552), 1, "", "Sıvı Yağ", new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6552) },
                    { 14, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6553), 1, "", "Sarımsak", new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6553) },
                    { 15, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6554), 1, "", "Tavuk Kalça", new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6555) },
                    { 16, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6555), 1, "", "Yoğurt", new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6556) },
                    { 17, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6556), 1, "", "Limon Suyu", new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6556) },
                    { 18, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6557), 1, "", "Köri", new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6557) },
                    { 19, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6558), 1, "", "Krema", new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6558) },
                    { 20, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6559), 1, "", "Zeytinyağı", new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6559) },
                    { 21, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6591), 1, "", "Tereyağı", new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6591) },
                    { 22, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6592), 1, "", "Havuç", new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6593) },
                    { 23, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6593), 1, "", "Kabak", new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6594) },
                    { 24, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6594), 1, "", "Domates Salçası", new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6595) },
                    { 25, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6595), 1, "", "Pilavlık Bulgur", new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6596) },
                    { 26, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6596), 1, "", "Tavuk Baget", new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6596) },
                    { 27, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6597), 1, "", "Su", new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6597) },
                    { 28, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6599), 1, "", "Spagetti", new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6599) },
                    { 29, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6600), 1, "", "Biber Salçası", new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6600) },
                    { 30, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6601), 1, "", "Kuru Fasulye", new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6601) },
                    { 31, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6601), 1, "", "Tel Şehriye", new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6602) },
                    { 32, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6602), 1, "", "Toz Şeker", new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6603) },
                    { 33, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6603), 1, "", "Domates", new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6604) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreateDate", "Creator", "Email", "Firstname", "ForgotPassword", "Lastname", "Password", "ProfileImage", "UpdateDate" },
                values: new object[] { 1, new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6445), 1, "admin@admin.com", "Admin", null, "", "123456", "chefimage.png", new DateTime(2023, 6, 12, 18, 25, 59, 506, DateTimeKind.Local).AddTicks(6453) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FavoriteFoods");

            migrationBuilder.DropTable(
                name: "FoodMaterials");

            migrationBuilder.DropTable(
                name: "Foods");

            migrationBuilder.DropTable(
                name: "Materials");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
