using AurigaPetProject2023.DataAccess.Entities;

namespace AurigaPetProject2023.DataAccess.Dto
{
    public class ItemWithRentInfo
    {
        public Item ItemData { get; set; }
        public RentInfo RentInfo { get; set; }
    }
}
