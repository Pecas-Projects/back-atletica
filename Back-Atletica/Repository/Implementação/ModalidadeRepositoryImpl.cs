using Back_Atletica.Data;
using Back_Atletica.Models;
using Back_Atletica.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public HttpRes BuscarPorTodos()
        {
            return new HttpRes(200, _context.Modalidades.ToList());
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

        public bool existeModalidade(int id)
        {
            return _context.Modalidades.Any(a => a.ModalidadeId == id);
        }
    }
}
