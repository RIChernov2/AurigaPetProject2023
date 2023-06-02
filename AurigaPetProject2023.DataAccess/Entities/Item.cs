using System.ComponentModel.DataAnnotations.Schema;

namespace AurigaPetProject2023.DataAccess.Entities
{
    public class Item
    {
        [Column("Item_ID")]
        public int ItemID { get; set; }
        [Column("ItemType_ID")]
        public int ItemTypeID { get; set; }
        public string Description { get; set; }

        // Ignore
        public ItemType ItemType { get; set; }
        public int? UniqueID { get; set; }
    }
}
