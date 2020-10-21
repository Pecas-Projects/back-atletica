using Back_Atletica.Models;
using Back_Atletica.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Repository
{
    public interface IMembroRepository
    {
        HttpRes Criar(Membro membro);
        HttpRes BuscarPorNome(string nome);
        HttpRes BuscarPorId(int id);
        HttpRes BuscarTodos();
        HttpRes Atualizar(int id, Membro membro);
        HttpRes Deletar(int id);
        HttpRes BuscarPorCargo(string nome);
        HttpRes BuscarPorDepartamento(string nome);
        bool existeMembro(Membro membro);
    }
}
