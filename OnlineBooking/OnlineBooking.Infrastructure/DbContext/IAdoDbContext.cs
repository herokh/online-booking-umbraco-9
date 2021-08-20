using OnlineBooking.Domain.SeedWork;
using System.Data;

namespace OnlineBooking.Infrastructure.DbContext
{
    public interface IAdoDbContext : IDbContext
    {
        IDbCommand CreateCommand();
    }
}
