using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Exercise1.Models
{
    public class MembershipType
    {
        // GET: MembershipType
        /* public ActionResult Index()
        {
            return View();
        } */
        
        // test2.1
        [Required] // it wwasn't in his commit, now if I debug I have an error -> test2.2
        public string Name { get; set; }

        public byte Id { get; set; }

        public short SignUpFee { get; set; }

        public byte DurationInMonths { get; set; }

        public byte DiscountRate { get; set; }


    }
}