using Back_Atletica.Repository;
using Back_Atletica.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Business.Implementação
{
    public class JogoBusinessImpl : IJogoBusiness
    {
        private IJogoRepository _JogoRepository;

        public JogoBusinessImpl(IJogoRepository jogoRepository)
        {
            _JogoRepository = jogoRepository;
        }
        public HttpRes BuscarCategorias()
        {
            return _JogoRepository.BuscarCategorias();
        }

        public HttpRes BuscarPorAtletica(int atleticaId)
        {
            return _JogoRepository.BuscarPorAtletica(atleticaId);
        }

        public HttpRes BuscarPorId(int id)
        {
            return _JogoRepository.BuscarPorId(id);
        }

        public HttpRes BuscarPorModalidade(int atleticaModalidadeId)
        {
            return _JogoRepository.BuscarPorModalidade(atleticaModalidadeId);
        }

        public HttpRes Deletar(int id)
        {
            return _JogoRepository.Deletar(id);
        }
    }
}
