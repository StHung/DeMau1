using System;
using System.Collections.Generic;
using System.Text;

namespace DeMau1
{
    class Account
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public Account()
        {

        }

        public Account(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }
    }
}
