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
        HttpRes RegistrarAtletica(Atletica atletica);
        HttpRes RegistrarMembro(Membro membro);
        HttpRes Login(Atletica atletica);
        HttpRes ResetarSenha(string email);
        string GerarTokenJWT(string email);
        string GerarPIN();
    }
}