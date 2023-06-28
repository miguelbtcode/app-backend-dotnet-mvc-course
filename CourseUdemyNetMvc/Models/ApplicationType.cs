using System.ComponentModel.DataAnnotations;

namespace CourseUdemyNetMvc.Models;

public class ApplicationType
{
    [Key]
    public int Id { get; set; }
    [Required(ErrorMessage = "El nombre del tipo de aplicacion es obligatorio.")]
    public string? Name { get; set; }
}