<%@ Page Title="" Language="C#" MasterPageFile="user.master" AutoEventWireup="true" CodeFile="registration.aspx.cs" Inherits="registration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
    
    <style type="text/css">
        .auto-style4 {
            text-align: center;
            height: 28px;
        }
        .auto-style5 {
            height: 24px;
        }
    .auto-style6 {
        height: 57px;
    }
        .auto-style7 {
            text-align: center;
            height: 44px;
        }
        .auto-style8 {
            height: 27px;
        }
        .auto-style9 {
            height: 70px;
        }
    </style>
    
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
      
    <table class="auto-style1" style="height: 416px; width: 22%; background-color: #006699;" align="center" >
        <tr>
            <td class="auto-style7" colspan="2"><strong>User Login</strong></td>
        </tr>
        <tr>
            <td class="auto-style6">First Name</td>
            <td class="auto-style6">
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Last Name</td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Email</td>
            <td>
                <asp:TextBox ID="TextBox3" runat="server" OnTextChanged="TextBox3_TextChanged"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Address</td>
            <td>
                <asp:TextBox ID="TextBox4" runat="server" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style9">Gender</td>
            <td class="auto-style9">
                <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                    <asp:ListItem>Male</asp:ListItem>
                    <asp:ListItem>Female</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td class="auto-style5">Password</td>
            <td class="auto-style5">
                <asp:TextBox ID="TextBox5" runat="server" TextMode="Password" OnTextChanged="Button1_Click1"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Confirm Password</td>
            <td class="auto-style3">
                <asp:TextBox ID="TextBox6" runat="server" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>City</td>
            <td>
                <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Ph_No</td>
            <td>
                <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style8"></td>
            <td class="auto-style8">
                <asp:Button ID="Button1" runat="server" Text="Register" OnClick="Button1_Click1" />
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
    </table>
    
      
</asp:Content>

