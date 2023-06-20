using System;

namespace AurigaPetProject2023.DataAccess.Entities
{
    public class BannedInfo
    {
        // оставил, как пример другой возможной связи на таблицу, не через OnModelCreating
        //[Key]
        //[Column("BannedInfo_ID")]
        public int BannedInfoID { get; set; }

        //[Column("User_ID")]
        public int UserID { get; set; }
        public DateTime Date { get; set; }
        public string Reason { get; set; }
    }
}
