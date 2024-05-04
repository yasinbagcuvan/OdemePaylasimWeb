using Microsoft.EntityFrameworkCore;
using PayShare.DAL.Context;
using PayShareMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace PayShare.DAL.Repositories.Abstract
{
	public abstract class Repo<TEntity> : IRepo<TEntity> where TEntity : BaseEntity
	{
		private PayShareDbContext _dbContext;
        protected DbSet<TEntity> entities;
        protected Repo(PayShareDbContext dbContext)
        {
            _dbContext = dbContext;
            entities = _dbContext.Set<TEntity>();
        }
        public int Add(TEntity entity)
		{
			entity.Created = DateTime.Now;
			//_dbContext.Entry(entity).State = EntityState.Added;
            entities.Add(entity);
			return _dbContext.SaveChanges();
		}

		public int Delete(TEntity entity)
		{
			//_dbContext.Set<TEntity>().Attach(entity);
           //_dbContext.Entry(entity).State = EntityState.Detached;
			entities.Remove(entity);
			return _dbContext.SaveChanges();
		}

		public IEnumerable<TEntity> GetAll()
		{
			return _dbContext.Set<TEntity>().AsNoTracking().ToList();
		}

		public TEntity? GetById(int id)
		{
			return _dbContext.Set<TEntity>().AsNoTracking().FirstOrDefault( x=>x.Id ==id);
		}

		public int Update(TEntity entity)
		{

			entity.Updated = DateTime.Now;
            _dbContext.Entry(entity).State = EntityState.Modified;

            entities.Update(entity);
			return _dbContext.SaveChanges();
		}
	}
}
