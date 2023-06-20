using System;

namespace AurigaPetProject2023.DataAccess.Entities
{
    public class DisabledInfo
    {
        public int DisabledInfoID { get; set; }
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
