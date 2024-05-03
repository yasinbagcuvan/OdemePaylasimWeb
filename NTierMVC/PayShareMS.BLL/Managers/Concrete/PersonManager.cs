using PayShare.DAL.Context;
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
    public class PersonManager : Manager<PersonDto,Person>
    {
        
        public PersonManager(PersonService personService)
        {
			_service = personService;
        }

    }
}
