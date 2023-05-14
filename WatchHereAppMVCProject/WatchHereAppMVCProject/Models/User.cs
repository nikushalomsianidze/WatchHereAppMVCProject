using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace WatchHereAppMVCProject.Models
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
    }
}
