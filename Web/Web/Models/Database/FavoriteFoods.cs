using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Models.Database
{
    [Table("FavoriteFoods")]
    public class FavoriteFoods : BaseModel
    {
        [Column("FoodId", Order = 1)]
        public int FoodId { get; set; }
        [Column("UserId", Order = 2)]
        public int UserId { get; set; }
    }
}
