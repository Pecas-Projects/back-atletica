using Back_Atletica.Models;
using Back_Atletica.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Repository
{
    public interface IPublicacaoRepository
    {
        HttpRes Criar(Publicacao publicacao);
        HttpRes BuscarPorAtletica(int atleticaId);
        HttpRes BuscarPorId(int id);
        HttpRes Atualizar(int id, Publicacao publicacao);
        HttpRes Deletar(int id);
        bool existePublicacao(int id);
    }
}
