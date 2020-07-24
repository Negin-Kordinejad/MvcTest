using MvcTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcTest.ViewModels
{
    public class FullCustomerDataModel : Models.Custumer
    {
       // public int Id { get; set; }
        public MembershipType MembershipType { get; set; }
      

    }
}