using System.ComponentModel.DataAnnotations;

namespace CourseUdemyNetMvc.Models;

public class Category
{
    [Key]    
    public int Id { get; set; }
    [Required(ErrorMessage = "Nombre de Categoria es Obligatorio.")]
    public string? CategoryName { get; set; }
    [Required(ErrorMessage = "Orden es Obligatorio.")]
    [Range(1, int.MaxValue, ErrorMessage = "El Orden debe de ser Mayor a Cero.")]
    public int ShowOrder { get; set; }
}