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
	public class GeneralLedgerManager : Manager<GeneralLedgerDto, GeneralLedger>
	{

		public GeneralLedgerManager(GeneralLedgerService GeneralLedgerService)
		{
			_service = GeneralLedgerService;
		}
	}
}
