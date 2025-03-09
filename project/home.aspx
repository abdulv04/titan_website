<%@ Page Title="" Language="C#" MasterPageFile="~/project/user.master" AutoEventWireup="true" CodeFile="home.aspx.cs" Inherits="project_home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style=" width:1251px; height:30px;">
        <tr style="background-color:#5f98f3">
            <td colspan="2" style= "text-align: right; margin-left: 40px;">
                 <asp:Label ID="Label4" runat="server" style="text-align:left" Font-Bold="True" Font-Names="Arial"></asp:Label>
                <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="True" Font-Names="Arial Rounded MT Bold" NavigateUrl="~/project/login.aspx">Click to Login</asp:HyperLink>           
                <asp:Button ID="Button1" runat="server" Text="LogOut" BackColor="#FF5050" BorderColor="White" Font-Bold="True" Font-Names="Comic Sans MS" ForeColor="Aqua" Height="27px" Width="105px" OnClick="Button1_Click"></asp:Button>
            </td>
            <td style="text-align:right">
                <asp:TextBox ID="TextBox1" runat="server" Height="21px" Width="174px"></asp:TextBox>
                <asp:ImageButton ID="ImageButton2" runat="server" Height="23px" Width="25px" OnClick="ImageButton2_Click1" ImageUrl="~/project/images/search.jpg" />
            </td>
                </tr>
        </table>
    <asp:DataList ID="DataList1" runat="server" DataKeyField="ProductId" DataSourceID="SqlDataSource1" Height="150px" Width="310px" CellPadding="4" CellSpacing="50" HorizontalAlign="Center" RepeatColumns="3" RepeatDirection="Horizontal" OnSelectedIndexChanged="Button1_Click" style="margin-right: 0px">
        <ItemTemplate>
            <table style="width: 100%;">
                <tr>
                    <td style="text-align:center; background-color:#5f98f3">
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("Pname") %>' Font-Bold="True" Font-Names="Arial" ForeColor="White"></asp:Label></td>
                </tr>
                <tr>
                    <td style="text-align:center">
                        <asp:Image ID="Image1" runat="server" BorderColor="#5F98F3" BorderWidth="1px" Imageurl='<%# Eval("Pimage") %>'  Height="279px" Width="278px" />

                    </td>
                </tr>
                <tr>
                    <td style="text-align:center; background-color:#5f98f3">
                        <asp:Label ID="Label2" runat="server" Text="Price: Rs" Font-Bold="True" Font-Names="Arial" ForeColor="White" style="text-align:center"></asp:Label>
                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("Pprice") %>' Font-Bold="True" Font-Names="Arial" ForeColor="White" style="text-align:center"></asp:Label></td>
                </tr>
                <tr>
                    <td align="center">Qauntity
                        <asp:DropDownList ID="DropDownList1" runat="server">
                            <asp:ListItem>1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem>3</asp:ListItem>
                            <asp:ListItem>4</asp:ListItem>
                            <asp:ListItem>5</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:center; background-color:#5f98f3">
                        <asp:ImageButton ID="ImageButton1" runat="server" Height="40px" ImageUrl="~/project/images/add to cart.jpg" Width="160px" 
                            CommandArgument='<%# Eval("ProductId") %>' CommandName="AddToCart" OnClick="ImageButton1_Click" />
                    </td>
                      </tr>
                        <caption>
                            
                        </caption>
                
            </table>
            <br />
            <br />
        </ItemTemplate>
       
    </asp:DataList>
     <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
         SelectCommand="SELECT [ProductId], [Pname], [Pimage], [Pprice] FROM [product]">

        </asp:SqlDataSource>
</asp:Content>

