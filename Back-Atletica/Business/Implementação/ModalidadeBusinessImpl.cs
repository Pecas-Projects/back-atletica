﻿using Back_Atletica.Models;
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


        public HttpRes Criar(Modalidade modalidade)
        {
            return _ModalidadeRepository.Criar(modalidade);
        }

        public HttpRes Deletar(int id)
        {
            return _ModalidadeRepository.Deletar(id);
        }

        public HttpRes BuscarPorTodos()
        {
            return _ModalidadeRepository.BuscarPorTodos();
        }

        public HttpRes BuscarPorId(int id)
        {
            return _ModalidadeRepository.BuscarPorId(id);
        }

        public HttpRes Atualizar(Modalidade modalidade)
        {
            return _ModalidadeRepository.Atualizar(modalidade);
        }
    }
}
