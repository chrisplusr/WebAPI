using System.ComponentModel.DataAnnotations; 

namespace WebAPI.Data.Dtos;

public class UpdateFilmeDto
{

  [Required]
  public string Titulo { get; set; }

  [Required]
  [StringLength(50)]
  public string Genero { get; set; }
  
  [Required]
  [Range(70, 600)]
  public int Duracao { get; set; }
  
}