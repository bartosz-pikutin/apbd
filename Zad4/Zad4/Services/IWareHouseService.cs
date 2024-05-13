using Zad4.Model;

namespace Zad4.Services;

public interface IWareHouseService
{

    int CreateWareHouse(Zapytanie zapytanie);
    
    int? AddProductToWarehouseProcedure(Zapytanie zapytanie);


}