using Back_Atletica.Models;
using Back_Atletica.Repository;
using Back_Atletica.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Business.Implementação
{
    public class EventoBusinessImpl : IEventoBusiness
    {
        private IEventoRepository _EventoRepository;

        public EventoBusinessImpl(IEventoRepository eventorepository)
        {
            _EventoRepository = eventorepository;
        }

        public HttpRes AtualizarEvento(int eventoId, Evento evento)
        {
            return _EventoRepository.AtualizarEvento(eventoId, evento);
        }

        public HttpRes BuscarPorCategoria(int atleticaId, string nomeCategoria)
        {
            return _EventoRepository.BuscarPorCategoria(atleticaId, nomeCategoria);
        }

        public HttpRes BuscarTodos(int atleticaId)
        {
            return _EventoRepository.BuscarTodos(atleticaId);
        }

        public HttpRes CriarEvento(Evento evento)
        {
            return _EventoRepository.CriarEvento(evento);
        }

        public HttpRes DeletarEvento(int eventoId)
        {
            return _EventoRepository.DeletarEvento(eventoId);
        }
    }
}
