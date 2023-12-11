using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Models.Database
{
    [Table("Users")]
    public class Users : BaseModel
    {
        [Column("Firstname", Order = 1)]
        public string? Firstname { get; set; }
        [Column("Lastname", Order = 2)]
        public string? Lastname { get; set; }
        [Column("Email", Order = 3)]
        public string Email { get; set; }
        [Column("Password", Order = 4)]
        public string Password { get; set; }
        [Column("ProfileImage", Order = 5)]
        public string ProfileImage { get; set; } = "chefimage.png";
        [Column("ForgotPassword", Order = 6)]
        public int? ForgotPassword { get; set; }
    }
}
