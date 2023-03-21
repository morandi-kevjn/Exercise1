using System;
// we have a problem with this generic (System.Collections.Generic.List):
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Exercise1.Models
{
    public class Customer
    {
        public int Id { get; set; }

        // this syntax is the Overriding Conventions and it is from ep28, it says that is required and max length 255.
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        // we add this attribute in ep26:

        public bool IsSubscribedToNewsLetter { get; set; }
        
        public MembershipType MembershipType { get; set; }
        
        // ep40
        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }

        // ep39
        // [Display(Name = "Date of Birth")]
        // ep40
        [Display(Name = "Date of Birth")]
        // test3 pt2
        [DisplayFormat(DataFormatString = "{0:dddd, MMMM, d, yyyy}", ApplyFormatInEditMode = true)]
        // test2.2
        public DateTime? BirthDate { get; set; }
    }
}