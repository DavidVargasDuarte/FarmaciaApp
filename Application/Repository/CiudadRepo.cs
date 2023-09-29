using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository
{
    public class CiudadRepo : GenericRepo<Ciudad>, ICiudad
    {
        protected readonly Context _context;

        public CiudadRepo(Context context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Departamento>> GetAllAsync()
        {
            return await _context. Ciudades

                .Include(p => p. Ciudades)
                .ToListAsync();
        }

        public override async Task<Ciudad> GetByIdAsync(int id)
        {
            return await _context. Ciudades

            .Include(p => p. Ciudades)
            .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}