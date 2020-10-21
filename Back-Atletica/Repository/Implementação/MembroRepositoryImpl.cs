using Back_Atletica.Data;
using Back_Atletica.Models;
using Back_Atletica.Utils;
using Microsoft.EntityFrameworkCore;
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
            if (id != membro.MembroId)
            {
                return new HttpRes(400, "O id passado não é o mesmo do objeto em questão");
            }

            context.Entry(membro).State = EntityState.Modified;

            try
            {
                context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!existeMembro(id))
                {
                    return new HttpRes(404, "Não existe nenhum produto com este id");
                }
                else
                {
                    return new HttpRes(400, "Ocorreu algum erro durante a atualização!");
                }
            }

            return new HttpRes(200, membro);
        }

        public HttpRes BuscarPorCargo(string nome)
        {
            throw new NotImplementedException();
        }

        public HttpRes BuscarPorCargo(int atleticaId, string nome)
        {
            throw new NotImplementedException();
        }

        public HttpRes BuscarPorDepartamento(int atleticaId, string nome)
        {
            throw new NotImplementedException();
        }

        public HttpRes BuscarPorId(int id)
        {
            Membro membro = new Membro();

            try
            {
                membro = context.Membros.Find(id);
            }
            catch
            {
                return new HttpRes(404, "Erro ao conectar com o banco!");
            }

            return new HttpRes(200, membro);
        }


        public HttpRes BuscarPorNome(int atleticaId, string nome)
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

        public HttpRes BuscarTodos(int atleticaId)
        {
            var membros = new List<Membro>();

            try
            {
                membros = context.Membros.Where(m => m.Pessoa.AtleticaId.Equals(atleticaId)).ToList<Membro>();
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

        public bool existeMembro(int membroId)
        {
            bool existe = false;

            try
            {
                existe = context.Membros.Any(m => m.MembroId == membroId);
            }
            catch
            {
                Console.WriteLine("Ocorreu algum erro!");
            }

            return existe;
        }
    }
}
