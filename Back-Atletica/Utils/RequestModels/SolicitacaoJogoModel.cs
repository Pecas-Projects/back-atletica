using Back_Atletica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Utils.RequestModels
{
    public class SolicitacaoJogoModel
    {
        public class CriarSolicitacaoJogoModel
        {
            public DateTime DataHora { get; set; }
            public string Local { get; set; }
            public int AtleticaConvidadaId { get; set; }
            public int JogoCategoriaId { get; set; }
            public int ModalidadeId { get; set; }

            public SolicitacaoJogo Transform()
            {
                SolicitacaoJogo solicitacao = new SolicitacaoJogo
                {
                    DataHora = DataHora,
                    Local = Local,
                    AtleticaId = AtleticaConvidadaId,
                    JogoCategoriaId = JogoCategoriaId,
                    ModalidadeId = ModalidadeId,
                    Aprovado = false
                };
                return solicitacao;
            }
        }
    }
}
