﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica
{
    public class Env
    {
        //Davi string
        public static string ConnString = "User ID = postgres; Password=password; Host=localhost;Port=5432; Database=Olympos;Pooling=true;Minimum Pool Size=0;Maximum Pool Size=100;";
        //Atari string
        //public static string ConnString = "User ID = postgres; Password=pass; Host=localhost;Port=5000; Database=Olympos-db;";
        //public static string ConnString = "Database=db5h3tu260ofsh; Host=ec2-18-235-20-228.compute-1.amazonaws.com; Port=5432; User ID=htqmtyzoggbpnu; Password=74fde93835f7a6dfec243887db269383909f5f95a24373e4f53fa7e727751e64;";

        public static string Secret = "06345633691ed389ac8cda3568b0b174";

        public static string Issuer = "back-atletica.com";

        public string Encriptografia(string senha)
        {
            string hashed = BCrypt.Net.BCrypt.HashPassword(senha);

            return hashed;
        }
    }
}