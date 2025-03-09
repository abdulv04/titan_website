using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.IO;

public partial class project_Pdf_generate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Check if order ID exists in session
            if (Session["orderid"] != null)
            {
                try
                {
                    // Display order details
                    Label1.Text = Session["orderid"].ToString();
                    Label2.Text = Session["Orderdate"].ToString();
                    
                    // Get user address from database
                    if (Session["username"] != null)
                    {
                        string username = Session["username"].ToString();
                        GetUserAddress(username);
                    }
                    else
                    {
                        Label3.Text = "Guest Customer";
                    }
                    
                    // Populate the GridView with order items
                    PopulateOrderItems();
                    
                    // Calculate and display grand total
                    if (GridView1.Rows.Count > 0)
                    {
                        CalculateGrandTotal();
                    }
                }
                catch (Exception ex)
                {
                    // Log the error but don't redirect
                    Response.Write("<script>console.log('Error loading invoice: " + ex.Message.Replace("'", "\\'") + "');</script>");
                }
            }
            else
            {
                // Only redirect if there's truly no order ID
                Response.Write("<script>alert('No order information found. Redirecting to home page.'); window.location='home.aspx';</script>");
            }
        }
    }
    
    private void GetUserAddress(string username)
    {
        try
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=D:\Titan watch(3004)\App_Data\Database1.mdf;Integrated Security=True");
            con.Open();
            
            SqlCommand cmd = new SqlCommand("SELECT fname, lname, email, address, city, ph_no FROM reg1 WHERE email=@email", con);
            cmd.Parameters.AddWithValue("@email", username);
            
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                Label3.Text = dr["fname"].ToString() + " " + dr["lname"].ToString() + "<br/>" +
                              dr["address"].ToString() + "<br/>" +
                              dr["city"].ToString() + "<br/>" +
                              "Phone: " + dr["ph_no"].ToString() + "<br/>" +
                              "Email: " + dr["email"].ToString();
            }
            
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            Label3.Text = "Customer Information Not Available";
        }
    }
    
    private void PopulateOrderItems()
    {
        try
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("sno");
            dt.Columns.Add("productid");
            dt.Columns.Add("productname");
            dt.Columns.Add("quantity");
            dt.Columns.Add("price");
            dt.Columns.Add("totalprice");
            
            // Debug information
            Response.Write("<script>console.log('Populating order items...');</script>");
            Response.Write("<script>console.log('Order ID: " + Session["orderid"] + "');</script>");
            
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=D:\Titan watch(3004)\App_Data\Database1.mdf;Integrated Security=True");
            con.Open();
            
            // First, check if there are any records in orderdetails for this order
            SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM orderdetails WHERE orderid=@orderid", con);
            checkCmd.Parameters.AddWithValue("@orderid", Session["orderid"]);
            int recordCount = Convert.ToInt32(checkCmd.ExecuteScalar());
            
            Response.Write("<script>console.log('Record count: " + recordCount + "');</script>");
            
            if (recordCount > 0)
            {
                // Fetch order details from the database
                SqlCommand cmd = new SqlCommand("SELECT sno, pid, pname, pprice, pquantity FROM orderdetails WHERE orderid=@orderid", con);
                cmd.Parameters.AddWithValue("@orderid", Session["orderid"]);
                
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    DataRow row = dt.NewRow();
                    row["sno"] = dr["sno"];
                    row["productid"] = dr["pid"];
                    row["productname"] = dr["pname"];
                    row["quantity"] = dr["pquantity"];
                    
                    decimal price = Convert.ToDecimal(dr["pprice"]);
                    int quantity = Convert.ToInt32(dr["pquantity"]);
                    decimal totalPrice = price * quantity;
                    
                    row["price"] = price.ToString();
                    row["totalprice"] = totalPrice.ToString();
                    
                    dt.Rows.Add(row);
                    
                    Response.Write("<script>console.log('Added product: " + dr["pname"] + "');</script>");
                }
                
                dr.Close();
            }
            else
            {
                // If no records in orderdetails, try to get data from the session
                if (Session["buyitems"] != null)
                {
                    Response.Write("<script>console.log('Using session data for products');</script>");
                    
                    DataTable cartItems = (DataTable)Session["buyitems"];
                    for (int i = 0; i < cartItems.Rows.Count; i++)
                    {
                        DataRow row = dt.NewRow();
                        row["sno"] = cartItems.Rows[i]["sno"];
                        row["productid"] = cartItems.Rows[i]["pid"];
                        row["productname"] = cartItems.Rows[i]["pname"];
                        row["quantity"] = cartItems.Rows[i]["pquantity"];
                        row["price"] = cartItems.Rows[i]["pprice"];
                        row["totalprice"] = cartItems.Rows[i]["ptotalprice"];
                        
                        dt.Rows.Add(row);
                        
                        Response.Write("<script>console.log('Added product from session: " + cartItems.Rows[i]["pname"] + "');</script>");
                    }
                }
            }
            
            con.Close();
            
            // Bind the data to the GridView
            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
                Response.Write("<script>console.log('GridView bound with " + dt.Rows.Count + " rows');</script>");
            }
            else
            {
                // Add a dummy row for testing if no products found
                Response.Write("<script>console.log('No products found, adding dummy data');</script>");
                
                DataRow dummyRow = dt.NewRow();
                dummyRow["sno"] = "1";
                dummyRow["productid"] = "N/A";
                dummyRow["productname"] = "No product details available";
                dummyRow["quantity"] = "0";
                dummyRow["price"] = "0";
                dummyRow["totalprice"] = "0";
                dt.Rows.Add(dummyRow);
                
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }
        catch (Exception ex)
        {
            // Log the error
            Response.Write("<script>console.error('Error in PopulateOrderItems: " + ex.Message.Replace("'", "\\'") + "');</script>");
        }
    }
    
    private void CalculateGrandTotal()
    {
        try
        {
            decimal grandTotal = 0;
            
            // First try to calculate from the GridView
            if (GridView1.Rows.Count > 0)
            {
                foreach (GridViewRow row in GridView1.Rows)
                {
                    string totalPriceStr = row.Cells[5].Text;
                    if (!string.IsNullOrEmpty(totalPriceStr))
                    {
                        decimal rowTotal;
                        if (decimal.TryParse(totalPriceStr, out rowTotal))
                        {
                            grandTotal += rowTotal;
                        }
                    }
                }
            }
            
            // If GridView calculation didn't work, try from database
            if (grandTotal == 0)
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=D:\Titan watch(3004)\App_Data\Database1.mdf;Integrated Security=True");
                con.Open();
                
                SqlCommand cmd = new SqlCommand("SELECT SUM(pprice * pquantity) AS GrandTotal FROM orderdetails WHERE orderid=@orderid", con);
                cmd.Parameters.AddWithValue("@orderid", Session["orderid"]);
                
                object result = cmd.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    grandTotal = Convert.ToDecimal(result);
                }
                
                con.Close();
            }
            
            // If database calculation didn't work, try from session
            if (grandTotal == 0 && Session["buyitems"] != null)
            {
                DataTable cartItems = (DataTable)Session["buyitems"];
                foreach (DataRow row in cartItems.Rows)
                {
                    if (row["ptotalprice"] != null)
                    {
                        decimal rowTotal;
                        if (decimal.TryParse(row["ptotalprice"].ToString(), out rowTotal))
                        {
                            grandTotal += rowTotal;
                        }
                    }
                }
            }
            
            Label4.Text = grandTotal.ToString("0.00");
            Response.Write("<script>console.log('Grand total calculated: " + grandTotal + "');</script>");
        }
        catch (Exception ex)
        {
            // Log the error
            Response.Write("<script>console.error('Error in CalculateGrandTotal: " + ex.Message.Replace("'", "\\'") + "');</script>");
            Label4.Text = "0.00";
        }
    }
    
    protected void Button1_Click(object sender, EventArgs e)
    {
        // Create PDF document
        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment;filename=TitanWatch_Invoice_" + Session["orderid"] + ".pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        
        // Hide the download button and home link when rendering to PDF
        Button1.Visible = false;
        HyperLink1.Visible = false;
        
        Panel1.RenderControl(hw);
        
        // Show the controls again
        Button1.Visible = true;
        HyperLink1.Visible = true;
        
        StringReader sr = new StringReader(sw.ToString());
        Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
        HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
        PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        
        pdfDoc.Open();
        htmlparser.Parse(sr);
        pdfDoc.Close();
        
        Response.Write(pdfDoc);
        Response.End();
    }
    
    public override void VerifyRenderingInServerForm(Control control)
    {
        // This override is needed for the PDF generation to work
    }
}