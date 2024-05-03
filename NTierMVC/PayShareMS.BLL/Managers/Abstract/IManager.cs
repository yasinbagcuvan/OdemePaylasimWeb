using PayShareMS.DTO;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayShareMS.BLL.Managers.Abstract
{
	public interface IManager<TDto> where TDto : BaseDto
	{
		int Add(TDto dto);
		int Update(TDto dto);
		int Delete(TDto dto);
		IEnumerable<TDto> GetAll();
		TDto? GetById(int id);
	}
}
