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

  /*
    Para inserir uma nova informação no banco de dados usamos o post(HttpPost).
    O método GET é usado para recuperar informações do servidor,
    enquanto o método POST é usado para enviar dados ao servidor,
  */
  [HttpPost]
  public void AdicionaFilme([FromBody] Filme filme) 
  {
    //o parâmetro filme vem através do corpo da requisição
    listaDeFilmes.Add(filme);
    Console.WriteLine(filme.Titulo);
    Console.WriteLine(filme.Duracao);
  }
}