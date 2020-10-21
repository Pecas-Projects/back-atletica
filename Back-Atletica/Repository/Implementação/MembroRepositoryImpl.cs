using Back_Atletica.Data;
using Back_Atletica.Models;
using Back_Atletica.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Repository.Implementação
{
    public class MembroRepositoryImpl : IMembroRepository
    {
        AtleticaContext context;

        public MembroRepositoryImpl(AtleticaContext contxt)
        {
            context = contxt;
        }

        public HttpRes Atualizar(int id, Membro membro)
        {
            throw new NotImplementedException();
        }

        public HttpRes BuscarPorCargo(string nome)
        {
            throw new NotImplementedException();
        }

        public HttpRes BuscarPorDepartamento(string nome)
        {
            throw new NotImplementedException();
        }

        public HttpRes BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public HttpRes BuscarPorNome(string nome)
        {
            throw new NotImplementedException();
        }

        public HttpRes BuscarTodos()
        {
            throw new NotImplementedException();
        }

        public HttpRes Criar(Membro membro)
        {
            throw new NotImplementedException();
        }

        public HttpRes Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public bool existeMembro(string nome)
        {
            throw new NotImplementedException();
        }
    }
}
