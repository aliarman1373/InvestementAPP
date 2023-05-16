using InvestmentAppProd.Core.Interfaces;
using InvestmentAppProd.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentAppProd.Infrastructure.Repositories
{
    public class Repository<T> :IRepository<T> where T : class
    {
        private readonly DataContext _db;
        internal DbSet<T> dbSet;
        public Repository(DataContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
        }
        public async Task CreateAsync(T entity)
        {
            try
            {
                await dbSet.AddAsync(entity);
                await SaveChanges();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message); ;
            }

        }

        public async Task DeleteAsync(T entity)
        {

            dbSet.Remove(entity);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return dbSet.ToList();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> filter = null, bool tracked = true, string? includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            if (!tracked)
            {
                query = query.AsNoTracking();
            }
            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return await query.FirstOrDefaultAsync();
        }

        public async Task SaveChanges()
        {
            await _db.SaveChangesAsync();
        }

        public async Task<T> UpdateAsync(T entity)
        {
            dbSet.Update(entity);
            await SaveChanges();
            return entity;

        }

    }
}
