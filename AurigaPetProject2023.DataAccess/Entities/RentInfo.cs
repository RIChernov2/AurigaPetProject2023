using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AurigaPetProject2023.DataAccess.Entities
{
    public class RentInfo
    {
        [Key]
        [Column("RentInfo_ID")]
        public int RentInfoID { get; set; }
        [Column("User_ID")]
        public int UserID { get; set; }
        [Column("Item_ID")]
        public int ItemID { get; set; }
        [Column("Start_Date")]
        public DateTime StartDate { get; set; }
        [Column("Expire_Date")]
        public DateTime? ExpireDate { get; set; }
        [Column("End_Date")]
        public DateTime? EndtDate { get; set; }
        public double Cost { get; set; }
        public bool IsPaid { get; set; }
    }
}
