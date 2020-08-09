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
    public partial class account_opening : System.Web.UI.Page
    {
        State state = new State();
        Masterrepo masterrepo = new Masterrepo();
        AccountDetails obj = new AccountDetails();
        BankingRepo bankingRepo = new BankingRepo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["method"] == "save")
                {
                    btnupdate.Visible = false;
                    btndelete.Visible = false;
                    BindStateDropDown();
                    var dateAndTime = DateTime.Now.ToShortDateString();
                    //var date = dateAndTime.Date;

                    lbldate.Text = Convert.ToString(dateAndTime);
                    hformno.InnerText = bankingRepo.GetFormNo().ToString();
                }
                else if (Session["method"] == "update")
                {
                    btnsave.Visible = false;
                    int formno = Convert.ToInt32(Session["ID"]);
                    Edit(formno);
                }
            }
        }
        void BindStateDropDown()
        {
            List<State> states = masterrepo.SelectStates();

            List<Branch> branches = masterrepo.SelectBranches(1);
            ddlstate.DataSource = states;
            ddlstate.DataTextField = "StateName";
            ddlstate.DataValueField = "StateId";
            ddlstate.DataBind();
            ddlstate.Items.Insert(0, new ListItem("--Select--"));
        }
        void BindCityDropdown(int stateid)
        {
            List<City> cities = masterrepo.SelectCities(stateid);
            ddlcity.DataSource = cities;
            ddlcity.DataTextField = "CityName";
            ddlcity.DataValueField = "CityId";
            ddlcity.DataBind();
            ddlcity.Items.Insert(0, new ListItem("--Select--"));
        }
        void BindBranchDropdown(int cityid)
        {
            List<Branch> cities = masterrepo.SelectBranches(cityid);
            ddlbranch.DataSource = cities;
            ddlbranch.DataTextField = "BranchName";
            ddlbranch.DataValueField = "BranchId";
            ddlbranch.DataBind();
            ddlbranch.Items.Insert(0, new ListItem("--Select--"));
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            obj.FormFillingDateTime = DateTime.Now.Date;
            TimeSpan TodayTime = DateTime.Now.TimeOfDay;

            obj.FormFillingTime = TodayTime;
            obj.CustTitle = Convert.ToInt16(ddltitle.SelectedValue);
            obj.FirstName = txtfname.Text;
            obj.MiddleName = txtmiddlename.Text;
            obj.LastName = txtlname.Text;
            obj.Sex = Convert.ToInt16(ddlsex.SelectedValue);
            obj.DOB = Convert.ToDateTime(txtdob.Text);


            txtage.Text = txtage.Text.Replace("years old", "");

            obj.Cust_age = Convert.ToInt32(txtage.Text);
            obj.Cust_std_code = txtstdcode.Text;
            obj.Cust_telephone = txttelephone.Text;
            obj.Cust_mobile = txtmobile.Text;
            obj.Cust_email_id = txtemail.Text;
            obj.Cust_state_code = Convert.ToInt16(ddlstate.SelectedValue);
            string st = Request.Form["hdncity"].ToString();
            string sts = Request.Form["hdnbranch"].ToString();
            

            obj.Cust_city_code = Convert.ToInt64(st); //Convert.ToInt16(ddlcity.SelectedValue);
            obj.Cust_branch_code = Convert.ToInt16(sts);
            obj.Cust_account_type = Convert.ToInt16(ddltypeodacc.SelectedValue);
            obj.Cust_preferred_language = Convert.ToInt16(ddllanguage.SelectedValue);
            string str = bankingRepo.CreateAcccount(obj);
            alert.Visible = true;
            alertmsg.InnerText = str;
        }
        public void Edit(int formno)
        {
            BindStateDropDown();

            List<AccountDetails> accountDetails = bankingRepo.GetAccountDetails(formno);
            foreach (var item in accountDetails)
            {
                hformno.InnerText = item.FormNo.ToString();
                lbldate.Text = item.FormFillingDateTime.ToShortDateString();
                ddltitle.SelectedValue = item.CustTitle.ToString();
                ddlstate.SelectedValue = item.Cust_state_code.ToString();
                BindCityDropdown(Convert.ToInt32(ddlstate.SelectedValue));
                ddlcity.SelectedValue = item.Cust_city_code.ToString();
                BindBranchDropdown(Convert.ToInt32(ddlcity.SelectedValue));
                ddlbranch.SelectedValue = item.Cust_branch_code.ToString();
                ddlsex.SelectedValue = item.Sex.ToString();
                ddltypeodacc.SelectedValue = item.Cust_account_type.ToString();
                ddllanguage.SelectedValue = item.Cust_preferred_language.ToString();
                txtfname.Text = item.FirstName;
                txtmiddlename.Text = item.MiddleName;
                txtlname.Text = item.LastName;
                txtdob.Text = item.DOB.ToShortDateString();
                txtage.Text = item.Cust_age.ToString();
                txtstdcode.Text = item.Cust_state_code.ToString();
                txttelephone.Text = item.Cust_telephone;
                txtmobile.Text = item.Cust_mobile;
                txtemail.Text = item.Cust_email_id;

            };


        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            obj.FormFillingDateTime = DateTime.Now.Date;
            TimeSpan TodayTime = DateTime.Now.TimeOfDay;
            obj.FormFillingTime = TodayTime;
            obj.CustTitle = Convert.ToInt16(ddltitle.SelectedValue);
            obj.FirstName = txtfname.Text;
            obj.MiddleName = txtmiddlename.Text;
            obj.LastName = txtlname.Text;
            obj.Sex = Convert.ToInt16(ddlsex.SelectedValue);
            obj.DOB = Convert.ToDateTime(txtdob.Text);
            txtage.Text = txtage.Text.Replace("years old", "");
            obj.Cust_age = Convert.ToInt32(txtage.Text);
            obj.Cust_std_code = txtstdcode.Text;
            obj.Cust_telephone = txttelephone.Text;
            obj.Cust_mobile = txtmobile.Text;
            obj.Cust_email_id = txtemail.Text;
            obj.Cust_state_code = Convert.ToInt16(ddlstate.SelectedValue);
            string st = Request.Form["hdncity"].ToString();
            string sts = Request.Form["hdnbranch"].ToString();

            obj.Cust_city_code = Convert.ToInt16(st);
            obj.Cust_branch_code = Convert.ToInt16(sts);
            obj.Cust_account_type = Convert.ToInt16(ddltypeodacc.SelectedValue);
            obj.Cust_preferred_language = Convert.ToInt16(ddllanguage.SelectedValue);
            int formno = Convert.ToInt32(Session["ID"]);
            string str = bankingRepo.UpdateAcccount(obj, formno);
            alert.Visible = true;
            alertmsg.InnerText = str;
        }

        protected void btnpre_Click(object sender, EventArgs e)
        {
            int formno = Convert.ToInt32(Session["ID"]);
            int i =Convert.ToInt32( hformno.InnerText)-1;
            Edit(i);
        }

        protected void btnnext_Click(object sender, EventArgs e)
        {
            int i = Convert.ToInt32(hformno.InnerText) + 1;
            Session["ID"] = i;
                Edit(i);
         
            
        }

        protected void btndelete_Click(object sender, EventArgs e)
        {
            delauth.Visible = true;
            
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("/accountslist.aspx");
        }

        protected void btnyes_Click(object sender, EventArgs e)
        {
            delauth.Visible = false;
            int formno = Convert.ToInt32(hformno.InnerText);
            string str = bankingRepo.UpdateAccountStatus(formno, 0);
            alert.Visible = true;
            alertmsg.InnerText = str;
        }

        protected void btnno_Click(object sender, EventArgs e)
        {
            delauth.Visible = false;
        }

        protected void ddlstate_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<City> cities = masterrepo.SelectCities(Convert.ToInt32( ddlstate.SelectedValue));
            ddlcity.DataSource = cities;
            ddlcity.DataTextField = "CityName";
            ddlcity.DataValueField = "CityId";
            ddlcity.DataBind();
            ddlcity.Items.Insert(0, new ListItem("--Select--","0"));
        }
    }
}