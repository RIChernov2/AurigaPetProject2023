using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurigaPetProject2023.DataAccess.Entities
{
    public class ItemWithStatus: Item
    {
        public bool Disabled { get; set; }
        public bool InRent { get; set; }
        public bool InRepair { get; set; }

        public override string ToString()
        {
            return $"ID - {ItemID}, TID - {ItemTypeID}, Dis - {Disabled}, InRent - {InRent}, InRepair - {InRepair}, Description - {Description} ";
        }
    }

}

