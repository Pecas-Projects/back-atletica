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
    public class AtleticaBusinessImpl : IAtleticaBusiness
    {

        private IAtleticaRepository _AtleticaRepository;

        public AtleticaBusinessImpl(IAtleticaRepository atleticaRepository)
        {
            _AtleticaRepository = atleticaRepository;
        }

        public HttpRes Atualizar(int id, Atletica atletica)
        {
            return _AtleticaRepository.Atualizar(id, atletica);
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

        public HttpRes Deletar(int id)
        {
            return _AtleticaRepository.Deletar(id);
        }
    }
}
