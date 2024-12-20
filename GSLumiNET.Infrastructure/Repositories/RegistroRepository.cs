﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GSLumiNET.Domain.Entities;
using GSLumiNET.Domain.Interfaces;
using GSLumiNET.Infrastructure.AppData;

namespace GSLumiNET.Infrastructure.Repositories
{
    public class RegistroRepository : IRegistroRepository
    {
        private readonly ApplicationContext _context;

        public RegistroRepository(ApplicationContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public RegistroEntity Adicionar(RegistroEntity registro)
        {
            _context.Registro.Add(registro);
            _context.SaveChanges();
            return registro;
        }

        public RegistroEntity Editar(RegistroEntity registro)
        {
            _context.Registro.Update(registro);
            _context.SaveChanges();
            return registro;
        }

        public RegistroEntity ObterPorId(int id)
        {
            return _context.Registro.Find(id);
        }

        public IEnumerable<RegistroEntity> ObterTodos()
        {
            return _context.Registro.ToList();
        }

        public RegistroEntity Remover(int id)
        {
            var registro = _context.Registro.Find(id);
            if (registro != null)
            {
                _context.Registro.Remove(registro);
                _context.SaveChanges();
            }
            return registro;
        }
    }
}
