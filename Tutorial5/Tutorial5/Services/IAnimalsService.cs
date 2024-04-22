using Tutorial5.Models;
using Tutorial5.Models.DTOs;

namespace Tutorial5.Services;

public interface IAnimalsService
{
    IEnumerable<Animal> GetAnimals(string orderBy);
    int CreateAnimal(AddAnimal animal);
    int UpdateAnimal(AddAnimal animal);
    int DeleteAnimal(int id);
}