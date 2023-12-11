using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Web.Models.Database
{
    public class BaseModel
    {
        [Key]
        [Column("Id", Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime UpdateDate { get; set; } = DateTime.Now;
        public int Creator { get; set; } = 1; // 1 ise admin tarafından oluşturuldu
    }
}
