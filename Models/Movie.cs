using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exercise1.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        // test2.3
        // [Required] test3
        public Genre Genre { get; set; }

        [Required]
        public byte GenreId { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:dddd, MMMM, d, yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateAdded { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:dddd, MMMM, d, yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }

        [Required]
        // ep60
        [Range(1, 20)]
        public byte NumberInStock { get; set; }

    }
}