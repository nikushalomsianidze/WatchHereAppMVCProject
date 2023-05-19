using System;
using WatchHereAppMVCProject.Models;

namespace WatchHereAppMVCProject.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {

            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                context.Database.EnsureCreated();

                if (!context.Movies.Any())
                {
                    context.Movies.AddRange(new List<Movie>()
                    {
                        new Movie()
                        {
                            Name = "Blade Runner 2049",
                            Description =
                            "This is the Blade Runner description",
                            ImgUrl = "https://shorturl.at/rsuNX",
                            ReleaseDate = new DateTime(2017, 10, 3),
                            MovieCategory = MovieCategory.Action
                        },
                        new Movie()
                        {
                            Name = "ghost in the shell",
                            Description =
                            "This is the ghost in the shell description",
                            ImgUrl = "https://shorturl.at/CQRZ4",
                            ReleaseDate = new DateTime(1995, 9, 23),
                            MovieCategory = MovieCategory.Anime,
                        },
                        new Movie()
                        {
                            Name = "A Clockwork Orange",
                            Description =
                            "This is the A Clockwork Orange description",
                            ImgUrl = "https://shorturl.at/czE05",
                            ReleaseDate = new DateTime(1971, 12, 19),
                            MovieCategory = MovieCategory.Drama,
                        },
                        new Movie()
                        {
                            Name = "Akira",
                            Description =
                            "This is the Akira description",
                            ImgUrl = "https://shorturl.at/ekHMR",
                            ReleaseDate = new DateTime(1988, 12, 19),
                            MovieCategory = MovieCategory.Anime,
                        },
                        new Movie()
                        {
                            Name = "A Man Named Scott",
                            Description =
                            "This is A Man Named Scott description",
                            ImgUrl = "https://shorturl.at/emZ28",
                            ReleaseDate = new DateTime(2021, 12, 19),
                            MovieCategory = MovieCategory.Documentary,
                        },
                        new Movie()
                        {
                            Name = "The Fast and the Furious: Tokyo Drift",
                            Description =
                            "This is the The Fast and the Furious: Tokyo Drift description",
                            ImgUrl = "https://shorturl.at/pAS34",
                            ReleaseDate = new DateTime(2006, 12, 19),
                            MovieCategory = MovieCategory.Action,
                        },
                    });
                    context.SaveChanges();
                }
            }
           
        }
    }
}
