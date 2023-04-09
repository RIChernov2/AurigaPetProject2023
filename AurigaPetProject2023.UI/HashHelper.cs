using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;


namespace AurigaPetProject2023.UI
{
    public static class HashHelper
    {
        public  static string GetHash(string password)
        {
            byte[] salt = Encoding.ASCII.GetBytes("mySaltWhichIveChosen");
            Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(password, salt, 1000);
            byte[] hash = pbkdf2.GetBytes(20);
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);
            string hashedPassword = Convert.ToBase64String(hashBytes);
            return hashedPassword;
        }

        private static List<User> _users;

        public static User GetUser(string login, string password)
        {
            if (_users == null)
            {
                _users = new List<User>()
                {
                    new User(){Login = "Admin", Password = GetHash("123"), IsManager = true },
                    new User(){Login = "User", Password = GetHash("321"), IsManager = false },
                };
            }

            return _users.Where(x => x.Login == login && x.Password == GetHash(password)).FirstOrDefault();
        }
    }

    public class User
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public bool IsManager { get; set; }
    }
}
