using System.Data.SqlClient;
using Microsoft.AspNetCore.Http.HttpResults;
using Zad4.Model;

namespace Zad4.Repositories;

public class WareHouseRepository : IWareHouseRepository
{
    private IConfiguration _configuration;
    public WareHouseRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    String connectionString = "Data Source=db-mssql16.pjwstk.edu.pl;Initial Catalog=s24819;Integrated Security=True;MultipleActiveResultSets=true";
  
    
    public int? CreateWareHouse(Zapytanie zapytanie)
    {
        using var con = new SqlConnection(connectionString);
        con.Open();
        
        using var cmdDoesProductExist = new SqlCommand();
        cmdDoesProductExist.Connection = con;
        cmdDoesProductExist.CommandText = "SELECT COUNT(*) FROM Product WHERE IdProduct = @IdProduct";
        cmdDoesProductExist.Parameters.AddWithValue("@IdProduct", zapytanie.IdProduct);

        
        int productCount = (int)cmdDoesProductExist.ExecuteScalar();

        if (productCount == 0)
        {
            return null;
        }
        else
        {
            Console.WriteLine("produkt istnieje");
        }
        
        using var cmdDoesWarehouseExist = new SqlCommand();
        cmdDoesWarehouseExist.Connection = con;
        cmdDoesWarehouseExist.CommandText = "SELECT COUNT(*) FROM Warehouse WHERE IdWarehouse = @IdWarehouse";
        cmdDoesWarehouseExist.Parameters.AddWithValue("@IdWarehouse", zapytanie.IdWarehouse);
        int warehouseCount = (int)cmdDoesWarehouseExist.ExecuteScalar();

        if (warehouseCount == 0)
        {
            return null;
        }
        else
        {
            Console.WriteLine("magazyn istnieje");
        }
        
        
        using var cmdIsOrderCorrect = new SqlCommand();
        cmdIsOrderCorrect.Connection = con;
        cmdIsOrderCorrect.CommandText = "SELECT COUNT(*) FROM [Order] WHERE IdProduct = @IdProduct AND Amount = @Amount AND CreatedAt < @CreatedAt";
        cmdIsOrderCorrect.Parameters.AddWithValue("@IdProduct", zapytanie.IdProduct);
        cmdIsOrderCorrect.Parameters.AddWithValue("@Amount", zapytanie.Amount);
        cmdIsOrderCorrect.Parameters.AddWithValue("@CreatedAt", zapytanie.CreatedAt);
        int orderCount = (int)cmdIsOrderCorrect.ExecuteScalar();
        int IDorder;
        if (orderCount == 0)
        {
            return null;
        }
        else
        {
            Console.WriteLine("data git istnieje");
            using var cmdGetOrderID = new SqlCommand();
            cmdGetOrderID.Connection = con;
            cmdGetOrderID.CommandText = "SELECT IdOrder FROM [Order] WHERE IdProduct = @IdProduct AND Amount = @Amount";
            cmdGetOrderID.Parameters.AddWithValue("@IdProduct", zapytanie.IdProduct);
            cmdGetOrderID.Parameters.AddWithValue("@Amount", zapytanie.Amount);
            IDorder = (int)cmdGetOrderID.ExecuteScalar();

            if (IDorder == 0)
            {
                return null;
            }
            else
            {
                Console.WriteLine("id order git");
            }
        }
        
        
        using var cmdGetIdOrder = new SqlCommand();
        cmdGetIdOrder.Connection = con;
        cmdGetIdOrder.CommandText = "SELECT IdOrder FROM [Order] WHERE IdProduct = @IdProduct";
        cmdGetIdOrder.Parameters.AddWithValue("@IdProduct", zapytanie.IdProduct);
        object result = cmdGetIdOrder.ExecuteScalar();
        int idOrderValue = result == DBNull.Value ? 0 : Convert.ToInt32(result);
        Console.WriteLine(idOrderValue);
        
        using var cmdHasOrderBeenFulfilled = new SqlCommand();
        cmdHasOrderBeenFulfilled.Connection = con;
        cmdHasOrderBeenFulfilled.CommandText = "SELECT COUNT(*) FROM Product_Warehouse WHERE IdOrder = @IDorder";
        cmdHasOrderBeenFulfilled.Parameters.AddWithValue("@IDorder", idOrderValue);
        object fulfilledRes = cmdHasOrderBeenFulfilled.ExecuteScalar();
        int orderFullfilled = fulfilledRes == DBNull.Value ? 0 : Convert.ToInt32(fulfilledRes);
        
        if (orderFullfilled != 0)
        {
            Console.WriteLine(orderFullfilled);
            return null;
        }
        else
        {
            Console.WriteLine("Nie ma jeszcze takiego zamowienia");
        }
        
        using var cmdUpdateFulfilledAt = new SqlCommand();
        cmdUpdateFulfilledAt.Connection = con;
        cmdUpdateFulfilledAt.CommandText = "UPDATE [Order] SET FulfilledAt = GETDATE()";
        cmdUpdateFulfilledAt.ExecuteNonQuery();
       
        using var cmdGetPrice = new SqlCommand();
        cmdGetPrice.Connection = con;
        cmdGetPrice.CommandText = "SELECT Price FROM Product WHERE IdProduct = @IdProduct";
        cmdGetPrice.Parameters.AddWithValue("@IdProduct", zapytanie.IdProduct);
        object priceRest = cmdGetPrice.ExecuteScalar();
        decimal price = priceRest == DBNull.Value ? 0m : Convert.ToDecimal(priceRest);
        Console.WriteLine("Cena wynosi: " + price);

        
        using var cmdInsertOrder = new SqlCommand();
        cmdInsertOrder.Connection = con;
        cmdInsertOrder.CommandText = "INSERT INTO Product_Warehouse (IdWarehouse, IdProduct, IdOrder, Amount, Price, CreatedAt) VALUES (@IdWarehouse, @IdProduct, @IdOrder, @Amount, @Price, GETDATE()); SELECT SCOPE_IDENTITY();";
        cmdInsertOrder.Parameters.AddWithValue("@IdWarehouse", zapytanie.IdWarehouse);
        cmdInsertOrder.Parameters.AddWithValue("@IdProduct", zapytanie.IdProduct);
        cmdInsertOrder.Parameters.AddWithValue("@IDorder", idOrderValue);
        cmdInsertOrder.Parameters.AddWithValue("@Amount", zapytanie.Amount);
        cmdInsertOrder.Parameters.AddWithValue("@Price", (zapytanie.Amount * price));
        int idProductWarehouse = Convert.ToInt32(cmdInsertOrder.ExecuteScalar());
        
        Console.WriteLine(idProductWarehouse);
        return idProductWarehouse;
    }

    
   
}    
    
