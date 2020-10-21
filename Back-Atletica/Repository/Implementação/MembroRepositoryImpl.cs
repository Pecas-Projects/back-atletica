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
            var membros = new List<Membro>();

            try
            {
                membros = context.Membros.ToList<Membro>();
            }
            catch
            {
                return new HttpRes(404, "Erro ao conectar com o banco!");
            }

            return new HttpRes(200, membros);
        }

        public HttpRes Criar(Membro membro)
        {
            throw new NotImplementedException();
        }

        public HttpRes Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public bool existeMembro(Membro membro)
        {
            bool existe = false;

            try
            {
                existe = context.Membros.Any(m => m.Pessoa.Nome == membro.Pessoa.Nome && m.Pessoa.Sobrenome == membro.Pessoa.Sobrenome);
            }
            catch
            {
                Console.WriteLine("Ocorreu algum erro!");
            }

            return existe;
        }
    }
}
