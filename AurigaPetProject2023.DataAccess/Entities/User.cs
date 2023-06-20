using System.Collections.Generic;

namespace AurigaPetProject2023.DataAccess.Entities
{
    public class User
    {
        public int UserID { get; set; }
        public string LoginName { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        // Ignore
        public List<int> Roles { get; set; }
    }
}
