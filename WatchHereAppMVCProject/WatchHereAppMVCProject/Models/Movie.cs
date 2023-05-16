using System.ComponentModel.DataAnnotations;
using WatchHereAppMVCProject.Data;

namespace WatchHereAppMVCProject.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImgUrl { get; set; }
        public DateTime ReleaseDate { get; set; }
        public MovieCategory MovieCategory{ get;set; }

    }
}
