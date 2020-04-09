namespace BlogApp.Business.Repositories
{
    using System;
    using System.Collections.Generic;
    using BlogApp.Data.Models;
    public interface IRepository<T> where T : CoreEntity
    {
         void Add(T entity);
         void Update(T entity);
         void Delete(Guid Id);
         T GetById(Guid Id);
         IEnumerable<T> GetAll();
    }
}