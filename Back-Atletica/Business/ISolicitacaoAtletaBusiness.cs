﻿using Back_Atletica.Models;
using Back_Atletica.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Business
{
    public interface ISolicitacaoAtletaBusiness
    {
        HttpRes CriarSolicitacaoAtletas(SolicitacaoAtleta solicitacaoAtleta, List<int> ModalidadesId);
        HttpRes BuscarTodas(int atleticaId);
        HttpRes DeletarSolicitacaoAtleta(int solicitacaoAtletaId);
        HttpRes DeletarSolicitacaoAtletaAprovado(int solicitacaoAtletaId);
    }
}
