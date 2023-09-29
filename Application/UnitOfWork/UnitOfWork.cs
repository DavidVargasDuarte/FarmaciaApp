using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Repository;
using Domain.Interfaces;
using Persistence;

namespace Application.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly Context context;
        private PaisRepo _Paises;
        private DepartamentoRepo _Departamentos;
        public UnitOfWork(Context _context)
        {
            context = _context;
        }
        public IPais Paises
        {
            get
            {
                if (_Paises == null)
                {
                    _Paises = new(context);
                }
                return _Paises;
            }
        }
        public IDepartamento Departamentos
        {
            get
            {
                if (_Departamentos == null)
                {
                    _Departamentos = new DepartamentoRepo(context);
                }
                return _Departamentos;
            }
        }
        public void Dispose()
        {
            context.Dispose();
        }
        public async Task<int> SaveAsync()
        {
            return await context.SaveChangesAsync();
        }
    }
}