using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcTest.ViewModels
{
    public class NewCustomerViewModel
    {
        public IEnumerable<Models.MembershipType> MtType { get; set; }
        public FullCustomerDataModel customer { get; set; }

    }
}