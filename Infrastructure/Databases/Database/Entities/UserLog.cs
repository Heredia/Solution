using Model.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Databases.Database.Entities
{
    [Table("UsersLogs", Schema = "User")]
    public class UserLog
    {
        [Key]
        public long UserLogId { get; set; }

        [Required]
        public long UserId { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [Required]
        public LogType LogType { get; set; }

        public string Message { get; set; }
    }
}