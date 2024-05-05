using AutoMapper;
using PayShare.DAL.Repositories.Concrete;
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
	public class GeneralLedgerService : Service<GeneralLedger, GeneralLedgerDto>
	{
		public GeneralLedgerService(GeneralLedgerRepo repo) : base(repo)
		{
			//base._profile = new GeneralLedgerProfile();
			MapperConfiguration config = new MapperConfiguration(config =>
			{
				Profile profile = new GeneralLedgerProfile();
				config.AddProfile(profile);
			});
			base.Mapper=config.CreateMapper();
		}
	}
}
