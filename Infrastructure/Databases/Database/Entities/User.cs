using Model.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Databases.Database.Entities
{
    [Table("Users", Schema = "User")]
    public class User
    {
        [Key]
        public long UserId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Surname { get; set; }

        [Required]
        [StringLength(250)]
        public string Email { get; set; }

        [Required]
        [StringLength(300)]
        public string Login { get; set; }

        [Required]
        [StringLength(500)]
        public string Password { get; set; }

        [Required]
        public Status Status { get; set; }

        public virtual ICollection<UserLog> UsersLogs { get; set; } = new HashSet<UserLog>();

        public virtual ICollection<UserRole> UsersRoles { get; set; } = new HashSet<UserRole>();
    }
}