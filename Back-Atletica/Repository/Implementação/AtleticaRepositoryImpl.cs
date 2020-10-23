﻿using Back_Atletica.Data;
using Back_Atletica.Models;
using Back_Atletica.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Repository.Implementação
{
    public class AtleticaRepositoryImpl : IAtleticaRepository
    {
        AtleticaContext _context;

        public AtleticaRepositoryImpl(AtleticaContext context)
        {
            _context = context;
        }

        public HttpRes Atualizar(int id, Atletica atletica)
        {
            if (atletica == null)
            {
                return new HttpRes(400, "Verifique os dados enviados");
            }

            try
            {
                //if (!existeAtletica(id)) return new HttpRes(404, "Não existe nenhum atlética com este id");

                Atletica atleticaDate = _context.Atleticas.SingleOrDefault(a => a.AtleticaId == id);

               if(atleticaDate == null ) return new HttpRes(404, "Atletica não encontrada");

                atletica.AtleticaId = id;
                atletica.CampusId = atleticaDate.CampusId;

                _context.Entry(atleticaDate).CurrentValues.SetValues(atletica);

                _context.SaveChanges();

                return new HttpRes(200, atletica);
            }
            catch (Exception ex)
            {
                if (ex.InnerException == null) return new HttpRes(400, ex.Message);
                return new HttpRes(400, ex.InnerException.Message);
            }

        }

        public HttpRes BuscaPorId(int id)
        {
            Atletica atletica = _context.Atleticas.SingleOrDefault(a => a.AtleticaId == id);
            if (atletica == null)
            {
                return new HttpRes(404, "Não existe nenhuma atlética com este id");
            }
            return new HttpRes(200, atletica);
        }

        public HttpRes BuscaPorInstituicao(int faculdadeId)
        {
            List<Atletica> atleticas = _context.Atleticas
                .Where(a => a.Campus.FaculdadeId.Equals(faculdadeId))
                .ToList();

            return new HttpRes(200, atleticas);
        }

        public HttpRes BuscaPorNome(string nome)
        {
            var atleticas = _context.Atleticas
                .Where(a => EF.Functions.Like(a.Nome.ToUpper(), "%" + nome.ToUpper() + "%"))
                .OrderBy(a => EF.Functions.Like(a.Nome.ToUpper(), nome.ToUpper() + "%") ? 1 :
                    EF.Functions.Like(a.Nome.ToUpper(), "%" + nome.ToUpper()) ? 3 : 2)
                .ToList();

            return new HttpRes(200, atleticas);
        }

        public HttpRes BuscarTodos()
        {
            return new HttpRes(200, _context.Atleticas.ToList());
        }

        public HttpRes Criar(Atletica atletica)
        {
            _context.Atleticas.Add(atletica);
            _context.SaveChanges();

            return new HttpRes(200, atletica);
        }
 
        public HttpRes Deletar(int id)
        {
            var atletica = _context.Atleticas.SingleOrDefault(a => a.AtleticaId == id);
            if (atletica == null)
            {
                return new HttpRes(404, "Atletica não encontrada");
            }

            _context.Atleticas.Remove(atletica);
            _context.SaveChanges();

            return new HttpRes(204);
        }

        public bool existeAtletica(int id)
        {
            return _context.Atleticas.Any(a => a.AtleticaId == id);
        }
    }
}
