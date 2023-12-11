using AngleSharp;
using AngleSharp.Io;
using Web.Models.Database;
using Web.Models.Dto;

namespace Web.WebScraping
{
    public class FoodFind : IFoodFind
    {
        public async Task<List<FoodMaterialsDto>> DataScraping(string searchKeyword, int userId)
        {
            List<FoodMaterialsDto> lstFoodMaterials = new List<FoodMaterialsDto>();

            searchKeyword = searchKeyword.Replace(" ", "+");
            string baseAddress = $"https://www.lezzet.com.tr/arama";
            string targetAddress = $"{baseAddress}?searchKeyword={searchKeyword}";

            var userAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36";
            var config = Configuration.Default
            .WithDefaultLoader(
                new LoaderOptions
                {
                    Filter = request =>
                    {
                        request.Headers["User-Agent"] = userAgent;
                        return true;
                    },
                }
            )
            .WithDefaultCookies();

            var context = BrowsingContext.New(config);
            var currDocument = context.OpenAsync(targetAddress).Result;

            var counterVar = currDocument.QuerySelector("body > section.d-flex.align-items-center.bg-yellow > div > div:nth-child(1) > div > h2")?.TextContent.Trim();

            if (string.IsNullOrEmpty(counterVar))
                return lstFoodMaterials;

            string counterStr = "";
            foreach (char karakter in counterVar)
            {
                if (Char.IsDigit(karakter))
                {
                    counterStr += karakter;
                }
            }

            int counterInt;
            bool countBool = int.TryParse(counterStr, out counterInt);
            if (!countBool)
                return lstFoodMaterials;

            //int excess = 0;
            //if (counterInt <= 16)
            //    counterInt = 1;
            //else
            //{
            //    excess = (counterInt % 16) > 0 ? (counterInt % 16) : 0;
            //    counterInt = (int)(counterInt / 16) + (excess > 0 ? 1 : 0);
            //}

            counterInt = counterInt < 8 ? counterInt : 8;
            //sadece ilk sayfayi cekecek
            int firstPage = counterInt > 16 ? 16 : counterInt;

            for (int icx = 1; icx < firstPage + 1; icx++)
            {
                try
                {
                    var link = currDocument.QuerySelector($"body > section.d-flex.align-items-center.bg-yellow > div > div:nth-child(2) > div:nth-child({icx}) > div > div.img-content > a")?.GetAttribute("href");
                    var title = currDocument.QuerySelector($"body > section.d-flex.align-items-center.bg-yellow > div > div:nth-child(2) > div:nth-child({icx}) > div > div.recipe-content-text-content > div.box-header > a")?.TextContent.Trim();

                    var currentMeal = context.OpenAsync(baseAddress + link).Result;

                    Foods foods = new Foods();

                    foods.FoodName = currentMeal.QuerySelector($"body > section.detail-content.bg-white.content-index > div > div:nth-child(1) > div > h1")?.TextContent.Trim();
                    foods.FoodImage = currentMeal.QuerySelector($"body > section.detail-content.bg-white.content-index > div > div:nth-child(2) > div.col-md-9 > div:nth-child(1) > img")?.GetAttribute("src");
                    foods.FoodCountForPeople = GetInt(currentMeal.QuerySelector($"body > section.detail-content.bg-white.content-index > div > div:nth-child(2) > div.col-md-9 > div:nth-child(3) > div:nth-child(1) > div > div:nth-child(3) > span > b")?.TextContent.Trim());
                    foods.FoodCountForPeopleText = currentMeal.QuerySelector($"body > section.detail-content.bg-white.content-index > div > div:nth-child(2) > div.col-md-9 > div:nth-child(3) > div:nth-child(1) > div > div:nth-child(3) > span > b")?.TextContent.Trim().Split(foods.FoodCountForPeople.ToString())?[1];
                    foods.FoodPreparingTime = GetInt(currentMeal.QuerySelector($"body > section.detail-content.bg-white.content-index > div > div:nth-child(2) > div.col-md-9 > div:nth-child(3) > div:nth-child(1) > div > div:nth-child(1) > span > b")?.TextContent.Trim());
                    foods.FoodPreparingTimeText = currentMeal.QuerySelector($"body > section.detail-content.bg-white.content-index > div > div:nth-child(2) > div.col-md-9 > div:nth-child(3) > div:nth-child(1) > div > div:nth-child(1) > span > b")?.TextContent.Trim().Split(foods.FoodPreparingTime.ToString())?[1];
                    foods.FoodCookingTime = GetInt(currentMeal.QuerySelector($"body > section.detail-content.bg-white.content-index > div > div:nth-child(2) > div.col-md-9 > div:nth-child(3) > div:nth-child(1) > div > div:nth-child(2) > span > b")?.TextContent.Trim());
                    foods.FoodCookingTimeText = currentMeal.QuerySelector($"body > section.detail-content.bg-white.content-index > div > div:nth-child(2) > div.col-md-9 > div:nth-child(3) > div:nth-child(1) > div > div:nth-child(2) > span > b")?.TextContent.Trim().Split(foods.FoodCookingTime.ToString())?[1];
                    foods.FoodRecipe = currentMeal.QuerySelector($"body > section.detail-content.bg-white.content-index > div > div:nth-child(7) > div.col-md-9.text-gray-content.recipe-detail")?.TextContent.Trim();
                    foods.CreateDate = foods.UpdateDate = new DateTime();


                    List<Materials> lstMaterials = new List<Materials>();
                    currentMeal.QuerySelectorAll($"body > section.detail-content.bg-white.content-index > div > div:nth-child(4) > div.col-md-9 > div > div > ul > li")
                        .ToList()
                        .ForEach(f => lstMaterials.Add(new Materials() { MaterialName = f.InnerHtml, CreateDate = new DateTime(), UpdateDate = new DateTime(), Creator = userId }));

                    lstFoodMaterials.Add(new FoodMaterialsDto() { Foods = foods, Materials = lstMaterials });

                }
                catch (Exception)
                {

                }                
            }


            return lstFoodMaterials;

        }
        private int GetInt(string counterVar)
        {
            if (string.IsNullOrEmpty(counterVar))
                return -1;

            string counterStr = "";
            foreach (char karakter in counterVar)
            {
                if (Char.IsDigit(karakter))
                {
                    counterStr += karakter;
                }
            }

            int counterInt;
            bool countBool = int.TryParse(counterStr, out counterInt);
            if (!countBool)
                return -1;

            return counterInt;
        }
    }
}
