using System.ComponentModel.DataAnnotations.Schema;


namespace AurigaPetProject2023.DataAccess.Entities
{
    public class Product
    {
        [Column("Product_ID")]
        public int ProductID { get; set; }
        [Column("ProductType_ID")]
        public int ProductTypeID { get; set; }
        public string Description { get; set; }

        public ProductType ProductType { get; set; }
    }
}
