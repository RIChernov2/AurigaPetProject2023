using System.ComponentModel.DataAnnotations.Schema;

namespace AurigaPetProject2023.DataAccess.Entities
{
    public class ItemUniqueInfo
    {
        [Column("ItemUnique_ID")]
        public int ItemUniqueID { get; set; }
        [Column("Item_ID")]
        public int ItemID { get; set; }

    }
}
