using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PhonebookApi.Data;

namespace PhonebookApi.Repositories
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        T GetById(int id);
        IEnumerable<T> Get();
        void Remove(int id);
        void Commit();
        void Update(T entity);

    }

    public class Repository<T> : IRepository<T> where T: class
    {
        protected readonly DataContext _context;

        public Repository(DataContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public IEnumerable<T> Get()
        {
            return _context.Set<T>().ToList();
        }

        public void Remove(int id)
        {
            var type = _context.Set<T>().Find(id);
            _context.Remove(type);
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}