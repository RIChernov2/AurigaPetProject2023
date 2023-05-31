using AurigaPetProject2023.DataAccess.Repositories.Interfaces;
using System.Collections.Generic;

namespace AurigaPetProject2023.DataAccess.Entities
{
    public class UserWithDiscountInfo : IUserWithDiscountInfo
    {
        public UserWithDiscountInfo (User user, DiscountInfo discountInfo)
        {
            UserID = user.UserID;
            LoginName = user.LoginName;
            Phone = user.Phone;
            //if (discountInfo == null)
            //{
            //    DiscountPercentage = 0;
            //}
            //else
            //{
            //    DiscountPercentage = discountInfo.DiscountPercentage;
            //}

            DiscountPercentage = discountInfo == null ? (byte)0: discountInfo.DiscountPercentage;

        }
        public int UserID { get; set; }
        public string LoginName { get; set; }
        public string Phone { get; set; }
        public byte DiscountPercentage { get; set; }

        public string Print()
        {
            return $"ID=> {UserID}, Login/Phone => {LoginName ??= "-"}/{Phone ??= "-"}";
        }
    }
}
