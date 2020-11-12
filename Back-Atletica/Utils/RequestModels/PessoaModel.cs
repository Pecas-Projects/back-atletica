using Back_Atletica.Models;
using System.ComponentModel.DataAnnotations;

namespace Back_Atletica.Utils.RequestModels
{
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
}
