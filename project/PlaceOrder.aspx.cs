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
        try
        {
            // Debug information
            Response.Write("<script>console.log('Starting payment processing...');</script>");
            Response.Write("<script>console.log('Order ID: " + Session["orderid"] + "');</script>");
            Response.Write("<script>console.log('Order Date: " + Session["Orderdate"] + "');</script>");
            
            // Create connection
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=D:\Titan watch(3004)\App_Data\Database1.mdf;Integrated Security=True");
            con.Open();
            
            // First, check if the CardDetail table exists, if not, create it
            string checkTableQuery = "IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'CardDetail') " +
                                   "CREATE TABLE CardDetail (" +
                                   "CardId INT IDENTITY(1,1) PRIMARY KEY, " +
                                   "Fname NVARCHAR(50) NOT NULL, " +
                                   "Lname NVARCHAR(50) NOT NULL, " +
                                   "CardNo NVARCHAR(16) NOT NULL, " +
                                   "ExpireDate NVARCHAR(10) NOT NULL, " +
                                   "CVV NVARCHAR(3) NOT NULL, " +
                                   "BillingAddr NVARCHAR(255) NOT NULL, " +
                                   "OrderId NVARCHAR(50) NULL)";
            
            SqlCommand createTableCmd = new SqlCommand(checkTableQuery, con);
            createTableCmd.ExecuteNonQuery();
            
            // Now insert the card details
            SqlCommand cmd = new SqlCommand("INSERT INTO CardDetail (Fname, Lname, CardNo, ExpireDate, CVV, BillingAddr, OrderId) VALUES (@Fname, @Lname, @CardNo, @ExpireDate, @CVV, @BillingAddr, @OrderId)", con);
            
            // Add parameters
            cmd.Parameters.AddWithValue("@Fname", TextBox1.Text);
            cmd.Parameters.AddWithValue("@Lname", TextBox2.Text);
            cmd.Parameters.AddWithValue("@CardNo", TextBox3.Text);
            cmd.Parameters.AddWithValue("@ExpireDate", TextBox4.Text);
            cmd.Parameters.AddWithValue("@CVV", TextBox5.Text);
            cmd.Parameters.AddWithValue("@BillingAddr", TextBox6.Text);
            cmd.Parameters.AddWithValue("@OrderId", Session["orderid"] ?? DBNull.Value);
            
            cmd.ExecuteNonQuery();
            con.Close();
            
            // Make sure we're preserving the session variables needed for the PDF page
            if (Session["orderid"] == null || Session["Orderdate"] == null)
            {
                // If session variables are missing, set them
                if (Session["orderid"] == null)
                {
                    // Generate a new order ID if needed
                    Random rnd = new Random();
                    Session["orderid"] = "ORD" + rnd.Next(100000, 999999).ToString();
                }
                
                if (Session["Orderdate"] == null)
                {
                    Session["Orderdate"] = DateTime.Now.ToShortDateString();
                }
            }
            
            // Explicitly redirect to the PDF generation page
            Response.Redirect("Pdf_generate.aspx", false);
            Context.ApplicationInstance.CompleteRequest();
        }
        catch (Exception ex)
        {
            // Display error message
            Response.Write("<script>alert('Error: " + ex.Message.Replace("'", "\\'") + "');</script>");
        }
    }
}