using Back_Atletica.Models;
using Back_Atletica.Utils;
using System.Security.Cryptography;
using Org.BouncyCastle.Crypto.Generators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Back_Atletica.Data;

namespace Back_Atletica.Repository.Implementação
{
    public class AutenticacaoRepositoryImpl : IAutenticacaoRepository
    {

        AtleticaContext _context;

        public AutenticacaoRepositoryImpl(AtleticaContext context)
        {
            _context = context;
        }

        public string GerarPIN()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            var result = new string(
                Enumerable.Repeat(chars, 5)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());
            return result;
        }

        public string GerarTokenJWT(string email)
        {
            throw new NotImplementedException();
        }

        public HttpRes Login(Atletica atletica)
        {
            throw new NotImplementedException();
        }

        public HttpRes RegistrarAtletica(Atletica atletica)
        {
            Env hash = new Env();

            try
            {
                string encrip = hash.Encriptografia(atletica.Senha);

                atletica.Senha = encrip;
                atletica.PIN = GerarPIN();

                _context.Add(atletica);

                _context.SaveChanges();

                return new HttpRes(201, atletica);
            }
            catch(Exception ex)
            {
                if (ex.InnerException == null) return new HttpRes(400, ex.Message);

                return new HttpRes(400, ex.InnerException.Message);
            }
        }

        public HttpRes RegistrarMembro(Membro membro)
        {
            throw new NotImplementedException();
        }

        public HttpRes ResetarSenha(string email)
        {
            throw new NotImplementedException();
        }
    }
}
