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
            if (Session["buyitems"] == null)
            {
                Button1.Enabled = false;

            }
            else
            {
                Button1.Enabled = true;

            }
            //Ading Product to gridview
            Session["addproduct"] = "false";
            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add("sno");
            dt.Columns.Add("pid");
            dt.Columns.Add("pname");
            dt.Columns.Add("pimage");
            dt.Columns.Add("pprice");
            dt.Columns.Add("pquantity");
            dt.Columns.Add("ptotalprice");


            if (Request.QueryString["id"] != null)
            {
                if (Session["Buyitems"] == null)
                {
                    dr = dt.NewRow();
                    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=D:\Titan watch(3004)\App_Data\Database1.mdf;Integrated Security=True");

                    SqlDataAdapter da = new SqlDataAdapter("select * from product1 where ProductId=" + Request.QueryString["id"], con);
                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    dr["sno"] = 1;
                    dr["pid"] = ds.Tables[0].Rows[0]["Productid"].ToString();
                    dr["pname"] = ds.Tables[0].Rows[0]["Pname"].ToString();
                    dr["pimage"] = ds.Tables[0].Rows[0]["Pimage"].ToString();
                    dr["pprice"] = ds.Tables[0].Rows[0]["Pprice"].ToString();
                    dr["pquantity"] = ds.Tables[0].Rows[0]["quantity"];

                    int price = Convert.ToInt32(ds.Tables[0].Rows[0]["pprice"].ToString());
                    int quantity = Convert.ToInt32(ds.Tables[0].Rows[0]["quantity"].ToString());
                    int Totalprice = price * quantity;
                    dr["ptotalprice"] = Totalprice;

                    dt.Rows.Add(dr);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                    Session["buyitems"] = dt;
                    Button1.Enabled = true;
                    GridView1.FooterRow.Cells[5].Text = "Total Amount";
                    GridView1.FooterRow.Cells[6].Text = grandtotal().ToString();
                    Response.Redirect("addtocart.aspx");

                }
                else
                {
                    dt = (DataTable)Session["buyitems"];
                    int sr;
                    sr = dt.Rows.Count;

                    dr = dt.NewRow();
                    SqlConnection scon = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=D:\Titan watch(3004)\App_Data\Database1.mdf;Integrated Security=True");
                    SqlDataAdapter da = new SqlDataAdapter("select * from product where productId=" + Request.QueryString["id"], scon);
                    DataSet ds = new DataSet();
                    da.Fill(ds);


                    dr["sno"] = sr + 1;
                    dr["pid"] = ds.Tables[0].Rows[0]["ProductId"].ToString();
                    dr["pname"] = ds.Tables[0].Rows[0]["Pname"].ToString();
                    dr["pimage"] = ds.Tables[0].Rows[0]["Pimage"].ToString();
                    dr["pprice"] = ds.Tables[0].Rows[0]["Pprice"].ToString();
                    dr["pquantity"] = ds.Tables[0].Rows[0]["Pquantity"].ToString();


                    int price = Convert.ToInt32(ds.Tables[0].Rows[0]["pprice"].ToString());
                    int quantity = Convert.ToInt32(ds.Tables[0].Rows[0]["quantity"].ToString());
                    int TotalPrice = price * quantity;
                    dr["ptotalPrice"] = TotalPrice;

                    dt.Rows.Add(dr);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                    Session["buyitems"] = dt;
                    Button1.Enabled = true;

                    GridView1.FooterRow.Cells[5].Text = "TotalAmount";
                    GridView1.FooterRow.Cells[6].Text = grandtotal().ToString();
                    Response.Redirect("addtocart.aspx");

                }
            }
            else
            {
                dt = (DataTable)Session["buyitems"];
                GridView1.DataSource = dt;
                GridView1.DataBind();
                if (GridView1.Rows.Count > 0)
                {
                    GridView1.FooterRow.Cells[5].Text = "Total Amount";
                    GridView1.FooterRow.Cells[6].Text = grandtotal().ToString();
                    
                }
            }
        }
        string OrderDate = DateTime.Now.ToShortDateString();
        Session["Orderdate"] = OrderDate;
      
    }
    
        //2.Calculating Final Price

        public int grandtotal()
        {
            DataTable dt = new DataTable();
            dt = (DataTable)Session["buyitems"];
            int nrow = dt.Rows.Count;
            int i=0;
            int totalprice = 0;
            while(i < nrow)
            {
                totalprice=totalprice+Convert.ToInt32(dt.Rows[i]["price"]);
                i=   i+1;
            }
       
            return totalprice;

       }
        public void orderid()
        {
            string alpha ="abCdefghijklmnopqrstuvwxyz1234567890";
            Random r= new Random();
            char[] myArray = new char[5];
            for(int i=0; i<5;i++)
            {
                myArray[i] = alpha[(int)(35*r.NextDouble())];
            
            }
            String orderid;
            orderid = "order_Id:" + DateTime.Now.Hour.ToString()+DateTime.Now.Second.ToString()+DateTime.Now.Day.ToString()+DateTime.Now.Month.ToString()+DateTime.Now.Year.ToString()+new string(myArray)+
                DateTime.Now.Minute.ToString()+ DateTime.Now.Second.ToString(); Session ["Orderid"] = orderid;


        }

    
    protected void GridView1_RowDeleting(object sender, GridViewDeletedEventArgs e)
    {
        DataTable dt = new DataTable();
        dt = (DataTable)Session["buyitems"];

        for (int i = 0; i <= dt.Rows.Count - 1; i++)
        {
            int sr;
            int sr1;
            string qdata;
            string dtdata;
            sr = Convert.ToInt32(dt.Rows[i]["sno"].ToString());
            TableCell cell = GridView1.Rows[i].Cells[i];
            qdata=cell.Text;
            dtdata=sr.ToString();
            sr1=Convert.ToInt32(qdata);

            if(sr==sr1)
            {
                dt.Rows[i].Delete();
                dt.AcceptChanges();
                break;
            }
        }
        //5.setting sno after deleting row items from cart
        for(int i=1;i<=dt.Rows.Count; i++)
        {
            dt.Rows[i-1]["sno"]=i;
            dt.AcceptChanges();

        }
        Session["buyitems"]=dt;
        Response.Redirect("addtocart.aspx");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        DataTable dt;
        dt = (DataTable)Session["buyitems"];
        for(int i=0;i<=dt.Rows.Count-1;i++)
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
}
  

