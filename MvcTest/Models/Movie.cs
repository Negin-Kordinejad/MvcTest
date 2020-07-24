using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcTest.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Display(Name="Movie Name")]
        public string Name  { get; set; }
    }
}