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
    // Dette repository vil håndtere datalagring og -hentning relateret til shifts i API'en
    [ApiController]
    [Route("api/category")]
    public class CategoryController : ControllerBase
    {
        private ICategoryRepository cRepo;

        public CategoryController()
        {
            this.cRepo = new CategoryRepository();
        }

        //Get
        //Fanger postede informationer til koordinator siden
        [EnableCors("policy")]
        [HttpGet]
        public IEnumerable<ShiftCategoryDTO> Get()
        {
            return cRepo.getCategories();
        }

        //Post
        //Poster informationer fra shifts formen til koordinator siden
        [EnableCors("policy")]
        [HttpPost]
        public void Add(ShiftCategoryDTO cat)
        {
            cRepo.AddCategory(cat);
        }
    }
}