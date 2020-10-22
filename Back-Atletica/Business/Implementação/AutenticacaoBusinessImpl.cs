using Back_Atletica.Models;
using Back_Atletica.Repository;
using Back_Atletica.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Business.Implementação
{
    public class AutenticacaoBusinessImpl : IAutenticacaoBusiness
    {
        IAutenticacaoRepository _repositorio;

        public AutenticacaoBusinessImpl(IAutenticacaoRepository repositorio)
        {
            _repositorio = repositorio;
        }

        public HttpRes Login(Atletica atletica)
        {
            return _repositorio.Login(atletica);
        }

        public HttpRes RegistrarAtletica(Atletica atletica)
        {
            return _repositorio.RegistrarAtletica(atletica);
        }

        public HttpRes RegistrarMembro(Membro membro)
        {
            return _repositorio.RegistrarMembro(membro);
        }

        public HttpRes ResetarSenha(string email)
        {
            throw new NotImplementedException();
        }
    }
}
