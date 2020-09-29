using Back_Atletica.Data;
using Back_Atletica.Models;
using Back_Atletica.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Repository.Implementação
{
    public class FuncaoRepositoryImpl : IFuncaoRepository
    {
        AtleticaContext context;

        public FuncaoRepositoryImpl(AtleticaContext cntxt)
        {
            context = cntxt;
        }

        public HttpRes Create(Funcao funcao)
        {
            throw new NotImplementedException();
        }

        public HttpRes Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool existeFuncao(Funcao funcao)
        {
            throw new NotImplementedException();
        }

        public HttpRes GetById(int id)
        {
            throw new NotImplementedException();
        }

        public HttpRes Update(Funcao funcao)
        {
            throw new NotImplementedException();
        }
    }
}
