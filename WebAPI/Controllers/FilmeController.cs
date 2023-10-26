//Controladores servem para lidar com as requisições recebidas e devolver uma resposta.

using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers;

//[Route("[controller]")]  -> Token que será substituído pelo nome do controlador ao qual o atributo está associado. 
//Isso permite que o roteador gere automaticamente URLs com base no nome do controlador.
[ApiController]
[Route("[controller]")] 
public class FilmeController : ControllerBase 
{
  private static List<Filme> listaDeFilmes = new List<Filme>();
  private static int id=0; 

  /*
    Para inserir uma nova informação no banco de dados usamos o post(HttpPost).
    O método GET é usado para recuperar informações do servidor,
    enquanto o método POST é usado para enviar dados ao servidor.
    CreatedAction() -> O padrão REST quando fazemos um Post diz que devemos retornar ao usuario que foi criado
    e qual caminho que ele pode entrar este objeto
  */
  [HttpPost]
  public IActionResult AdicionaFilme([FromBody] Filme filme) 
  {
    //o parâmetro filme vem através do corpo da requisição
    filme.Id= id++;  //não achei uma boa prática atribuir id manualmente
    listaDeFilmes.Add(filme);
    return CreatedAtAction(nameof(RecuperaFilmesPorId), new {id = filme.Id}, filme);
  }

  /* 
    Funções como Skip() e Take() estão relacionados com a paginação
    Nessa aplicação o usuario que vai passar como parâmetro os valores de Skip() e Take()
    A anotação [FromQuery] significa que o usuário vai passar essas informações através da Query
    https://localhost:7106/filme?skip=10&take=5
    [FromQuery] int skip = 0 -> valor padrão caso o usuario não entre com o valor
  */

  //A aplicação vai saber qual a função Get chamar pelo parâmetro da função
  [HttpGet]
  public IEnumerable<Filme> RecuperaFilmes([FromQuery] int skip = 0, [FromQuery]int take = 50) 
  {
    return listaDeFilmes.Skip(skip).Take(take);
  }
  
  // IActionResult siginifica resultado de uma ação que foi executada
  //FirstOrDefault -> busca um elemento da coleção
  // https://localhost:7106/filme/1 -> busca pelo filme de id == 1;
  [HttpGet("{id}")]
  public IActionResult RecuperaFilmesPorId(int id)
  {
    var filme = listaDeFilmes.FirstOrDefault(filme => filme.Id == id);
    if(filme == null) return NotFound(); //status code 404
    return Ok(filme);  //status code Ok e retorna o filme
  }
}