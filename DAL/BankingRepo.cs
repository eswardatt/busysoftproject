using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Busysoft.Entities;

namespace Busysoft.DAL
{
    public class BankingRepo
    {
        string constring = ConfigurationManager.ConnectionStrings["constring"].ConnectionString;

        public string CreateAcccount(AccountDetails obj)
        {
            string str = "";
            SqlConnection con = new SqlConnection(constring);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "CreateAccount";
            cmd.Parameters.Add("@filldate", SqlDbType.Date).Value = obj.FormFillingDateTime;
            cmd.Parameters.Add("@filltime", SqlDbType.Time).Value = obj.FormFillingTime;
            cmd.Parameters.Add("@cust_title", SqlDbType.Int).Value = obj.CustTitle;
            cmd.Parameters.Add("@fname", SqlDbType.VarChar).Value = obj.FirstName;
            cmd.Parameters.Add("@mname", SqlDbType.VarChar).Value = obj.MiddleName;
            cmd.Parameters.Add("@lname", SqlDbType.VarChar).Value = obj.LastName;
            cmd.Parameters.Add("@sex", SqlDbType.Int).Value = obj.Sex;
            cmd.Parameters.Add("@dob", SqlDbType.Date).Value = obj.DOB;
            cmd.Parameters.Add("@age", SqlDbType.Int).Value = obj.Cust_age;
            cmd.Parameters.Add("@stdcode", SqlDbType.NVarChar).Value = obj.Cust_std_code;
            cmd.Parameters.Add("@telephone", SqlDbType.VarChar).Value = obj.Cust_telephone;
            cmd.Parameters.Add("@mobile", SqlDbType.VarChar).Value = obj.Cust_mobile;
            cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = obj.Cust_email_id;
            cmd.Parameters.Add("@statecode", SqlDbType.Int).Value = obj.Cust_state_code;
            cmd.Parameters.Add("@citycode", SqlDbType.Int).Value = obj.Cust_city_code;
            cmd.Parameters.Add("@branchcode", SqlDbType.Int).Value = obj.Cust_branch_code;
            cmd.Parameters.Add("@accounttype", SqlDbType.Int).Value = obj.Cust_account_type;
            cmd.Parameters.Add("@language", SqlDbType.Int).Value = obj.Cust_preferred_language;
            cmd.Connection = con;


            try
            {
                con.Open();
                cmd.ExecuteNonQuery();

                str = "Saved Successfully";
            }
            catch (Exception ex)
            {
                //throw ex;
                str = "error:"+ex.ToString();
            }
            finally
            {
                con.Close();
            }

            return str;
        }
        public string UpdateAcccount(AccountDetails obj,int Id)
        {
            SqlConnection con = new SqlConnection(constring);
            string str = "";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "UpdateAccount";
            cmd.Parameters.Add("@formno", SqlDbType.Int).Value = Id;
            cmd.Parameters.Add("@filldate", SqlDbType.Date).Value = obj.FormFillingDateTime;
            
            cmd.Parameters.Add("@filltime", SqlDbType.Time).Value = obj.FormFillingTime;
            cmd.Parameters.Add("@cust_title", SqlDbType.Int).Value = obj.CustTitle;
            cmd.Parameters.Add("@fname", SqlDbType.VarChar).Value = obj.FirstName;
            cmd.Parameters.Add("@mname", SqlDbType.VarChar).Value = obj.MiddleName;
            cmd.Parameters.Add("@lname", SqlDbType.VarChar).Value = obj.LastName;
            cmd.Parameters.Add("@sex", SqlDbType.Int).Value = obj.Sex;
            cmd.Parameters.Add("@dob", SqlDbType.Date).Value = obj.DOB;
            cmd.Parameters.Add("@age", SqlDbType.Int).Value = obj.Cust_age;
            cmd.Parameters.Add("@stdcode", SqlDbType.NVarChar).Value = obj.Cust_std_code;
            cmd.Parameters.Add("@telephone", SqlDbType.VarChar).Value = obj.Cust_telephone;
            cmd.Parameters.Add("@mobile", SqlDbType.VarChar).Value = obj.Cust_mobile;
            cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = obj.Cust_email_id;
            cmd.Parameters.Add("@statecode", SqlDbType.Int).Value = obj.Cust_state_code;
            cmd.Parameters.Add("@citycode", SqlDbType.Int).Value = obj.Cust_city_code;
            cmd.Parameters.Add("@branchcode", SqlDbType.Int).Value = obj.Cust_branch_code;
            cmd.Parameters.Add("@accounttype", SqlDbType.Int).Value = obj.Cust_account_type;
            cmd.Parameters.Add("@language", SqlDbType.Int).Value = obj.Cust_preferred_language;
            cmd.Connection = con;
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();

                str = "Updated Successfully";
            }
            catch (Exception ex)
            {

                throw ex;
                str = "error:" + ex.ToString();
            }
            finally
            {
                con.Close();
            }

