using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AurigaPetProject2023.DataAccess.Entities
{
    public class User
    {
        [Column("User_ID")]
        public int UserID { get; set; }
        [Column("Login_Name")]
        public string LoginName { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public List<int> Roles { get; set; }
    }
}
