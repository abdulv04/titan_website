using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public partial class project_PlaceOrder : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\v11.0;AttachDbFilename=D:\Titan watch(3004)\App_Data\Database1.mdf;Integrated Security=True");
        con.Open();
        SqlCommand cmd=new SqlCommand("Insert into CardDetail" + "(Fname,Lname,CardNo,ExpireDate,CVV,BillingAddr)values(@Fname,@Lname,@CardNo,@ExpireDate,@CVV,@BillingAddr),con");
        cmd.Parameters.AddWithValue("@Fname",TextBox1.Text);
        cmd.Parameters.AddWithValue("@Lname",TextBox1.Text);
        cmd.Parameters.AddWithValue("@CardNo",TextBox1.Text);
        cmd.Parameters.AddWithValue("@ExpireDate",TextBox1.Text);
        cmd.Parameters.AddWithValue("@CVV",TextBox1.Text);
        cmd.Parameters.AddWithValue("@BillingAddr",TextBox1.Text);

        cmd.ExecuteNonQuery();
        con.Close();
        Response.Redirect("<script>alert ('Payment Made Successful');</script>");
        Session["address"] = TextBox6.Text;
        Response.Redirect("Pdf_generate.aspx");
    }
}