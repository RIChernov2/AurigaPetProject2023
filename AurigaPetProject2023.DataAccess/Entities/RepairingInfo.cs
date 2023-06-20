using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AurigaPetProject2023.DataAccess.Entities
{
    public class RepairingInfo
    {
        public int RepairingInfoID { get; set; }
        public int ItemID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Reason { get; set; }
        public string ResultDescription { get; set; }

        public override string ToString()
        {
            return
                $"ID операции списания - {RepairingInfoID}{Environment.NewLine}" +
                $"ID элемента в ремонте - {ItemID}{Environment.NewLine}" +
                $"Дата начала ремонта - {StartDate}{Environment.NewLine}" +
                $"Причина отправки в ремонт - {Reason}";
        }


        public RepairingInfo GetCopy()
        {
            return new RepairingInfo()
            {
                RepairingInfoID = this.RepairingInfoID,
                ItemID = this.ItemID,
                StartDate = this.StartDate,
                EndDate = this.EndDate,
                Reason = this.Reason,
                ResultDescription = this.ResultDescription
            };
        }
    }
}
