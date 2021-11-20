using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankingBAL;
using System.Data.SqlClient;
using System.Data;

namespace BankingDAL
{
    public class CustomerDAL
    {
        public bool ValidateUser(CustomerLogin data)
        {



            SqlConnection conn = new SqlConnection("server=laptop-rntefbs4\\sqlexpress;Integrated Security=true;database=BankingProject");

            string s = "SELECT[dbo].[fn_CustomerValidation](@p_userid,@p_pwd)";

            SqlCommand cmd = new SqlCommand(s, conn);

            cmd.Parameters.AddWithValue("@p_userid", data.Userid);
            cmd.Parameters.AddWithValue("@p_pwd", data.Password);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            bool ans = false;
            //array format
            //dr[0]
            if (Convert.ToInt32(dr[0]) == 1)
            {
                ans = true;

            }
            //else
            //{
            //    ans = false;
            //}
            conn.Close();
            conn.Dispose();
            return ans;

        }
        public int InsertCustomer(CustomerRegisteration r)
        {

            SqlConnection cn = new SqlConnection("server=laptop-rntefbs4\\sqlexpress;Integrated Security=true;database=BankingProject");
            cn.Open();
            string s = "[dbo].[sp_InsertCustomer]";
            SqlCommand cmd = new SqlCommand(s, cn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@c_Name", r.Name);
            cmd.Parameters.AddWithValue("@c_DOB", r.DOB);
            cmd.Parameters.AddWithValue("@c_Phone", r.Phone);
            cmd.Parameters.AddWithValue("@c_Email", r.Email);
            cmd.Parameters.AddWithValue("@c_Address", r.Address);
            cmd.Parameters.AddWithValue("@c_Username", r.username);
            cmd.Parameters.AddWithValue("@c_Password", r.password);
            cmd.Parameters.AddWithValue("@c_Branch", r.Branch);
            cmd.Parameters.AddWithValue("@c_AccountType", r.AccountType);
            cmd.Parameters.AddWithValue("@c_Reg_Date", r.Reg_Date);
            cmd.ExecuteNonQuery();
            cn.Close();
            cn.Dispose();
            return 0;
        }


        public DataTable showcust()
        {
            SqlConnection cn = new SqlConnection("server=LAPTOP-RNTEFBS4\\SQLEXPRESS;Integrated Security=true;database=BankingProject");

            SqlDataAdapter da = new SqlDataAdapter("select * from Customer", cn);


            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            DataSet ds = new DataSet();
            da.Fill(ds, "Customer");
            return ds.Tables["Customer"];

        }



        public string editDetails(CustomerRegisteration bal)
        {
            SqlConnection cn = new SqlConnection("server=LAPTOP-RNTEFBS4\\SQLEXPRESS;Integrated Security=true;database=BankingProject");
            string s = "[dbo].[UpdateDetails]";
            SqlCommand cmd = new SqlCommand(s, cn);
            cmd.Parameters.AddWithValue("@p_Email", bal.Email);
            cmd.Parameters.AddWithValue("@p_Phone", bal.Phone);
            cmd.Parameters.AddWithValue("@p_Address", bal.Address);      
            cmd.Parameters.AddWithValue("@p_password", bal.password);
            // cmd.Parameters.AddWithValue("@orderid", bal.OrderId);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cn.Open();
            string s1 = "Updated";

            cmd.ExecuteNonQuery();
            cn.Close();
            cn.Dispose();
            return s1;


        }


        

            public DataTable showAccountDetails()
            {
                SqlConnection cn = new SqlConnection("server=LAPTOP-RNTEFBS4\\SQLEXPRESS;Integrated Security=true;database=BankingProject");

                SqlDataAdapter da = new SqlDataAdapter("select * from Account", cn);


                da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                DataSet ds = new DataSet();
                da.Fill(ds, "Account");
                return ds.Tables["Account"];

            }

        







    }


}
    public class AdminDAL
    {

        public bool adminLogin(AdminLogin b)
        {

            SqlConnection cn = new SqlConnection("server=laptop-rntefbs4\\sqlexpress;Integrated Security=true;database=BankingProject");
            string s = "SELECT[dbo].[fn_AdminValidation](@p_userid,@p_pwd)";
            SqlCommand cmd = new SqlCommand(s, cn);
            cmd.Parameters.AddWithValue("@p_userid", b.Userid);
            cmd.Parameters.AddWithValue("@p_pwd", b.Password);
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            bool ans = false;
            //array format
            //dr[0]
            if (Convert.ToInt32(dr[0]) == 1)
            {
                ans = true;

            }
            //else
            //{
            //    ans = false;
            //}
            cn.Close();
            cn.Dispose();
            return ans;
        }
    }

    public class BeneficiaryDAL
    {
        public int ADDBENEFICIARY(Beneficiary b)
        {
            SqlConnection cn = new SqlConnection("server=laptop-rntefbs4\\sqlexpress;Integrated Security=true;database=BankingProject");
            cn.Open();
            SqlCommand cmd = new SqlCommand("[dbo].[ADDBENEFICIARY]", cn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@benfname", b.benfname);
            cmd.Parameters.AddWithValue("@accountNo", b.accountNo);
            cmd.Parameters.AddWithValue("@ifsc", b.ifsc);
            cmd.Parameters.AddWithValue("@branch", b.branch);

            cmd.ExecuteNonQuery();
            cn.Close();
            cn.Dispose();
            return 0;
        }
        public DataTable showall()
        {
            SqlConnection cn = new SqlConnection("server=LAPTOP-RNTEFBS4\\SQLEXPRESS;Integrated Security=true;database=BankingProject");
            //adapter/charger---- connect/disconnect
            SqlDataAdapter da = new SqlDataAdapter("select * from beneficiary", cn);
            //SqlCommand cmd = new SqlCommand("[dbo].[ADDBENEFICIARY]", cn);
            //cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //DataSet is in-memory copy of your database datatable
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            DataSet ds = new DataSet();
            da.Fill(ds, "beneficiary");
            return ds.Tables["beneficiary"];
            //cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@benfname", b.benfname);
            //cmd.Parameters.AddWithValue("@accountNo", b.accountNo);
            //cmd.Parameters.AddWithValue("@ifsc", b.ifsc);
            //cmd.Parameters.AddWithValue("@branch", b.branch);

            //cmd.ExecuteNonQuery();
            //cn.Close();
            //cn.Dispose();
            //return 0;
        }
    }
    public class TransactionDAL
    {
        public int ADD_TRANSACTION_RECORD(TRANSACTION t)
        {

            SqlConnection cn = new SqlConnection("server=laptop-rntefbs4\\sqlexpress;Integrated Security=true;database=BankingProject");
            cn.Open();
            SqlCommand cmd = new SqlCommand("[dbo].[ADD_TRANSACTION_RECORD]", cn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TranDate", t.TranDate);
            cmd.Parameters.AddWithValue("@Amount", t.Amount);
            cmd.Parameters.AddWithValue("@TranType", t.TranType);
            cmd.Parameters.AddWithValue("@AccId", t.AccId);

            cmd.ExecuteNonQuery();
            cn.Close();
            cn.Dispose();
            return 0;
        }

        public DataTable showTrans()
        {
            SqlConnection cn = new SqlConnection("server=LAPTOP-RNTEFBS4\\SQLEXPRESS;Integrated Security=true;database=BankingProject");

            SqlDataAdapter da = new SqlDataAdapter("select * from Transactions", cn);
          
            
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            DataSet ds = new DataSet();
            da.Fill(ds, "Transactions");
            return ds.Tables["Transactions"];
            
        }




    }





