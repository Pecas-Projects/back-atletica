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
            throw new NotImplementedException();
        }

        public HttpRes BuscarPorTodos()
        {
            throw new NotImplementedException();
        }

        public HttpRes BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public bool existeModalidade(int id)
        {
            return _context.Modalidades.Any(a => a.ModalidadeId == id);
        }
    }
}
