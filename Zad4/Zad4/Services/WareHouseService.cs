using System.Data;
using Zad4.Repositories;
using Zad4.Model;
using System.Data.SqlClient;

namespace Zad4.Services;

public class WareHouseService : IWareHouseService
{
    private readonly IWareHouseRepository _wareHouseRepository;
    
    public WareHouseService(IWareHouseRepository wareHouseRepository)
    {
        _wareHouseRepository = wareHouseRepository;
    }
    
    public int CreateWareHouse(Zapytanie zapytanie)
    {
        //Business logic
        return (int)_wareHouseRepository.CreateWareHouse(zapytanie);
    }
    
    String connectionString = "Data Source=db-mssql16.pjwstk.edu.pl;Initial Catalog=s24819;Integrated Security=True;MultipleActiveResultSets=true";
    public int? AddProductToWarehouseProcedure(Zapytanie zapytanie)
    {
        try
        {
            using var con = new SqlConnection(connectionString);
            con.Open();

            using var cmd = new SqlCommand("AddProductToWarehouse", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@IdProduct", zapytanie.IdProduct);
            cmd.Parameters.AddWithValue("@IdWarehouse", zapytanie.IdWarehouse);
            cmd.Parameters.AddWithValue("@Amount", zapytanie.Amount);
            cmd.Parameters.AddWithValue("@CreatedAt", zapytanie.CreatedAt);

            SqlParameter newIdParam = new SqlParameter("@NewId", SqlDbType.Int);
            newIdParam.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(newIdParam);

            cmd.ExecuteNonQuery();

            return (int?)cmd.Parameters["@NewId"].Value;
        }
        catch (SqlException ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
            return null;
        }
    }


}