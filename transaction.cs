using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankingApiProject.Models
{
    public class transaction
    {
        public DateTime TranDate { get; set; }
        public float Amount { get; set; }
        public string TranType { get; set; }
        public int AccId { get; set; }

    }
}