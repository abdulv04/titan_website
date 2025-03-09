<%@ Page Title="" Language="C#" MasterPageFile="~/project/Admin/admin.master" AutoEventWireup="true" CodeFile="product_detail.aspx.cs" Inherits="project_Admin_product_detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
<table align="center" 
        style="height: 505px; width: 1137px; background-image: url('../img/whitw%20bg.jpg');">
<tr>
<td align="center" style="font-size: large">
    <asp:Label ID="Label1" runat="server" Text="Product Details..." 
        Font-Bold="True" Font-Underline="True" ForeColor="Black"></asp:Label>

<br />
    <br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
    CellPadding="4" DataSourceID="SqlDataSource1" 
    ForeColor="#5f98f3" GridLines="Vertical" Height="334px" Width="1079px" 
        BorderStyle="Ridge"  ShowFooter="True" ShowHeaderWhenEmpty="True" UseAccessibleHeader="False">
        <AlternatingRowStyle BackColor="White" ForeColor="black" />
        <Columns>
            <asp:BoundField DataField="ProductId" HeaderText="pid" 
                SortExpression="pid" />
            <asp:BoundField DataField="Pname" HeaderText="pname" 
                SortExpression="pname" />
            <asp:BoundField DataField="Pprice" HeaderText="price" 
                SortExpression="price" />
            <asp:ImageField DataImageUrlField="Pimage" HeaderText="productimage">
                <ControlStyle Height="50px" Width="50px" />
            </asp:ImageField>
        </Columns>
        <EditRowStyle BackColor="#5f98f3" />
        <FooterStyle BackColor="#5f98f3" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5f98f3" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>
    </td>
</tr>
</table>

<asp:SqlDataSource ID="SqlDataSource1" runat="server" 
    ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
    SelectCommand="SELECT * FROM [product]"></asp:SqlDataSource>
</asp:Content>

