

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseUdemyNetMvc.Models;

public class Product
{
    [Key] 
    public int ProductId { get; set; }
    
    [Required(ErrorMessage = "The Product name is required")]
    public string? ProductName { get; set; }
    
    [Required(ErrorMessage = "The Short description is required")]
    public string? ShortDescription { get; set; }
    
    [Required(ErrorMessage = "The long description is required")]
    public string? LongDescription { get; set; }
    
    [Required(ErrorMessage = "The price of product is required")]
    [Range(1, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
    public double Price { get; set; }
    
    public string? ImagenUrl { get; set; }
    
    // Foreign key
    public int CategoriaId { get; set; }
    [ForeignKey("CategoryId")]
    public virtual Category? Category { get; set; }
    
    public int ApplicationTypeId { get; set; }
    [ForeignKey("ApplicationTypeId")]
    public virtual ApplicationType? ApplicationType { get; set; }
}