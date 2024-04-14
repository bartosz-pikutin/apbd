using Zad3.Model;

namespace Zad3.Repositories;


public interface IAnimalRepository
{
    IEnumerable<Animal> GetAnimal();
    int CreateAnimal(Animal animal);
    Animal GetAnimal(int idAnimal);
    int UpdateAnimal(Animal animal);
    int DeleteAnimal(int idAnimal);
    
}