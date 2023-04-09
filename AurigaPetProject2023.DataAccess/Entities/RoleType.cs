using System.ComponentModel.DataAnnotations.Schema;

namespace AurigaPetProject2023.DataAccess.Entities
{
    public class RoleType
    {
        [Column("RoleType_ID")]
        public int RoleID { get; set; }
        public string Name { get; set; }
    }
}
