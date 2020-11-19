using Back_Atletica.Models;
using System.ComponentModel.DataAnnotations;

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


}
