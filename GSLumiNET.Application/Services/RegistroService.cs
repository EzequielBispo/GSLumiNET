using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GSLumiNET.Domain.Interfaces;
using GSLumiNET.Domain.Entities;

namespace GSLumiNET.Application.Services
{
    public class RegistroService : IRegistroService
    {
        private readonly IRegistroRepository _repository;

        public RegistroService(IRegistroRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public RegistroEntity AdicionarRegistro(RegistroEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "O registro não pode ser nulo.");
            }
            return _repository.Adicionar(entity);
        }

        public RegistroEntity EditarRegistro(RegistroEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "O registro não pode ser nulo.");
            }
            return _repository.Editar(entity);
        }

        public RegistroEntity ObterPorId(int id)
        {
            return _repository.ObterPorId(id) ?? throw new KeyNotFoundException($"Registro com ID {id} não encontrado.");
        }

        public RegistroEntity RemoverRegistro(int id)
        {
            var registro = _repository.Remover(id);
            if (registro == null)
            {
                throw new KeyNotFoundException($"Registro com ID {id} não encontrado.");
            }
            return registro;
        }

        public IEnumerable<RegistroEntity> ObterTodos()
        {
            return _repository.ObterTodos();
        }
    }
}
