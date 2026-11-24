namespace movieAPI_v1.Models
{
    public class MovieDetails
    {
        public int Id { get; set; }
        public string Synopsis { get; set; } = "";
        public string Language { get; set; } = "";
        public decimal Budget { get; set; }
        public int MovieId { get; set; }
        public Movie? Movie { get; set; } = null!;
    }
}
