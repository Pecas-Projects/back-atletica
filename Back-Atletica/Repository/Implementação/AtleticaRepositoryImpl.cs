using Back_Atletica.Data;
using Back_Atletica.Models;
using Back_Atletica.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Repository.Implementação
{
    public class AtleticaRepositoryImpl : IAtleticaRepository
    {
        AtleticaContext _context;

        public AtleticaRepositoryImpl(AtleticaContext context)
        {
            _context = context;
        }

        public void Biruliru()
        {
            throw new NotImplementedException();
        }

        public HttpRes Create(Atletica atletica)
        {
            _context.Add(atletica);

            _context.SaveChanges();

            return new HttpRes(201, atletica);
        }
    }
}
