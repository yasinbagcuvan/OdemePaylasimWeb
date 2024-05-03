using PayShare.DAL.Context;
using PayShare.DAL.Repositories.Abstract;
using PayShareMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayShare.DAL.Repositories.Concrete
{
	public class EventRepo : Repo<Event>
	{
        public EventRepo(PayShareDbContext dbContext) : base(dbContext)
        {
            
        }
    }
}
