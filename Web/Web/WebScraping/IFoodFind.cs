using Web.Models.Dto;

namespace Web.WebScraping
{
    public interface IFoodFind
    {
        Task<List<FoodMaterialsDto>> DataScraping(string searchKeyword, int userId);
    }
}
