using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using.Infrastructure.Data;
using Core.Interfaces;

namespace Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitoOfWork, IDisposable
    {
        private readonly RopaApiContext _context;

        public UnitOfWork(RopaApiContext context) => _context = context;
        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}