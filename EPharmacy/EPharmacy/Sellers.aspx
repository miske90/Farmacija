<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Sellers.aspx.cs" Inherits="EPharmacy.Sellers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <html lang="en">
<head>
    
    <title>Medicines</title>
    <link rel="stylesheet" href="Medicines.css">
    <style>
        

          .table-condesed, .table-condesed tr td{
              border:0px solid #fff;
         }

          tr:nth-child(even){
              background: #f8f7ff;
          }
          tr:nth-child(odd){
              background: #fff;
          }
        .auto-style1 {
            left: 527px;
            top: 9px;
            width: 1020px;
        }
    </style>
</head>
<body>
    <div id="BigCont" style="left: 5%; top: 10%">
        <div id="Ti" style="left: 17%; top: -8px; width: 845px;"><h3>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Sellers</h3></div>
        <div id="I" style="left: 5%; top: 17px; width: 195px; height: 99px; margin-left: 500px; background-image:url('Img/Agent.png');" ></div><br><br>
        <div id="Block1" style="left:20%;">
                <input type="text" name="" id="SName" placeholder="Seller Name" runat="server">
                <asp:DropDownList ID="SGen" runat="server">
                        <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                        <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
                </asp:DropDownList> 
                <input type="date" name="" id="SDOB" runat="server">    
                <input type="text" name="" id="SPhone" placeholder="Phone Number" runat="server">   
                <input type="text" name="" id="SAddress" placeholder="Seller Address" runat="server">
                <input type="text" name="" id="SPassword" placeholder="Seller Password" runat="server">
                   
        </div><br><br>
        <div id="BtDiv" class="auto-style1">
           <asp:Button ID="AddBtn" runat="server" Text="Add"  style="background-color:#148b0b;width:100px;color:white;height:30px;border-radius:10px;border:none" OnClick="AddBtn_Click"/>
           <asp:Button ID="EditBtn" runat="server" Text="Edit" style="background-color:#148b0b;width:100px;color:white;height:30px;border-radius:10px;border:none" OnClick="EditBtn_Click" />
           <asp:Button ID="DeleteBtn" runat="server" Text="Delete" style="background-color:#148b0b;width:100px;color:white;height:30px;border-radius:10px;border:none" OnClick="DeleteBtn_Click" />
        </div><br /><br />
        <div id ="GVDiv">
            <asp:GridView ID="SellerGV" runat="server" CssClass="table table-condesed table-hover"  AutoGenerateSelectButton="True" style="left: 1%; top: 0px; width: 1061px" OnSelectedIndexChanged="SellerGV_SelectedIndexChanged">
            </asp:GridView>

        </div>
    </div>
</body>
</html>
</asp:Content>
