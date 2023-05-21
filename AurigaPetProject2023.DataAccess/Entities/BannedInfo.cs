using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AurigaPetProject2023.DataAccess.Entities
{
    public class BannedInfo
    {
        [Key]
        [Column("BannedInfo_ID")]
        public int BannedInfoID { get; set; }

        [Column("User_ID")]
        public int UserID { get; set; }
        public DateTime Date { get; set; }
        public string Reason { get; set; }
    }
}
