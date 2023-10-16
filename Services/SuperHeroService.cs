using Microsoft.AspNetCore.Mvc;
using SuperHeroApi.Model;

using SuperHeroApi.Data;
using Microsoft.EntityFrameworkCore;

namespace SuperHeroApi.Services
{
    public class SuperHeroService : ISuperHeroService
    {
        private DataContext _context;
        public SuperHeroService(DataContext context) 
        { 
            _context = context;
        }
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero superHero)
        {
            await _context.SuperHero.AddAsync(superHero); 
            await _context.SaveChangesAsync();
            return await _context.SuperHero.ToListAsync();
        }

        public async Task<ActionResult<List<SuperHero>?>> DeleteHero(int id)
        {
            var heroToDelete = await _context.SuperHero.FindAsync(id);
            if (heroToDelete is null)
            {
                return null;
            }
            _context.SuperHero.Remove(heroToDelete);
            await _context.SaveChangesAsync();
            return await _context.SuperHero.ToListAsync();
        }

        public async Task<ActionResult<List<SuperHero>>> GetAllHeroes()
        {
            return await _context.SuperHero.ToListAsync();
        }

        public async Task<ActionResult<SuperHero?>> GetSingleHero(int id)
        {
            var hero = await _context.SuperHero.FindAsync(id);
            if(hero is null)
            {
                return null;
            }
            return  hero;
        }

        public async Task<ActionResult<List<SuperHero>?>> UpdateHero(int id, SuperHero superHero)
        {
            var heroToUpdate = await _context.SuperHero.FindAsync(id);
            if (heroToUpdate is null)
            {
                return null;
            }

            heroToUpdate.FirstName= superHero.FirstName;
            heroToUpdate.LastName= superHero.LastName;
            heroToUpdate.Name= superHero.Name;
            heroToUpdate.Place= superHero.Place;

            await _context.SaveChangesAsync();

            return await _context.SuperHero.ToListAsync();

        }
    }
}
