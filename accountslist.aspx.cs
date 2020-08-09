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
    public partial class accountslist : System.Web.UI.Page
    {
        AccountDetails obj = new AccountDetails();
        BankingRepo bankingRepo = new BankingRepo();
        public static List<string> idslist = new List<string>();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid(Convert.ToInt32( DropDownList1.SelectedValue));
            }
        

        }
        void BindGrid(int sex)
        {
            List<AccountDetails> accountDetails =(from ll in bankingRepo.GetAccountDetails() where ll.Sex==sex select ll).ToList();
            gvlist.DataSource = accountDetails;
            gvlist.DataBind();


            for (int i = 0; i < gvlist.Rows.Count; i++)
            {
                Label id = gvlist.Rows[i].FindControl("lblformno") as Label;
                CheckBox check = gvlist.Rows[i].FindControl("chckbkl") as CheckBox;
                if (idslist.Count > 0&&Session["list"]!=null)
                {
                    idslist = Session["list"].ToString().Split(',').ToList();
                    for (int j = 0; j < idslist.Count; j++)
                    {
                        if (idslist[j] == id.Text)
                        {
                            gvlist.Rows[i].Attributes.Add("style", "background-color:skyblue");
                            check.Checked = true;
                        }
                    }
                }
                Session.Remove("list");

                if (idslist.Count>0 && Session["list"] == null)
                {

                    for (int j = 0; j < idslist.Count; j++)
                    {
                        if (idslist[j]==id.Text)
                        {
                            gvlist.Rows[i].Attributes.Add("style", "background-color:skyblue");
                            check.Checked = true;
                        }
                    }
                }
           
            }
        }
        void applycolortorow()
        {

        }
        protected void gvlist_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            
            
            if (e.CommandName == "Edit_Click")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvlist.Rows[rowIndex];
                string formno = (row.FindControl("lblformno") as Label).Text;
                Session["ID"] = formno;
                Session["method"] = "update";
                Response.Redirect("/account_opening.aspx");
            }
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            Session["method"] = "save";
            Server.Transfer("/account_opening.aspx");
        }

        protected void gvlist_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblsex = e.Row.FindControl("lblsex") as Label;
                Label lblgender = e.Row.FindControl("lblgender") as Label;
                if (lblsex.Text=="1")
                {
                    lblgender.Text = "Male";
                }
                else if (lblsex.Text == "2")
                {
                    lblgender.Text = "Female";
                }
                else if (lblsex.Text == "3")
                {
                    lblgender.Text = "Others";
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            lbl.Text = TextBox1.Text;
        }

        protected void rblFruits_SelectedIndexChanged(object sender, EventArgs e)
        {
            Label1.Text = rblFruits.SelectedValue;
        }

        protected void chckbkl_CheckedChanged(object sender, EventArgs e)
        {
         
           StoreCheckvalues();

        }
       
        void StoreCheckvalues()
        {
            int x = gvlist.Rows.Count;
            for (int i = 0; i < x; i++)
            {
                Label id = gvlist.Rows[i].FindControl("lblformno") as Label;
                CheckBox check = gvlist.Rows[i].FindControl("chckbkl") as CheckBox;
                if (check.Checked)
                {
                    if (!idslist.Contains(id.Text))
                    {
                        idslist.Add(id.Text);
                    }                   
                }
               else if (!check.Checked)
                {
                    idslist.Remove(id.Text);
                }

            }
            BindGrid(Convert.ToInt32(DropDownList1.SelectedValue));
        }

        protected void gvlist_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvlist.PageIndex = e.NewPageIndex;
            BindGrid(Convert.ToInt32(DropDownList1.SelectedValue));
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string str;
            str = string.Join(",", idslist);
            Session["list"] = str;
            Response.Redirect("/accountsdetailslist.aspx");
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGrid(Convert.ToInt32(DropDownList1.SelectedValue));
        }
    }
}