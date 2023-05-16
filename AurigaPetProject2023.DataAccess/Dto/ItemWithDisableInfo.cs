using AurigaPetProject2023.DataAccess.Entities;

namespace AurigaPetProject2023.DataAccess.Dto
{
    public class ItemWithDisableInfo
    {
        public Item ItemData { get; set; }
        public DisabledInfo DisabledInfoData { get; set; }
    }
}
