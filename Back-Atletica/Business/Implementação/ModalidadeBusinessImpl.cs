using Back_Atletica.Models;
using Back_Atletica.Repository;
using Back_Atletica.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_Atletica.Business.Implementação
{
    public class ModalidadeBusinessImpl : IModalidadeBusiness
    {
        private IModalidadeRepository _ModalidadeRepository;

        public ModalidadeBusinessImpl(IModalidadeRepository modalidadeRepository)
        {
            _ModalidadeRepository = modalidadeRepository;
        }


        public HttpRes Create(Modalidade modalidade)
        {
            return _ModalidadeRepository.Create(modalidade);
        }

        public HttpRes Delete(int id)
        {
            return _ModalidadeRepository.Delete(id);
        }

        public HttpRes GetAll()
        {
            return _ModalidadeRepository.GetAll();
        }

        public HttpRes GetById(int id)
        {
            return _ModalidadeRepository.GetById(id);
        }

        public HttpRes Update(Modalidade modalidade)
        {
            return _ModalidadeRepository.Update(modalidade);
        }
    }
}
