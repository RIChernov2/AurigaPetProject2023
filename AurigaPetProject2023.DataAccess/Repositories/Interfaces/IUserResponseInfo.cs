﻿using System.Collections.Generic;
using System.Drawing.Printing;

namespace AurigaPetProject2023.DataAccess.Repositories.Interfaces
{
    public interface IUserResponseInfo
    {
        int UserID { get; set; }
        public string LoginName { get; set; }
        public string Phone { get; set; }
        List<int> Roles { get; set; }
    }
}
