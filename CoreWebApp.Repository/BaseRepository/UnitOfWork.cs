using CoreWebApp.Data.BaseOperation;
using CoreWebApp.Repository.BaseRepository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace CoreWebApp.Repository.BaseRepository
{
  public  class UnitOfWork : IUnitOfWork
    {
        #region constructors
        private CoreWebAppDbContext _context;
        public UnitOfWork(CoreWebAppDbContext context)
        {
            this._context = context;
        }


        #endregion

        #region private-fields
        private bool disposed;
        private readonly CoreWebAppDbContext context;

        #endregion

        #region Methods

        public IBaseRepository<T> GetRepository<T>() where T : class
        {
            var repositoryInstance = new BaseRepository<T>(_context);
            return repositoryInstance;
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }

        #endregion

        #region Disposing

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
                if (disposing)
                    _context.Dispose();
            disposed = true;
        }
        #endregion
    }
}
