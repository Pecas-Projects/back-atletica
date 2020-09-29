using Back_Atletica.Models;
using Back_Atletica.Repository;
using Back_Atletica.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Business.Implementação
{
    public class FuncaoBusinessImpl : IFuncaoBusiness
    {
        private IFuncaoRepository _FuncaoRepository;

        public FuncaoBusinessImpl(IFuncaoRepository funcaoRepository)
        {
            _FuncaoRepository = funcaoRepository;
        }

        public HttpRes Create(Funcao funcao)
        {
            return _FuncaoRepository.Create(funcao);
        }

        public HttpRes Delete(int id)
        {
            return _FuncaoRepository.Delete(id);
        }

        public HttpRes GetById(int id)
        {
            return _FuncaoRepository.GetById(id);
        }

        public HttpRes Update(Funcao funcao)
        {
            return _FuncaoRepository.Update(funcao);
        }
    }
}
