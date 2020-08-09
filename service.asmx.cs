using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using Busysoft.DAL;
using Busysoft.Entities;

namespace Busysoft
{
    /// <summary>
    /// Summary description for service
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     [System.Web.Script.Services.ScriptService]
    public class service : System.Web.Services.WebService
    {
        Masterrepo masterrepo = new Masterrepo();
        [WebMethod]
        public void ListCitiesByState(int stateId)
        {
            List<City> cities = masterrepo.SelectCities(stateId);
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(cities));

        }
        [WebMethod]
        public void ListBranchesByCity(int cityId)
        {
            List<Branch> branches = masterrepo.SelectBranches(cityId);
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(branches));

        }
    }
}
