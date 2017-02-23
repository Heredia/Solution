using Model.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Databases.Database.Entities
{
    [Table("UsersRoles", Schema = "User")]
    public class UserRole
    {
        [Key]
        [Column(Order = 1)]
        public long UserId { get; set; }

        [Key]
        [Column(Order = 2)]
        public Role Role { get; set; }
    }
}