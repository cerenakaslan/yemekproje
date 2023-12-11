using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Models.Database
{
    [Table("MyFoods")]
    public class MyFoods : BaseModel
    {
        [Column("FoodName", Order = 1)]
        public string FoodName { get; set; }
        [Column("FoodImage", Order = 2)]
        public string? FoodImage { get; set; }
        [Column("FoodCountForPeople", Order = 3)]
        public int FoodCountForPeople { get; set; }
        [Column("FoodCountForPeopleText", Order = 4)]
        public string? FoodCountForPeopleText { get; set; }
        [Column("FoodPreparingTime", Order = 5)]
        public int FoodPreparingTime { get; set; }
        [Column("FoodPreparingTimeText", Order = 6)]
        public string? FoodPreparingTimeText { get; set; }
        [Column("FoodCookingTime", Order = 7)]
        public int FoodCookingTime { get; set; }
        [Column("FoodCookingTimeText", Order = 8)]
        public string? FoodCookingTimeText { get; set; }
        [Column("FoodRecipe", Order = 9)]
        public string? FoodRecipe { get; set; }
    }
}
