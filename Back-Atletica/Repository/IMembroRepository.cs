﻿using Back_Atletica.Models;
using Back_Atletica.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Repository
{
    public interface IMembroRepository
    {
        HttpRes Criar(Membro membro);
        HttpRes BuscarPorNome(int atleticaId, string nome);
        HttpRes BuscarPorId(int id);
        HttpRes BuscarTodosNaAtletica(int atleticaId);
        HttpRes BuscarTodos();
        HttpRes Atualizar(int id, Membro membro);
        HttpRes Deletar(int id);
        bool existeMembro(Membro membro);
        bool existeMembro(int membroId);
    }
}
