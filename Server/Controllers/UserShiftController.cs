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
    // Dette repository vil håndtere datalagring og -hentning relateret til shifts i API'en
    [ApiController]
    [Route("api/usershift")]
    public class UserShiftController : ControllerBase
    {
        private IUserShiftRepository shiftRepo;

        public UserShiftController()
        {
            this.shiftRepo = new UserShiftRepository();
        }

        //Post
        //Poster informationer fra shifts formen til koordinator siden
        [EnableCors("policy")]
        [HttpPut]
        public void Take(UserShiftDTO shift)
        {
            shiftRepo.TakeShift(shift);
        }

        //Get
        //Fanger postede informationer til koordinator siden
        [EnableCors("policy")]
        [HttpGet]
        public IEnumerable<UserShiftDTO> Get()
        {
            return shiftRepo.GetUserShifts();
        }
    }
}
