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
    // Dette repository vil håndtere datalagring og -hentning relateret til booking i API'en
    [ApiController]
    [Route("api/booking")]
    public class BookingController : ControllerBase
    {
        private IBookingRepository mRepo;

        public BookingController()
        {
            this.mRepo = new BookingRepository();
        }

        //Post
        //Poster informationer fra booking formen til pedel siden
        [EnableCors("policy")]
        [HttpPost]
        public void Book(BookingItems shelter)
        {
            mRepo.Book(shelter);
        }

        //Get
        //Fanger postede informationer til pedel siden
        [EnableCors("policy")]
        [HttpGet]
        public IEnumerable<BookingItems> Get()
        {
            return mRepo.getBookings();
        }

        //Delete
        //Sletter informationer fra pedel siden
        [HttpDelete]
        [Route("{id}")]

        public void Delete(int id)
        {
            mRepo.RemoveItems(id);
        }
    }
}
