using Back_Atletica.Data;
using Back_Atletica.Models;
using Back_Atletica.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Repository.Implementação
{
    public class FaculdadeRepositoryImpl : IFaculdadeRepository
    {
        AtleticaContext _context;

        public FaculdadeRepositoryImpl(AtleticaContext context)
        {
            _context = context;
        }

        public HttpRes BuscarTodas()
        {
            List<Faculdade> faculdades = _context.Faculdades.ToList();
            return new HttpRes(200, faculdades);
        }
    }
}
