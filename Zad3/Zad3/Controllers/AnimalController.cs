using Zad3.Model;
using Zad3.Services;
using Microsoft.AspNetCore.Mvc;

namespace AnimalControllers.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AnimalController : ControllerBase
{
    private IAnimalService _animalService;
    
    public AnimalController(IAnimalService animalService)
    {
        _animalService = animalService;
    }
    
    /// <summary>
    /// Endpoints used to return list of students.
    /// </summary>
    /// <returns>List of students</returns>
    [HttpGet]
    public IActionResult GetStudents()
    {
        var animals = _animalService.GetAnimal();
        return Ok(animals);
    }
    
    /// <summary>
    /// Endpoint used to return a single student.
    /// </summary>
    /// <param name="id">Id of a student</param>
    /// <returns>Student</returns>

    
    /// <summary>
    /// Endpoint used to create a student.
    /// </summary>
    /// <param name="student">New student data</param>
    /// <returns>201 Created</returns>
    [HttpPost]
    public IActionResult CreateAnimal(Animal animal)
    {
        var affectedCount = _animalService.CreateAnimal(animal);
        return StatusCode(StatusCodes.Status201Created);
    }
    
    /// <summary>
    /// Endpoint used to update a student.
    /// </summary>
    /// <param name="id">Id of a student</param>
    /// <param name="student">204 No Content</param>
    /// <returns></returns>
    [HttpPut("{id:int}")]
    public IActionResult UpdateStudent(int id, Animal animal)
    {
        var affectedCount = _animalService.UpdateAnimal(animal);
        return NoContent();
    }
    
    /// <summary>
    /// Endpoint used to delete a student.
    /// </summary>
    /// <param name="id">Id of a student</param>
    /// <returns>204 No Content</returns>
    [HttpDelete("{id:int}")]
    public IActionResult DeleteAnimal(int id)
    {
        var affectedCount = _animalService.DeleteAnimal(id);
        return NoContent();
    }
}