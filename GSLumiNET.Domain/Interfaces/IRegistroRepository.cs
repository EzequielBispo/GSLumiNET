using GSLumiNET.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSLumiNET.Domain.Interfaces
{
    public interface IRegistroRepository
    {
        RegistroEntity? ObterPorId(int id);
        IEnumerable<RegistroEntity>? ObterTodos();
        RegistroEntity? Adicionar(RegistroEntity registro);
        RegistroEntity? Editar(RegistroEntity registro);
        RegistroEntity? Remover(int id);
    }
}
