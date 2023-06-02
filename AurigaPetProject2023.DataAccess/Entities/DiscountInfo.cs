using System.ComponentModel.DataAnnotations.Schema;

namespace AurigaPetProject2023.DataAccess.Entities
{
    public class DiscountInfo
    {
        [Column("User_ID")]
        public int UserID { get; set; }
        public byte DiscountPercentage { get; set; }
    }
}
