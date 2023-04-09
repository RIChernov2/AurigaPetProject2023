﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;


namespace AurigaPetProject2023.DataAccess.Helpers
{
    public static class HashHelper
    {
        public static string GetHash(string password)
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
    }
}
