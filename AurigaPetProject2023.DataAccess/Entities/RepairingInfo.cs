using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AurigaPetProject2023.DataAccess.Entities
{
    public class RepairingInfo
    {
        [Key]
        [Column("RepairingInfo_ID")]
        public int RepairingInfoID { get; set; }
        [Column("Item_ID")]
        public int ItemID { get; set; }
        [Column("Start_Date")]
        public DateTime StartDate { get; set; }
        [Column("End_Date")]
        public DateTime? EndtDate { get; set; }
        public string Reason { get; set; }
        public string ResultDescription { get; set; }
    }
}
