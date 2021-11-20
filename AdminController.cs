using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BankingDAL;
using BankingBAL;
using System.Web.Http.Cors;

namespace BankingApiProject.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class AdminController : ApiController
    {
        public string Get()
        {
            return "value";
        }

        [System.Web.Http.HttpPost]
        public IHttpActionResult adminLogin(AdminLogin al)
        {
            AdminDAL ds = new AdminDAL();
            AdminLogin ad = new AdminLogin();
            ad.Userid = al.Userid;
            ad.Password = al.Password;
            bool ans = ds.adminLogin(ad);

            if (ans == false)
            {
                return Ok(new { status = 401 });

            }
            else
            {
                return Ok(new { status = 200 });

            }

        }
    }
}
