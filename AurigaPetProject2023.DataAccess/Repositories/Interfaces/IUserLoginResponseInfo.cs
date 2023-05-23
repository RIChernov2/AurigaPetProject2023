using System.Collections.Generic;


namespace AurigaPetProject2023.DataAccess.Repositories.Interfaces
{
    public interface IUserLoginResponseInfo
    {
        int UserID { get; set; }
        public string LoginName { get; set; }
        public string Phone { get; set; }
        List<int> Roles { get; set; }
    }
}
