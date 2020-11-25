using Back_Atletica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Utils.RequestModels
{
    public class SolicitacaoAtletaModel
    {
        public class CriarSolicitacaoAtletaModel
        {
            public string Nome { get; set; }
            public string Sobrenome { get; set; }
            public string WhatsApp { get; set; }
            public string Email { get; set; }
            public int CursoId { get; set; }
            public char Genero { get; set; }
            public DateTime AnoEntradaFacul { get; set; }
            public List<int> ModalidadesId { get; set; }


            public SolicitacaoAtleta Transform()
            {
                SolicitacaoAtleta solicitacao = new SolicitacaoAtleta
                {
                    Nome = Nome,
                    Sobrenome = Sobrenome,
                    WhatsApp = WhatsApp,
                    Email = Email,
                    AnoEntradaFacul = AnoEntradaFacul,
                    CursoId = CursoId,
                    Genero = Genero,
                    Aprovado = false
                };

                return solicitacao;
            }
        }
    }
}
