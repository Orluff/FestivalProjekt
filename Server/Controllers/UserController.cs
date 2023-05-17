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
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private IUserRepository userRepo;

        public UserController()
        {
            this.userRepo = new UserRepository();
        }

        //Post
        //Poster informationer fra shifts formen til koordinator siden
        [EnableCors("policy")]
        [HttpPost]
        public void Add(UserDTO user)
        {
            userRepo.AddUser(user);
        }

        //Post
        //Poster informationer fra shifts formen til koordinator siden
        [EnableCors("policy")]
        [HttpPut]
        public void Update(UserDTO user)
        {
            userRepo.UpdateUser(user);
        }

        //Get
        //Fanger postede informationer til koordinator siden
        [EnableCors("policy")]
        [HttpGet]
        public IEnumerable<UserDTO> Get()
        {
            return userRepo.getUsers();
        }

        //Delete
        //Sletter informationer fra koordinator siden
        [HttpDelete]
        [Route("{id}")]

        public void Remove(int id)
        {
            userRepo.RemoveUser(id);
        }
    }
}
