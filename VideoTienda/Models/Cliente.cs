using System.ComponentModel.DataAnnotations;

namespace VideoTienda.Models;

public class Cliente
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "El nombre es obligatorio")]
    [StringLength(100, ErrorMessage = "El nombre no puede superar los 100 caracteres")]
    public string Nombre { get; set; }
    
    [Required(ErrorMessage = "El email es obligatorio")]
    [EmailAddress(ErrorMessage = "El email no es válido")]
    public string Email { get; set; }
    
    public ICollection<Video>? Videos { get; set; }
}
