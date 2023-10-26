/*
  DTOs trazem diversas vantagens relacionadas a organização de código. 
  Além disso, utilizando DTOs, conseguimos ter um maior controle em nossas requisições e respostas.
  Com DTOs podemos definir os parâmetros enviados de maneira isolada do nosso modelo do banco de dados.
  Há parâmetros que não precisamos enviar, como por exemplo o id. 
*/

using System.ComponentModel.DataAnnotations; 

namespace WebAPI.Data.Dtos;

public class CreateFilmeDto
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