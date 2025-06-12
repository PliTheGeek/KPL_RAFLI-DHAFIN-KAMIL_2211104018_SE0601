public class Movie
{
    public int Id { get; set; } // Unique identifier for each movie
    public string Title { get; set; }
    public string Director { get; set; }
    public List<string> Stars { get; set; }
    public string Description { get; set; }
}
