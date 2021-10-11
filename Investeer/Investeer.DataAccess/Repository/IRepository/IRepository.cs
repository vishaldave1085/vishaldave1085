﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Investeer.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T:class
    {
        T Get(int id);
        IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null, string includeProperty = null);
        T GetFirstOrDefault(Expression<Func<T, bool>> filter = null, string includeProperty = null);
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Remove(int id);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}
