using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class ColorRepository : GenericRepository<Color>, IColor
    {
        private readonly SantiagoRopaContext _context;
        public ColorRepository(SantiagoRopaContext context) : base(context)
        {
            _context = context;
        }
    }
}