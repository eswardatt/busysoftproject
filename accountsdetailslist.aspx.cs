using Busysoft.DAL;
using Busysoft.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Busysoft
{
    public partial class accountsdetailslist : System.Web.UI.Page
    {
        static List<string> str = new List<string>();

        protected void Page_Load(object sender, EventArgs e)
        {
            bindgrid();
        }
        void bindgrid()
        {
            if (Session["list"]!=null)
            {
                str = Session["list"].ToString().Split(',').ToList();
            }

            AccountDetails obj = new AccountDetails();
            BankingRepo bankingRepo = new BankingRepo();
            List<AccountDetails> accountDetails = new List<AccountDetails>();
            List<AccountDetails> accountDetails_1 = new List<AccountDetails>();
            accountDetails = bankingRepo.GetAccountDetails();
            for (int i = 0; i < str.Count; i++)
            {
                accountDetails_1 = accountDetails_1.Concat(from ll in accountDetails where ll.FormNo ==Convert.ToInt32(str[i]) select ll ).ToList();
            }
            Session.Remove("list");
            GridView1.DataSource = accountDetails_1;
            GridView1.DataBind();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit_Click")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridView1.Rows[rowIndex];
                string formno = (row.FindControl("lblformno") as Label).Text;
                str.Remove(formno);
            }
            bindgrid();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string str_1;
            str_1 = string.Join(",", str);
            Session["list"] = str_1;
            Response.Redirect("/accountslist.aspx");
        }
    }
}