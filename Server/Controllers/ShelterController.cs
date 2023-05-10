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
        private IBookingRepository mRepo;

        public ShelterController()
		{
            this.mRepo = new BookingRepository();
        }

        //Fanger informationer om shelters
        [EnableCors("policy")]
        [HttpGet]
        public IEnumerable<ShelterItems> Get()
        {
            return mRepo.getShelters();
        }
    }
}

