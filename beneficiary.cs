using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankingApiProject.Models
{
    public class beneficiary
    {
        public string benfname { get; set; }
        public int accountNo { get; set; }
        public string ifsc { get; set; }
        public string branch { get; set; }
    }
}