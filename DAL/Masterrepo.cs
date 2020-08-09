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
    public class Masterrepo
    {
        string constring = ConfigurationManager.ConnectionStrings["constring"].ConnectionString;
        public List<State> SelectStates()
        {
            SqlConnection con = new SqlConnection(constring);
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SelectStates", con);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataSet dataset = new DataSet();
            dataAdapter.Fill(dataset);
            var stateList = dataset.Tables[0].AsEnumerable()
            .Select(dataRow => new State
            {

                StateId = dataRow.Field<long>("State_code"),
                StateName = dataRow.Field<string>("StateName")

            }).ToList();
            return stateList;



        }
        public List<City> SelectCities(int StateID)
        {
            SqlConnection con = new SqlConnection(constring);
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SelectCitiesBasedOnstate", con);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.AddWithValue("@statecode", StateID);

            DataSet dataset = new DataSet();
            dataAdapter.Fill(dataset);
            var cityList = dataset.Tables[0].AsEnumerable()
            .Select(dataRow => new City
            {

                CityId = dataRow.Field<long>("city_code"),
                CityName = dataRow.Field<string>("city_name"),

            }).ToList();
            return cityList;



        }
        public List<Branch> SelectBranches(int CityId)
        {
            SqlConnection con = new SqlConnection(constring);
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SelectBranchesByCity", con);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.AddWithValue("@citycode", CityId);
            DataSet dataset = new DataSet();
            dataAdapter.Fill(dataset);
            var cityList = dataset.Tables[0].AsEnumerable()
            .Select(dataRow => new Branch
            {
                BranchId = dataRow.Field<long>("branch_code"),
                BranchName = dataRow.Field<string>("branch_name"),

            }).ToList();
            return cityList;
        }

        public List<Branch> SelectBranchesByBranchId(int BranchId)
        {
            SqlConnection con = new SqlConnection(constring);
            SqlDataAdapter dataAdapter = new SqlDataAdapter("selectbranchname", con);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.AddWithValue("@branchcode", BranchId);
            DataSet dataset = new DataSet();
            dataAdapter.Fill(dataset);
            var cityList = dataset.Tables[0].AsEnumerable()
            .Select(dataRow => new Branch
            {
                BranchId = dataRow.Field<long>("branch_code"),
                BranchName = dataRow.Field<string>("branch_name"),

            }).ToList();
            return cityList;
        }

        public List<City> SelectCitiesBycityid(int cityid)
        {
            SqlConnection con = new SqlConnection(constring);
            SqlDataAdapter dataAdapter = new SqlDataAdapter("selectcityname", con);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.AddWithValue("@citycode", cityid);
            DataSet dataset = new DataSet();
            dataAdapter.Fill(dataset);
            var cityList = dataset.Tables[0].AsEnumerable()
            .Select(dataRow => new City
            {

                CityId = dataRow.Field<long>("city_code"),
                CityName = dataRow.Field<string>("city_name"),

            }).ToList();
            return cityList;



        }
    }
}