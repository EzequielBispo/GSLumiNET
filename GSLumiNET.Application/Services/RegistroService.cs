﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GSLumiNET.Domain.Interfaces;
using System.Threading.Tasks;
using GSLumiNET.Domain.Entities;

namespace GSLumiNET.Application.Services
{
    public class RegistroService : IRegistroService
    {
        private readonly IRegistroRepository _repository;

        public RegistroService(IRegistroRepository repository)
        {
            _repository = repository;
        }

        public RegistroEntity EditarRegistro(RegistroEntity entity)
        {
            return _repository.Editar(entity);
        }

        public RegistroEntity AdicionarRegistro(RegistroEntity entity)
        {
            return _repository.Adicionar(entity);
        }

        public RegistroEntity ObterPorId(int id)
        {
            return _repository.ObterPorId(id);
        }
        public RegistroEntity RemoverRegistro(int id)
        {
            return _repository.Remover(id);
        }
        public IEnumerable<RegistroEntity> ObterTodos()
        {
            return _repository.ObterTodos();
        }
    }
}
