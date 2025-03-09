using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;



/*using System.Data;
using System.Data.SqlClient;*/

using iTextSharp.text;
using System.IO;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;



public partial class project_Pdf_generate : System.Web.UI.Page
{
    public static void GeneratePdf(HttpResponse response)
    {
        response.ContentType = "application/pdf";
        response.AddHeader("content-disposition", "attachment;filename=example.pdf");
        response.Cache.SetCacheability(HttpCacheability.NoCache);
        Document doc= new Document();
        PdfWriter.GetInstance(doc,response.OutputStream);
        doc.Open();
        doc.Add(new Paragraph("Hello this is a pdf generated in asp.net"));
        doc.Close();
        response.End();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
           
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        project_Pdf_generate.GeneratePdf(Response);  
    }
   
   
}