﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Server.Repositories;
using Server;

namespace Server.Controllers
{
    // Dette repository vil håndtere datalagring og -hentning relateret til shifts i API'en
    [ApiController]
    [Route("api/shift")]
    public class ShiftController : ControllerBase
    {
        private IShiftRepository shiftRepo;

        public ShiftController()
        {
            this.shiftRepo = new ShiftRepository();
        }

        //Post
        //Poster informationer fra shifts formen til koordinator siden
        [EnableCors("policy")]
        [HttpPost]
        public void Add(ShiftDTO shift)
        {
            shiftRepo.AddShift(shift);
        }

        //Get
        //Fanger postede informationer til koordinator siden
        [EnableCors("policy")]
        [HttpGet]
        public IEnumerable<ShiftDTO> Get()
        {
            return shiftRepo.getShifts();
        }

        //Delete
        //Sletter informationer fra koordinator siden
        [EnableCors("policy")]
        [HttpDelete]
        [Route("{id}")]

        public void Remove(int id)
        {
            shiftRepo.RemoveShift(id);
        }

        [EnableCors("policy")]
        [HttpPut("{id}")]
        public void RemoveSpot(int id)
        {
            var shift = new ShiftDTO { shift_id = id };
            shiftRepo.RemoveSpot(shift);
        }

        //Post
        //Poster informationer fra shifts formen til koordinator siden
        [EnableCors("policy")]
        [HttpPut]
        public void UpdateShift(ShiftDTO shift)
        {
            shiftRepo.UpdateShift(shift);
        }
    }
}