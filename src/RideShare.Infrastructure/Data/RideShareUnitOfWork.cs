using Microsoft.EntityFrameworkCore.Storage;
using RideShare.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RideShare.Infrastructure.Data
{
    public class RideShareUnitOfWork : IUnitOfWork
    {
        private readonly RideShareDbContext _context;
        private IDbContextTransaction? _transaction;
        public RideShareUnitOfWork(RideShareDbContext context)
        {
            _context = context;
        }
        public async Task BeginTransactionAsync(CancellationToken cancellationToken = default)
        {
            _transaction =await _context.Database.BeginTransactionAsync(cancellationToken);
        }

        public async Task CommitTransactionAsync(CancellationToken cancellationToken = default)
        {
            if (_transaction is null)
            {
                throw new InvalidOperationException("No active transaction exists.");
            }

            await _transaction.CommitAsync(cancellationToken);

            await _transaction.DisposeAsync();

            _transaction = null;
        }

        public async Task RollbackTransactionAsync(CancellationToken cancellationToken = default)
        {
            if (_transaction is null)
            {
                return;
            }

            await _transaction.RollbackAsync(cancellationToken);

            await _transaction.DisposeAsync();

            _transaction = null;
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
