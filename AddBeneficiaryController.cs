using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BankingBAL;
using BankingDAL;
using System.Web.Http.Cors;
using System.Data;
using BankingApiProject.Models;

namespace BankingApiProject.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class AddBeneficiaryController : ApiController
    {
        //public string Get()
        //{
        //    return "value";
        //}
        public List<beneficiary> Get()
        {
            BeneficiaryDAL dal = new BeneficiaryDAL();
            DataTable dt = new DataTable();
            dt = dal.showall();
            List<beneficiary> list = new List<beneficiary>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                beneficiary m = new beneficiary();
                m.benfname = dt.Rows[i][1].ToString();
                m.accountNo = Convert.ToInt32(dt.Rows[i][2]);
                m.ifsc = dt.Rows[i][3].ToString();
                m.branch=dt.Rows[i][4].ToString();
                list.Add(m);
            }
            return list;
        }

        public beneficiary Get(int id)
        {
            BeneficiaryDAL dal = new BeneficiaryDAL();
            Beneficiary bal = new Beneficiary();

            beneficiary model = new beneficiary();
            model.benfname = bal.benfname;
            model.accountNo = bal.accountNo;
            model.ifsc = bal.ifsc;
            model.branch = bal.branch;

            return model;
        }

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult ADDBENEFICIARY(Beneficiary be)
        {
            BeneficiaryDAL da = new BeneficiaryDAL();

            Beneficiary ad = new Beneficiary();
            //be.benfId = be.benfId;
            be.benfname = be.benfname;
            be.accountNo = be.accountNo;
            be.ifsc = be.ifsc;
            be.branch = be.branch;

            int tno = da.ADDBENEFICIARY(be);

            return Ok(new { status = 200 });
        }
    }
}
