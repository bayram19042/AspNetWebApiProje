using AspNetWebApiProje.Core.Entities;
using AspNetWebApiProje.Core.Interfaces;
using AspNetWebApiProje.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AspNetWebApiProje.Service.Services
{
    public class RepositoryService<TEntity> : IService<TEntity> where TEntity:BaseEntity
    {
        protected readonly IUow _uow;
        protected readonly IRepository<TEntity> _repo;
        public RepositoryService(IRepository<TEntity> repo,IUow uow)
        {
            _uow = uow;
            _repo = repo;
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            await _repo.CreateAsync(entity);
            await _uow.CommitAsync();
            return entity;
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _repo.GelAllAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _repo.GetByIdAsync(id);
        }

        public void Remove(int id)
        {
            _repo.Remove(id);
            _uow.Commit();
        }

        public void Update(TEntity entity)
        {
            _repo.Update(entity);
            _uow.Commit();
        }

        public async Task<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
        {
            return await _repo.Where(predicate);
        }
    }
}
