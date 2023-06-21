using E_Coms_DataAccess.Data;
using E_Coms_DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_Coms_DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _appDbContext;
        internal DbSet<T> dbset;

        public Repository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            this.dbset = _appDbContext.Set<T>();
            _appDbContext.Products.Include(u => u.Category).Include(u => u.CategoryId);
        }

        public void Add(T entity)
        {
            dbset.Add(entity);
        }

        public T Get(Expression<Func<T, bool>> filter, string? includeProps = null)
        {
            IQueryable<T> query = dbset.Where(filter);
             query = query.Where(filter);
            if (!string.IsNullOrEmpty(includeProps))
            {
                foreach (var prop in includeProps.
                    Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(prop);
                }
            }
            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll(string? includeProps = null)
        {
            IQueryable<T> query = dbset;
            if(!string.IsNullOrEmpty(includeProps))
            {
               foreach(var prop in includeProps.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(prop);
                }
            }
            return query.ToList();
        }

        public void Remove(T entity)
        {
            dbset.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            dbset.RemoveRange(entities);
        }
    }
}
