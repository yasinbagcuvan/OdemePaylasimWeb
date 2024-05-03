using AutoMapper;
using PayShare.DAL.Repositories.Abstract;
using PayShare.DAL.Services.Abstract;
using PayShareMS.DTO;
using PayShareMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayShareMS.BLL.Managers.Abstract
{
	public abstract class Manager<TDto, TEntity> where TDto : BaseDto where TEntity : BaseEntity
		
	{
		protected  Service<TEntity, TDto> _service;

		public int Add(TDto dto)	{ return _service.Add(dto);}
		public int Update(TDto dto) { return _service.Update(dto); }
		public int Delete(TDto dto) { return _service.Delete(dto); }
		public IEnumerable<TDto> GetAll() { return _service.GetAll(); }
		public TDto? GetById(int id) { return _service.GetById(id); }



	}
}
