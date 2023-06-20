using System;

namespace AurigaPetProject2023.DataAccess.Entities
{
    public class ItemType
    {
        public int ItemTypeID { get; set; }
        public string Name { get; set; }
        public bool IsUnique { get; set; }

        public override string ToString()
        {
            string id = ItemTypeID == 0 ? "..." : ItemTypeID.ToString();
            string unique = IsUnique ? "Да" : "Нет";
            return $"ID - {id} {Environment.NewLine}Название " +
                $"- {Name} {Environment.NewLine}Уникальный - {unique}";
        }
    }
}

