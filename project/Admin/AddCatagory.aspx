<%@ Page Title="" Language="C#" MasterPageFile="~/project/Admin/admin.master" AutoEventWireup="true" CodeFile="AddCatagory.aspx.cs" Inherits="project_Admin_AddCatagory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 251px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center>
        <div class="navbar" style="border-width:3px; border-color:#333333">
            <table align="center" style="width:386px; height:410px;">
                <tr >
                    <td colspan="2" align="center">
                        <h2>
                            ADD Category
                        </h2>
                    </td>

                </tr>
                <tr>
                    <td>
                        <b style="font-size:21px; font-weight:bold"> Category:&nbsp;&nbsp;&nbsp;&nbsp; </b>&nbsp;

                    </td>
                    <td class="auto-style1">

                        <asp:TextBox ID="TextBox1" runat="server" BorderColor="#333333" BorderWidth="2px"
                             CausesValidation="True" Height="44px" Width="230px" Font-Bold="true" Font-Size="Medium" ForeColor="Black"></asp:TextBox>
                        &nbsp;
                        
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Catagory Name" 
                            ControlToValidate="TextBox1" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">

                        <asp:Button ID="Button1" runat="server" Text="ADD" BackColor="Aqua" BorderColor="#333333" 
                            BorderWidth="2px" Font-Bold="True" Font-Size="Medium" Height="44px" Width="80px" OnClick="Button1_Click1"></asp:Button>
                    </td>
                </tr>
                <tr>
                    <td colspan="2"><br />

                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" BorderColor="#333333" BorderWidth="2px" CssClass="button" DataKeyNames="CatagoryId" EmptyDataText="No Record To Display" >
                            <%--OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" PageSize="4" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
                            <Columns>
                                <asp:TemplateField HeaderText="Category">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox2" runat="server" Font-Bold="True" Text='<%# Eval("CategoryName") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("CategoryName") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:CommandField CausesValidation="False" HeaderText="Operation" ShowDeleteButton="True" ShowEditButton="True">
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:CommandField>
                            </Columns>
                            <HeaderStyle BorderColor="#333333" BorderWidth="3px" />
                            <RowStyle Font-Size="Larger" Width="257px" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
    </center>
</asp:Content>

