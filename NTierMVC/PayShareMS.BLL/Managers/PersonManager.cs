using PayShare.DAL.Context;
using PayShare.DAL.Services.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayShareMS.BLL.Managers
{
	public class PersonManager
	{
		private PersonService _personService;
        public PersonManager(PayShareDbContext dbContext)
        {
            _personService = new PersonService(dbContext);
        }

    }
}
