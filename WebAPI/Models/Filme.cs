namespace WebAPI.Models;

using System.ComponentModel.DataAnnotations; 

/* DATA ANNOTATIONS
require-> campo obrigatorio
range-> intervalo(min, max)
*/

public class Filme 
{
  public int Id { get; set; }
  [Required]
  public string Titulo { get; set; }
  [Required]
  [MaxLength(50)]
  public string Genero { get; set; }
  [Required]
  [Range(70, 600)]
  public int Duracao { get; set; }
  
}