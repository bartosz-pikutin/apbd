using Zad3.Model;

namespace Zad3.Repositories;

public interface IAnimalRepository
{
    IEnumerable<Animal> GetAnimal(string orderBy);
    int CreateAnimal(Animal animal);
    int UpdateAnimal(Animal animal);
    int DeleteAnimal(int idAnimal);
}