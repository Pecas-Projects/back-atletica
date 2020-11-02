﻿using Back_Atletica.Controllers;
using Back_Atletica.Models;
using Back_Atletica.Repository;
using Back_Atletica.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Business.Implementação
{
    public class AtletaBusinessImpl : IAtletaBusiness
    {
        private IAtletaRepository _atletaRepository;

        public AtletaBusinessImpl(IAtletaRepository atletaRepository)
        {
            _atletaRepository = atletaRepository;
        }
       
        public HttpRes Atualizar(int atletaID, Atleta atleta)
        {
            return _atletaRepository.Atualizar(atletaID, atleta);
        }

        public HttpRes BuscaAtivos(int atleticaID)
        {
           return _atletaRepository.BuscaAtivos(atleticaID);
        }

        public HttpRes BuscaPorID(int atletaID)
        {
            return _atletaRepository.BuscaPorID(atletaID);
        }

        public HttpRes BuscaPorJogo(int JogoID)
        {
            return _atletaRepository.BuscaPorJogo(JogoID);
        }

        public HttpRes BuscaPorModalidade(int modalidadeID, int atleticaID)
        {
            return _atletaRepository.BuscaPorModalidade(modalidadeID, atleticaID);
        }

        public HttpRes BuscarPorJogo(int JogoID)
        {
            return _atletaRepository.BuscaPorJogo(JogoID);
        }

        public HttpRes BuscarTodos(int atleticaID)
        {
            return _atletaRepository.BuscarTodos(atleticaID);
        }

        public HttpRes CriarAtleta(Atleta atleta)
        {
            return _atletaRepository.CriarAtleta(atleta);
        }

        public HttpRes Deletar(int atletaID)
        {
            return _atletaRepository.Deletar(atletaID);
        }
    }
}
