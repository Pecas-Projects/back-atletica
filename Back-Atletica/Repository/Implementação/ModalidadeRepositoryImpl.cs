using Back_Atletica.Data;
using Back_Atletica.Models;
using Back_Atletica.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Back_Atletica.Utils.ResponseModels.ModalidadeResponseModels;

namespace Back_Atletica.Repository.Implementação
{
    public class ModalidadeRepositoryImpl : IModalidadeRepository
    {
        AtleticaContext _context;

        public ModalidadeRepositoryImpl(AtleticaContext context)
        {
            _context = context;
        }

        public HttpRes Criar(Modalidade modalidade)
        {
            _context.Modalidades.Add(modalidade);
            _context.SaveChanges();

            return new HttpRes(200, modalidade);
        }

        public HttpRes CriarAtleticaModalidade(AtleticaModalidade modalidade)
        {
            _context.AtleticaModalidades.Add(modalidade);
            _context.SaveChanges();

            return new HttpRes(200, modalidade);
        }

        public HttpRes Deletar(int id)
        {
            var modalidade = _context.Modalidades.Find(id);
            if (modalidade == null)
            {
                return new HttpRes(404, "Não existe nenhum modalidade com este id");
            }

            _context.Modalidades.Remove(modalidade);
            _context.SaveChanges();

            return new HttpRes(204);
        }

        public HttpRes ExcluiModalidade(int atleticaModalidadeId)
        {
            AtleticaModalidade modalidade = _context.AtleticaModalidades.SingleOrDefault(a => a.AtleticaModalidadeId == atleticaModalidadeId);

            if (modalidade == null)
            {
                return new HttpRes(404, "Modalidade não encontrada");
            }

            _context.AtleticaModalidades.Remove(modalidade);
            _context.SaveChanges();

            return new HttpRes(204);
        }

        public HttpRes BuscarPorTodos()
        {
            return new HttpRes(200, _context.Modalidades.ToList());
        }

        public HttpRes BuscarTodosNaAtletica(int atleticaId)
        {
            Atletica atletica = _context.Atleticas.SingleOrDefault(a => a.AtleticaId == atleticaId);

            if(atletica == null)
            {
                return new HttpRes(404, "Atlética não encontrada!");
            }

            List<AtleticaModalidade> atleticaModalidade = _context.AtleticaModalidades
                .Include(am => am.Modalidade)
                .Include(am => am.Imagem)
                .Include(am => am.AgendaTreinos)
                .Include(am => am.Membro).ThenInclude(a => a.Pessoa)
                .Where(am => am.AtleticaId == atleticaId).ToList();

            ModalidadesAtletica atleticaModalidades = new ModalidadesAtletica();
           
            return new HttpRes(200, atleticaModalidades.Transform(atleticaModalidade));
        }

        public HttpRes BuscarPorId(int id)
        {
            var modalidade = _context.Modalidades.Find(id);
            if (modalidade == null)
            {
                return new HttpRes(404, "Não existe nenhuma modalidade com este id");
            }
            return new HttpRes(200, modalidade);
        }

        public HttpRes AtualizaModalidadeAtletica(int atleticaModalidadeId, AtleticaModalidade modalidade)
        {
            if (modalidade == null) return new HttpRes(400, "Verifique os dados enviados");

            try
             { 
            modalidade.AtleticaModalidadeId = atleticaModalidadeId;
                AtleticaModalidade modalidadeAtletica = _context.AtleticaModalidades
                    .SingleOrDefault(m => m.AtleticaModalidadeId == atleticaModalidadeId);

                if (modalidadeAtletica == null) 
                    return new HttpRes(404, "Modalidade ou atlética não encontrada!");

                _context.Entry(modalidadeAtletica).CurrentValues.SetValues(modalidade);

                _context.SaveChanges();               

            }
            catch (Exception ex)
            {
                if (ex.InnerException == null)                 
                return new HttpRes(400, ex.InnerException.Message);
            } 

            return new HttpRes(200, modalidade);
        }

        public bool existeModalidade(int id)
        {
            return _context.Modalidades.Any(a => a.ModalidadeId == id);
        }

    }
}
