using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroApi.Services;
using SuperHeroApi.Model;

namespace SuperHeroApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
      private  readonly ISuperHeroService  _superHeroService;

        public SuperHeroController(ISuperHeroService superHeroService)
        {
            _superHeroService = superHeroService;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAllHeroes()
        {
          return await  _superHeroService.GetAllHeroes();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<SuperHero>>> GetSingleHero(int id)
        {
           var res = await _superHeroService.GetSingleHero(id);
            if(res is null)
            {
                return NotFound("Hero not found!");
            }
            return Ok(res);
        }


        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero superHero)
        {
            var result = await _superHeroService.AddHero(superHero);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id)
        {
          var result = await _superHeroService.DeleteHero(id);   
            if(result is null)
            {
                return NotFound("Hero not found!");
            }

            return Ok(result);
        }

        [HttpPut]

        public async Task<ActionResult<List<SuperHero>>> UpdateHero(int id, SuperHero superHero)
        {
          var result = await  _superHeroService.UpdateHero(id, superHero);
            if(result is null)
            {
                return NotFound("Hero not found!");
            }
            return Ok(result);
        }
    }
}
