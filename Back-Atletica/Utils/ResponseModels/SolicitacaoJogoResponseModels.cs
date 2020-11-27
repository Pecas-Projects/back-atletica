using Back_Atletica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Back_Atletica.Utils.ResponseModels.SolicitacaoAtletaResponseModels;

namespace Back_Atletica.Utils.ResponseModels
{
    public class SolicitacaoJogoResponseModels
    {
        public class SolicitacaoJogoResponse
        {
            public int SolicitacaoJogoId { get; set; }
            public bool Aprovado { get; set; }
            public DateTime DataHora { get; set; }
            public string Local { get; set; }
            public AtleticaResponseModel AtleticaAdversaria { get; set; }
            public JogoCategoriaResponse JogoCategoria { get; set; }
            public ModalidadeResponse Modalidade { get; set; }

            public SolicitacaoJogoResponse Transform(SolicitacaoJogo solicitacao)
            {
                SolicitacaoJogoResponse sj = new SolicitacaoJogoResponse()
                {
                    SolicitacaoJogoId = solicitacao.SolicitacaoJogoId,
                    Aprovado = solicitacao.Aprovado,
                    DataHora = solicitacao.DataHora,
                    Local = solicitacao.Local,
                };
                if(solicitacao.AtleticaAdversaria != null)
                {
                    AtleticaResponseModel a = new AtleticaResponseModel();
                    sj.AtleticaAdversaria = a.Transform(solicitacao.AtleticaAdversaria);
                }
                if(solicitacao.JogoCategoria != null)
                {
                    JogoCategoriaResponse j = new JogoCategoriaResponse();
                    sj.JogoCategoria = j.Transform(solicitacao.JogoCategoria);
                }
                if(solicitacao.Modalidade != null)
                {
                    ModalidadeResponse m = new ModalidadeResponse();
                    sj.Modalidade = m.Transform(solicitacao.Modalidade);
                }

                return sj;
            }

        }

        public class JogoCategoriaResponse
        {
            public int JogoCategoriaId { get; set; }
            public string Nome { get; set; }
            public string? Cor { get; set; }

            public JogoCategoriaResponse Transform(JogoCategoria jogoCategoria)
            {
                JogoCategoriaResponse jc = new JogoCategoriaResponse()
                {
                    JogoCategoriaId = jogoCategoria.JogoCategoriaId,
                    Nome = jogoCategoria.Nome,
                    Cor = jogoCategoria.Cor
                };

                return jc;
            }
            
        }
    }
}
