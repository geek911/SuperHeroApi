using Microsoft.AspNetCore.Mvc;
using SuperHeroApi.Data;
using SuperHeroApi.Models;

namespace SuperHeroApi.Controllers;


[ApiController]
[Route("api/[controller]")]
public class SuperHeroController : ControllerBase
{

    readonly SuperHeroContext _context;
    public SuperHeroController(SuperHeroContext context)
    {
        _context = context;
    }
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var heroes =  _context.SuperHeroes.AsAsyncEnumerable();

        return Ok(heroes);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var hero = await _context.SuperHeroes.FindAsync(id);

        if (hero is null)
        {
            return NotFound();
        }
        
        return Ok(hero);
    }



    [HttpPost]
    public async Task<IActionResult> Post([FromBody] SuperHero hero)
    {
        var newHero = await _context.SuperHeroes.AddAsync(hero);

        await _context.SaveChangesAsync();

        return Ok(hero);
    }
    
    [HttpPut]
    public async Task<IActionResult> Put([FromBody] SuperHero hero)
    {
        var existingHero = await _context.SuperHeroes.FindAsync(hero.Id);

        if (existingHero is null)
        {
            _context.Add(hero);
        }
        else
        {
            _context.Update(hero);
        }

        await _context.SaveChangesAsync();

        return Ok(hero);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    { 
        var hero = await _context.SuperHeroes.FindAsync(id);

        if (hero ==null)
        {
            return NotFound();
        }

        _context.SuperHeroes.Remove(hero);
        await _context.SaveChangesAsync();

        return Ok(hero);

    }
}