using Web.Models.Database;

namespace Web.Models.Dto
{
    public class FoodMaterialsDto
    {
        public List<Materials> Materials { get; set; }
        public Foods Foods { get; set; }
    }
}
