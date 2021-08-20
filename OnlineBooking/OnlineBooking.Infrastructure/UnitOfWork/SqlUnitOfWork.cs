using Microsoft.Extensions.Configuration;
using OnlineBooking.Domain.SeedWork;
using System;

namespace OnlineBooking.Application.Repositories
{
    public class SqlUnitOfWork : IUnitOfWork
    {
        private readonly IDbContext _context;
        private bool _disposed;

        public SqlUnitOfWork(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("umbracoDbDSN");
            _context = new AdoDbContext(connectionString);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                _context.Dispose();
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
