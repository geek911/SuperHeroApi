using Microsoft.EntityFrameworkCore;
using SuperHeroApi.Models;

namespace SuperHeroApi.Data;

public class SuperHeroContext : DbContext
{
    readonly string _dbName;

    public DbSet<SuperHero> SuperHeroes { get; set; }
    
    public SuperHeroContext()
    {
        _dbName = $"{Environment.CurrentDirectory}{Path.PathSeparator}superhero.db";
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Data Source={_dbName}");
    }
}