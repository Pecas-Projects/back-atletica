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
            if (membro == null)
            {
                return new HttpRes(400, "Verifique os dados enviados");
            }

            try
            {
                Membro membroDate = context.Membros.SingleOrDefault(a => a.MembroId == id);

                if (membroDate == null) return new HttpRes(404, "Membro não encontrado");

                membro.MembroId = id;
                membro.Senha = membroDate.Senha;
                membro.ImagemId = membroDate.ImagemId;

                context.Entry(membroDate).CurrentValues.SetValues(membro);
            }
            catch (Exception ex)
            {
                if (ex.InnerException == null) return new HttpRes(400, ex.Message);
                return new HttpRes(400, ex.InnerException.Message);
            }

            return new HttpRes(200, membro);
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
            var membros = new List<Membro>();

            AtleticaRepositoryImpl atletica = new AtleticaRepositoryImpl(context);

            if (!atletica.existeAtletica(atleticaId))
            {
                return new HttpRes(404, "Não existe nenhuma atlética com este id");
            }

            try
            {
                membros = context.Membros.Where(m => m.Pessoa.AtleticaId == atleticaId &&
                    (m.Pessoa.Nome.ToLower().Contains(nome.ToLower()) || 
                    m.Pessoa.Sobrenome.ToLower().Contains(nome.ToLower()) ||
                    (m.Pessoa.Nome + " " + m.Pessoa.Sobrenome).ToLower().Contains(nome.ToLower())
                    ))
                    .OrderBy(m => EF.Functions.Like(m.Pessoa.Nome.ToUpper(), nome.ToUpper() + "%") ? 1 :
                    EF.Functions.Like(m.Pessoa.Nome.ToUpper(), "%" + nome.ToUpper()) ? 3 : 2)
                    .ToList();
            }
            catch
            {
                return new HttpRes(404, "Erro ao conectar com o banco!");
            }

            return new HttpRes(200, membros);

        }

        public HttpRes BuscarTodos()
        {
            var membros = new List<Membro>();

            try
            {
                membros = context.Membros.Include(a => a.Pessoa).ToList<Membro>();
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
            if (!existeMembro(id))
            {
                return new HttpRes(404, "Não existe nenhum membro com este id");
            }

            var membro = new Membro();
            var pessoa = new Pessoa();
            try
            {
                membro = context.Membros.Find(id);
                pessoa = context.Pessoas.Where(p => p.PessoaId == membro.PessoaId).FirstOrDefault();
                
                if(pessoa.Tipo == "AM")
                {
                    pessoa.Tipo = "A";
                }
                else if(pessoa.Tipo == "M")
                {
                    context.Pessoas.Remove(pessoa);
                }

                context.Membros.Remove(membro);
                context.SaveChanges();
            }
            catch
            {
                return new HttpRes(400, "Algo deu errado!");
            }

            return new HttpRes(204);
        }

        public bool existeMembro(Membro membro)
        {

            return context.Membros
                .Any(m => m.Pessoa.Nome == membro.Pessoa.Nome && 
                m.Pessoa.Sobrenome == membro.Pessoa.Sobrenome);
                       
        }

        public bool existeMembro(int membroId)
        {
            return  context.Membros.Any(m => m.MembroId == membroId);
        }
    }
}
