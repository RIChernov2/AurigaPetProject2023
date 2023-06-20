namespace AurigaPetProject2023.DataAccess.Entities
{
    public class Item
    {
        public int ItemID { get; set; }
        public int ItemTypeID { get; set; }
        public string Description { get; set; }

        // Ignore
        public ItemType ItemType { get; set; }
        public int? UniqueID { get; set; }
    }
}
