using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Data;
using System;
using System.Linq;

namespace MvcMovie.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new MvcMovieContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<MvcMovieContext>>()))
        {
            // Look for any movies.
            if (context.Movie.Any())
            {
                return;   // DB has been seeded
            }
            context.Movie.AddRange(
                new Movie
                {
                    Title = "When Harry Met Sally",
                    Rating = "R",
                    Genre = "Romantic Comedy",
                    ReleaseDate = DateTime.Parse("1989-2-12"),
                    Price = 7.99M
                },
                new Movie
                {
                    Title = "Ghostbusters ",
                    Rating = "PG-13",
                    Genre = "Comedy",
                    ReleaseDate = DateTime.Parse("1984-3-13"),
                    Price = 8.99M
                },
                new Movie
                {
                    Title = "Ghostbusters 2",
                    Rating = "PG-13",
                    Genre = "Comedy",
                    ReleaseDate = DateTime.Parse("1986-2-23"),
                    Price = 9.99M
                },
                new Movie
                {
                    Title = "Rio Bravo",
                    Rating = "PG-13",
                    Genre = "Western",
                    ReleaseDate = DateTime.Parse("1959-4-15"),
                    Price = 3.99M
                }
            );
            context.SaveChanges();
        }
    }
}