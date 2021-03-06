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
    public class PublicacaoRepositoryImpl : IPublicacaoRepository
    {
        AtleticaContext _context;

        public PublicacaoRepositoryImpl(AtleticaContext context)
        {
            _context = context;
        }

        public HttpRes Atualizar(int id, Publicacao publicacao)
        {
            if (publicacao == null)
            {
                return new HttpRes(400, "Verifique os dados enviados");
            }
            try
            {
                Publicacao publicacaoData = _context.Publicacoes.SingleOrDefault(p => p.PublicacaoId == id && p.AtleticaId == publicacao.AtleticaId);

                if (publicacaoData == null) return new HttpRes(404, "Publicação não encontrada");

                publicacao.PublicacaoId = id;

                _context.Entry(publicacaoData).CurrentValues.SetValues(publicacao);
                _context.SaveChanges();

                return new HttpRes(200, publicacao);
            }
            catch (Exception ex)
            {
                if (ex.InnerException == null) return new HttpRes(400, ex.Message);
                return new HttpRes(400, ex.InnerException.Message);
            }
        }

        public HttpRes BuscarPorAtletica(int atleticaId)
        {
            var publicacoes = _context.Publicacoes
                .Where(p => p.Atletica.AtleticaId.Equals(atleticaId))
                .Include("Imagem")
                .ToList();

            return new HttpRes(200, publicacoes);
        }

        public HttpRes BuscarPorId(int id)
        {
            var publicacao = _context.Publicacoes.Find(id);
            if (publicacao == null)
            {
                return new HttpRes(404, "Não existe nenhuma publicação com este id");
            }
            return new HttpRes(200, publicacao);
        }

        public HttpRes Criar(Publicacao publicacao)
        {
            try
            {
                _context.Publicacoes.Add(publicacao);
                _context.SaveChanges();

                return new HttpRes(200, publicacao);
            }
            catch (Exception ex)
            {
                if (ex.InnerException == null) return new HttpRes(400, ex.Message);
                return new HttpRes(400, ex.InnerException.Message);
            }
        }

        public HttpRes Deletar(int id)
        {
            try
            {
                var publicacao = _context.Publicacoes.Find(id);
                if (publicacao == null)
                {
                    return new HttpRes(404, "Não existe nenhum publicação com este id");
                }
                // Remove a imagem da publicação também
                Imagem img = new Imagem { ImagemId = publicacao.ImagemId };
                _context.Imagens.Attach(img);
                _context.Imagens.Remove(img);

                _context.Publicacoes.Remove(publicacao);
                _context.SaveChanges();

                return new HttpRes(204);
            }
            catch (Exception ex)
            {
                if (ex.InnerException == null) return new HttpRes(400, ex.Message);
                return new HttpRes(400, ex.InnerException.Message);
            }
        }

        public bool existePublicacao(int id)
        {
            return _context.Publicacoes.Any(p => p.PublicacaoId == id);
        }
    }
}
