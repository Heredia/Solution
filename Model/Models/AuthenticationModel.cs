using Model.Enums;
using System.Collections.Generic;

namespace Model.Models
{
    public class AuthenticationModel
    {
        public long UserId { get; set; }

        public string Name { get; set; }

        public IEnumerable<Role> Roles { get; set; } = new List<Role>();
    }
}