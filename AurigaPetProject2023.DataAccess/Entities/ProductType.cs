using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AurigaPetProject2023.DataAccess.Entities
{
    public class ProductType
    {
        [Column("ProductType_ID")]
        public int ProductTypeID { get; set; }
        public string Name { get; set; }
        [Column("Unique")]
        public bool IsUnique { get; set; }

        public override string ToString()
        {
            string id = ProductTypeID == 0 ? "..." : ProductTypeID.ToString();
            string unique = IsUnique ? "Да" : "Нет";
            return $"ID - {id}{Environment.NewLine}Название " +
                $"- {Name}{Environment.NewLine}Уникальный - {unique}";
        }
    }
}

