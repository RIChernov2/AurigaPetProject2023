using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AurigaPetProject2023.DataAccess.Entities
{
    public class Role
    {
        [Column("User_ID")]
        public int UserID { get; set; }
        [Column("RoleType_ID")]
        public int RoleType { get; set; }
    }
}
