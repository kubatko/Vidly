﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Genre field is required")]
        public int GenreId { get; set; }
        [Required]

        public DateTime ReleaseDate { get; set; }

        //[NumberInStockEqualZeroValidation]
        public int NumberInStock { get; set; }
    }
}