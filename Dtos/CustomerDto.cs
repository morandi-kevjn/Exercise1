using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; // add ep67
using System.Linq;
using System.Web;
using Exercise1.Models; // add ep67

// created in ep67

namespace Exercise1.Dtos
{
    public class CustomerDto
    {
        // there we have to use Primitive types or CustomDto types.

        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        // questo era stato tolto ma serviva ep68
        public byte MembershipTypeId { get; set; }

        // ep70
        /*
        [Min18YearsIfAMember]
        public DateTime? BirthDate { get; set; }
        */
    }
}