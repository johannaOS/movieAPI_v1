using Microsoft.EntityFrameworkCore;
using movieAPI_v1.Data;
using movieAPI_v1.Models;

namespace movieAPI_v1.Extensions
{
    public static class SeedData
    {
        public static void SeedDatabase(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<MovieContext>();

            context.Database.Migrate();

            // Skydd mot dubbelseedning
            if (context.Movies.Any())
            {
                return;
            }

            // 1. Skådespelare
            var actors = new List<Actor>
            {
                new Actor { Name = "Anna Lind", BirthYear = 1985 },
                new Actor { Name = "Erik Berg", BirthYear = 1978 },
                new Actor { Name = "Sara Holm", BirthYear = 1990 }
            };

            // 2. Filmer med skådespelare (N:M)
            var movies = new List<Movies>
            {
                new Movies
                {
                    Title = "Stjärnnatten",
                    Year = 2019,
                    Genre = "Sci-Fi",
                    Duration = 120,
                    Actors = new List<Actor> { actors[0], actors[1] }
                },
                new Movies
                {
                    Title = "Skuggan i skogen",
                    Year = 2021,
                    Genre = "Thriller",
                    Duration = 95,
                    Actors = new List<Actor> { actors[2] }
                }
            };

            context.Actors.AddRange(actors);
            context.Movies.AddRange(movies);
            context.SaveChanges(); // Nu har alla Id

            // 3. Detaljer (1:1)
            var details = new List<MovieDetails>
            {
                new MovieDetails
                {
                    Synopsis = "En grupp astronauter upptäcker en signal från rymden.",
                    Language = "Svenska",
                    Budget = 15000000.50m,
                    MovieId = movies[0].Id
                },
                new MovieDetails
                {
                    Synopsis = "En journalist utreder försvinnanden i en liten by.",
                    Language = "Svenska",
                    Budget = 8200000.00m,
                    MovieId = movies[1].Id
                }
            };

            // 4. Recensioner (1:M)
            var reviews = new List<Review>
            {
                new Review
                {
                    ReviewerName = "Jonas",
                    Comment = "Riktigt spännande!",
                    Rating = 5,
                    MovieId = movies[0].Id
                },
                new Review
                {
                    ReviewerName = "Maria",
                    Comment = "Bra stämning men lite segt i mitten.",
                    Rating = 3,
                    MovieId = movies[1].Id
                }
            };

            context.MovieDetails.AddRange(details);
            context.Reviews.AddRange(reviews);
            context.SaveChanges();
        }
    }
}