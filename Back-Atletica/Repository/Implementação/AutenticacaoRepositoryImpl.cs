using Back_Atletica.Models;
using Back_Atletica.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public HttpRes LoginAtletica(Atletica atletica)
        {
            try
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
            catch (Exception ex)
            {
                if (ex.InnerException == null) return new HttpRes(400, ex.Message);
                return new HttpRes(400, ex.InnerException.Message);
            }
        }

        public HttpRes LoginMembro(Membro membro)
        {
            try
            {
                Membro dadosMembro = _context.Membros
                                .Include(m => m.Pessoa)
                                    .ThenInclude(p => p.Atletica)
                                .FirstOrDefault(p => p.Pessoa.Email == membro.Pessoa.Email);

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
            catch (Exception ex)
            {
                if (ex.InnerException == null) return new HttpRes(400, ex.Message);
                return new HttpRes(400, ex.InnerException.Message);
            }

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
                new Claim(JwtRegisteredClaimNames.Gender, "M"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken();

            if (tipo == "Reset")
            {
                token = new JwtSecurityToken(
                    issuer: Env.Issuer,
                    audience: Env.Issuer,
                    claims,
                    expires: DateTime.Now.AddMinutes(60),
                    signingCredentials: credentials
                    );
            }
            else
            {
                token = new JwtSecurityToken(
                    issuer: Env.Issuer,
                    audience: Env.Issuer,
                    claims,
                    expires: DateTime.Now.AddHours(60000),
                    signingCredentials: credentials
                    );
            }

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
                new Claim(JwtRegisteredClaimNames.Gender, "A"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken();

            if (tipo == "Reset")
            {
                token = new JwtSecurityToken(
                    issuer: Env.Issuer,
                    audience: Env.Issuer,
                    claims,
                    expires: DateTime.Now.AddMinutes(60),
                    signingCredentials: credentials
                    );
            }
            else
            {
                token = new JwtSecurityToken(
                    issuer: Env.Issuer,
                    audience: Env.Issuer,
                    claims,
                    expires: DateTime.Now.AddHours(60000),
                    signingCredentials: credentials
                    );
            }

            var encodetoken = new JwtSecurityTokenHandler().WriteToken(token);
            return encodetoken;

        }

        public HttpRes RegistrarAtletica(Atletica atletica, List<int> cursosIds)
        {
            Env hash = new Env();

            try
            {
                string encrip = hash.Encriptografia(atletica.Senha);

                atletica.Senha = encrip;
                atletica.PIN = new AtleticaPin().GerarPIN();

                foreach (int i in cursosIds)
                {
                    _context.Add(new AtleticaCurso { CursoId = i, Atletica = atletica });
                }

                foreach (ImagemAtletica imagem in atletica.ImagemAtleticas)
                {
                    _context.ImagemAtleticas.Add(imagem);
                }

                _context.SaveChanges();

                return new HttpRes(201, atletica);
            }
            catch (Exception ex)
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

                if (atletica == null)
                {
                    return new HttpRes(404, "Atletica não encontrada");
                }

                membro.Senha = hash.Encriptografia(membro.Senha);
                membro.Pessoa.Atletica = atletica;

                _context.Add(membro);

                _context.SaveChanges();

                return new HttpRes(201, membro);

            }
            catch (Exception ex)
            {
                if (ex.InnerException == null) return new HttpRes(400, ex.Message);

                return new HttpRes(400, ex.InnerException.Message);
            }
        }

        public HttpRes ResetarSenha(string email, string tipo)
        {
            try
            {
                MailAddress endEmail = new MailAddress(email);

                string emailReceiver = endEmail.Address;

                if (tipo.Equals("A"))
                {
                    Atletica atletica = _context.Atleticas.SingleOrDefault(u => u.Email == emailReceiver);

                    if (atletica == null) return new HttpRes(404);

                    var token = GerarTokenJWTAtletica(atletica, "Reset");
                    EnvioEmail mail = new EnvioEmail("Olympos", "olymposatleticas@gmail.com", "Ana", emailReceiver, "Ouvimos seu pedido de ajuda!");

                    mail.CreateEmail("Recuperação de senha Olympos",
                        "<h2>Olá " + atletica.Nome + " " + " este é um Email de recuperação de conta!</h2>"
                        + "<h3>O link é valido apenas por 1 Hora</h3>"
                        + "<a href=\"http://localhost:3000/RedefinirSenha/" + token + "\">Clique aqui para restaurar a senha!</a>");

                    mail.ConnectSMTPServer("smtp.gmail.com", 587, "olymposatleticas@gmail.com", "olympos123");

                    mail.SendEmail();
                }
                else if (tipo.Equals("M"))
                {
                    Membro membro = _context.Membros.Include(p => p.Pessoa).SingleOrDefault(u => u.Pessoa.Email == emailReceiver);

                    if (membro == null) return new HttpRes(404);

                    var token = GerarTokenJWTMembro(membro, "Reset");
                    EnvioEmail mail = new EnvioEmail("Olympos", "olymposatleticas@gmail.com", "Ana", emailReceiver, "Ouvimos seu pedido de ajuda!");

                    mail.CreateEmail("Recuperação de senha Olympos",
                        "<h2>Olá " + membro.Pessoa.Nome + " " + " este é um Email de recuperação de conta!</h2>"
                        + "<h3>O link é valido apenas por 1 Hora</h3>"
                        + "<a href=\"http://localhost:3000/RedefinirSenha/" + token + "\">Clique aqui para restaurar a senha!</a>");

                    mail.ConnectSMTPServer("smtp.gmail.com", 587, "olymposatleticas@gmail.com", "olympos123");

                    mail.SendEmail();
                }



                return new HttpRes(204);
            }
            catch (Exception ex)
            {
                return new HttpRes(400, ex.Message);
            }
        }

        public HttpRes MudancaSenha(int id, string senha, string tipo)
        {
            Env settings = new Env();
            try
            {
                if (tipo.Equals("A"))
                {
                    Atletica atletica = _context.Atleticas.SingleOrDefault(u => u.AtleticaId == id);

                    Atletica atleticaNova = atletica;

                    atleticaNova.Senha = settings.Encriptografia(senha);

                    _context.Entry(atletica).CurrentValues.SetValues(atleticaNova);

                    _context.SaveChanges();
                }
                else if (tipo.Equals("M"))
                {
                    Membro membro = _context.Membros.SingleOrDefault(m => m.MembroId == id);

                    Membro membroNovo = membro;

                    membroNovo.Senha = settings.Encriptografia(senha);

                    _context.Entry(membro).CurrentValues.SetValues(membroNovo);
                    _context.SaveChanges();
                }

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
