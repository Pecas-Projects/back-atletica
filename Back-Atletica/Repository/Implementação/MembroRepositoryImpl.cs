using Back_Atletica.Data;
using Back_Atletica.Models;
using Back_Atletica.Utils;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Repository.Implementação
{
    public class MembroRepositoryImpl : IMembroRepository
    {
        AtleticaContext _context;

        public MembroRepositoryImpl(AtleticaContext contxt)
        {
            _context = contxt;
        }

        public HttpRes Atualizar(int id, Membro membro)
        {
            if (membro == null)
            {
                return new HttpRes(400, "Verifique os dados enviados");
            }

            try
            {
                Membro membroDate = _context.Membros.Include(i => i.Imagem).Include(p => p.Pessoa).SingleOrDefault(a => a.MembroId == id);

                if (membroDate == null) return new HttpRes(404, "Membro não encontrado");

                membro.Pessoa.AtleticaId = membroDate.Pessoa.AtleticaId;
                membro.MembroId = id;
                membro.Senha = membroDate.Senha;
                membro.PessoaId = membroDate.PessoaId;
                membro.Pessoa.PessoaId = membroDate.PessoaId;

                if (membro.ImagemId != membroDate.ImagemId)
                {
                    Account account = new Account(Env.CLOUD_NAME, Env.API_KEY, Env.API_SECRET);
                    Cloudinary cloudinary = new Cloudinary(account);
                    var deletionParams = new DeletionParams(membroDate.Imagem.PublicId);
                    cloudinary.Destroy(deletionParams);

                    _context.Remove(membroDate.Imagem);
                }

                _context.Entry(membroDate).CurrentValues.SetValues(membro);

                _context.SaveChanges();
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

            membro = _context.Membros.Include(m => m.Pessoa).SingleOrDefault(m => m.MembroId == id);

            return new HttpRes(200, membro);
        }


        public HttpRes BuscarPorNome(int atleticaId, string nome)
        {
            var membros = new List<Membro>();

            membros = _context.Membros.Include(m => m.Pessoa)
                .Where(m => m.Pessoa.AtleticaId == atleticaId &&
                (m.Pessoa.Nome.ToLower().Contains(nome.ToLower()) ||
                m.Pessoa.Sobrenome.ToLower().Contains(nome.ToLower()) ||
                (m.Pessoa.Nome + " " + m.Pessoa.Sobrenome).ToLower()
                .Contains(nome.ToLower())))
                .OrderBy(m => EF.Functions.Like(m.Pessoa.Nome.ToUpper(),
                nome.ToUpper() + "%") ? 1 : EF.Functions.Like(m.Pessoa.Nome.ToUpper(),
                "%" + nome.ToUpper()) ? 3 : 2)
                .ToList();


            return new HttpRes(200, membros);

        }

        public HttpRes BuscarTodos()
        {
            List<Membro> membros = new List<Membro>();

            membros = _context.Membros.Include(a => a.Pessoa).ToList<Membro>();

            return new HttpRes(200, membros);
        }

        public HttpRes BuscarTodosNaAtletica(int atleticaId)
        {
            List<Membro> membros = new List<Membro>();

            membros = _context.Membros.Include(a => a.Pessoa).Where(m => m.Pessoa.AtleticaId.Equals(atleticaId)).ToList<Membro>();

            return new HttpRes(200, membros);
        }

        public HttpRes Criar(Membro membro)
        {
            throw new NotImplementedException();
        }

        public HttpRes Deletar(int id)
        {
            try
            {
                if (!existeMembro(id))
                {
                    return new HttpRes(404, "Não existe membro com este id");
                }

                Membro membro = new Membro();
                Pessoa pessoa = new Pessoa();


                membro = _context.Membros.SingleOrDefault(m => m.MembroId == id);
                pessoa = _context.Pessoas.Include(p => p.Atletica).SingleOrDefault(p => p.PessoaId == membro.PessoaId);

                if (pessoa.Tipo == "AM")
                {
                    pessoa.Tipo = "A";
                }
                else if (pessoa.Tipo == "M")
                {
                    _context.Pessoas.Remove(pessoa);
                }

                _context.Membros.Remove(membro);
                pessoa.Atletica.PIN = new AtleticaPin().GerarPIN();

                _context.SaveChanges();



                return new HttpRes(204);
            }
            catch (Exception ex)
            {
                if (ex.InnerException == null) return new HttpRes(400, ex.Message);
                return new HttpRes(400, ex.InnerException.Message);
            }
        }

        public bool existeMembro(Membro membro)
        {

            return _context.Membros
                .Any(m => m.Pessoa.Nome == membro.Pessoa.Nome &&
                m.Pessoa.Sobrenome == membro.Pessoa.Sobrenome);

        }

        public bool existeMembro(int membroId)
        {
            return _context.Membros.Any(m => m.MembroId == membroId);
        }
    }
}
