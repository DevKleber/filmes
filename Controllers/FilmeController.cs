namespace FilmesApi.Controller;

using FilmesApi.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]

public class FilmeController : ControllerBase
{

    private static List<Filme> filmes = new List<Filme>();

    [HttpPost]
    public string AdicionaFilme([FromBody] Filme filme)
    {
        filmes.Add(filme);
        Console.WriteLine(filme.Titulo);
        Console.WriteLine(filme.Duracao);

        return "Filme inserido com sucesso";
    }
}