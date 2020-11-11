using Back_Atletica.Models;
using Back_Atletica.Utils;
using System.Security.Cryptography;
using Org.BouncyCastle.Crypto.Generators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Back_Atletica.Data;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;

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

        public HttpRes LoginAtletica(Atletica atletica)
        {
            Atletica atleticaDados = _context.Atleticas.FirstOrDefault(p => p.Email == atletica.Email);

            if (atleticaDados == null || !BCrypt.Net.BCrypt.Verify(atletica.Senha, atleticaDados.Senha)) return new HttpRes(400, "Email ou senha incorretos");

            atleticaDados.Senha = "";

            var token = GerarTokenJWTAtletica(atleticaDados, "Login");

            var loginDados = new
            {
                Atletica = atleticaDados,
                token = token
            };

            return new HttpRes(200, "Logado com sucesso", loginDados);
        }

        public HttpRes LoginMembro(Membro membro)
        {
            Membro dadosMembro = _context.Membros.Include(m => m.Pessoa).FirstOrDefault(p => p.Pessoa.Email == membro.Pessoa.Email);

            if (dadosMembro == null || !BCrypt.Net.BCrypt.Verify(membro.Senha, dadosMembro.Senha)) return new HttpRes(400, "Email ou senha incorretos");

            membro.Senha = "";

            var token = GerarTokenJWTMembro(dadosMembro, "Login");

            var loginDados = new
            {
                Atletica = dadosMembro,
                token = token
            };

            return new HttpRes(200, loginDados);
        }

        private object GerarTokenJWTMembro(Membro membro, string tipo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Env.Secret));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, membro.MembroId.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, membro.Pessoa.Email),
                new Claim(JwtRegisteredClaimNames.Typ, tipo),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: Env.Issuer,
                audience: Env.Issuer,
                claims,
                expires: DateTime.Now.AddMinutes(tipo == "Reset" ? 30 : 480),
                signingCredentials: credentials
                );

            var encodetoken = new JwtSecurityTokenHandler().WriteToken(token);
            return encodetoken;
        }

        private object GerarTokenJWTAtletica(Atletica atletica, string tipo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Env.Secret));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, atletica.AtleticaId.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, atletica.Email),
                new Claim(JwtRegisteredClaimNames.Typ, tipo),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: Env.Issuer,
                audience: Env.Issuer,
                claims,
                expires: DateTime.Now.AddMinutes(tipo == "Reset" ? 30 : 480),
                signingCredentials: credentials
                );

            var encodetoken = new JwtSecurityTokenHandler().WriteToken(token);
            return encodetoken;

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
            Env hash = new Env();

            try
            {
                Atletica atletica = _context.Atleticas.SingleOrDefault(a => a.PIN.Equals(membro.Pessoa.Atletica.PIN));

                if(atletica == null)
                {
                    return new HttpRes(404, "Atletica não encontrada");
                }

                membro.Senha = hash.Encriptografia(membro.Senha);
                membro.Pessoa.Atletica = atletica;

                _context.Add(membro);

                _context.SaveChanges();

                return new HttpRes(201, membro);

            }
            catch(Exception ex)
            {
                if (ex.InnerException == null) return new HttpRes(400, ex.Message);

                return new HttpRes(400, ex.InnerException.Message);
            }
        }

        public HttpRes ResetarSenhaAtletica(string email)
        {
            try
            {
                MailAddress endEmail = new MailAddress(email);

                string emailReceiver = endEmail.Address;

                Atletica atletica = _context.Atleticas.SingleOrDefault(u => u.Email == emailReceiver);

                if (atletica == null) return new HttpRes(404);

                var token = GerarTokenJWTAtletica(atletica, "Reset");

                EnvioEmail mail = new EnvioEmail("Olympos", "olymposatleticas@gmail.com", "Ana", emailReceiver, "Teste De envio");

                mail.CreateEmail("Recuperação de senha Olympos",
                    "<h2>Olá " + atletica.Nome + " " + " este é um Email de recuperação de conta!</h2>"
                    + "<h3>O link é valido apenas por 30 minutos</h3>"
                    + "<a href=\"https://static8.depositphotos.com/1052928/952/i/450/depositphotos_9520406-stock-photo-duck-white.jpg" + "\">Clique aqui para restaurar a senha!</a>");

                mail.ConnectSMTPServer("smtp.gmail.com", 587, "olymposatleticas@gmail.com", "olympos123");

                mail.SendEmail();

                return new HttpRes(204);
            }
            catch (Exception ex)
            {
                return new HttpRes(400, ex.Message);
            }
        }

        public HttpRes MudancaSenha(int id, string senha)
        {
            Env settings = new Env();
            try
            {
                Atletica atletica = _context.Atleticas.SingleOrDefault(u => u.AtleticaId == id);

                Atletica atleticaNova = atletica;

                atleticaNova.Senha = settings.Encriptografia(atletica.Senha);

                _context.Entry(atletica).CurrentValues.SetValues(atleticaNova);

                _context.SaveChanges();

                return new HttpRes(200);
            }
            catch (Exception ex)
            {
                if (ex.InnerException == null)
                    return new HttpRes(400, ex.Message);

                return new HttpRes(400, ex.InnerException.Message);
            }
        }
    }
}
