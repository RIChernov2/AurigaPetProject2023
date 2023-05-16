using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AurigaPetProject2023.DataAccess.Entities
{
    public class DisabledInfo
    {
        [Key]
        [Column("DisabledInfo_ID")]
        public int DisabledInfoID { get; set; }
        [Column("Item_ID")]
        public int ItemID { get; set; }
        public DateTime Date { get; set; }
        public string Reason { get; set; }

        public override string ToString()
        {
            return
                $"ID операции списания - {DisabledInfoID}{Environment.NewLine}" +
                $"Дата списания - {Date}{Environment.NewLine}" +
                $"Причина списания - {Reason}";
        }
    }
}
