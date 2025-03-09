using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Configuration;

public partial class project_login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Button1.Visible = true;
        HyperLink1.Visible = true;

    }
   
    protected void Button1_Click1(object sender, EventArgs e)
    {

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=D:\Titan watch(3004)\App_Data\Database1.mdf;Integrated Security=True");
            SqlDataAdapter sda = new SqlDataAdapter("Select*from reg1 where email='" + TextBox1.Text + "'and password='" + TextBox2.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (TextBox1.Text == "Admin" & TextBox2.Text == "1") 
            {
                HyperLink1.Text = "Admin Login Successfully..";
                HyperLink1.ForeColor = System.Drawing.Color.DarkGreen;
                Button1.Visible = false;
                HyperLink1.Visible = true;

            }
            else if (dt.Rows.Count == 1)
            {
                Session["username"] = TextBox1.Text;
                Response.Redirect("home.aspx");
                Button1.Visible = true;
                HyperLink1.Visible = false;

            }
            else
            {
                HyperLink1.ForeColor=System.Drawing.Color.Red;
                HyperLink1.Text="Login Failed...";
            }

         
        
    }
}