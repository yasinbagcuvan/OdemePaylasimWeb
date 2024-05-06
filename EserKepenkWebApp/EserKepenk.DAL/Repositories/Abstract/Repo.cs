using Entities;
using EserKepenk.DAL.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EserKepenk.DAL.Repositories.Abstract
{
    public abstract class Repo<TEntity> : IRepo<TEntity> where TEntity : BaseEntity 
    {
        private EserKepenkDbContext _context;
        protected DbSet<TEntity> entities;
        protected Repo(EserKepenkDbContext context)
        {
            _context = context;
            entities = _context.Set<TEntity>();
        }

        public int Add(TEntity entity)
        {
           entities.Add(entity);
            return _context.SaveChanges();
        }

        public int Delete(TEntity entity)
        {
            entities.Remove(entity);
            return _context.SaveChanges();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().AsNoTracking().ToList();
        }

        public TEntity? GetById(int id)
        {
            return _context.Set<TEntity>().AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public int Update(TEntity entity)
        {
            TEntity orjinal = this.GetById(entity.Id);
            entity.Created = orjinal.Created;
            entity.Updated = DateTime.Now;

            _context.Update(entity);
            return _context.SaveChanges();
        }
    }
}
