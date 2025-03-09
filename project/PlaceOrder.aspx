<%@ Page Title="" Language="C#" MasterPageFile="~/project/user.master" AutoEventWireup="true" CodeFile="PlaceOrder.aspx.cs" Inherits="project_PlaceOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <table align="center" style=" margin-top:50px; width:531px; height:563px; background-color:darkcyan">
            <tr>
                <td colspan="2" align="center" style=" vertical-align:top">
                    <asp:Label ID="Label1" runat="server" Text="Card Details" Font-Bold="True" Font-Size="XX-Large" ForeColor="White"></asp:Label>
                </td>
            </tr>
             <tr>
                <td align="center" style=" vertical-align:top">
                    <asp:TextBox ID="TextBox1" runat="server" BorderColor="Black" BorderWidth="2px" Font-Bold="True" Font-Size="Medium" Height="44px" Width="188px" placeholder="First Name"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="First Name Is Empty" ControlToValidate="TextBox1" ForeColor="Red">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="First Name must be in character" 
                        ControlToValidate="TextBox1" ForeColor="Red" ValidationExpression="^[A-Za-z]*$">*</asp:RegularExpressionValidator>
                </td>
                <td align="center" style=" vertical-align:top">
                    <asp:TextBox ID="TextBox2" runat="server" BorderColor="Black" BorderWidth="2px" Font-Bold="True" Font-Size="Medium" Height="44px" Width="188px" placeholder="Last Name"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Last Name Is Empty" ControlToValidate="TextBox2" ForeColor="Red">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Last Name must be in character" 
                        ControlToValidate="TextBox2" ForeColor="Red" ValidationExpression="^[A-Za-z]*$">*</asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center" >
                    <asp:Image ID="Image1" runat="server" BorderColor="Black" BorderWidth="2px" Height="200px" Width="438px" />
                    5</td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:Label ID="Label2" runat="server" Text="Card Number" Font-Bold="True" 
                        Font-Size="Large" ForeColor="White"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center" style=" vertical-align:top;">
                    <asp:TextBox ID="TextBox3" runat="server" BorderColor="Black" BorderWidth="2px" Font-Bold="True" Font-Size="Medium" Height="44px"
                         Width="442px" placeholder="16 digits"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Card Number Is Empty" 
                        ControlToValidate="TextBox3" ForeColor="Red">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Card Number must be 16 Digits character" 
                        ControlToValidate="TextBox3" ForeColor="Red" ValidationExpression="[0-9]{16}">*</asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td align="center">
                     <asp:Label ID="Label3" runat="server" Text="Expire Date" Font-Bold="True" 
                        Font-Size="Large" ForeColor="White"></asp:Label>
                </td>
                <td align="center">
                    <asp:Label ID="Label4" runat="server" Text="CVV" Font-Bold="True" 
                        Font-Size="Large" ForeColor="White"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="center" style=" vertical-align:top">
                    <asp:TextBox ID="TextBox4" runat="server" BorderColor="Black" BorderWidth="2px" Font-Bold="True" Font-Size="Medium" Height="44px"
                         Width="188px" placeholder="MM/YY(Eg:061996)"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Expire Date is Empty" 
                        ControlToValidate="TextBox4" ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
                
                <td align="center" style=" vertical-align:top">
                     <asp:TextBox ID="TextBox5" runat="server" BorderColor="Black" BorderWidth="2px" Font-Bold="True" Font-Size="Medium" Height="44px"
                         Width="188px" placeholder="3 digits"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="CVV  Is Empty" 
                        ControlToValidate="TextBox5" ForeColor="Red">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="CVV Number must be of 3  Digits character" 
                        ControlToValidate="TextBox5" ForeColor="Red" ValidationExpression="[0-9]{3}">*</asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center" style=" vertical-align:top">
                    <asp:TextBox ID="TextBox6" runat="server" BorderColor="Black" BorderWidth="2px" Font-Bold="True" Font-Size="X-large" Height="50px"
                         Width="442px" placeholder="Billing Address" TextMode="MultiLine"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Address  Is Empty" 
                        ControlToValidate="TextBox6" ForeColor="Red">*</asp:RequiredFieldValidator>
                   
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:Button ID="Button1" runat="server" Text="Submit" BackColor="Black" BorderColor="White" 
                        BorderWidth="2px" Font-Bold="True" Font-Size="Large" ForeColor="White" Height="44px" Width="188px" OnClick="Button1_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" Font-Bold="True" ForeColor="Red" HeaderText="X the Folloeing Errors" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/project/addtocart.aspx">Privious Page</asp:HyperLink>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:HyperLink ID="HyperLink2" runat="server" Font-Bold="True" NavigateUrl="~/project/home.aspx">Home Page</asp:HyperLink>
                </td>
            </tr>
        </table>
    </div>

</asp:Content>

