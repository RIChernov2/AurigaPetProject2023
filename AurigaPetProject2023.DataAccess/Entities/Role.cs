using System.ComponentModel.DataAnnotations.Schema;

namespace AurigaPetProject2023.DataAccess.Entities
{
    public class Role
    {
        public int UserID { get; set; }
        public int RoleTypeID { get; set; }
    }
}
