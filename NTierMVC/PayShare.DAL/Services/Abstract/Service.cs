﻿using AutoMapper;
using PayShare.DAL.Repositories.Abstract;
using PayShareMS.DTO;
using PayShareMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace PayShare.DAL.Services.Abstract
{
	public abstract class Service<TEntity, TDto> : IService<TDto> where TEntity : BaseEntity where TDto : BaseDto
	{
		protected  IMapper _mapper;
		public Repo<TEntity> _repo;


		public Service(Repo<TEntity> repo)
		{
			MapperConfiguration configuration = new MapperConfiguration(configuration =>
			{
				configuration.CreateMap<TDto,TEntity>().ReverseMap();


			});
			
			_mapper = configuration.CreateMapper();
			_repo = repo;
		}

        public IMapper Mapper
        {
            set { _mapper = value; }
        }

        public int Add(TDto dto)
		{
			TEntity entity = _mapper.Map<TEntity>(dto) ;
			return _repo.Add(entity);
		}

		public int Delete(TDto dto)
		{
			TEntity entity = _mapper.Map<TEntity>(dto);
			return _repo.Delete(entity);
		}

		public IEnumerable<TDto> GetAll()
		{
			IEnumerable<TEntity> entities = _repo.GetAll();

			IEnumerable<TDto> dtos = _mapper.Map<IEnumerable<TDto>>(entities);

			return dtos;
		}

		public TDto? GetById(int id)
		{
			TEntity? entity = _repo.GetById(id);

			TDto? dto = _mapper.Map<TDto>(entity);

			return dto;
		}

		public int Update(TDto dto)
		{
			TEntity entity = _mapper.Map<TEntity>(dto);
			
			return _repo.Update(entity);
		}
	}
}
