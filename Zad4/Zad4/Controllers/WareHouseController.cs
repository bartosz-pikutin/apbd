using Zad4.Model;
using Zad4.Services;
using Microsoft.AspNetCore.Mvc;

namespace WareHouseController.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WareHouseController : ControllerBase
{
    private IWareHouseService _wareHouseService;
    
    public WareHouseController(IWareHouseService wareHouseService)
    {
        _wareHouseService = wareHouseService;
    }
    
    /// <summary>
    /// Endpoints used to return list of animals.
    /// </summary>
    /// <param name="orderBy"></param>
    /// <returns>List of animals</returns>
    [HttpGet("{orderBy}")]
    public IActionResult GetAnimal(String orderBy = "Name")
    {
        var animals = _wareHouseService.GetAnimal(orderBy);
        return Ok(animals);
    }

    /// <summary>
    /// Endpoint used to create an animal.
    /// </summary>
    /// <param name="animal">New animal data</param>
    /// <returns>201 Created</returns>
    [HttpPost]
    public IActionResult CreateAnimal(Animal animal)
    {
        var affectedCount = _wareHouseService.CreateAnimal(animal);
        return StatusCode(StatusCodes.Status201Created);
    }
    
    /// <summary>
    /// Endpoint used to update an animal.
    /// </summary>
    /// <param name="id">Id of an animal</param>
    /// <param name="animal">204 No Content</param>
    /// <returns></returns>
    [HttpPut("{id:int}")]
    public IActionResult UpdateAnimal(int id, Animal animal)
    {
        var affectedCount = _wareHouseService.UpdateAnimal(animal);
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
        var affectedCount = _wareHouseService.DeleteAnimal(id);
        return NoContent();
    }
}