﻿using System.ComponentModel.DataAnnotations;

namespace GakkoHorizontalSlice.Model;

public class Warehouse
{
    
    [Key]
    public int IdWarehouse { get; set; }
    [Required]
    [MaxLength(200)]
    public string Name { get; set; }
    [Required]
    [MaxLength(200)]
    public string Address { get; set; }
}