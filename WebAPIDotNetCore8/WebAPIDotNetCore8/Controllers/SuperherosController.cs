#nullable enable

using Microsoft.AspNetCore.Mvc;
using WebAPIDotNetCore8.Models;

namespace WebAPIDotNetCore8.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class SuperherosController : ControllerBase
    {
        private static List<SuperHeroModel> SuperHeros =
            new List<SuperHeroModel>()
            {
                new SuperHeroModel() { Id = 1, Name = "Saif" , Power = "SuperMan" },
                new SuperHeroModel() { Id = 2, Name = "Khan" , Power = "Batman" },
                new SuperHeroModel() { Id = 3, Name = "Hakro" , Power = "SpiderMan" },
                new SuperHeroModel() { Id = 4, Name = "Akber" , Power = "IronMan" },
                new SuperHeroModel() { Id = 5, Name = "Umer" , Power = "Hulk" },
                new SuperHeroModel() { Id = 6, Name = "Zain" , Power = "Strange" },
            };

        // GET api/superheros
        [HttpGet]
        public ActionResult<IEnumerable<SuperHeroModel>> GetAllSuperHeros()
        {
            return SuperHeros;
        }

        // Get by id : api/superheros/{id}
        [HttpGet("{id}")]
        public ActionResult<SuperHeroModel> GetSuperHeroById(int id)
        {
            var superHero = SuperHeros.FirstOrDefault(x => x.Id == id);

            if (superHero == null)
            {
                return NotFound();
            }

            return Ok(superHero);
        }

        //Create new superhero [Httppost]

        [HttpPost]
        public ActionResult<SuperHeroModel> CreateSuperHero(SuperHeroModel modelSuperHero)
        {
            var superHeroTemp = SuperHeros.FirstOrDefault(x => x.Id == modelSuperHero.Id);

            if (superHeroTemp == null)
            {
                SuperHeros.Add(modelSuperHero);
                return Ok(modelSuperHero);
            }

            return BadRequest();
        }

        [HttpPut("{id}")]
        public ActionResult UpdateSuperHero(SuperHeroModel superHero)
        {
            var superHeroTemp = SuperHeros.FirstOrDefault(x => x.Id == superHero.Id);

            if (superHeroTemp != null)
            {
                superHeroTemp.Power = superHero.Power;
                superHeroTemp.Name = superHero.Name;
                return Ok(superHeroTemp);
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteSuperHero(int id)
        {
            var superHeroTemp = SuperHeros.FirstOrDefault(x => x.Id == id);
            if (superHeroTemp != null)
            {
                SuperHeros.Remove(superHeroTemp);
                return Ok(SuperHeros);
            }
            return BadRequest();
        }

    }
}
