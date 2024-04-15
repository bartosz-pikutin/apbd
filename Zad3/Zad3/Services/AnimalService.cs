using Zad3.Repositories;
using Zad3.Model;

namespace Zad3.Services;

public class AnimalService : IAnimalService
{
    private readonly IAnimalRepository _animalRepository;
    
    public AnimalService(IAnimalRepository animalRepository)
    {
        _animalRepository = animalRepository;
    }

    public IEnumerable<Animal> GetAnimals()
    {
        //Business logic
        return _animalRepository.GetAnimal();
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