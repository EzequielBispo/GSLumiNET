using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GSLumiNET.Domain.Interfaces;
using System.Threading.Tasks;

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
            return _repository.EditarRegistro(entity);
        }

        public RegistroEntity AdicionarRegistro(RegistroEntity entity)
        {
            return _repository.AdicionarRegistro(entity);
        }
    }
}
