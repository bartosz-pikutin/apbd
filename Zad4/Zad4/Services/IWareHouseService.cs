using Zad4.Model;

namespace Zad4.Services;

public interface IWareHouseService
{
    IEnumerable<Animal> GetAnimal(String orderBy);
    int CreateAnimal(Animal animal);
    int UpdateAnimal(Animal animal);
    int DeleteAnimal(int idAnimal);
}