using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;


public partial class project_Admin_AddCatagory : System.Web.UI.Page
{
    string str=(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=D:\Titan watch(3004)\App_Data\Database1.mdf;Integrated Security=True");
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!IsPostBack)
        //{
        //    ShowGrid();
        //}
    }
    
    protected void Button1_Click1(object sender, EventArgs e)
    {
    
        SqlConnection con1 = new SqlConnection(str);
        SqlDataAdapter sda=new SqlDataAdapter("select * from category where CategoryName='"+ TextBox1.Text.ToString()+"'",con1);
        //SqlCommand cmd1 = new SqlCommand("select * from Catagory where CatagoryName='" + TextBox1.Text.ToString() + "'", con1);

        DataTable dt= new DataTable();
        //SqlDataAdapter sda = new SqlDataAdapter();
        sda.Fill(dt);
        if(dt.Rows.Count==1)
        {
            Response.Write("<script>alert ('This categpry is Alredy Present');</script>");

        }
        else
        {
            SqlConnection con= new SqlConnection(str);
            con.Open();
            SqlCommand cmd= new SqlCommand("Insert into category values (@CategoryName)",con);
            //cmd.Parameters.AddWithValue("@CategoryId", '0');
            cmd.Parameters.AddWithValue("@CategoryName", TextBox1.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Write("<script>alert('One Record Added');</script>");
            TextBox1.Text="";
            ShowGrid();
        }

        

    }
    public void ShowGrid()
    {
        SqlConnection conn = new SqlConnection(str);
        SqlDataAdapter sda = new SqlDataAdapter("Select * from category", conn);

        DataTable dt = new DataTable();
        sda.Fill(dt);
        GridView1.DataSource = dt;
        GridView1.DataBind();

    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        ShowGrid();
    }

    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        ShowGrid();
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int CId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
        SqlConnection con1 = new SqlConnection(str);
        con1.Open();
        SqlCommand cmd1 = new SqlCommand("delet from category where CategoryId=@1", con1);
        cmd1.Parameters.AddWithValue("@1", CId);
        cmd1.ExecuteNonQuery();
        con1.Close();
        Response.Write("<script>alert('Category Delet Successfully');</script>");
        ShowGrid();
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        ShowGrid();
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        GridViewRow row = GridView1.Rows[e.RowIndex];
        int CId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
        string CategoryName = (row.FindControl("TextBox2") as TextBox).Text;
        SqlConnection con2 = new SqlConnection(str);
        con2.Open();
        SqlCommand cmd1 = new SqlCommand("Update Category set CategoryName=@1 where CategoryId=@2", con2);
        cmd1.Parameters.AddWithValue("@1", CategoryName);
        cmd1.Parameters.AddWithValue("@2", CId);
        cmd1.ExecuteNonQuery();
        con2.Close();
        Response.Write("<script>alert('category update successful');</script>");
        GridView1.EditIndex = -1;

    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}