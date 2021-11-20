using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingBAL
{
    public class CustomerLogin
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

    public class AdminLogin
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

    public class CustomerRegisteration
    {

        public string Name { get; set; }
        
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


    public class Beneficiary
    {
        //public int benfId { get; set; }
        public string benfname { get; set; }
        public int accountNo { get; set; }
        public string ifsc { get; set; }
        public string branch { get; set; }
    }


    public class TRANSACTION
    {
        public DateTime TranDate { get; set; }
        public float Amount { get; set; }
        public string TranType { get; set; }
        public int AccId { get; set; }

    }



    public class Account
    {
        public int AccNumber { get; set; }
        public string AccType { get; set; }
        public DateTime Reg_Date { get; set; }
        public int Balance { get; set; }
      
    }

   

}

