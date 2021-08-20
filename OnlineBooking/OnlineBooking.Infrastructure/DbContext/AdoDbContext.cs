using OnlineBooking.Infrastructure.DbContext;
using System;
using System.Data;
using System.Data.SqlClient;

namespace OnlineBooking.Application.Repositories
{
    public class AdoDbContext : IAdoDbContext
    {
        private readonly IDbConnection _connection;
        private IDbTransaction _transaction;

        public AdoDbContext(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
            _connection.Open();
            _connection.BeginTransaction();
        }

        public IDbCommand CreateCommand()
        {
            var command = _connection.CreateCommand();
            command.Transaction = _transaction;
            return command;
        }
        public void SaveChanges()
        {
            if (_transaction == null)
            {
                throw new InvalidOperationException("Transaction have already been already been commited. Check your transaction handling.");
            }
            _transaction.Commit();
            _transaction = null;
        }
        public void Dispose()
        {
            if (_transaction != null)
            {
                _transaction.Rollback();
                _transaction = null;
            }
            _connection.Close();
        }
    }
}
