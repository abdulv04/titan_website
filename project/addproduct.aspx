<%@ Page Title="" Language="C#" MasterPageFile="~/project/user.master" AutoEventWireup="true" CodeFile="addproduct.aspx.cs" Inherits="project_addproduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="height:510px">
        <table style="width:700px; height:390px;background-color:#5f98f3;" align="center">
            <tr>
                <td align="center" width="50%" colspan="2"> 
                    <h1>Adding Product</h1>
                </td>
               
            </tr>
             <tr>
                <td align="center" width="50%" >
                    <h3> Product Id:</h3> 

                </td>
                <td width="50%" >
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td align="center" width="50%" > 
                    <h3> Product Name:</h3> 
                </td>
                <td width="50%" >
                     <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td align="center" width="50%" >
                    <h3> Product Dec: </h3>

                </td>
                <td width="50%" >
                     <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td align="center" width="50%" > 
                    <h3> Image: </h3>
                </td>
                <td width="50%" >
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                </td>
            </tr>
             <tr>
                <td align="center" width="50%" > 
                     <h3>Product Price</h3>
                </td>
                <td width="50%" >
                    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td align="center" width="50%" colspan="2">
                    <asp:Button ID="Button1" runat="server" Text="Add" Font-Bold="True" ForeColor="Black" Height="36px" OnClick="Button1_Click" Width="88px" /> </td>
              
            </tr>
             <tr>
                <td align="center" width="50%" colspan="2">
                    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                </td>
                
            </tr>
        </table>
    </div>
</asp:Content>

