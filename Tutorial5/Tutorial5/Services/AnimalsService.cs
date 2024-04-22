using Microsoft.AspNetCore.Mvc;
using Tutorial5.Models;
using Tutorial5.Models.DTOs;
using Tutorial5.Repositories;

namespace Tutorial5.Services;

public class AnimalsService : IAnimalsService
{
    private readonly IAnimalsRepositories _animalsRepositories;

    public AnimalsService(IAnimalsRepositories animalsRepositories)
    {
        _animalsRepositories = animalsRepositories;
    }

    public IEnumerable<Animal> GetAnimals(string? orderBy)
    {
        var animals = _animalsRepositories.GetAnimals();
        switch (orderBy?.ToLower())
        {
            case "name":
                return animals.OrderBy(a => a.Name).ToList();
            case "description":
                return animals.OrderBy(a => a.Description).ToList();
            case "category":
                return animals.OrderBy(a => a.Category).ToList();
            case "area":
                return animals.OrderBy(a => a.Area).ToList();
            default:
                return animals.OrderBy(a => a.Name).ToList();
        }
    }

    public int CreateAnimal(AddAnimal animal)
    {
        return _animalsRepositories.CreateAnimal(animal);
    }

    public int UpdateAnimal(AddAnimal animal)
    {
        return _animalsRepositories.UpdateAnimal(animal);
    }

    public int DeleteAnimal(int id)
    {
        return _animalsRepositories.DeleteAnimal(id);
    }
}