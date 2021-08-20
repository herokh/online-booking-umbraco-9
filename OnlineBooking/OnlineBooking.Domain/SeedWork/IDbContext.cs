using System;

namespace OnlineBooking.Domain.SeedWork
{
    public interface IDbContext : IDisposable
    {
        void SaveChanges();
    }
}
