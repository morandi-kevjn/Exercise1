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
        public Movie Movie { get; set; }

        /* this is cool, with this code we can change the title in the page of the movie. 
         * If we are adding a new movie is "New Movie", otherwise it is "Edit Movie" 
         */
        public string Title
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
    }
}