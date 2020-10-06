﻿using Back_Atletica.Models;
using Back_Atletica.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Business
{
    public interface IAtleticaBusiness
    {
        HttpRes Criar(Atletica atletica);
        HttpRes BuscarTodos();
        HttpRes BuscaPorId(int id);
        HttpRes BuscaPorNome(string nome);
        HttpRes BuscaPorInstituicao(Faculdade faculdade);
        HttpRes Deletar(int id);
        HttpRes Atualizar(int id, Atletica atletica);
    }
}
