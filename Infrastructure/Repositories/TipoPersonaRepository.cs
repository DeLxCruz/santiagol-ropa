using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class TipoPersonaRepository : GenericRepository<TipoPersona>, ITipoPersona
    {
        private readonly RopaApiContext _context;

        public TipoPersonaRepository(RopaApiContext context) : base(context)
        {
            _context = context;
        }
        
    }
}