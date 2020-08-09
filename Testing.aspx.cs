using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Busysoft.DAL;
using Busysoft.Entities;

namespace Busysoft
{
    public partial class Testing : System.Web.UI.Page
    {
        State state = new State();
        Masterrepo masterrepo = new Masterrepo();
        protected void Page_Load(object sender, EventArgs e)
        {
            //List<State> states = masterrepo.SelectStates();
            //List<City> cities = masterrepo.SelectCities(1);
            //List<Branch> branches = masterrepo.SelectBranches(1);
            //DropDownList1.DataSource = states;
            //DropDownList1.DataTextField = "StateName";
            //DropDownList1.DataValueField = "";
            //DropDownList1.DataBind();
            //DropDownList1.Items.Insert(0, new ListItem("--Select--"));
            
        }
    }
}