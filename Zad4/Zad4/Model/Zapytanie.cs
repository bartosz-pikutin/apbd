using System.ComponentModel.DataAnnotations;

namespace Zad4.Model;

public class Zapytanie
{
    [Required]
    public int IdProduct { get; set; }
    [Required]
    public int IdWarehouse { get; set; }
    [Required]
    public int Amount { get; set; }
    [Required]
    [DataType(DataType.DateTime)]
    public DateTime CreatedAt { get; set; }

    public bool Read()
    {
        throw new NotImplementedException();
    }
}