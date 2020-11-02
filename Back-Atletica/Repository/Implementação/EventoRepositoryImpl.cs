using Back_Atletica.Data;
using Back_Atletica.Models;
using Back_Atletica.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Repository.Implementação
{
    public class EventoRepositoryImpl : IEventoRepository
    {
        AtleticaContext _context;

        public EventoRepositoryImpl(AtleticaContext context)
        {
            _context = context;
        }

        public HttpRes AtualizarEvento(int eventoId, Evento evento)
        {
            if (evento == null)
            {
                return new HttpRes(400, "Verifique os dados enviados");
            }

            try
            {
                //if (!existeAtletica(id)) return new HttpRes(404, "Não existe nenhum atlética com este id");

                Evento eventoData = _context.Eventos.SingleOrDefault(e => e.EventoId == eventoId);
                if (eventoData == null) return new HttpRes(404, "Evento não encontrada");

                EventoCategoria categoria = new EventoCategoria();
                categoria = _context.EventoCategorias.SingleOrDefault(e => e.EventoCategoriaId == eventoData.EventoCategoriaId);

                if (evento.EventoCategoria.Nome != categoria.Nome)
                {
                    categoria = _context.EventoCategorias.SingleOrDefault(e => e.Nome == evento.EventoCategoria.Nome);

                    if (categoria == null)
                    {
                        EventoCategoria novaCategoria = new EventoCategoria();

                        novaCategoria.Nome = evento.EventoCategoria.Nome;
                        _context.EventoCategorias.Add(novaCategoria);
                        _context.SaveChanges();
                        evento.EventoCategoria = novaCategoria;
                        evento.EventoCategoriaId = novaCategoria.EventoCategoriaId;
                    }
                    {
                        evento.EventoCategoria = categoria;
                        evento.EventoCategoriaId = categoria.EventoCategoriaId;
                    }
                    
                    
                }
                else
                {
                    evento.EventoCategoriaId = eventoData.EventoCategoriaId;
                }

                evento.EventoId = eventoId;
                evento.AtleticaId = eventoData.AtleticaId;
                _context.Entry(eventoData).CurrentValues.SetValues(evento);
                _context.SaveChanges();

                return new HttpRes(200, evento);
            }
            catch (Exception ex)
            {
                if (ex.InnerException == null) return new HttpRes(400, ex.Message);
                return new HttpRes(400, ex.InnerException.Message);
            }

        }

        public HttpRes BuscarPorCategoria(int atleticaId, string nomeCategoria)
        {
            EventoCategoria categoria = _context.EventoCategorias.SingleOrDefault(e => e.Nome == nomeCategoria);
            if(categoria == null)
            {
                return new HttpRes(404, "Não existe nenhuma categoria com este nome");
            }

            Atletica atletica = _context.Atleticas.SingleOrDefault(e => e.AtleticaId == atleticaId);
            if (atletica == null)
            {
                return new HttpRes(404, "Não existe nenhuma atlética com este id");
            }

            List<Evento> eventos = _context.Eventos
                .Where(e => e.EventoCategoriaId.Equals(categoria.EventoCategoriaId) && (e.AtleticaId.Equals(atleticaId)))
                .ToList();

            return new HttpRes(200, eventos);
        }

        public HttpRes BuscarTodos(int atleticaId)
        {

            List<Evento> eventos = _context.Eventos
                .Where(e => e.AtleticaId.Equals(atleticaId))
                .ToList();

            return new HttpRes(200, eventos);
        }

        public HttpRes CriarEvento(Evento evento, int atleticaId)
        {
            Atletica atletica = new Atletica();
            EventoCategoria categoria = new EventoCategoria();

            atletica = _context.Atleticas.SingleOrDefault(e => e.AtleticaId == atleticaId);
            if (atletica == null)
            {
                return new HttpRes(404, "Atletica não encontrada");
            }
            evento.AtleticaId = atleticaId;

            categoria = _context.EventoCategorias.SingleOrDefault(e => e.Nome == evento.EventoCategoria.Nome);

            if(categoria == null)
            {
                EventoCategoria novaCategoria = new EventoCategoria();
                novaCategoria.Nome = evento.EventoCategoria.Nome;
                _context.EventoCategorias.Add(novaCategoria);
                _context.SaveChanges();
                evento.EventoCategoria = novaCategoria;
                evento.EventoCategoriaId = novaCategoria.EventoCategoriaId;
            }
            else
            {
                evento.EventoCategoria = categoria;
                evento.EventoCategoriaId = categoria.EventoCategoriaId;
            }
            
            _context.Eventos.Add(evento);
            _context.SaveChanges();

            return new HttpRes(200, evento);
        }

        public HttpRes DeletarEvento(int eventoId)
        {
            var evento = _context.Eventos.SingleOrDefault(e => e.EventoId == eventoId);
            if (evento == null)
            {
                return new HttpRes(404, "Evento não encontrado");
            }

            _context.Eventos.Remove(evento);
            _context.SaveChanges();

            return new HttpRes(204);
        }
    }
}
