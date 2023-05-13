using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AurigaPetProject2023.DataAccess.Entities
{
    public class DisabledInfo
    {
        [Key]
        [Column("DisabledInfo_ID")]
        public int DisabledInfoID { get; set; }
        [Column("Item_ID")]
        public int ItemID { get; set; }
    }
}
