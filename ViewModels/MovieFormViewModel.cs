using Exercise1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Exercise1.ViewModels
{
    public class MovieFormViewModel
    {

        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

    }
}