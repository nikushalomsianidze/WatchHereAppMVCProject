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
                    });
                    context.SaveChanges();
                }
            }
           
        }
    }
}
