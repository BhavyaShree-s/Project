using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankingApiProject.Models
{
    public class customerRegisteration
    {
        public string Name { get; set; }
        //[Required]
        //[Display(Name = "Date Of Birth :")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        public DateTime DOB { get; set; }

        public int Phone { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string username { get; set; }

        public string password { get; set; }

        public string Branch { get; set; }
        public string AccountType { get; set; }
        public DateTime Reg_Date { get; set; }
    }
}