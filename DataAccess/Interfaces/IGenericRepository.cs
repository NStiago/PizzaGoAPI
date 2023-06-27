﻿using Microsoft.EntityFrameworkCore.Query;

namespace PizzaGoAPI.DataAccess.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllAsync(Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null);
        T Get(int id);
        Task<T?> GetAsync(int id);
        void Create(T entity);
        void CreateAsync(T entity);
        void Update(T entity);
        void UpdateAsync(T entity);
        void Delete(int id);
        void DeleteAsync(int id);
    }
}