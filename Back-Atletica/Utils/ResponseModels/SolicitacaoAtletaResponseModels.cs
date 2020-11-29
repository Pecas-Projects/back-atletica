using Back_Atletica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Utils.ResponseModels
{
    public class SolicitacaoAtletaResponseModels
    {
        public class SolicitacaoAtletaResponse
        {
            public int SolicitacaoAtletaId { get; set; }
            public string Nome { get; set; }
            public string Sobrenome { get; set; }
            public string? WhatsApp { get; set; }
            public string Email { get; set; }
            public bool Aprovado { get; set; }
            public char Genero { get; set; }
            public DateTime? AnoEntradaFacul { get; set; }
            public List<ModalidadeResponse> ModalidadesInteresse { get; set; }

            public SolicitacaoAtletaResponse Transform(SolicitacaoAtleta solicitacaoAtleta)
            {
                SolicitacaoAtletaResponse sa = new SolicitacaoAtletaResponse
                {
                    SolicitacaoAtletaId = solicitacaoAtleta.SolicitacaoAtletaId,
                    Nome = solicitacaoAtleta.Nome,
                    Sobrenome = solicitacaoAtleta.Sobrenome,
                    WhatsApp = solicitacaoAtleta.WhatsApp,
                    Email = solicitacaoAtleta.Email,
                    Aprovado = solicitacaoAtleta.Aprovado,
                    Genero = solicitacaoAtleta.Genero
                };

                if (solicitacaoAtleta.SolicitacaoAtletaModalidades.Count() > 0)
                {
                    List<ModalidadeResponse> list = new List<ModalidadeResponse>();
                    foreach (SolicitacaoAtletaModalidade s in solicitacaoAtleta.SolicitacaoAtletaModalidades)
                   {
                       
                        if(s.Modalidade != null)
                        {
                            ModalidadeResponse m = new ModalidadeResponse();

                            list.Add(m.Transform(s.Modalidade));
                        }
                        
                    }
                    sa.ModalidadesInteresse = list;
                }

                return sa;
            }
        }

        public class ModalidadeResponse
        {
            public int ModalidadeId { get; set; }
            public string Nome { get; set; }
            public string Genero { get; set; }

            public ModalidadeResponse Transform(Modalidade modalidade)
            {
                ModalidadeResponse m = new ModalidadeResponse
                {
                    ModalidadeId = modalidade.ModalidadeId,
                    Nome = modalidade.Nome,
                    Genero = modalidade.Genero
                };
                return m;
            }
        }
    }
}
