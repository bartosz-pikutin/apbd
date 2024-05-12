using Zad4.Model;

namespace Zad4.Repositories;

public interface IWareHouseRepository
{
    IEnumerable<Animal> GetAnimal(string orderBy);
    int CreateAnimal(Animal animal);
    int UpdateAnimal(Animal animal);
    int DeleteAnimal(int idAnimal);
}