using InventoryApp.Data;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryApp.Domain.Repository;
namespace InventoryApp.Domain.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private InventoryDBContext _context;
        private IDbContextTransaction _transaction;
        private bool disposed = false;
        public UnitOfWork()
        {
            _context = new InventoryDBContext();
        }
        public object Context
        {
            get { return _context; }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                    _context.Dispose();
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Commit()
        {
            _transaction.Commit();
        }

        public void CreateTransaction()
        {
            _transaction = _context.Database.BeginTransaction();
        }

        public void Rollback()
        {
            _transaction.Rollback();
            _transaction.Dispose();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
        public class Repository<TEntity> : GenericRepository<TEntity>, IRepository<TEntity> where TEntity : class
        {
            public Repository(UnitOfWork unitOfWork) : base(unitOfWork) { }
        }
    }
}
