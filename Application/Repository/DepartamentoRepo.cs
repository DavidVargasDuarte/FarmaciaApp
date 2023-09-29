using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository
{
    public class DepartamentoRepo : GenericRepo<Departamento>, IDepartamento
    {

        protected readonly Context _context;

        public DepartamentoRepo(Context context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Departamento>> GetAllAsync()
        {
            return await _context.Departamentos
                .Include(p => p.Ciudades)
                .ToListAsync();
        }

        public override async Task<Departamento> GetByIdAsync(int id)
        {
            return await _context.Departamentos
            .Include(p => p.Ciudades)
            .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}