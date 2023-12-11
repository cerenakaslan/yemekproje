using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Models.Database
{
    [Table("FoodMaterials")]
    public class FoodMaterials : BaseModel
    {
        [Column("FoodId", Order = 1)]
        public int FoodId { get; set; }
        [Column("MaterialId", Order = 2)]
        public int MaterialId { get; set; }
        [Column("MaterialCount", Order = 3)]
        public string? MaterialCount { get; set; }
    }
}
