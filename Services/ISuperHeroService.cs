using Microsoft.AspNetCore.Mvc;
using SuperHeroApi.Model;

namespace SuperHeroApi.Services
{
    public interface ISuperHeroService
    {
        Task<ActionResult<List<SuperHero>>> GetAllHeroes();
        Task<ActionResult<SuperHero?>> GetSingleHero(int id);
        Task<ActionResult<List<SuperHero>>> AddHero(SuperHero superHero);
        Task<ActionResult<List<SuperHero>?>> DeleteHero(int id);
        Task<ActionResult<List<SuperHero>?>> UpdateHero(int id,SuperHero superHero);
    }
}
