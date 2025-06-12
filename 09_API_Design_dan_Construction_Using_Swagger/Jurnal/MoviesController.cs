using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class MoviesController : ControllerBase
{
    private static List<Movie> Movies = new List<Movie>();
    private static int nextId = 1;

    // Static constructor to initialize the Movies list
    static MoviesController()
    {
        Movies.Add(new Movie
        {
            Id = nextId++,
            Title = "The Shawshank Redemption",
            Director = "Frank Darabont",
            Stars = new List<string> { "Tim Robbins", "Morgan Freeman", "William Sadler" },
            Description = "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency."
        });
        Movies.Add(new Movie
        {
            Id = nextId++,
            Title = "The Godfather",
            Director = "Francis Ford Coppola",
            Stars = new List<string> { "Marlon Brando", "Al Pacino", "James Caan" },
            Description = "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son."
        });
        Movies.Add(new Movie
        {
            Id = nextId++,
            Title = "The Dark Knight",
            Director = "Christopher Nolan",
            Stars = new List<string> { "Christian Bale", "Heath Ledger", "Aaron Eckhart" },
            Description = "When the menace known as the Joker emerges, Batman must accept one of the greatest psychological and physical tests of his ability to fight injustice."
        });
    }

    [HttpGet]
    public ActionResult<IEnumerable<Movie>> Get()
    {
        return Ok(Movies);
    }

    [HttpGet("{id}")]
    public ActionResult<Movie> Get(int id)
    {
        var movie = Movies.FirstOrDefault(m => m.Id == id);
        if (movie == null) return NotFound();
        return Ok(movie);
    }

    [HttpPost]
    public ActionResult<Movie> Post([FromBody] Movie movie)
    {
        movie.Id = nextId++;
        Movies.Add(movie);
        return CreatedAtAction(nameof(Get), new { id = movie.Id }, movie);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var movie = Movies.FirstOrDefault(m => m.Id == id);
        if (movie == null) return NotFound();
        Movies.Remove(movie);
        return NoContent();
    }
}
    