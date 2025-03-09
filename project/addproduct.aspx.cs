using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

public partial class project_addproduct : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["id"] != null)
            {
                string productId = Request.QueryString["id"];
                int quantity = Convert.ToInt32(Request.QueryString["quantity"] ?? "1");

                if (Session["Buyitems"] == null)
                {
                    dr = dt.NewRow();
                    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=D:\Titan watch(3004)\App_Data\Database1.mdf;Integrated Security=True");

                    SqlDataAdapter da = new SqlDataAdapter("select * from product where ProductId=" + productId, con);
                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    dr["sno"] = 1;
                    dr["pid"] = ds.Tables[0].Rows[0]["ProductId"].ToString();
                    dr["pname"] = ds.Tables[0].Rows[0]["Pname"].ToString();
                    dr["pimage"] = ds.Tables[0].Rows[0]["Pimage"].ToString();
                    dr["pprice"] = ds.Tables[0].Rows[0]["Pprice"].ToString();
                    dr["pquantity"] = quantity;

                    int price = Convert.ToInt32(ds.Tables[0].Rows[0]["Pprice"].ToString());
                    int totalPrice = price * quantity;
                    dr["ptotalprice"] = totalPrice;
                }
                else
                {
                    dt = (DataTable)Session["buyitems"];
                    int sr;
                    sr = dt.Rows.Count;

                    dr = dt.NewRow();
                    SqlConnection scon = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=D:\Titan watch(3004)\App_Data\Database1.mdf;Integrated Security=True");
                    SqlDataAdapter da = new SqlDataAdapter("select * from product where productId=" + productId, scon);
                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    dr["sno"] = sr + 1;
                    dr["pid"] = ds.Tables[0].Rows[0]["ProductId"].ToString();
                    dr["pname"] = ds.Tables[0].Rows[0]["Pname"].ToString();
                    dr["pimage"] = ds.Tables[0].Rows[0]["Pimage"].ToString();
                    dr["pprice"] = ds.Tables[0].Rows[0]["Pprice"].ToString();
                    dr["pquantity"] = quantity;

                    int price = Convert.ToInt32(ds.Tables[0].Rows[0]["Pprice"].ToString());
                    int totalPrice = price * quantity;
                    dr["ptotalprice"] = totalPrice;
                }
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=D:\Titan watch(3004)\App_Data\Database1.mdf;Integrated Security=True");
        if (FileUpload1.HasFile)
        {
            string filename = FileUpload1.PostedFile.FileName;
            string filpath = "images/" + FileUpload1.FileName;
            FileUpload1.PostedFile.SaveAs(Server.MapPath("~/images/") + filename);
            con.Open();
            SqlCommand cmd = new SqlCommand("Insert into product values('"+TextBox1.Text+"','"+TextBox2.Text+"','"+TextBox3.Text+"','"+filpath+"','"+TextBox4.Text+"')", con);
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("home.aspx");
        }
    }

    public int grandtotal()
    {
        DataTable dt = new DataTable();
        dt = (DataTable)Session["buyitems"];
        int nrow = dt.Rows.Count;
        int i = 0;
        int totalprice = 0;
        while(i < nrow)
        {
            totalprice = totalprice + Convert.ToInt32(dt.Rows[i]["ptotalprice"]);
            i = i + 1;
        }
        return totalprice;
    }
}