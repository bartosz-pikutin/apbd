using System.ComponentModel.DataAnnotations;

namespace Zad3.Model;

public class Animal
{
    public int IdAnimal{ get; set; }
    [Required]
    [MaxLength(200)]
    public string Name { get; set; }
    [Required]
    [MaxLength(200)]
    public string Description { get; set; }
    [Required]
    [EmailAddress]
    public string Category { get; set; }
    [Required]
    [MaxLength(200)]
    public string Area { get; set; }
    [Required]
    [MaxLength(200)]
    public int IndexNumber { get; set; }
}