using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        [Display(Name = "Movie")]
        public string Name { get; set; }
        public MovieGenre Genre { get; set; }
        public int GenreId { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
        [Required]
        public int NumberInStock { get; set; }
        
    }
}