﻿using Back_Atletica.Models;
using Back_Atletica.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Repository
{
    public interface IAutenticacaoRepository
    {
        HttpRes RegistrarAtletica(Atletica atletica, List<int> cursosIds);
        HttpRes RegistrarMembro(Membro membro);
        HttpRes LoginAtletica(Atletica atletica);
        HttpRes LoginMembro(Membro membro);
        HttpRes ResetarSenhaAtletica(string email);
        HttpRes MudancaSenha(int id, string senha);
        string GerarPIN();
    }
}
