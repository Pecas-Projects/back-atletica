using Back_Atletica.Models;
using Back_Atletica.Repository;
using Back_Atletica.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Business.Implementação
{
    public class MembroBusinessImpl : IMembroBusiness
    {
        private IMembroRepository _MembroRepository;

        public MembroBusinessImpl(IMembroRepository membroRepository)
        {
            _MembroRepository = membroRepository;
        }

        public HttpRes Atualizar(int id, Membro membro)
        {
            return _MembroRepository.Atualizar(id, membro);
        }

        public HttpRes BuscarPorId(int id)
        {
            return _MembroRepository.BuscarPorId(id);
        }

        public HttpRes BuscarPorNome(int atleticaId, string nome)
        {
            return _MembroRepository.BuscarPorNome(atleticaId, nome);
        }

        public HttpRes BuscarTodos()
        {
            return _MembroRepository.BuscarTodos();
        }

        public HttpRes BuscarTodosNaAtletica(int atleticaId)
        {
            return _MembroRepository.BuscarTodosNaAtletica(atleticaId);
        }

        public HttpRes Criar(Membro membro)
        {
            return _MembroRepository.Criar(membro);
        }

        public HttpRes Deletar(int id)
        {
            return _MembroRepository.Deletar(id);
        }
    }
}
