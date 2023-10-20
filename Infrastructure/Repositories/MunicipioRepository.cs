using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class MunicipioRepository : GenericRepository<Municipio>, IMunicipio
    {
        private readonly SantiagoRopaContext _context;
        public MunicipioRepository(SantiagoRopaContext context) : base(context)
        {
            _context = context;
        }
    }
}