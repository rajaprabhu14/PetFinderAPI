using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetFinder.Entities;
using PetFinder.Infrastructure;
using PetFinder.Models;
using PetFinder.Models.Pet;
using PetFinder.Repositories;

namespace PetFinder.Services;

public class PetService(PetDbContext petDbContext) : IPetRepository
{
    private readonly PetDbContext _petDbContext = petDbContext;

    public async Task<bool> AddPetDetail(Pet pet)
    {
        _petDbContext.Pets.Add(pet);
        await _petDbContext.SaveChangesAsync();

        return true;
    }

    public async Task<List<PetDetail>> GetAll()
    {
        var response = await _petDbContext.Pets.ToListAsync();

        var pets = new List<PetDetail>();

        foreach (var item in response)
        {
            var details = new PetDetail()
            {
                Id = item.Id,
                Name = item.Name,
                ContactAddress = item.ContactAddress,
                LostCity = item.LostCity,
                FilePath = item.FilePath,
                IsFound = item.IsFound,
            };
            
            pets.Add(details);
        }

        return pets;
    }

    public async Task<bool> UpdatePet(int id)
    {
        var response = await _petDbContext.Pets.FindAsync(id);

        if(response is not null)
        {
            response.IsFound = true;
            _petDbContext.Pets.Update(response ?? new Pet());
            await _petDbContext.SaveChangesAsync();

            return true;
        }

        return false;
        
    }
}
