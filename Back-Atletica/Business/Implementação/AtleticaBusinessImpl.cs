using Back_Atletica.Controllers;
using Back_Atletica.Models;
using Back_Atletica.Repository;
using Back_Atletica.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Business.Implementação
{
    public class AtleticaBusinessImpl : IAtleticaBusiness
    {

        private IAtleticaRepository _AtleticaRepository;

        public AtleticaBusinessImpl(IAtleticaRepository atleticaRepository)
        {
            _AtleticaRepository = atleticaRepository;
        }

        public HttpRes Create(Atletica atletica)
        {
            return _AtleticaRepository.Create(atletica);
        }

        HttpRes IAtleticaBusiness.FindAll()
        {
            throw new NotImplementedException();
        }

        HttpRes IAtleticaBusiness.FindById()
        {
            throw new NotImplementedException();
        }
    }
}
