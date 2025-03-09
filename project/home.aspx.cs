﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;



public partial class project_home : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["addproduct"] = "false";

        if (Session["username"] != null)
        {
            Label4.Text = "Logged in as  "   +  Session["username"].ToString();
            HyperLink1.Visible=false;
            Button1.Visible=true;

        }
        else
        {
            Label4.Text="Hello You can Login here....";
            HyperLink1.Visible=true;
            Button1.Visible=false;
        }
      
    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
       
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("home.aspx");
        Label4.Text = "You can Logged Out Successfully....";

    }
    protected void ImageButton2_Click1(object sender, ImageClickEventArgs e)
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=D:\Titan watch(3004)\App_Data\Database1.mdf;Integrated Security=True");
        SqlDataAdapter sda = new SqlDataAdapter("Select * from product where(pname like '%"+TextBox1.Text+"%')or(productId like '%"+TextBox1.Text+"%')",con);
        DataTable dt=new DataTable();
        sda.Fill(dt);
        DataList1.DataSourceID=null;
        DataList1.DataSource=dt;
        DataList1.DataBind();

    }
    protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "AddToCart")
        {
            DropDownList list = (DropDownList)(e.Item.FindControl("DropDownList1"));
            Response.Redirect("addtocart.aspx?id=" + e.CommandArgument.ToString() + "&quantity=" + list.SelectedItem.ToString());
        }
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        if (Session["username"] == null)
        {
            Response.Redirect("login.aspx");
        }
        else
        {
            ImageButton btn = (ImageButton)sender;
            DataListItem item = (DataListItem)btn.NamingContainer;
            DropDownList list = (DropDownList)item.FindControl("DropDownList1");
            Response.Redirect("addtocart.aspx?id=" + btn.CommandArgument + "&quantity=" + list.SelectedItem.ToString());
        }
    }
}