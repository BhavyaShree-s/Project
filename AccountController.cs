using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BankingApiProject.Models;
using BankingBAL;
using BankingDAL;
using System.Web.Http.Cors;


namespace BankingApiProject.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class AccountController : ApiController
    {
        public List<accountDet> Get()
        {
            CustomerDAL d = new CustomerDAL();
            DataTable dt = new DataTable();
            dt = d.showAccountDetails();
            List<accountDet> list = new List<accountDet>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                accountDet e = new accountDet();
                e.AccNumber = Convert.ToInt32(dt.Rows[i][1]);
                e.AccType = dt.Rows[i][2].ToString();
                e.Reg_Date = Convert.ToDateTime(dt.Rows[i][3]);
                e.Balance = Convert.ToInt32(dt.Rows[i][4]);

                list.Add(e);
            }
            return list;
        }
        public accountDet Get(int id)
        {
            CustomerDAL dal = new CustomerDAL();
            Account bal = new Account();

            accountDet model = new accountDet();
            model.AccNumber = bal.AccNumber;
            model.AccType = bal.AccType;
            model.Reg_Date = bal.Reg_Date;
            model.Balance = bal.Balance;
          
           

            return model;
        }
    }
}
