using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica
{
    public class Env
    {
        //Maria string
        //public static string ConnString = "User ID = postgres; Password=0; Host=localhost;Port=5432; Database=Olympos-db;";
        //public static string ConnString = "User ID = postgres; Password=pass; Host=localhost;Port=5000; Database=Olympos-db;";
        //public static string ConnString = "User ID = postgres; Password=0; Host=localhost;Port=5432; Database=Olympos-db;";
        //Davi string
        //public static string ConnString = "User ID = postgres; Password=password; Host=localhost;Port=5432; Database=Olympos;Pooling=true;Minimum Pool Size=0;Maximum Pool Size=100;";
        //Atari string
        //public static string ConnString = "User ID = postgres; Password=pass; Host=localhost;Port=5000; Database=Olympos-db;";
        public static string ConnString = "Database=d997bj0duk47mj; Host=ec2-54-166-114-48.compute-1.amazonaws.com; Port=5432; User ID=hwcxfgdafwshil; Password=5117528ea4aa31db3956b05641b7dea22967153b1d94aaac1ec00d2b60f84d69;";


        public static string Secret = "06345633691ed389ac8cda3568b0b174";

        public static string Issuer = "back-atletica.com";

        public static string CLOUD_NAME = "hxekm1gqf";

        public static string API_KEY = "316935171762257";

        public static string API_SECRET = "Q13ezfp1AYPhi2cgsjasBFXgTJo";

        public string Encriptografia(string senha)
        {
            string hashed = BCrypt.Net.BCrypt.HashPassword(senha);

            return hashed;
        }
    }
}
