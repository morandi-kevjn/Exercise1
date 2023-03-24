using Exercise1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

// test3 -> created before but it had to be created now

namespace Exercise1.ViewModels
{
    public class MovieFormViewModels
    {
        public IEnumerable<Genre> Genres { get; set; }
        // ep60 test4 public Movie Movie { get; set; }
        // add this <<<
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Display (Name = "Genre")]
        [Required]
        public byte? GenreId { get; set; }

        [Display(Name = "ReleaseDate")]
        [Required]
        [DisplayFormat(DataFormatString = "{0:dddd, MMMM, d, yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ReleaseDate { get; set; }

        [Display(Name = "Number in Stock")]
        [Range(1, 20)]
        [Required]
        public byte NumberInStock { get; set; }

        // modify this
        /* this is cool, with this code we can change the title in the page of the movie. 
         * If we are adding a new movie is "New Movie", otherwise it is "Edit Movie" 
         */
        /* public string Title
        {
            get
            {
                if(Movie != null && Movie.Id !=0)
                {
                    return "Edit Movie";
                }

                return "New Movie";
            }
        }
        */
        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Movie" : "New Movie";
            }
        }

        public MovieFormViewModels()
        {
            Id = 0;
        }

        public MovieFormViewModels(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            NumberInStock = movie.NumberInStock;
            GenreId = movie.GenreId;
        }

        // >>>
    }
}