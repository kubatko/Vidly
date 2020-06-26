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
        [Required(ErrorMessage = "Genre field is required")]
        public int GenreId { get; set; }
        [Required]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }
        
        [NumberInStockEqualZeroValidation]
        [Display(Name = "Number In Stock")]
        public int NumberInStock { get; set; }
        
    }
}