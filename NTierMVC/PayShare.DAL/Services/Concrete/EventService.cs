﻿using PayShare.DAL.Repositories.Concrete;
using PayShare.DAL.Services.Abstract;
using PayShareMS.BLL.Profiles;
using PayShareMS.DTO;
using PayShareMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayShare.DAL.Services.Concrete
{
	public class EventService : Service<Event, EventDto>
	{
		public EventService(EventRepo repo) : base(repo)
		{
			//base._profile = new EventProfile();
		}
	}
}
