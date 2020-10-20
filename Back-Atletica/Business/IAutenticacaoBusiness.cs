using Back_Atletica.Models;
using Back_Atletica.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Business
{
    public interface IAutenticacaoBusiness
    {
        HttpRes RegistrarAtletica(Atletica atletica);
        HttpRes RegistrarMembro(Membro membro);
        HttpRes Login(Atletica atletica);
        HttpRes ResetarSenha(string email);
    }
}
