using

namespace Zad3.Services;

public class IAnimalService
{
    IEnumerable<Animal> GetAnimal();
    int CreateAnimal(Animal animal);
    int UpdateAnimal(Animal animal);
    int DeleteAnimal(int idAnimal);
}