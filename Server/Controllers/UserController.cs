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
    // Dette repository vil håndtere datalagring og -hentning relateret til brugere i API'en
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
        //Poster informationer fra bruger formen til koordinator siden
        //Tilføjer den modtagne bruger
        [EnableCors("policy")]
        [HttpPost]
        public void Add(UserDTO user)
        {
            userRepo.AddUser(user);
        }

        //Put
        //Opdater bruger
        [EnableCors("policy")]
        [HttpPut]
        public void Update(UserDTO user)
        {
            userRepo.UpdateUser(user);
        }

        //Get
        //Fanger postede informationer til koordinator siden
        //Returnerer en liste over UserDTO'er (brugerne)
        [EnableCors("policy")]
        [HttpGet]
        public IEnumerable<UserDTO> Get()
        {
            return userRepo.getUsers();
        }

        //Delete
        //Sletter informationer fra koordinator siden
        //Slet den valgte bruger
        [HttpDelete]
        [Route("{id}")]

        public void Remove(int id)
        {
            userRepo.RemoveUser(id);
        }
    }
}
