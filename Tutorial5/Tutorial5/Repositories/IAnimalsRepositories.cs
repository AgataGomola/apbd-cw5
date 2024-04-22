using Tutorial5.Models;
using Tutorial5.Models.DTOs;

namespace Tutorial5.Repositories;

public interface IAnimalsRepositories
{
    IEnumerable<Animal> GetAnimals();
    int CreateAnimal(AddAnimal animal);
    int UpdateAnimal(AddAnimal animal);
    int DeleteAnimal(int id);

}