using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class CargoRepository : GenericRepository<Cargo>, ICargo
    {
        private readonly SantiagoRopaContext _context;
        public CargoRepository(SantiagoRopaContext context) : base(context)
        {
            _context = context;
        }
    }

}