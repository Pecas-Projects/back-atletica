using Back_Atletica.Controllers;
using Back_Atletica.Models;
using Back_Atletica.Repository;
using Back_Atletica.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Business.Implementação
{
    public class AtletaBusinessImpl : IAtletaBusiness
    {
        private IAtletaRepository _atletaRepository;

        public AtletaBusinessImpl(IAtletaRepository atletaRepository)
        {
            _atletaRepository = atletaRepository;
        }

        public HttpRes AdicionarAtletaModalidade(int atletaId, int atleticaModalidadeId)
        {
            return _atletaRepository.AdicionarAtletaModalidade(atletaId, atleticaModalidadeId);
        }

        public HttpRes AdicionarAtletaTime(int atleticaId, int jogoId, AtletaAtleticaModalidadeTimeEscalado aamte)
        {
            return _atletaRepository.AdicionarAtletaTime(atleticaId, jogoId, aamte);
        }

        public HttpRes Atualizar(int atletaID, Atleta atleta)
        {
            return _atletaRepository.Atualizar(atletaID, atleta);
        }

        public HttpRes BuscaAtivos(int atleticaID)
        {
           return _atletaRepository.BuscaAtivos(atleticaID);
        }

        public HttpRes BuscaPorID(int atletaID)
        {
            return _atletaRepository.BuscaPorID(atletaID);
        }

        public HttpRes BuscaPorJogo(int JogoID)
        {
            return _atletaRepository.BuscaPorJogo(JogoID);
        }

        public HttpRes BuscaPorModalidade(int atleticaModalidadeId)
        {
            return _atletaRepository.BuscaPorModalidade(atleticaModalidadeId);
        }

        public HttpRes BuscarForaModalidade(int atleticaId, int modalidadeId)
        {
            return _atletaRepository.BuscarForaModalidade(atleticaId, modalidadeId);
        }

        public HttpRes BuscarPorJogo(int JogoID)
        {
            return _atletaRepository.BuscaPorJogo(JogoID);
        }

        public HttpRes BuscarTodos(int atleticaID)
        {
            return _atletaRepository.BuscarTodos(atleticaID);
        }

        public HttpRes CriarAtleta(Atleta atleta)
        {
            return _atletaRepository.CriarAtleta(atleta);
        }

        public HttpRes Deletar(int atletaID)
        {
            return _atletaRepository.Deletar(atletaID);
        }

        public HttpRes RemoverAtletaModalidade(int atletaAtleticaModalidadeId)
        {
            return _atletaRepository.RemoverAtletaModalidade(atletaAtleticaModalidadeId);
        }
    }
}
