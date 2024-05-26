namespace FilmesApi.Controller;

using FilmesApi.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]

public class FilmeController : ControllerBase
{

    private static List<Filme> filmes = new List<Filme>();
    private static int id = 0;

    [HttpGet("{id}")]
    public Filme? DetalharFilme(int id)
    {
        return filmes.FirstOrDefault(filme => filme.Id == id);
    }

    [HttpGet]
    public IEnumerable<Filme> RecuperaFilme()
    {
        return filmes;
    }

    [HttpPost]
    public ActionResult<string> AdicionaFilme([FromBody] Filme filme)
    {
        if (filme == null)
        {
            return BadRequest("Filme não pode ser nulo.");
        }

        filme.Id = id++;
        filmes.Add(filme);
        Console.WriteLine(filme.Titulo);
        Console.WriteLine(filme.Duracao);

        return "Filme inserido com sucesso";
    }
}