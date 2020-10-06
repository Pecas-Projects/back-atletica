using Back_Atletica.Models;
using Back_Atletica.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Business
{
    public interface ICursoBusiness
    {
        HttpRes Criar(Curso curso);
        HttpRes BuscarTodos();
        HttpRes BuscarPorId(int id);
        HttpRes BuscarPorNome(string nome);
    }
}