            return str;
        }

        public List<AccountDetails> GetAccountDetails()
        {
            SqlConnection con = new SqlConnection(constring);
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SelectAccountDetails", con);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataSet dataset = new DataSet();
            dataAdapter.Fill(dataset);
            var accountsList = dataset.Tables[0].AsEnumerable()
            .Select(dataRow => new AccountDetails
            {

                FormNo = dataRow.Field<long>("Form_number"),
                FormFillingDateTime = dataRow.Field<DateTime>("Form_filling_date"),
                FormFillingTime = dataRow.Field<TimeSpan>("Form_filling_time"),
                CustTitle = dataRow.Field<int>("Cust_title"),
                FirstName = dataRow.Field<string>("Cust_first_name"),
                MiddleName = dataRow.Field<string>("Cust_middle_name"),
                LastName = dataRow.Field<string>("Cust_last_name"),
                Sex = dataRow.Field<int>("Cust_sex"),
                DOB = dataRow.Field<DateTime>("Cust_date_of_birth"),
                Cust_age = dataRow.Field<int>("Cust_age"),
                Cust_std_code = dataRow.Field<string>("Cust_std_code"),
                Cust_telephone = dataRow.Field<string>("Cust_telephone"),
                Cust_mobile = dataRow.Field<string>("Cust_mobile"),
                Cust_email_id = dataRow.Field<string>("Cust_email_id"),
                Cust_state_code = dataRow.Field<long>("Cust_state_code"),
                CustStatename = dataRow.Field<string>("StateName"),
                Cust_city_code = dataRow.Field<long>("Cust_city_code"),
                Cust_branch_code = dataRow.Field<long>("Cust_branch_code"),
                Cust_account_type = dataRow.Field<int>("Cust_account_type"),
                Cust_preferred_language = dataRow.Field<long>("Cust_preferred_language")

            }).ToList();
           
            return accountsList;
        }

        public List<AccountDetails> GetAccountDetails(int formno)
        {
            List<AccountDetails> accountDetails = (from ll in GetAccountDetails()
                                                   where ll.FormNo == formno
                                                   select ll).ToList();
            return accountDetails;
        }

        public string UpdateAccountStatus(int formno,int status)
        {
            SqlConnection con = new SqlConnection(constring);
            string str = "";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "DeactiveorActiveAccount";
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = formno;
            cmd.Parameters.Add("@status", SqlDbType.Int).Value = status;
            cmd.Connection = con;
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                str = "Deleted Successfully";
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                con.Close();
            }
            return str;
        }
        public int GetFormNo()
        {
            int i = 0;
            SqlConnection con = new SqlConnection(constring);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetNewFormNo";
            cmd.Connection = con;
            try
            {
                con.Open();
                i =Convert.ToInt32( cmd.ExecuteScalar());
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                con.Close();
            }
            return i;


        }
    }
    
}