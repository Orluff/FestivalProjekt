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
    [Route("api/shift")]
    public class ShiftController : ControllerBase
    {
        private IShiftRepository mRepo;

        public ShiftController()
        {
            this.mRepo = new ShiftRepository();
        }

        //Post
        //Poster informationer fra shifts formen til koordinator siden
        [EnableCors("policy")]
        [HttpPost]
        public void Take(Shift shift)
        {
            mRepo.TakeShift(shift);
        }

        //Get
        //Fanger postede informationer til koordinator siden
        [EnableCors("policy")]
        [HttpGet]
        public IEnumerable<Shift> Get()
        {
            return mRepo.getShifts();
        }

        //Delete
        //Sletter informationer fra koordinator siden
        [HttpDelete]
        [Route("{id}")]

        public void Release(int id)
        {
            mRepo.ReleaseShift(id);
        }
    }
}
