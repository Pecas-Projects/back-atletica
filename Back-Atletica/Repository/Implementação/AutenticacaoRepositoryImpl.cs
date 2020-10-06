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

        public string GerarTokenJWT(string email)
        {
            throw new NotImplementedException();
        }

        public HttpRes Login(Atletica atletica)
        {
            throw new NotImplementedException();
        }

        public HttpRes Registrar(Atletica atletica)
        {
            Env hash = new Env();

            try
            {
                string encrip = hash.Encriptografia(atletica.Senha);

                atletica.Senha = encrip;

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

        public HttpRes ResetarSenha(string email)
        {
            throw new NotImplementedException();
        }
    }
}
