using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace WatchHereAppMVCProject.Models
{
    public class User : IdentityUser
    {
        public string Name { get; set; }

        public string Bio { get;set; }
        public ICollection<Movie> LikedMovies { get; set; }
    }
}
