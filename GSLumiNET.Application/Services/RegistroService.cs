using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GSLumiNET.Domain.Entities;
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
    }
}
