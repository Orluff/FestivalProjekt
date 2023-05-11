using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using DnsClient;
using Server.Repositories;
using Server;

namespace Server.Controllers
{
    [ApiController]
    [Route("api/shelter")]
    public class ShelterController : ControllerBase 
	{
        private IShiftRepository mRepo;

        public ShelterController()
		{
            this.mRepo = new ShiftRepository();
        }

        //Fanger informationer om shelters
        [EnableCors("policy")]
        [HttpGet]
        public IEnumerable<ShiftDTO> Get()
        {
            return mRepo.getShifts();
        }
    }
}

