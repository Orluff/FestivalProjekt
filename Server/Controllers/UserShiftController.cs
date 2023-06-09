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
    // Dette repository vil håndtere datalagring og -hentning relateret til brugerens vagter i API'en
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
        //Poster informationer fra usershift formen til koordinator siden
        //Tilføjer den valgte vagt til brugerens vagtliste
        [EnableCors("policy")]
        [HttpPost]
        public void Take(UserShiftDTO shift)
        {
            shiftRepo.TakeShift(shift);
        }

        //Get
        //Fanger postede informationer til koordinator siden
        //Returnerer en liste over UserShiftDTO'er (brugerens vagter)
        [EnableCors("policy")]
        [HttpGet]
        public IEnumerable<UserShiftDTO> Get()
        {
            return shiftRepo.GetUserShifts();
        }

        //Delete
        //Sletter informationer fra koordinator siden
        //Slet den valgte vagt fra brugerens vagtliste
        [EnableCors("policy")]
        [HttpDelete]
        [Route("{id}")]

        public void Remove(int id)
        {
            shiftRepo.RemoveShift(id);
        }
    }
}
