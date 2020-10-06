using Back_Atletica.Models;
using Back_Atletica.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Repository
{
    public interface IProdutoRepository
    {
        HttpRes Criar(Produto produto);
        HttpRes BuscarPorAtletica(int atleticaId);
        HttpRes BuscarPorId(int id);
        HttpRes BuscarPorNome(int atleticaId, string nome);
        HttpRes BuscarPorCategoria(int atleticaId, string categoria);
        HttpRes Atualizar(int id, Produto produto);
        HttpRes Deletar(int id);
        bool existeProduto(Produto produto);
    }
}
