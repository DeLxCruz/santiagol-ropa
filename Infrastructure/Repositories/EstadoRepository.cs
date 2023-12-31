using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class EstadoRepository : GenericRepository<Estado>, IEstado
    {
        
        private readonly RopaApiContext _context;

        public EstadoRepository(RopaApiContext context) : base(context)
        {
            _context = context;
        }

    }
}