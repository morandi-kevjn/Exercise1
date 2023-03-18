using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Exercise1.Models;

// created this in Ep40

namespace Exercise1.ViewModels
{
    public class CustomerFormViewModels
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }

        public Customer Customer { get; set; }
    }
}