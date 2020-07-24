using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcTest.Models
{
    public class Custumer
    {
        public int Id { get; set; } = 0;
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(50)]
        public string Name { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }
        // public MembershipType MembershipType { get; set; }
        [Required(ErrorMessage = "please enter Membershiptype")]
        public byte MembershipTypeId { get; set; }

        [Display(Name = "Date Of Birth")]
        [ValidateBirhdate]
        public DateTime BirthDate { get; set; }

    }
}