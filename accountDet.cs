using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankingApiProject.Models
{
    public class accountDet
    {
        public int AccNumber { get; set; }
        public string AccType { get; set; }
        public DateTime Reg_Date { get; set; }
        public int Balance { get; set; }
    }
}