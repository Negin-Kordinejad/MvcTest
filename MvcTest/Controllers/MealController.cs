using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcTest.Controllers
{
    public class MealController : Controller
    {
        // GET: Meal
        public ActionResult layout()
        {
            MvcTest.Models.Meal M = new Models.Meal();
            M.Name = "Ash";
            M.Calories = 20;
            List<String> L = new List<string> {"noodle","beens" };
            M.Ingredients = L;
          
            return View(M);
        }
    }
}