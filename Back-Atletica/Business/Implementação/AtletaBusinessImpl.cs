using Back_Atletica.Controllers;
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

        HttpRes IAtletaBusiness.Atualizar(int atletaID, Atleta atleta)
        {
            return _atletaRepository.Atualizar(atletaID, atleta);
        }

        HttpRes IAtletaBusiness.BuscaAtivos(int atleticaID)
        {
           return _atletaRepository.BuscaAtivos(atleticaID);
        }

        HttpRes IAtletaBusiness.BuscaPorID(int atletaID)
        {
            return _atletaRepository.BuscaPorID(atletaID);
        }

        HttpRes IAtletaBusiness.BuscaPorModalidade(int modalidadeID)
        {
            return _atletaRepository.BuscaPorModalidade(modalidadeID);
        }

        HttpRes IAtletaBusiness.BuscaPorTime(int timeEscaladoID)
        {
            return _atletaRepository.BuscaPorTime(timeEscaladoID);
        }

        HttpRes IAtletaBusiness.BuscarTodos(int atleticaID)
        {
            return _atletaRepository.BuscarTodos(atleticaID);
        }

        HttpRes IAtletaBusiness.CriarAtleta(Atleta atleta)
        {
            return _atletaRepository.CriarAtleta(atleta);
        }

        HttpRes IAtletaBusiness.Deletar(int atletaID)
        {
            return _atletaRepository.Deletar(atletaID);
        }
    }
}
