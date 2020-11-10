using Back_Atletica.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Utils.RequestModels
{
    public class AutenticacaoModel
    {

        public class EmailModel
        {
            public string Email { get; set; }

            public string Transform()
            {
                return Email;
            }
        }

        public class SenhaResetarModel
        {
            public string Senha { get; set; }

            public string Transform()
            {
                return Senha;
            }
        }

        public class LoginAtleticaModel
        {
            [Required]
            public string Credencial { get; set; }

            [Required]
            public string Senha { get; set; }

            public Atletica Transform()
            {
                Atletica atletica = new Atletica
                {
                    Email = this.Credencial,
                    Senha = this.Senha
                };

                return atletica;
            }
        }

        public class LoginMembroModel
        {
            [Required]
            public string Senha { get; set; }
            [Required]
            public SenhaModel Email { get; set; }

            public Membro Transform()
            {
                Membro membro = new Membro
                {
                    Senha = this.Senha,
                    Pessoa = this.Email.Transform()
                };

                return membro;
            }
        }

        public class SenhaModel
        {
            [Required]
            public string Email { get; set; }

            public Pessoa Transform()
            {
                Pessoa pessoa = new Pessoa
                {
                    Email = Email
                };

                return pessoa;
            }
        }

        public class RegistroMembroModel
        {

            [Required]
            public string Senha { get; set; }

            [Required]
            public PessoaModel Pessoa { get; set; }

            

            public Membro Transform()
            {
                Membro membro = new Membro
                {
                    Senha = this.Senha,
                    Pessoa = this.Pessoa.Transform()
                    
                };

                return membro;
            }
        }
    }

    public class PessoaModel
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Sobrenome { get; set; }
        [Required]
        public string Email { get; set; }
        public string Whatsapp { get; set; }
        public string Tipo { get; set; }
        public char Genero { get; set; }
        public int CursoId { get; set; }

        public Pessoa Transform()
        {
            Pessoa pessoa = new Pessoa
            {
                Nome = this.Nome,
                Sobrenome = this.Sobrenome,
                Email = Email,
                Whatsapp = this.Whatsapp,
                Tipo = this.Tipo,
                Genero = this.Genero,
                CursoId = this.CursoId
            };
            return pessoa;
        }
    }

    public class RegistroAtleticaModel 
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Senha { get; set; }
        public string Descricao { get; set; }
        public CampusModel Campus { get; set; }

        public Atletica Transform()
        {
            Atletica atletica = new Atletica
            {
                Nome = Nome,
                Email = Email,
                Senha = Senha,
                Descricao = Descricao,
                Campus = Campus.Transform()
            };

            return atletica;
        }
    }
    public class CampusModel
    {
        public string Nome { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Rua { get; set; }
        public string Estado { get; set; }
        public string CEP { get; set; }
        public FaculdadeModel Faculdade { get; set; }

        public Campus Transform()
        {
            Campus campos = new Campus
            {
                Nome = Nome,
                Cidade = Cidade,
                Bairro = Bairro,
                Rua = Rua,
                Estado = Estado,
                CEP = CEP,
                Faculdade = Faculdade.Transform()
            };

            return campos;
        }
    }

    public class FaculdadeModel
    {
        public string Nome { get; set; }

        public Faculdade Transform()
        {
            Faculdade faculdade = new Faculdade
            {
                Nome = this.Nome
            };

            return faculdade;
        }

    }

    public class CursoModel
    {
        [Required]
        public string Nome { get; set; }

        public Curso Transform()
        {
            Curso curso = new Curso
            {
                Nome = this.Nome
            };

            return curso;
        }
    }
}
