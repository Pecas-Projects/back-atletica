using Back_Atletica.Models;

namespace Back_Atletica.Utils.RequestModels
{
    public class EnderecoModel
    {
        public class CampusModel
        {
            public string Nome { get; set; }
            public string Cidade { get; set; }
            public string Bairro { get; set; }
            public string Rua { get; set; }
            public string Estado { get; set; }
            public string CEP { get; set; }
            public string Complemento { get; set; }
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
                    Complemento = Complemento,
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
    }
}
