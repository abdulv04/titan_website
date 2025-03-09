<%@ Page Title="" Language="C#" MasterPageFile="~/project/user.master" AutoEventWireup="true" CodeFile="Pdf_generate.aspx.cs" Inherits="project_Pdf_generate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
    <asp:Button ID="Button1" runat="server" Text="Download invoice" BackColor="Silver" Font-Bold="True" Font-Size="X-Large" Height="49px" OnClick="Button1_Click" />
    <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="True" Font-Size="X-Large" NavigateUrl="~/project/home.aspx">Go To Home Page</asp:HyperLink>
    <asp:Panel ID="Panel1" runat="server">
        <table>
            <tr>
                <td style="text-align:center>
                    <h2 style="text-align:center>
                        Retail Invoice
                    </h2>

                </td>
            </tr>
             <tr>
                <td >
                    Order No:
                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                    Order Date:
                    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <table>
                        <tr>
                            <td>
                                
                                buyer Address:
                                <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                            </td>
                            <td>
                                Seller Address: <br /><br />
                                jiravala Socity,Mahemdavad,Gujrat....
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        
             <tr>
                <td>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="1000px">

                        <Columns>
                            <asp:BoundField DataField="sno" HeaderText="SNo">
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="productid" HeaderText="Product Id">
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="productname" HeaderText="Product Name">
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="quantity" HeaderText="Quantity">
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="price" HeaderText="Price">
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="totalprice" HeaderText="Total price">
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                        </Columns>

                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td>
                    Grand Total:
                    <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
             <tr>
                <td align="center">
                    This Is Computer Generated Invoice And Does Not Requared Signature:
                </td>
            </tr>


        </table>
    
       </asp:Panel>
</asp:Content>

