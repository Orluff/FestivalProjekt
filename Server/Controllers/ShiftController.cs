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
        public void Add(ShiftDTO shift)
        {
            mRepo.AddShift(shift);
        }

        //Get
        //Fanger postede informationer til koordinator siden
        [EnableCors("policy")]
        [HttpGet]
        public IEnumerable<ShiftDTO> Get()
        {
            return mRepo.getShifts();
        }

        //Delete
        //Sletter informationer fra koordinator siden
        [EnableCors("policy")]
        [HttpDelete]
        [Route("{id}")]

        public void Remove(int id)
        {
            mRepo.RemoveShift(id);
        }
    }
}
