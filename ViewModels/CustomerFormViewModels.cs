using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Exercise1.Models;
using System.ComponentModel.DataAnnotations; //test3 pt2

// created this in Ep40

namespace Exercise1.ViewModels
{
    public class CustomerFormViewModels
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }

        public Customer Customer { get; set; }
        
        // test3 pt2
        public string Title
        {
            get
            {
                if (Customer != null && Customer.Id != 0)
                {
                    return "Edit Customer";
                }

                return "New Customer";
            }
        }
    }
}