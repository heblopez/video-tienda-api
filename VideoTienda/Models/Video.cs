using System.ComponentModel.DataAnnotations;

namespace VideoTienda.Models;

public class Video
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "El título es obligatorio")]
    [StringLength(100, ErrorMessage = "El título no puede exceder los 100 caracteres")]
    public string Titulo { get; set; }
    
    [Required(ErrorMessage = "El género es obligatorio")]
    public string Genero { get; set; }
    
    [Required(ErrorMessage = "La fecha de lanzamiento es obligatoria")]
    public DateTime FechaLanzamiento { get; set; }
    
    [Range(0, 1000, ErrorMessage = "El precio debe estar entre 0 y 1000")]
    public decimal Precio { get; set; }
    
    public int ClienteId { get; set; }
    public Cliente Cliente { get; set; }
}