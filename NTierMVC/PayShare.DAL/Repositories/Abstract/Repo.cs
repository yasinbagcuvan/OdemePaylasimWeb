using PayShare.DAL.Context;
using PayShareMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayShare.DAL.Repositories.Abstract
{
	public abstract class Repo<TEntity> : IRepo<TEntity> where TEntity : BaseEntity
	{
		private PayShareDbContext _dbContext;
        protected Repo(PayShareDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int Add(TEntity entity)
		{
			entity.Created = DateTime.Now;
			_dbContext.Add(entity);
			return _dbContext.SaveChanges();
		}

		public int Delete(TEntity entity)
		{
			_dbContext.Remove(entity);
			return _dbContext.SaveChanges();
		}

		public IEnumerable<TEntity> GetAll()
		{
			return _dbContext.Set<TEntity>().ToList();
		}

		public TEntity? GetById(int id)
		{
			return _dbContext.Set<TEntity>().Find(id);
		}

		public int Update(TEntity entity)
		{
			entity.Updated = DateTime.Now;
			_dbContext.Update(entity);
			return _dbContext.SaveChanges();
		}
	}
}
