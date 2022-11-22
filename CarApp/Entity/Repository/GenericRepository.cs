using Entity.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entity.Repository
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        protected readonly AppContext _context;
        private bool disposed = false;
        public GenericRepository(AppContext obj)
        {
            _context = obj;
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task Create(T obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            await _context.Set<T>().AddAsync(obj);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(T obj)
        {
            _context.Set<T>().Remove(obj);
            await Save();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task<T> GetEntity(long id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public IEnumerable<T> GetEntityList()
        {
            return _context.Set<T>().ToList();
        }

        public async Task Update(T obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            await Save();
        }

        public void Detach(T obj)
        {
            _context.Entry(obj).State = EntityState.Detached;
            _context.SaveChanges();
        }
    }
}
