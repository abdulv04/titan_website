<%@ Page Title="" Language="C#" MasterPageFile="~/project/Admin/admin.master" AutoEventWireup="true" CodeFile="Orderdetail.aspx.cs" Inherits="project_Admin_Orderdetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    

        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="Black" 
            GridLines="Horizontal" Width="506px" Height="256px" BackColor="White" 
            BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
                <asp:BoundField DataField="orderid" HeaderText="orderid" 
                    SortExpression="orderid" />
                <asp:BoundField DataField="sno" HeaderText="sno" SortExpression="sno" />
                <asp:BoundField DataField="pid" HeaderText="pid" SortExpression="pid" />
                <asp:BoundField DataField="pprice" HeaderText="pprice" SortExpression="pprice" >
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="pquantity" HeaderText="pquantity" SortExpression="pquantity" >
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="orderdate" HeaderText="orderdate" 
                    SortExpression="orderdate" >
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
            </Columns>
            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#242121" />
        </asp:GridView>
    
    <p>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            SelectCommand="SELECT * FROM [orderdetails]" OnSelecting="SqlDataSource1_Selecting">
        </asp:SqlDataSource>
    </p>

</asp:Content>

