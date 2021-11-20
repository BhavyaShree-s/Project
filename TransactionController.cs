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
    public class TransactionController : ApiController
    {
        //public string Get()
        //{
        //    return "value";
        //}


        public List<transaction> Get()
        {

            TransactionDAL dal = new TransactionDAL();
            DataTable dt = new DataTable();
            dt = dal.showTrans();
            List<transaction> list = new List<transaction>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                transaction m = new transaction();
                m.TranDate = Convert.ToDateTime(dt.Rows[i][1]);
                m.Amount = Convert.ToInt32(dt.Rows[i][2]);
                m.TranType = dt.Rows[i][3].ToString();
                m.AccId = Convert.ToInt32(dt.Rows[i][4]);
                list.Add(m);
                //Convert.ToDateTime(dt.Rows[i][0]);
            }
            
            return list;
        }

        public transaction Get(int id)
        {
            TransactionDAL dal = new TransactionDAL();
            TRANSACTION bal = new TRANSACTION();

            transaction trans = new transaction();
            trans.TranDate = bal.TranDate;
            trans.Amount = bal.Amount;
            trans.TranType = bal.TranType;
            trans.AccId = bal.AccId;

            return trans;
        }



        public IHttpActionResult ADD_TRANSACTION_RECORD(TRANSACTION tr)
        {
            TransactionDAL da = new TransactionDAL();

            TRANSACTION ad = new TRANSACTION();

            tr.TranDate = tr.TranDate;
            tr.Amount = tr.Amount;
            tr.TranType = tr.TranType;
            tr.AccId = tr.AccId;

            int tno = da.ADD_TRANSACTION_RECORD(tr);

            return Ok(new { status = 200 });
        }


    }
}
