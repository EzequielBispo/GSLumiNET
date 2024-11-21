using GSLumiNET.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSLumiNET.Domain.Interfaces
{
    public interface IRegistroService
    {
        RegistroEntity EditarRegistro(RegistroEntity entity);
        RegistroEntity AdicionarRegistro(RegistroEntity entity);
        RegistroEntity ObterPorId(int id);
        RegistroEntity RemoverRegistro(int id);
        IEnumerable<RegistroEntity> ObterTodos();
    }
}
