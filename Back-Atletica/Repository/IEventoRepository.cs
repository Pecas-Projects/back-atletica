using Back_Atletica.Models;
using Back_Atletica.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Repository
{
    public interface IEventoRepository
    {
        HttpRes CriarEvento(Evento evento, int atleticaId);
        HttpRes BuscarTodos(int atleticaId);
        HttpRes BuscarPorCategoria(int atleticaId, string nomeCategoria);
        HttpRes AtualizarEvento(int eventoId, Evento evento);
        HttpRes DeletarEvento(int eventoId);
    }
}
