<%@ Page Title="" Language="C#" MasterPageFile="~/project/user.master" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="project_login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">

        .auto-style3 {
            width: 29%;
            height: 378px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <div>
        <center>
            
           
            <table class="auto-style3" style="background-color:aqua; height: 291px;">
                <tr>
                    <td colspan="2"><b>User Login Page</b></td>
                </tr>
                <tr>
                    <td>Email</td>
                    <td>
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Password</td>
                    <td>
                        <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Button ID="Button1" runat="server" Height="45px" Text="Login" Width="90px" OnClick="Button1_Click1" />
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:HyperLink ID="HyperLink1" runat="server">HyperLink</asp:HyperLink>
                    </td>
                </tr>
            </table>
            
           Don't have Username and Password
            <a href="registration.aspx">Registration Now</a>
        </center>
       
    </div>
      
        

</asp:Content>

