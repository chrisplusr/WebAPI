//Controladores servem para lidar com as requisições recebidas e devolver uma resposta.

using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers;

//[Route("[controller]")]  -> Token que será substituído pelo nome do controlador ao qual o atributo está associado. Isso permite que o roteador gere automaticamente URLs com base no nome do controlador.
[ApiController]
[Route("[controller]")] 
public class FilmeController : ControllerBase 
{
  private static List<Filme> listaDeFilmes = new List<Filme>();
  public void AdicionaFilme(Filme filme) 
  {
    filme.Add(filme);
  }
}