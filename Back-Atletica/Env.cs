using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica
{
    public class Env
    {
        //Maria string
        public static string ConnString = "User ID = postgres; Password=0; Host=localhost;Port=5432; Database=Olympos-db;";
        //public static string ConnString = "User ID = postgres; Password=pass; Host=localhost;Port=5000; Database=Olympos-db;";
        //public static string ConnString = "User ID = postgres; Password=0; Host=localhost;Port=5432; Database=Olympos-db;";
        //Davi string
        //public static string ConnString = "User ID = postgres; Password=password; Host=localhost;Port=5432; Database=Olympos;Pooling=true;Minimum Pool Size=0;Maximum Pool Size=100;";
        //Atari string
        //public static string ConnString = "User ID = postgres; Password=pass; Host=localhost;Port=5000; Database=Olympos-db;";
        //public static string ConnString = "Database=d70kl3l4ska11m; Host=ec2-3-216-89-250.compute-1.amazonaws.com; Port=5432; User ID=bnmcomctyuwvtf; Password=98165167fcf16910caa7f3b9d73dfcf9d5a1a9ea90e227c679a93a6677971a92;";


        public static string Secret = "06345633691ed389ac8cda3568b0b174";

        public static string Issuer = "back-atletica.com";

        public static string CLOUD_NAME = "hvnjvmiud";

        public static string API_KEY = "346644413438193";

        public static string API_SECRET = "JVTO6XTCUszkUMgFaPQfLSiNBgs";

        public string Encriptografia(string senha)
        {
            string hashed = BCrypt.Net.BCrypt.HashPassword(senha);

            return hashed;
        }
    }
}
