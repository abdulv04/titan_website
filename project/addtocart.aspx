<%@ Page Title="" Language="C#" MasterPageFile="~/project/user.master" AutoEventWireup="true" CodeFile="addtocart.aspx.cs" Inherits="project_addtocart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div align="center" style="margin:0 auto;">
        <h2 style="text-decoration:underline overline; color:#5f98f3">You Have Following Product In Your Cart</h2>
        <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="True" Font-Names="Colonna MT" Font-Size="X-Large" NavigateUrl="~/project/home.aspx">Continue Shopping </asp:HyperLink>
        <br /><br />

        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="#5F98F3" BorderColor="#333333" BorderWidth="5px" EmptyDataText="No Product Available In Shopping Cart" Font-Bold="True" Height="257px" ShowFooter="True" Width="1100px" OnRowDeleting="GridView1_RowDeleting">
            <Columns>
                <asp:BoundField DataField="sno" HeaderText="Sr No">
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="pid" HeaderText="ProductId">
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:ImageField DataImageUrlField="Pimage" HeaderText="Product Image">
                    <ControlStyle Height="300px" Width="340px" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:ImageField>
                <asp:BoundField DataField="Pname" HeaderText="Product Name">
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="pprice" HeaderText="Price">
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="Pquantity" HeaderText="Quantity">
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="Ptotalprice" HeaderText="Total Price">
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:CommandField DeleteText="Remove" ShowDeleteButton="True" />
            </Columns>
            <FooterStyle BackColor="#666FFF" ForeColor="White" />
            <HeaderStyle BackColor="DarkOrchid" ForeColor="White" />
        </asp:GridView>
        <br />
        <asp:Button ID="Button1" runat="server" Text="Button" BackColor="#FF6699" BorderColor="#0A2C2A" Font-Bold="True" Font-Size="Larger" Height="46px" Width="135px" OnClick="Button1_Click" />
    </div>
</asp:Content>

