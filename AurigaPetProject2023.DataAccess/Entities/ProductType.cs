using System.ComponentModel.DataAnnotations.Schema;

namespace AurigaPetProject2023.DataAccess.Entities
{
    public class ProductType
    {
        [Column("ProductType_ID")]
        public int ProductTypeID { get; set; }
        public string Name { get; set; }
        [Column("Unique")]
        public bool IsUnique { get; set; }
    }
}

