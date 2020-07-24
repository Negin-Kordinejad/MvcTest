using MvcTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcTest.Controllers
{
    public class AddressController : Controller
    {
        // GET: Address
        public static List<Address> addresses = new List<Address>();
         
        Models.Address A = new Address() { Street = "dsfds", City = "efds"};
      //  [Route("MvcTest/address/create")]
        [ActionName("create")]
        public ActionResult create()
        {
          //  addresses.Add(new Address() { City = "efds", Street = "dsfds" });
            
            return View(A);
        }

    //    [Route("MvcTest/address/save")]
        [HttpPost]
        public ActionResult save(FormCollection f)
        {
            //[Bind(Include="Street,City")] Address Ad
            addresses.Add(new Address() { Street = f["Street"],City = f["City"]});
            return RedirectToAction("Index");
            //if (addresses.Count > 4)
            //    return RedirectToAction("Index");
            //else
            //    return RedirectToAction("create");
        }
        public ActionResult Index()
        {
            return View(addresses);
        }
    }
}