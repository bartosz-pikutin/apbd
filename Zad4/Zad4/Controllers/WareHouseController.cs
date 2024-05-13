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
    /// Endpoint used to run my endpoint.
    /// </summary>
    /// <returns>201 Created</returns>
    [HttpPost]
    public IActionResult WareHouseRun(Zapytanie zapytanie)
    {
        var affectedCount = _wareHouseService.CreateWareHouse(zapytanie);
        if (affectedCount == null)
        {
            return StatusCode(StatusCodes.Status400BadRequest, "Failed to add product to Product_Warehouse.");
        }
        return StatusCode(StatusCodes.Status201Created);

    }
    
    [HttpPost("AddProductToWarehouse")]
    public IActionResult AddProductToWarehouse(Zapytanie zapytanie)
    {
        var result = _wareHouseService.AddProductToWarehouseProcedure(zapytanie);
        if (result == null)
        {
            return StatusCode(StatusCodes.Status400BadRequest, "Failed to add product to warehouse.");
        }
        else
        {
            return StatusCode(StatusCodes.Status201Created, result);
        }
    }

    
}