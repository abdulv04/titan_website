using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;

public partial class registration : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click1(object sender, EventArgs e)
    {
        try
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=D:\Titan watch(3004)\App_Data\Database1.mdf;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into reg1" + "(fname,lname,email,address,gender,password,conpassword,city,ph_no) values (@fname,@lname,@email,@address,@gender,@password,@conpassword,@city,@ph_no)", con);
            cmd.Parameters.AddWithValue("@fname", TextBox1.Text);
            cmd.Parameters.AddWithValue("@lname", TextBox2.Text);
            cmd.Parameters.AddWithValue("@email", TextBox3.Text);
            cmd.Parameters.AddWithValue("@address", TextBox4.Text);
            cmd.Parameters.AddWithValue("@gender",  RadioButtonList1.SelectedValue);
            cmd.Parameters.AddWithValue("@password",TextBox5.Text);
            cmd.Parameters.AddWithValue("@conpassword", TextBox6.Text);
            cmd.Parameters.AddWithValue("@city", TextBox7.Text);
            cmd.Parameters.AddWithValue("@ph_no", TextBox8.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            Label1.Text = "Register Success";
            Response.Redirect("login.aspx");
        }
        catch
        {
            Label1.Text = "Register fail";
        }
    }
    protected void TextBox3_TextChanged(object sender, EventArgs e)
    {

    }
}
