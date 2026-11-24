using Microsoft.EntityFrameworkCore;

public class MovieContext(DbContextOptions<MovieContext> options) : DbContext(options)
{
    public DbSet<movieAPI_v1.Models.Movie> Movie { get; set; } = default!;
}
