using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BankingBAL;
using BankingDAL;
using System.Web.Http.Cors;
using BankingApiProject.Models;
using System.Data;

namespace BankingApiProject.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CustomerController : ApiController
    {
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };

        //}
        //public string get(int id)
        //{
        //    return "value";
        //}

        [System.Web.Http.HttpPost]
        public IHttpActionResult CustomerLogin(CustomerLogin login)
        {
            CustomerDAL d = new CustomerDAL();
            CustomerLogin lm = new CustomerLogin();
            lm.Userid = login.Userid;
            lm.Password = login.Password;
            bool status = d.ValidateUser(lm);

            if (status == false)
            {
                return Ok(new { status = 401 });
            }
            else

                return Ok(new { status = 200 });
        }

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult InsertCustomer(CustomerRegisteration al)
        {
            CustomerDAL dal = new CustomerDAL();

            CustomerRegisteration ad = new CustomerRegisteration();
            al.Name = al.Name;
            al.DOB = al.DOB;
            al.Phone = al.Phone;
            al.Email = al.Email;
            al.Address = al.Address;
            al.username = al.username;
            al.password = al.password;
            al.Branch = al.Branch;
            al.AccountType = al.AccountType;
            al.Reg_Date = al.Reg_Date;

            int tno = dal.InsertCustomer(al);

            return Ok(new { status = 200 });
        }



        
        public List<customerRegisteration> Get()
        {
            CustomerDAL dal = new CustomerDAL();
            DataTable dt = new DataTable();
            dt = dal.showcust();
            List<customerRegisteration> list = new List<customerRegisteration> ();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                customerRegisteration c = new customerRegisteration();
                c.Name = dt.Rows[i][1].ToString();
                c.DOB = Convert.ToDateTime(dt.Rows[i][2]);
                c.Phone = Convert.ToInt32(dt.Rows[i][3]);
                c.Email = dt.Rows[i][4].ToString();
                c.Address = dt.Rows[i][5].ToString();
                c.username = dt.Rows[i][6].ToString();
                c.password = dt.Rows[i][7].ToString();
                c.Branch= dt.Rows[i][8].ToString();
                c.AccountType = dt.Rows[i][9].ToString();
                c.Reg_Date = Convert.ToDateTime(dt.Rows[i][10]);

                list.Add(c);
            }
            return list;
        }

        public customerRegisteration Get(int id)
        {
            CustomerDAL dal = new CustomerDAL();
            CustomerRegisteration bal = new CustomerRegisteration();

            customerRegisteration model = new customerRegisteration();
            model.Name = bal.Name;
            model.DOB = bal.DOB;
            model.Phone = bal.Phone;
            model.Email = bal.Email;
            model.Address = bal.Address;
            model.username = bal.username;
            model.password = bal.password;
            model.Branch = bal.Branch;
            model.AccountType = bal.AccountType;
            model.Reg_Date = bal.Reg_Date;

            return model;
        }




        // [EnableCors(origins: "", headers: "", methods: "*")]
        //[System.Web.Http.HttpPut]
        public IHttpActionResult UpdateCust(CustomerRegisteration al)
        {
            CustomerDAL ds = new CustomerDAL();
            CustomerRegisteration ad = new CustomerRegisteration();
            ad.Email = al.Email;
            ad.Phone = al.Phone;
            ad.Address = al.Address;
           
            ad.password = al.password;
            ds.editDetails(ad);

            

            return Ok(new { status = 200 });
        }


       






    }
   
    
}
    