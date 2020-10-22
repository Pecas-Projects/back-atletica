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
            throw new NotImplementedException();
        }

        public HttpRes BuscaPorId(int id)
        {
            throw new NotImplementedException();
        }

        public HttpRes BuscaPorInstituicao(Faculdade faculdade)
        {
            throw new NotImplementedException();
        }

        public HttpRes BuscaPorNome(string nome)
        {
            throw new NotImplementedException();
        }

        public HttpRes BuscarTodos()
        {
            throw new NotImplementedException();
        }

        public HttpRes Criar(Atletica atletica)
        {
            return _AtleticaRepository.Criar(atletica);
        }

        public HttpRes Deletar(int id)
        {
            throw new NotImplementedException();
        }
    }
}
