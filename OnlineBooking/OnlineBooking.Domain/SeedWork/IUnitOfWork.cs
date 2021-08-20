using System;

namespace OnlineBooking.Domain.SeedWork
{
    public interface IUnitOfWork : IDisposable
    {

        void Commit();
    }
}
