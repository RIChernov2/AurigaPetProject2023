using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurigaPetProject2023.DataAccess.Repositories.Interfaces
{
    public interface IUserWithDiscountInfo
    {
        public int UserID { get; set; }
        public string LoginName { get; set; }
        public string Phone { get; set; }
        byte DiscountPercentage { get; set; }
        string Print();
    }
}
