using Back_Atletica.Models;
using Back_Atletica.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Business
{
    public interface IProdutoBusiness
    {
        HttpRes Criar(Produto produto);
        HttpRes BuscarPorAtletica(int atleticaId);
        HttpRes BuscarPorId(int id);
        HttpRes BuscarPorNome(int atleticaId, string nome);
        HttpRes BuscarPorCategoria(int atleticaId, int categoriaId);
        HttpRes Atualizar(int id, Produto produto);
        HttpRes Deletar(int id);
    }
}
