<%@ Page Title="" Language="C#" MasterPageFile="~/project/user.master" AutoEventWireup="true" CodeFile="Pdf_generate.aspx.cs" Inherits="project_Pdf_generate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .invoice-container {
            width: 90%;
            margin: 20px auto;
            font-family: Arial, sans-serif;
            border: 1px solid #ddd;
            padding: 20px;
            box-shadow: 0 0 10px rgba(0,0,0,0.1);
            background-color: #fff;
        }
        .invoice-header {
            text-align: center;
            padding: 10px;
            background-color: #5f98f3;
            color: white;
            margin-bottom: 20px;
            border-radius: 5px;
        }
        .invoice-info {
            display: flex;
            justify-content: space-between;
            margin-bottom: 20px;
            padding: 10px;
            background-color: #f9f9f9;
            border-radius: 5px;
        }
        .invoice-addresses {
            display: flex;
            justify-content: space-between;
            margin-bottom: 20px;
        }
        .address-box {
            width: 45%;
            padding: 15px;
            background-color: #f9f9f9;
            border-radius: 5px;
        }
        .invoice-items {
            margin-bottom: 20px;
        }
        .invoice-total {
            text-align: right;
            font-weight: bold;
            font-size: 18px;
            padding: 10px;
            background-color: #f9f9f9;
            border-radius: 5px;
            margin-bottom: 20px;
        }
        .invoice-footer {
            text-align: center;
            font-style: italic;
            color: #666;
            padding: 10px;
            border-top: 1px solid #ddd;
        }
        .download-btn {
            background-color: #5f98f3;
            color: white;
            padding: 10px 20px;
            border: none;
            border-radius: 5px;
            cursor: pointer;
            font-size: 16px;
            margin-right: 15px;
            transition: background-color 0.3s;
        }
        .download-btn:hover {
            background-color: #4a86e8;
        }
        .home-link {
            display: inline-block;
            background-color: #28a745;
            color: white;
            padding: 10px 20px;
            text-decoration: none;
            border-radius: 5px;
            font-size: 16px;
            transition: background-color 0.3s;
        }
        .home-link:hover {
            background-color: #218838;
        }
        .action-buttons {
            margin-bottom: 20px;
            text-align: center;
        }
        .gridview-style {
            width: 100%;
            border-collapse: collapse;
        }
        .gridview-style th {
            background-color: #5f98f3;
            color: white;
            padding: 10px;
            text-align: center;
        }
        .gridview-style td {
            padding: 8px;
            border: 1px solid #ddd;
        }
        .gridview-style tr:nth-child(even) {
            background-color: #f2f2f2;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="action-buttons">
        <asp:Button ID="Button1" runat="server" Text="Download Invoice" CssClass="download-btn" OnClick="Button1_Click" />
        <asp:HyperLink ID="HyperLink1" runat="server" CssClass="home-link" NavigateUrl="~/project/home.aspx">Go To Home Page</asp:HyperLink>
    </div>
   
    <asp:Panel ID="Panel1" runat="server" CssClass="invoice-container">
        <div class="invoice-header">
            <h2>Titan Watch - Retail Invoice</h2>
        </div>
        
        <div class="invoice-info">
            <div>
                <strong>Order No:</strong>
                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            </div>
            <div>
                <strong>Order Date:</strong>
                <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
            </div>
        </div>
        
        <div class="invoice-addresses">
            <div class="address-box">
                <h4>Buyer Information:</h4>
                <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
            </div>
            <div class="address-box">
                <h4>Seller Information:</h4>
                <p>Titan Watch Store<br />
                Jiravala Society<br />
                Mahemdavad, Gujarat<br />
                India - 387130<br />
                Phone: +91 9876543210<br />
                Email: contact@titanwatch.com</p>
            </div>
        </div>
        
        <div class="invoice-items">
            <h4>Order Details:</h4>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="gridview-style" Width="100%">
                <Columns>
                    <asp:BoundField DataField="sno" HeaderText="S.No">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="productid" HeaderText="Product ID">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="productname" HeaderText="Product Name">
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="quantity" HeaderText="Quantity">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="price" HeaderText="Unit Price">
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="totalprice" HeaderText="Total Price">
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                </Columns>
            </asp:GridView>
        </div>
        
        <div class="invoice-total">
            <span>Grand Total: ₹</span>
            <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
        </div>
        
        <div class="invoice-footer">
            <p>Thank you for shopping with Titan Watch!</p>
            <p>This is a computer-generated invoice and does not require a signature.</p>
        </div>
    </asp:Panel>
</asp:Content>

