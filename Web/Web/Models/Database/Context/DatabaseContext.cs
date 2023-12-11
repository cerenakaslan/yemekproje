using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Data;
using System.Reflection.Emit;
using System;
using Microsoft.EntityFrameworkCore;

namespace Web.Models.Database.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { } 

        protected override void OnModelCreating(ModelBuilder mbuilder)
        {
            mbuilder.Entity<Users>().HasData(new Users[] {
                new Users{Id=1, Firstname="Admin", Lastname="", Email="admin@admin.com", Password="123456"}
            });

            mbuilder.Entity<Materials>().HasData(new Materials[]
            {
                new Materials{Id=1, MaterialName = "Dana Kıyma", MaterialImage = ""},
                new Materials{Id=2, MaterialName = "Soğan", MaterialImage = ""},
                new Materials{Id=3, MaterialName = "Pirinç", MaterialImage = ""},
                new Materials{Id=4, MaterialName = "Maydanoz", MaterialImage = ""},
                new Materials{Id=5, MaterialName = "Tuz", MaterialImage = ""},
                new Materials{Id=6, MaterialName = "Karabiber", MaterialImage = ""},
                new Materials{Id=7, MaterialName = "Pul biber", MaterialImage = ""},
                new Materials{Id=8, MaterialName = "Yumurta", MaterialImage = ""},
                new Materials{Id=9, MaterialName = "Un", MaterialImage = ""},
                new Materials{Id=10, MaterialName = "Galeta Unu", MaterialImage = ""},
                new Materials{Id=11, MaterialName = "Süt", MaterialImage = ""},
                new Materials{Id=12, MaterialName = "Kimyon", MaterialImage = ""},
                new Materials{Id=13, MaterialName = "Sıvı Yağ", MaterialImage = ""},
                new Materials{Id=14, MaterialName = "Sarımsak", MaterialImage = ""},
                new Materials{Id=15, MaterialName = "Tavuk Kalça", MaterialImage = ""},
                new Materials{Id=16, MaterialName = "Yoğurt", MaterialImage = ""},
                new Materials{Id=17, MaterialName = "Limon Suyu", MaterialImage = ""},
                new Materials{Id=18, MaterialName = "Köri", MaterialImage = ""},
                new Materials{Id=19, MaterialName = "Krema", MaterialImage = ""},
                new Materials{Id=20, MaterialName = "Zeytinyağı", MaterialImage = ""},
                new Materials{Id=21, MaterialName = "Tereyağı", MaterialImage = ""},
                new Materials{Id=22, MaterialName = "Havuç", MaterialImage = ""},
                new Materials{Id=23, MaterialName = "Kabak", MaterialImage = ""},
                new Materials{Id=24, MaterialName = "Domates Salçası", MaterialImage = ""},
                new Materials{Id=25, MaterialName = "Pilavlık Bulgur", MaterialImage = ""},
                new Materials{Id=26, MaterialName = "Tavuk Baget" , MaterialImage = ""},
                new Materials{Id=27, MaterialName = "Su", MaterialImage = ""},
                new Materials{Id=28, MaterialName = "Spagetti", MaterialImage = ""},
                new Materials{Id=29, MaterialName = "Biber Salçası", MaterialImage = ""},
                new Materials{Id=30, MaterialName = "Kuru Fasulye", MaterialImage = ""},
                new Materials{Id=31, MaterialName = "Tel Şehriye", MaterialImage = ""},
                new Materials{Id=32, MaterialName = "Toz Şeker", MaterialImage = ""},
                new Materials{Id=33, MaterialName = "Domates", MaterialImage = ""},
            });

            mbuilder.Entity<Foods>().HasData(new Foods[]
            {
                new Foods{Id=1, FoodName = "Fırında Tavuklu Bulgur Kapama", FoodImage = "/images/tavuklu-bulgur-pilavi-yemekcom-1.jpg", FoodCountForPeople = 4, FoodCountForPeopleText = "Kişilik", FoodPreparingTime = 15, FoodPreparingTimeText = "Dakika", FoodCookingTime = 30, FoodCookingTimeText = "Dakika", FoodRecipe = "İlk olarak soğan, havuç, biber ve kabağı ufak küpler halinde doğrayıp ayrı ayrı kenarda bekletin.\r\n    Geniş bir tava ya da tencereye zeytinyağını, tereyağını koyup soğanları tencereye ekleyin ve orta ateşte hafif tuzlayarak yumuşayana kadar pişirin.\r\n    Tavaya sırasıyla havuçları, biberleri, bir diş doğranmış sarımsağı ve son olarak kabakları ekleyip soteleyin.\r\n    Tavaya tuzu ve baharatların ardından salçayı da ekleyin, 1 dakika kadar kavurduktan sonra bulgurları da ekleyip tüm malzeme bütünleşene kadar 3-4 dakika daha kavurun.\r\n    Karışımı fırın tepsisine aktarın, haşlanmış tavukları üzerine dizin, sıcak suyu da ekleyip üstünü folyoyla kaplayın.\r\n    Yemeği 200 derecelik sıcak fırında 20 dakika pişirdikten sonra folyoyu alın ve üzeri kızarana kadar 10 dakika daha pişirin. Servis edene kadar kapalı fırında demlenmeye bırakabilirsiniz. Afiyet olsun." },
                new Foods{Id=2, FoodName = "Köri Soslu Tavuk", FoodImage = "/images/kori-soslu-tavuk-yemekcom.jpg", FoodCountForPeople = 4, FoodCountForPeopleText = "Kişilik", FoodPreparingTime = 30, FoodPreparingTimeText = "Dakika", FoodCookingTime = 20, FoodCookingTimeText = "Dakika", FoodRecipe = "Tavuk kalçalarını ufak lokmalık parçalar halinde kesin. Bir kasenin içinde tavukları, soğan rendesi, sarımsak, yoğurt, limon suyu, tuz, karabiber ve köri ile karıştırın. Kaseyi streçleyin ve buzdolabında 3 saat dinlendirin.\r\n    Geniş bir tavayı ısıtın ve tavukları önlü arkalı az yağda 3-4 dakika kızartın. Kızaran tavukların üstüne krema ve köriyi de ekleyip ateşin altını en kısık konuma getirin.\r\n\r\n    Sos koyulaşınca ocaktan alın ve yemeğin üstüne ince kıyılmış kişniş ya da maydanoz serperek servis edin. Afiyet olsun."},
                new Foods{Id=3, FoodName = "Kremalı Spagetti", FoodImage = "/images/kremali-spagetti-sunum-yemekcom.webp", FoodCountForPeople = 2, FoodCountForPeopleText = "Kişilik", FoodPreparingTime = 5, FoodPreparingTimeText = "Dakika", FoodCookingTime = 15, FoodCookingTimeText = "Dakika", FoodRecipe = "Tencereye 2 litre kadar su ekleyin ve güzelce ısıtın. Üzerine spagettileri ekleyin. Haşlanana kadar 10-11 dakika civarı pişirin.\r\n\r\n    Kremayı ve tereyağını tencereye alın. Fokurdayana kadar güzelce pişirin.\r\n \r\n    Üzerine süzdüğünüz spagettileri ilave edin. Tuzunu ve karabiberini ekleyin.\r\n\r\n    Kıyılmış maydanoz ve cherry domatesle süsleyebilirsiniz. Afiyet olsun!\r\n "},
                new Foods{Id=4, FoodName = "Sütlü Kuru Fasulye", FoodImage = "/images/sutlu-kurufasulye-yeni-onecikan.jpg", FoodCountForPeople = 4, FoodCountForPeopleText = "Kişilik", FoodPreparingTime = 15, FoodPreparingTimeText = "Dakika", FoodCookingTime = 40, FoodCookingTimeText = "Dakika", FoodRecipe = "Geceden ıslatmış olduğunuz fasulyelerin suyunu süzün ve tencereye alın. Süt ve suyu karıştırarak üzerini geçene kadar ekleyin ve kaynamaya bırakın.Biraz kaynadıktan sonra süzgeç yardımıyla süzün. Tencereye yağ ve küp küp doğranmış soğanları ekleyip kavurun. Soğanların rengi dönünce salça ve fasulyeleri ekleyerek kavurun. Hizasını geçene kadar su ekleyip baharatlarını ilave edin. Süt ile kaynatıldığı için pişme süresi yarı yarıya kısalıyor,kontrollü pişirmekte fayda var. Piştikten sonra biraz dinlendirin. Ardından servis edin. Afiyetler olsun!    "},
                new Foods{Id=5, FoodName = "Tel Şehriyeli Pirinç Pilav", FoodImage = "/images/tel-sehriyeli-pirinc-pilavi-onecikan.jpg", FoodCountForPeople = 4, FoodCountForPeopleText = "Kişilik", FoodPreparingTime = 10, FoodPreparingTimeText = "Dakika", FoodCookingTime = 20, FoodCookingTimeText = "Dakika", FoodRecipe = "Pirincinizi iyice yıkadıktan sonra tuzlu sıcak suda yarım saat nişastasını atması için bekletin Şehriyeyi pilav tenceresine alarak tereyağı ve sıvı yağını ekleyip rengi dönene kadar kavurun. Pirinci ekleyin, bir miktar daha kavurun. Bu aşamada limon suyu ve şekeri ekleyip üzerine suyunu ekleyin. Tuzunu da ekleyip karıştırdıktan sonra kapağını kapatın, kısık ateşte pişmeye bırakın. Suyunu çeken pilavın üzerine bir bez kapatın ve kapağını kapatarak demlenmesi için bekleyin. Tel şehriyeli pirinç pilavı hazır, afiyetler olsun."},
                new Foods{Id=6, FoodName = "Közlenmiş Domates Çorbası ", FoodImage = "/images/kozlenmis-domates-corbasi-one-cikan.webp", FoodCountForPeople = 4, FoodCountForPeopleText = "Kişilik", FoodPreparingTime = 20, FoodPreparingTimeText = "Dakika", FoodCookingTime = 30, FoodCookingTimeText = "Dakika", FoodRecipe = "Fırınınızı 180 derecede ısıtmaya başlayın.Domatesleri iyice yıkayın ve kabuklarını soymadan ortadan ikiye bölün.Fırın tepsinize yağlı kağıt serin ve ortadan ikiye kestiğiniz domatesleri dizin. Üzerine biraz zeytinyağı gezdirin. Önceden ısıtılmış fırında yaklaşık 30 dakika kadar pişirin. Sarımsakları domatesleri fırına attıktan 15 dakika sonra atın.Közlenen domates ve sarımsakları fırından alın. Kabuklarını soyun. Sarımsakları ezin. Soğanı minik küpler halinde doğrayın. Bir tencerenin içerisine alın. Üzerine zeytinyağı ve salçayı ilave edin.Soğanlar iyice kavrulana kadar pişirmeye devam edin. Pişince içerisine ezdiğiniz sarımsakları ekleyin. Birkaç kez daha çevirin. Ardından közlenmiş domatesleri ve sıcak suyu ekleyin. Domatesler iyice eriyene kadar pişirin. Orta ateşte domatesler iyice eriyene kadar pişirin. Tuz ve baharatlarını ilave edin. Kıvam almaya başladığında ocaktan alın ve karışımı blenderdan geçirin. Üzerini dilediğiniz gibi süsleyerek sıcak sıcak servis edin. Afiyet olsun."},
            });

            mbuilder.Entity<FoodMaterials>().HasData(new FoodMaterials[]
            {
                new FoodMaterials{Id=1, FoodId = 1, MaterialId = 20, MaterialCount = "3"},
                new FoodMaterials{Id=2, FoodId = 1, MaterialId = 21, MaterialCount = "2"},
                new FoodMaterials{Id=3, FoodId = 1, MaterialId = 2, MaterialCount = "1"},
                new FoodMaterials{Id=4, FoodId = 1, MaterialId = 22, MaterialCount = "1"},
                new FoodMaterials{Id=5, FoodId = 1, MaterialId = 14, MaterialCount = "2"},
                new FoodMaterials{Id=6, FoodId = 1, MaterialId = 24, MaterialCount = "1"},
                new FoodMaterials{Id=7, FoodId = 1, MaterialId = 25, MaterialCount = "2"},
                new FoodMaterials{Id=8, FoodId = 1, MaterialId = 26, MaterialCount = "8"},
                new FoodMaterials{Id=9, FoodId = 2, MaterialId = 15, MaterialCount = "8"},
                new FoodMaterials{Id=10, FoodId = 2, MaterialId = 2, MaterialCount = "1"},
                new FoodMaterials{Id=11, FoodId = 2, MaterialId = 14, MaterialCount = "4"},
                new FoodMaterials{Id=12, FoodId = 2, MaterialId = 16, MaterialCount = "3"},
                new FoodMaterials{Id=13, FoodId = 2, MaterialId = 18, MaterialCount = "1"},
                new FoodMaterials{Id=14, FoodId = 2, MaterialId = 13, MaterialCount = "3"},
                new FoodMaterials{Id=15, FoodId = 3, MaterialId = 28, MaterialCount = "1/2paket"},
                new FoodMaterials{Id=16, FoodId = 3, MaterialId = 21, MaterialCount = "1 tatlı kaşığı"},
                new FoodMaterials{Id=17, FoodId = 3, MaterialId = 19, MaterialCount = "1 paket"},
                new FoodMaterials{Id=18, FoodId = 3, MaterialId = 6, MaterialCount = "1/2 çay kaşığı"},
                new FoodMaterials{Id=19, FoodId = 3, MaterialId = 5, MaterialCount = "1 çay kaşığı"},
                new FoodMaterials{Id=20, FoodId = 4, MaterialId = 30, MaterialCount = "2 su bardağı"},
                new FoodMaterials{Id=21, FoodId = 4, MaterialId = 2, MaterialCount = "1 adet"},
                new FoodMaterials{Id=22, FoodId = 4, MaterialId = 11, MaterialCount = "3 su bardağı"},
                new FoodMaterials{Id=23, FoodId = 4, MaterialId = 21, MaterialCount = "2 yemek kaşığı"},
                new FoodMaterials{Id=24, FoodId = 4, MaterialId = 29, MaterialCount = "1 yemek kaşığı"},
                new FoodMaterials{Id=25, FoodId = 4, MaterialId = 12, MaterialCount = "1 çay kaşığı"},
                new FoodMaterials{Id=26, FoodId = 4, MaterialId = 6, MaterialCount = "1 çay kaşığı"},
                new FoodMaterials{Id=27, FoodId = 4, MaterialId = 5, MaterialCount = "1 çay kaşığı"},
                new FoodMaterials{Id=28, FoodId = 5, MaterialId = 3, MaterialCount = "2 su bardağı"},
                new FoodMaterials{Id=29, FoodId = 5, MaterialId = 31, MaterialCount = "2 yemek kaşığı"},
                new FoodMaterials{Id=30, FoodId = 5, MaterialId = 27, MaterialCount = "2,5 su bardağı kaynar "},
                new FoodMaterials{Id=31, FoodId = 5, MaterialId = 21, MaterialCount = "2 yemek kaşığı "},
                new FoodMaterials{Id=32, FoodId = 5, MaterialId = 13, MaterialCount = "1 yemek kaşığı "},
                new FoodMaterials{Id=33, FoodId = 5, MaterialId = 5, MaterialCount = "1 tatlı kaşığı "},
                new FoodMaterials{Id=34, FoodId = 5, MaterialId = 17, MaterialCount = "3 damla "},
                new FoodMaterials{Id=35, FoodId = 5, MaterialId = 32, MaterialCount = "1/2 çay kaşığı "},
                new FoodMaterials{Id=36, FoodId = 6, MaterialId = 33, MaterialCount = "9 adet büyük boy "},
                new FoodMaterials{Id=37, FoodId = 6, MaterialId = 14, MaterialCount = "5 diş "},
                new FoodMaterials{Id=38, FoodId = 6, MaterialId = 20, MaterialCount = "5 yemek kaşığı "},
                new FoodMaterials{Id=39, FoodId = 6, MaterialId = 2, MaterialCount = "1 adet orta boy "},
                new FoodMaterials{Id=40, FoodId = 6, MaterialId = 27, MaterialCount = "5 su bardağı sıcak  "},
                new FoodMaterials{Id=41, FoodId = 6, MaterialId = 24, MaterialCount = "1 yemek kaşığı  "},
                new FoodMaterials{Id=42, FoodId = 6, MaterialId = 5, MaterialCount = "1 çay kaşığı  "},
                new FoodMaterials{Id=43, FoodId = 6, MaterialId = 6, MaterialCount = "1 çay kaşığı  "},
            });
        }
        public DbSet<Users> Users { get; set; }
        public DbSet<Foods> Foods { get; set; }
        public DbSet<Materials> Materials { get; set; }
        public DbSet<FoodMaterials> FoodMaterials { get; set; }
        public DbSet<FavoriteFoods> FavoriteFoods { get; set; }

    }
}
