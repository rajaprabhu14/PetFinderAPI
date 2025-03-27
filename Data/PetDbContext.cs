using Microsoft.EntityFrameworkCore;
using PetFinder.Entities;

namespace PetFinder.Data;

public class PetDbContext : DbContext
{
    public PetDbContext(DbContextOptions<PetDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<Pet> Pets { get; set; }
}
