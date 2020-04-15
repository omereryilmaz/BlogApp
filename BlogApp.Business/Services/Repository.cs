namespace BlogApp.Business.Services
{
    using System;
    using System.Collections.Generic;
    using Repositories;
    using Data.Models;
    using Data.Context;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;
    using System.Linq;
    using System.Linq.Expressions;

    public class Repository<T> : IRepository<T> where T : CoreEntity
    {
        private readonly BlogContext _context;
        private DbSet<T> _entities;
        public Repository(BlogContext context)
        {
            this._context = context;
            this._entities = context.Set<T>();
        }
        public void Add(T entity)
        {
            if(entity == null) throw new ArgumentNullException("entity");
            _entities.Add(entity);
            _context.SaveChanges();
        }
        public void Update(T entity)
        {
            if(entity == null) throw new ArgumentNullException("entity");
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();            
        }
        public void Delete(Guid Id)
        {
            if(Id == null) throw new ArgumentNullException("entity");
            T entity = _entities.SingleOrDefault(s => s.Id == Id);
            _entities.Remove(entity);
            _context.SaveChanges();
        }
        public T GetById(Guid Id)
        {
            if(Id == null) throw new ArgumentNullException("entity");
            return _entities.SingleOrDefault(s => s.Id == Id);
        }
        public IEnumerable<T> GetAll()
        {
            return _entities.AsEnumerable();    
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public bool Any(Expression<Func<T, bool>> exp)
        {
            return _entities.Any(exp);
        }
    }
}