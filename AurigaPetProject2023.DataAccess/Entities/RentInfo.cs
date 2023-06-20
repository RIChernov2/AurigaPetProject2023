using System;

namespace AurigaPetProject2023.DataAccess.Entities
{
    public class RentInfo
    {
        public int RentInfoID { get; set; }
        public int UserID { get; set; }
        public int ItemID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public DateTime? EndDate { get; set; }
        public double Cost { get; set; }
        public bool IsPaid { get; set; }

        public RentInfo GetCopy()
        {
            return new RentInfo()
            {
                RentInfoID = this.RentInfoID,
                UserID = this.UserID,
                ItemID = this.ItemID,
                StartDate = this.StartDate,
                ExpireDate = this.ExpireDate,
                EndDate = this.EndDate,
                Cost = this.Cost,
                IsPaid = this.IsPaid
            };
        }
    }
}
