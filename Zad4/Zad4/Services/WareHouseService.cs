using Zad4.Repositories;
using Zad4.Model;

namespace Zad4.Services;

public class WareHouseService : IWareHouseService
{
    private readonly IAnimalRepository _animalRepository;
    
    public WareHouseService(IAnimalRepository animalRepository)
    {
        _animalRepository = animalRepository;
    }

    public IEnumerable<Animal> GetAnimal(String orderBy)
    {
        //Business logic
        return _animalRepository.GetAnimal(orderBy);
    }
    
    public int CreateAnimal(Animal animal)
    {
        //Business logic
        return _animalRepository.CreateAnimal(animal);
    }
    

    public int UpdateAnimal(Animal animal)
    {
        //Business logic
        return _animalRepository.UpdateAnimal(animal);
    }

    public int DeleteAnimal(int idAnimal)
    {
        //Business logic
        return _animalRepository.DeleteAnimal(idAnimal);
    }

}