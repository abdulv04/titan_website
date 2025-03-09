using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class project_addtocart : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Initialize the cart if it doesn't exist
            if (Session["buyitems"] == null)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("sno");
                dt.Columns.Add("pid");
                dt.Columns.Add("pname");
                dt.Columns.Add("pimage");
                dt.Columns.Add("pprice");
                dt.Columns.Add("pquantity");
                dt.Columns.Add("ptotalprice");
                
                Session["buyitems"] = dt;
            }
            
            // Check if there's a product ID in the query string
            if (Request.QueryString["id"] != null)
            {
                string productId = Request.QueryString["id"];
                int quantity = 1; // Default quantity
                
                // Add the product to the cart
                AddProductToCart(productId, quantity);
            }
            
            // Display the cart items
            DisplayCartItems();
        }
        string OrderDate = DateTime.Now.ToShortDateString();
        Session["Orderdate"] = OrderDate;
    }

    private void AddProductToCart(string productId, int quantity)
    {
        DataTable cartTable = (DataTable)Session["buyitems"];
        DataRow dr;
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=D:\Titan watch(3004)\App_Data\Database1.mdf;Integrated Security=True");

        SqlDataAdapter da = new SqlDataAdapter("select * from product where ProductId=" + productId, con);
        DataSet ds = new DataSet();
        da.Fill(ds);

        dr = cartTable.NewRow();
        dr["sno"] = cartTable.Rows.Count + 1;
        dr["pid"] = ds.Tables[0].Rows[0]["ProductId"].ToString();
        dr["pname"] = ds.Tables[0].Rows[0]["Pname"].ToString();
        dr["pimage"] = ds.Tables[0].Rows[0]["Pimage"].ToString();
        dr["pprice"] = ds.Tables[0].Rows[0]["Pprice"].ToString();
        dr["pquantity"] = quantity;

        int price = Convert.ToInt32(ds.Tables[0].Rows[0]["Pprice"].ToString());
        int totalPrice = price * quantity;
        dr["ptotalprice"] = totalPrice;

        cartTable.Rows.Add(dr);
        GridView1.DataSource = cartTable;
        GridView1.DataBind();
        Session["buyitems"] = cartTable;
        Button1.Enabled = true;
        GridView1.FooterRow.Cells[5].Text = "Total Amount";
        GridView1.FooterRow.Cells[6].Text = grandtotal().ToString();
        Response.Redirect("addtocart.aspx");
    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            DataTable dt = (DataTable)Session["buyitems"];
            if (dt != null && dt.Rows.Count > e.RowIndex)
            {
                dt.Rows.RemoveAt(e.RowIndex);
                
                // Reassign serial numbers
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["sno"] = i + 1;
                }
                
                Session["buyitems"] = dt;
                
                // Rebind the GridView
                GridView1.DataSource = dt;
                GridView1.DataBind();
                
                // Update footer if there are items
                if (dt.Rows.Count > 0)
                {
                    GridView1.FooterRow.Cells[5].Text = "Total Amount";
                    GridView1.FooterRow.Cells[6].Text = grandtotal().ToString();
                    Button1.Enabled = true;
                }
                else
                {
                    Button1.Enabled = false;
                }
            }
        }
        catch (Exception ex)
        {
            // Log or display the error
            Response.Write("<script>alert('Error deleting item: " + ex.Message + "');</script>");
        }
    }

    //2.Calculating Final Price
    public int grandtotal()
    {
        DataTable dt = new DataTable();
        dt = (DataTable)Session["buyitems"];
        int nrow = dt.Rows.Count;
        int i = 0;
        int totalprice = 0;
        while (i < nrow)
        {
            totalprice = totalprice + Convert.ToInt32(dt.Rows[i]["ptotalprice"]);
            i = i + 1;
        }
        return totalprice;
    }

    public void orderid()
    {
        string alpha = "abCdefghijklmnopqrstuvwxyz1234567890";
        Random r = new Random();
        char[] myArray = new char[5];
        for (int i = 0; i < 5; i++)
        {
            myArray[i] = alpha[(int)(35 * r.NextDouble())];
        }
        String orderid;
        orderid = "order_Id:" + DateTime.Now.Hour.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + new string(myArray) +
            DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString(); Session["Orderid"] = orderid;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        DataTable dt;
        dt = (DataTable)Session["buyitems"];
        for (int i = 0; i <= dt.Rows.Count - 1; i++)
        {
            SqlConnection scon = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=D:\Titan watch(3004)\App_Data\Database1.mdf;Integrated Security=True");
            scon.Open();
            SqlCommand cmd = new SqlCommand("insert into orderdetails(orderid,sno,pid,pname,pprice,pquantity,orderdate)values('" + Session["orderid"] + "','" + dt.Rows[i]["sno"] + "','" + dt.Rows[i]["pid"] + "','" + dt.Rows[i]["pname"] + "','" + dt.Rows[i]["pprice"] + "','" + dt.Rows[i]["pquantity"] + "','" + dt.Rows[i]["orderdate"] + "')");
            cmd.ExecuteNonQuery();
            scon.Close();
        }
        //IF Session is Null Redirect to login else placing the order
        if (Session["username"] == null)
        {
            Response.Redirect("login.aspx");
        }
        else
        {
            if (GridView1.Rows.Count.ToString() == "0")
            {
                Response.Write("<script>alert('your Cart is Empty.You cannot place an order');</script>");
            }
            else
            {
                Response.Redirect("PlaceOrder.aspx");
            }
        }
    }

    private void DisplayCartItems()
    {
        DataTable cartTable = (DataTable)Session["buyitems"];
        GridView1.DataSource = cartTable;
        GridView1.DataBind();
        Button1.Enabled = cartTable.Rows.Count > 0;
    }
}

