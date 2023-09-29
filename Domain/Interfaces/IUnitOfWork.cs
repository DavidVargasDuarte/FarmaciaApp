using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IPais Paises {get;}
        IDepartamento Departamentos {get;}
        ICiudad Ciudades {get;}
        Task<int> SaveAsync();
    }
}