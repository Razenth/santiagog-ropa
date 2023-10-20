using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class PrendaRepository : GenericRepository<Prenda>, IPrenda
    {
        private readonly SantiagoRopaContext _context;
        public PrendaRepository(SantiagoRopaContext context) : base(context)
        {
            _context = context;
        }
    }
}