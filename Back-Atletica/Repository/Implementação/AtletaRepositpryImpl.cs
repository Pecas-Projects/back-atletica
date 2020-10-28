using Back_Atletica.Data;
using Back_Atletica.Models;
using Back_Atletica.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Repository.Implementação
{
    public class AtletaRepositpryImpl : IAtletaRepository
    {
        AtleticaContext _context;

        public AtletaRepositpryImpl(AtleticaContext context)
        {
            _context = context;
        }

        HttpRes IAtletaRepository.Atualizar(int id, Atleta atleta)
        {
            throw new NotImplementedException();
        }

        HttpRes IAtletaRepository.BuscaAtivos(int atleticaID)
        {
            throw new NotImplementedException();
        }

        HttpRes IAtletaRepository.BuscaPorID(int atletaID)
        {
            throw new NotImplementedException();
        }

        HttpRes IAtletaRepository.BuscaPorModalidade(int modalidadeID)
        {
            throw new NotImplementedException();
        }

        HttpRes IAtletaRepository.BuscaPorTime(int timeEscaladoID)
        {
            throw new NotImplementedException();
        }

        HttpRes IAtletaRepository.BuscarTodos(int atleticaID)
        {
            var atletas = new List<Atleta>();

            try
            {
                //atletas = _context.Atletas.Where(a => a.AtletaAtleticaModalidades. == atleticaID)
                   // .ToList();
            }
            catch
            {
                return new HttpRes(404, "Erro ao conectar com o banco!");
            }
            return new HttpRes(200, atletas);
        }

        HttpRes IAtletaRepository.CriarAtleta(Atleta atleta)
        {
            throw new NotImplementedException();

        }

        HttpRes IAtletaRepository.Deletar(int id)
        {
            throw new NotImplementedException();
        }

        bool IAtletaRepository.ExisteAtleta(int atletaID)
        {
            throw new NotImplementedException();
        }
    }
}
