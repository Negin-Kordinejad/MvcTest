using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcTest.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            var customers = GetCustomers();

            return View(customers);
        }
        [Route("Customers/Dtails/{id}")]
        public ActionResult Details(int id)
        {

            var customer = GetCustomerById(id);
            //GetCustomers().FirstOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        [Route("Customers/Dtails/CutomerOprations")]
        public ActionResult Edit(int Id)
        {
            if (Id > 0)
            {
                DataAccess DB = new DataAccess();
                var customer = GetCustomerById(Id);
                if (customer == null)
                    return HttpNotFound();
                var customerModel = new ViewModels.NewCustomerViewModel();
                customerModel.customer = customer;
                customerModel.MtType = DB.GetAllMemberShip();
                return View("CutomerOprations", customerModel);
            }
            else
            {
                DataAccess DB = new DataAccess();
                var customerModel = new ViewModels.NewCustomerViewModel();
                customerModel.customer = new ViewModels.FullCustomerDataModel();
                customerModel.MtType = DB.GetAllMemberShip();
                return View("CutomerOprations", customerModel);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(ViewModels.FullCustomerDataModel customer)
        {
            DataAccess DB = new DataAccess();
            ModelState.Remove("customer.Id");
            if (ModelState.IsValid)
            {
                Models.Custumer C = new Models.Custumer
                {
                    Id = customer.Id,
                    Name = customer.Name,
                    IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter,
                    MembershipTypeId = customer.MembershipTypeId,
                    BirthDate = customer.BirthDate

                };

                if (C.Id > 0)
                {
                    DB.UpdateCustomer(C);
                    return RedirectToAction("Details", new { Id = C.Id });
                }
                else
                {
                    DB.AddNewCustomer(C);
                    return RedirectToAction("Index");
                }
            }
            else
            {
                var customerModel = new ViewModels.NewCustomerViewModel();
                customerModel.MtType = DB.GetAllMemberShip();
                return View("CutomerOprations", customerModel);
            }

        }
        private IEnumerable<ViewModels.FullCustomerDataModel> GetCustomers()
        {
            DataAccess DB = new DataAccess();
            var CustomersList = DB.GetCusomers();
            foreach (var C in CustomersList)
            {
                C.MembershipType = DB.GetmemberShipId(C.MembershipTypeId).FirstOrDefault();
            }
            return CustomersList;
        }
        private ViewModels.FullCustomerDataModel GetCustomerById(int Id)
        {
            if (Id > 0)
            {
                DataAccess DB = new DataAccess();
                var C = DB.GetCustomerById(Id).FirstOrDefault();
                C.MembershipType = DB.GetmemberShipId(C.MembershipTypeId).FirstOrDefault();
                return C;
            }
            else
            {
                return null;
            }

        }


    }
}





//return new List<Models.Custumer>
//{
//new  Models.Custumer{Id=1,Name = "Andi" },
//new  Models.Custumer{Id=2,Name = "Negin" },
//new  Models.Custumer{Id=3,Name = "Niloo" },
//new  Models.Custumer{Id=4,Name = "Naz" },
//new  Models.Custumer{Id=5,Name = "Elena" },
//new  Models.Custumer{Id=6,Name = "Shadi" }
// };