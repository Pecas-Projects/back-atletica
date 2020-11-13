using Back_Atletica.Models;
using System.ComponentModel.DataAnnotations;

namespace Back_Atletica.Utils.RequestModels
{
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
