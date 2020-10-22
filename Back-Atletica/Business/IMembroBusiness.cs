using Back_Atletica.Models;
using Back_Atletica.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Business
{
    public interface IMembroBusiness
    {
        HttpRes Criar(Membro membro);
        HttpRes BuscarPorNome(int atleticaId, string nome);
        HttpRes BuscarPorId(int id);
        HttpRes BuscarTodos(int atleticaId);
        HttpRes BuscarTodos();
        HttpRes Atualizar(int id, Membro membro);
        HttpRes Deletar(int id);
    }
}
