using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Server.Repositories;
using Server;

namespace Server.Controllers
{
        // Dette repository vil håndtere datalagring og -hentning relateret til rollerne i API'en
        [ApiController]
        [Route("api/role")]
        public class RoleController : ControllerBase
        {
            private IRoleRepository rRepo;

            public RoleController()
            {
                this.rRepo = new RoleRepository();
            }

            //Get
            //Fanger postede informationer til koordinator siden
            // Returnerer en liste over RoleDTO'er (rollerne)
            [EnableCors("policy")]
            [HttpGet]
            public IEnumerable<RoleDTO> Get()
            {
                return rRepo.getRole();
            }
        }

    }