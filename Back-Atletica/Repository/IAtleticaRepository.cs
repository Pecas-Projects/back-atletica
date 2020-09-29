using Back_Atletica.Models;
using Back_Atletica.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Repository
{
    public interface IAtleticaRepository
    {
        HttpRes Create(Atletica atletica);

        void Biruliru();
    }
}
