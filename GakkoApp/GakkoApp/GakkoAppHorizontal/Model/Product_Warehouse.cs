using System.ComponentModel.DataAnnotations;

namespace GakkoHorizontalSlice.Model;

public class Product_Warehouse
{
    [Key]
    public int IdProductWarehouse { get; set; }
    [Required]
    public int IdWarehouse { get; set; }
    [Required]
    public int IdProduct { get; set; }
    [Required]
    public int IdOrder { get; set; }
    [Required]
    public int Amount { get; set; }
    [Required]
    public float Price { get; set; }
    [DataType(DataType.DateTime)]
    public DateTime CreatedAt { get; set; }
}