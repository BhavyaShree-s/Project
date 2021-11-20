using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankingApiProject.Models
{
    public class customerlogin
    {
        private string _userid;
        public string Userid
        {
            get
            {
                return _userid;
            }
            set
            {
                if (value.Length > 0)
                {
                    _userid = value;
                }
                else
                {
                    throw new ArgumentNullException("Username cannot be null");
                }


            }
            //public string Userid { get; set; }
        }
        private string _pwd;
        public string Password
        {
            get { return _pwd; }
            set
            {
                if (value.Length > 0)
                {
                    _pwd = value;
                }
                else
                {
                    throw new ArgumentNullException("Password cannot be null");
                }
            }
        }
    }
}