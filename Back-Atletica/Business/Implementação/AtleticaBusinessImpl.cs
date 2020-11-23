using Back_Atletica.Models;
using Back_Atletica.Repository;
using Back_Atletica.Utils;
using System.Collections.Generic;

namespace Back_Atletica.Business.Implementação
{
    public class AtleticaBusinessImpl : IAtleticaBusiness
    {

        private IAtleticaRepository _AtleticaRepository;

        public AtleticaBusinessImpl(IAtleticaRepository atleticaRepository)
        {
            _AtleticaRepository = atleticaRepository;
        }

        public HttpRes Atualizar(int id, Atletica atletica, List<int> CursosId, List<int> ImagensIds)
        {
            return _AtleticaRepository.Atualizar(id, atletica, CursosId, ImagensIds);
        }

        public HttpRes BuscaPorId(int id)
        {
            return _AtleticaRepository.BuscaPorId(id);
        }

        public HttpRes BuscaPorInstituicao(int faculdadeId)
        {
            return _AtleticaRepository.BuscaPorInstituicao(faculdadeId);
        }

        public HttpRes BuscaPorNome(string nome)
        {
            return _AtleticaRepository.BuscaPorNome(nome);
        }

        public HttpRes BuscarTodos()
        {
            return _AtleticaRepository.BuscarTodos();
        }

        public HttpRes Deletar(int atleticaId)
        {
            return _AtleticaRepository.Deletar(atleticaId);
        }

        public HttpRes ResetPin(int atleticaId)
        {
            return _AtleticaRepository.ResetPin(atleticaId);
        }

        public HttpRes RemoverMembro(int membroId, int atleticaId)
        {
            return _AtleticaRepository.RemoverMembro(membroId, atleticaId);
        }

        public HttpRes RankingAtleticas(int modalidadeId, int alteticaId)
        {
            return _AtleticaRepository.RankingAtleticas(modalidadeId, alteticaId);
        }
    }
}
