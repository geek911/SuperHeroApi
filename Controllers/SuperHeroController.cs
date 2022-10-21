using Microsoft.AspNetCore.Mvc;
using SuperHeroApi.Models;

namespace SuperHeroApi.Controllers;


[ApiController]
[Route("api/[controller]")]
public class SuperHeroController : ControllerBase
{
    
    static List<SuperHero> heroes = new List<SuperHero>
    {
        new()
        {
            Id = 1,
            Firstname = "Peter",
            Lastname = "Parker",
            Place = "New York City"
        }
    };
    
    [HttpGet]
    public IActionResult Get()
    {

        return Ok(heroes);
    }
    
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var hero = heroes.FirstOrDefault(hero => hero.Id == id);

        if (hero is null)
        {
            return NotFound();
        }
        
        return Ok(heroes);
    }



    [HttpPost]
    public IActionResult Post([FromBody] SuperHero hero)
    {
        if (heroes.Count > 0)
        {
            int lastId = heroes[^1].Id;

            hero.Id = lastId + 1;
            heroes.Add(hero);
            return Ok(hero);
        }
        else
        {
            return BadRequest("Was not able to save");
        }



    }

    public IActionResult Delete(int id)
    {
        var elementsRemoved = heroes.RemoveAll(h => h.Id == id);

        if (elementsRemoved > 0)
        {
            return Ok(elementsRemoved);
        }
        else
        {
            return BadRequest();
        }
    }
}