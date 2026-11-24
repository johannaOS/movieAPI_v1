using Microsoft.EntityFrameworkCore;
using movieAPI_v1.Models;

namespace movieAPI_v1.Data
{
    public class MovieContext(DbContextOptions<MovieContext> options) : DbContext(options)
    {
        public DbSet<Movies> Movies { get; set; } = default!;
        public DbSet<MovieDetails> MovieDetails { get; set; } = default!;
        public DbSet<Review> Reviews { get; set; } = default!;
        public DbSet<Actor> Actors { get; set; } = default!;
    }
}