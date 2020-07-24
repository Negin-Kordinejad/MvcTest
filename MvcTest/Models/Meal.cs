using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcTest.Models
{
    public class Meal
    {
        public string Name { get; set; }
        public double Calories { get; set; }
        public List<string> Ingredients { get; set; }
    }
}