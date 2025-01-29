﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustWpf
{
    class User
    {
        public int? Id { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }

        public User()
        {
            

        }

        public User(string login,string pass,string email)
        {
            Login = login;
            Password = pass;
            Email = email;
        }


    }
}
