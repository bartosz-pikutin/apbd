using Zad3.Model;

namespace Zad3.Services;

public interface IAnimalService
{
    IEnumerable<Animal> GetAnimal();
    int CreateAnimal(Animal animal);
    int UpdateAnimal(Animal animal);
    int DeleteAnimal(int idAnimal);
}