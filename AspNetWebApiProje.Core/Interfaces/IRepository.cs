﻿using AspNetWebApiProje.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AspNetWebApiProje.Core.Interfaces
{
    public interface IRepository<TEntity> where TEntity:BaseEntity
    {
        Task<List<TEntity>> GelAllAsync();
        Task<TEntity> GetByIdAsync(int id);
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> Where(Expression<Func<TEntity, bool>> predicate);
        void Update(TEntity entity);
        void Remove(int id);
    }
}
