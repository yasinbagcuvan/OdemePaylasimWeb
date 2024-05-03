using PayShare.DAL.Services.Concrete;
using PayShareMS.BLL.Managers.Abstract;
using PayShareMS.DTO;
using PayShareMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayShareMS.BLL.Managers.Concrete
{
	public class EventManager : Manager<EventDto, Event>
	{

		public EventManager(EventService eventService)
		{
			_service = eventService;
		}
	}
}
