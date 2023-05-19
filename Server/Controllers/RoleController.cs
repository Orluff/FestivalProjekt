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
            [EnableCors("policy")]
            [HttpGet]
            public IEnumerable<RoleDTO> Get()
            {
                return rRepo.getRole();
            }

            //Post
            //Poster informationer fra shifts formen til koordinator siden
           /* [EnableCors("policy")]
            [HttpPost]
            public void Add(RoleDTO role)
            {
                rRepo.AddRole(role);
            }*/
        }

    }