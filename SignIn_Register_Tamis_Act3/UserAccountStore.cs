
using System;
using System.Collections.Generic;

namespace SignIn_Register_Tamis_Act3
{
    public class UserAccount
    {
        public string FullName { get; set; }
        public string Password { get; set; }
    }

    public static class UserAccountStore
    {
        private static Dictionary<string, UserAccount> users =
            new Dictionary<string, UserAccount>(
                StringComparer.OrdinalIgnoreCase
            );

        public static bool Register(
            string fullName,
            string username,
            string password)
        {
            username = username.Trim();

            if (users.ContainsKey(username))
                return false;

            users.Add(username, new UserAccount
            {
                FullName = fullName.Trim(),
                Password = password
            });

            return true;
        }

        public static bool Login(string username, string password)
        {
            username = username.Trim();

            return users.ContainsKey(username) &&
                   users[username].Password == password;
        }
    }
}
