using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace MvcTest.ViewModels
{
    public class RandomMovieModel
    {
        public Models.Movie Movie { get; set; }
        public List<Models.Custumer> Custumer { get; set; }
    }
}