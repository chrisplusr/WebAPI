//Controladores servem para lidar com as requisições recebidas e devolver uma resposta.
//Filmes é a propriedade do FilmeContext: public DbSet<Filme> Filmes { get; set; }
// AutoMapper foi incluida para converter FilmeDto em Filme

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Data;
using WebAPI.Models;
using WebAPI.Data.Dtos;
using Azure;


namespace WebAPI.Controllers;

//[Route("[controller]")]  -> Token que será substituído pelo nome do controlador ao qual o atributo está associado. 
//Isso permite que o roteador gere automaticamente URLs com base no nome do controlador.
[ApiController]
[Route("[controller]")] 
public class FilmeController : ControllerBase 
{
  //injeção de dependência
  private FilmeContext _context;
  private IMapper _mapper; 

  public FilmeController(FilmeContext context, IMapper mapper)
  {
    this._context = context;
    this._mapper = mapper;
  }
  
  /*
    Para inserir uma nova informação no banco de dados usamos o post(HttpPost).
    O método GET é usado para recuperar informações do servidor,
    enquanto o método POST é usado para enviar dados ao servidor.
    CreatedAction() -> O padrão REST quando fazemos um Post diz que devemos retornar ao usuario que foi criado
    e qual caminho que ele pode entrar este objeto
  */
  [HttpPost]
  public IActionResult AdicionaFilme([FromBody] CreateFilmeDto filmeDto) 
  {
    Filme filme = _mapper.Map<Filme>(filmeDto); //conversão
    _context.Filmes.Add(filme);
    _context.SaveChanges();
    return CreatedAtAction(nameof(RecuperaFilmesPorId), new {id = filme.Id}, filme);
  }

  /* 
    Funções como Skip() e Take() estão relacionados com a paginação
    Nessa aplicação o usuario que vai passar como parâmetro os valores de Skip() e Take()
    A anotação [FromQuery] significa que o usuário vai passar essas informações através da Query
    https://localhost:7106/filme?skip=10&take=5
    [FromQuery] int skip = 0 -> valor padrão caso o usuario não entre com o valor
  */

 
  [HttpGet]
  public IEnumerable<Filme> RecuperaFilmes([FromQuery] int skip = 0, [FromQuery]int take = 50) 
  {
    return _context.Filmes.Skip(skip).Take(take);
  }
  
  // IActionResult siginifica resultado de uma ação que foi executada
  //FirstOrDefault -> busca um elemento da coleção
  // https://localhost:7106/filme/1 -> busca pelo filme de id == 1;
   //A aplicação vai saber qual a função Get chamar pelo parâmetro da função
  [HttpGet("{id}")]
  public IActionResult RecuperaFilmesPorId(int id)
  {
    var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
    if(filme == null) return NotFound(); //status code 404
    return Ok(filme);  //status code Ok e retorna o filme
  }

  //Pode ser usado o PUT e o PASH
  [HttpPut("{id}")]
  public IActionResult AtualizaFilme(int id, JsonPatchDocument<UpdateFilmeDto> patch) {
    var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
    
    if(filme == null) return NotFound();

   //converter
    var filmeParaAtualizar = _mapper.Map<UpdateFilmeDto>(filme);
    patch.ApplyTo(filmeParaAtualizar, ModelState);

    if(!TryValidateModel(filmeParaAtualizar)) {
      return ValidationProblem();
    }

    _mapper.Map(filmeDto, filme);  //os campos de filmeDto serão mapeados para meu filme
    _context.SaveChanges();
    return NoContent(); //status code utilizado para atualização
  }

  //mudanças parciais
  [HttpPatch("{id}")]
  public IActionResult AtualizaFilmeParcial(int id, [FromBody] UpdateFilmeDto  filmeDto) {
    var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
    
    if(filme == null) return NotFound();
    _mapper.Map(filmeDto, filme);  //os campos de filmeDto serão mapeados para meu filme
    _context.SaveChanges();
    return NoContent(); //status code utilizado para atualização
  }

    public class JsonPatchDocument<T>
    {
    }
}