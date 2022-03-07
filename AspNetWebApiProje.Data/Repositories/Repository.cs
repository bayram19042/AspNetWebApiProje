using AspNetWebApiProje.Core.Entities;
using AspNetWebApiProje.Core.Interfaces;
using AspNetWebApiProje.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AspNetWebApiProje.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly PersonelContext _context;
        protected readonly DbSet<TEntity> _dbSet;
        public Repository(PersonelContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;
        }

        public async Task<List<TEntity>> GelAllAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void Remove(int id)
        {
            var silinecekVeri = _dbSet.Find(id);
            _dbSet.Remove(silinecekVeri);
        }

        public void Update(TEntity entity)
        {
            var guncellenecekVeri = _dbSet.Find(entity.Id);
            _context.Entry(guncellenecekVeri).CurrentValues.SetValues(entity);
        }

        public async Task<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.AsNoTracking().Where(predicate).SingleOrDefaultAsync();
        }
    }
}
