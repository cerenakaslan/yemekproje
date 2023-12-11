using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Models.Database
{
    [Table("Materials")]
    public class Materials : BaseModel
    {
        [Column("MaterialName", Order = 1)]
        public string? MaterialName { get; set; }
        [Column("MaterialImage", Order = 2)]
        public string? MaterialImage { get; set; }
    }
}
