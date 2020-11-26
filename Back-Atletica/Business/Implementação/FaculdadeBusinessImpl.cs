using Back_Atletica.Repository;
using Back_Atletica.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Business.Implementação
{
    public class FaculdadeBusinessImpl : IFaculdadeBusiness
    {
        private IFaculdadeRepository _FaculdadeRepository;

        public FaculdadeBusinessImpl(IFaculdadeRepository faculdadeRepository)
        {
            _FaculdadeRepository = faculdadeRepository;
        }
        public HttpRes BuscarTodas()
        {
            return _FaculdadeRepository.BuscarTodas();
        }
    }
}
